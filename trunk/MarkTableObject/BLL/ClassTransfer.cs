using System;
using System.Collections.Generic;
using System.Text;
using hwj.CommonLibrary.Object;
using System.Reflection;

namespace hwj.MarkTableObject.BLL
{
    public class ClassTransfer
    {
        public enum AssemblyType
        {
            None,
            DLL,
            WebService,
        }
        public enum PropertyType
        {
            None,
            Arrary,
            Class,
            Enum,
            System,
        }
        #region Property
        public AssemblyType TransferType { get; private set; }
        public string FromClassName { get; private set; }
        public string FromNamespace { get; private set; }
        public string ToClassName { get; private set; }
        public string ToNamespace { get; private set; }
        public List<string> ArrayTypeList { get; private set; }
        public List<string> TypeNameList { get; private set; }
        public string ClassText { get; private set; }
        public string MethodText { get; private set; }
        private List<Type> TypeList { get; set; }
        #endregion

        public ClassTransfer(AssemblyType type, string fromClassName, string fromNamespace, string toClassName, string toNamespace)
        {
            TransferType = type;
            FromClassName = fromClassName;
            FromNamespace = fromNamespace;
            ToClassName = toClassName;
            ToNamespace = toNamespace;
            ArrayTypeList = new List<string>();
            TypeNameList = new List<string>();
            TypeList = new List<Type>();
        }
        public void Build(string typeFullName, List<Assembly> assemblyList)
        {
            Build(new List<string>() { typeFullName }, assemblyList);
        }
        public void Build(List<string> typeFullNameList, List<Assembly> assemblyList)
        {
            foreach (Assembly a in assemblyList)
            {
                TypeList.AddRange(a.GetTypes());
            }
            foreach (string fullName in typeFullNameList)
            {
                object obj = Activator.CreateInstance(FindType(fullName));
                MethodText = BuildTransferMethod(obj);
                ClassText = BuildClass();
            }
        }

        #region Bulid Class
        private string BuildClass()
        {
            int spaceNum = 0;
            StringHelper.SpaceString ss = new StringHelper.SpaceString();
            ss.AppendLine(spaceNum, "using System;");
            ss.AppendLine(spaceNum, "using System.Collections.Generic;");
            ss.AppendLine();
            ss.AppendFormat(spaceNum, "namespace {0}", ToNamespace);
            ss.AppendLine();
            ss.AppendLine(spaceNum, "{");

            foreach (string s in TypeNameList)
            {
                ss.Append(BuildClassText(spaceNum + 1, FindType(s)));
            }

            ss.AppendLine(spaceNum, "}");
            return ss.ToString();
        }
        private string BuildClassText(int spaceNum, Type type)
        {
            PropertyType propType = PropertyType.None;
            StringHelper.SpaceString ss = new StringHelper.SpaceString();

            if (type.IsEnum)
            {
                ss.AppendFormat(spaceNum, "public enum {0}", type.Name);
                ss.AppendLine();
                ss.AppendLine(spaceNum, "{");
                foreach (FieldInfo f in type.GetFields())
                {
                    if (f.FieldType.FullName == type.FullName)
                    {
                        ss.AppendFormat(spaceNum + 1, "{0},", f.Name);
                        ss.AppendLine();
                    }
                }

                ss.AppendLine(spaceNum, "}");
                ss.AppendLine();
            }
            else
            {
                ss.AppendFormat(spaceNum, "public class {0}", type.Name);
                ss.AppendLine();
                ss.AppendLine(spaceNum, "{");

                if (TransferType == AssemblyType.WebService)
                {
                    foreach (FieldInfo f in type.GetFields())
                    {
                        propType = GetPropertyType(f);

                        ss.Append(spaceNum + 1, BuildClassPropertyText(spaceNum + 1, propType, f.Name, f.FieldType.Name));
                        ss.AppendLine();
                    }
                }
                else
                {
                    foreach (PropertyInfo p in type.GetProperties())
                    {
                        propType = GetPropertyType(p);

                        ss.Append(spaceNum + 1, BuildClassPropertyText(spaceNum + 1, propType, p.Name, p.PropertyType.Name));
                        ss.AppendLine();
                    }
                }

                ss.AppendLine();
                ss.AppendFormat(spaceNum + 1, "public {0}()", type.Name);
                ss.AppendLine();
                ss.AppendLine(spaceNum + 1, "{");
                ss.AppendLine();
                ss.AppendLine(spaceNum + 1, "}");

                ss.AppendLine(spaceNum, "}");
                ss.AppendLine();

                if (ArrayTypeList.Contains(type.FullName))
                {
                    ss.AppendFormat(spaceNum, "public class {0}s : List<{0}> {{ }}", type.Name);
                    ss.AppendLine();
                    ss.AppendLine();
                }
            }
            return ss.ToString();
        }
        private string BuildClassPropertyText(int spaceNum, PropertyType propType, string propName, string typeName)
        {
            string tmp = string.Empty;

            if (propType == PropertyType.System || propType == PropertyType.Enum)
            {
                tmp = string.Format("public {0} {1} {{ get; set; }}", typeName, propName);
            }
            else if (propType == PropertyType.Arrary)
            {
                tmp = string.Format("public List<{0}> {1} {{ get; set; }}", ReplaceArrayName(typeName), propName);
            }
            else if (propType == PropertyType.Class)
            {
                tmp = string.Format("public {0} {1} {{ get; set; }}", typeName, propName);
            }

            return tmp;
        }
        #endregion

        #region Bulid Method
        private string BuildTransferMethod(object obj)
        {
            if (obj != null)
            {
                return BuildPropertyTextForFirst(obj, ToClassName, FromClassName, ToNamespace, 0);
            }
            return string.Empty;
        }

        private string BuildPropertyText(object obj, string toClass, string fromClass, string toNamespace, int spaceNum)
        {
            PropertyType propType = PropertyType.None;
            StringHelper.SpaceString ss = new StringHelper.SpaceString();
            object o = obj;

            if (TransferType == AssemblyType.WebService)
            {
                foreach (FieldInfo f in obj.GetType().GetFields())
                {
                    propType = GetPropertyType(f);

                    if (propType != PropertyType.None && propType != PropertyType.System)
                    {
                        o = Activator.CreateInstance(FindType(f.FieldType.FullName));
                    }

                    ss.Append(BuildProperty(propType, o, f.Name, toClass, fromClass, toNamespace, spaceNum));
                }
            }
            else
            {
                foreach (PropertyInfo p in obj.GetType().GetProperties())
                {
                    propType = GetPropertyType(p);

                    if (propType != PropertyType.None && propType != PropertyType.System)
                    {
                        o = Activator.CreateInstance(FindType(p.PropertyType.FullName));
                    }

                    ss.Append(BuildProperty(propType, o, p.Name, toClass, fromClass, toNamespace, spaceNum));
                }
            }

            return ss.ToString();
        }
        private string BuildProperty(PropertyType propType, object obj, string propName, string toClass, string fromClass, string toNamespace, int spaceNum)
        {
            StringHelper.SpaceString ss = new StringHelper.SpaceString();
            AddTypeList(ReplaceArrayName(obj.GetType().FullName));

            if (propType == PropertyType.System)
            {
                ss.AppendFormat(spaceNum + 1, "{0}.{2} = {1}.{2};", toClass, fromClass, propName);
                ss.AppendLine();
            }
            else if (propType == PropertyType.Arrary)
            {
                AddArrayTypeList(ReplaceArrayName(obj.GetType().FullName));

                ss.Append(BuildArrayText(obj, toClass, fromClass, toNamespace, propName, spaceNum));
            }
            else if (propType == PropertyType.Class)
            {
                ss.AppendLine();
                ss.AppendFormat(spaceNum + 1, "if ({0}.{1} != null)", fromClass, propName);
                ss.AppendLine();
                ss.AppendLine(spaceNum + 1, "{");

                ss.Append(spaceNum, BuildPropertyTextForClass(obj, string.Format("{0}.{1}", toClass, propName), string.Format("{0}.{1}", fromClass, propName), toNamespace, spaceNum));
                ss.AppendLine(spaceNum + 1, "}");
            }
            else if (propType == PropertyType.Enum)
            {
                ss.AppendFormat(spaceNum + 1, "{0}.{2} = ({3}.{4})Enum.Parse(typeof({3}.{4}), {1}.{2}.ToString());", toClass, fromClass, propName, toNamespace, obj.GetType().Name);
                ss.AppendLine();
            }

            return ss.ToString();
        }
        private string BuildPropertyTextForFirst(object obj, string toClass, string fromClass, string toNamespace, int spaceNum)
        {
            AddTypeList(ReplaceArrayName(obj.GetType().FullName));
            spaceNum = spaceNum + 1;
            StringHelper.SpaceString ss = new StringHelper.SpaceString();
            ss.AppendFormat(spaceNum, "{0}.{1} {2} = new {0}.{1}();", toNamespace, obj.GetType().Name, toClass);
            ss.AppendLine();
            ss.AppendFormat(spaceNum, "if ({0} != null)", fromClass);
            ss.AppendLine();
            ss.AppendLine(spaceNum, "{");

            ss.Append(BuildPropertyText(obj, toClass, fromClass, toNamespace, spaceNum));

            ss.AppendLine(spaceNum, "}");
            return ss.ToString();
        }
        private string BuildPropertyTextForClass(object obj, string toClass, string fromClass, string toNamespace, int spaceNum)
        {
            spaceNum = spaceNum + 1;
            StringHelper.SpaceString ss = new StringHelper.SpaceString();
            ss.AppendFormat(spaceNum, "{0} = new {1}.{2}();", toClass, toNamespace, obj.GetType().Name);
            ss.AppendLine();
            ss.Append(BuildPropertyText(obj, toClass, fromClass, toNamespace, spaceNum));

            return ss.ToString();
        }
        private string BuildPropertyTextForArray(object obj, string toClass, string fromClass, string toNamespace, int spaceNum)
        {
            spaceNum = spaceNum + 1;
            StringHelper.SpaceString ss = new StringHelper.SpaceString();
            ss.AppendFormat(spaceNum, "{0} {1}  = new {0}();", toNamespace, GetPrivateName(obj.GetType().Name));
            ss.AppendLine();
            ss.Append(BuildPropertyText(obj, GetPrivateName(obj.GetType().Name), fromClass, ToNamespace, spaceNum));

            return ss.ToString();
        }
        private string BuildArrayText(object obj, string toClass, string fromClass, string toNamespace, string propName, int spaceNum)
        {
            spaceNum++;
            string objName = obj.GetType().Name;
            string forVar = GetForeachName(objName); ;
            StringHelper.SpaceString ss = new StringHelper.SpaceString();

            ss.AppendLine();
            ss.AppendFormat(spaceNum, "{0}.{1} = new List<{2}.{3}>();", toClass, propName, toNamespace, objName);
            ss.AppendLine();
            ss.AppendFormat(spaceNum, "if ({0}.{1} != null)", fromClass, propName);
            ss.AppendLine();
            ss.AppendLine(spaceNum, "{");

            ss.AppendFormat(spaceNum + 1, "foreach ({0}.{1} {2} in {3}.{4})", FromNamespace, objName, forVar, fromClass, propName);
            ss.AppendLine();
            ss.AppendLine(spaceNum + 1, "{");

            //object o = Activator.CreateInstance(FindType(field.FieldType.FullName));
            ss.Append(1, BuildPropertyTextForArray(obj, string.Format("{0}.{1}", toClass, objName), forVar, string.Format("{0}.{1}", toNamespace, objName), spaceNum));

            ss.AppendLine();
            ss.AppendFormat(spaceNum + 2, "{0}.{1}.Add({2});", toClass, propName, GetPrivateName(objName));

            ss.AppendLine();
            ss.AppendLine(spaceNum + 1, "}");
            ss.AppendLine(spaceNum, "}");

            return ss.ToString();
        }
        #endregion

        #region Private Member
        private string GetPrivateName(string name)
        {
            return "_" + name;
        }
        private string GetForeachName(string name)
        {
            return "_fr" + name;
        }
        private string ReplaceArrayName(string name)
        {
            return name.Replace("[]", "");
        }

        private Type FindType(string typeFullName)
        {
            typeFullName = typeFullName.Replace("[]", "");
            foreach (Type t in TypeList)
            {
                if (t.FullName == typeFullName)
                {
                    return t;
                }
            }
            return null;
        }
        private void AddArrayTypeList(string typeFullName)
        {
            if (!ArrayTypeList.Contains(typeFullName))
            {
                ArrayTypeList.Add(typeFullName);
            }
        }
        private void AddTypeList(string typeFullName)
        {
            if (!TypeNameList.Contains(typeFullName))
            {
                TypeNameList.Add(typeFullName);
            }
        }
        private PropertyType GetPropertyType(FieldInfo f)
        {
            if (f.FieldType.FullName.StartsWith("System."))
            {
                return PropertyType.System;
            }
            else if (f.FieldType.IsArray)
            {
                return PropertyType.Arrary;
            }
            else if (f.FieldType.IsClass && f.FieldType.FullName.StartsWith("System.") == false)
            {
                return PropertyType.Class;
            }
            else if (f.FieldType.IsEnum)
            {
                return PropertyType.Enum;
            }
            return PropertyType.None;
        }
        private PropertyType GetPropertyType(PropertyInfo p)
        {
            if (p.PropertyType.FullName.StartsWith("System."))
            {
                return PropertyType.System;
            }
            else if (p.PropertyType.IsArray)
            {
                return PropertyType.Arrary;
            }
            else if (p.PropertyType.IsClass && p.PropertyType.FullName.StartsWith("System.") == false)
            {
                return PropertyType.Class;
            }
            return PropertyType.None;
        }

        #endregion
    }
}
