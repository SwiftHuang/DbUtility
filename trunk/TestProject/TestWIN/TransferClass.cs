using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hwj.CommonLibrary.Object;
using System.Reflection;

namespace TestWIN
{
    public class TransferClass
    {
        public string FromClassName { get; private set; }
        public string FromNamespace { get; private set; }
        public string ToClassName { get; private set; }
        public string ToNamespace { get; private set; }
        public object Instance { get; private set; }

        public TransferClass(object obj, string fromClassName, string fromNamespace, string toClassName, string toNamespace)
        {
            FromClassName = fromClassName;
            FromNamespace = fromNamespace;
            ToClassName = toClassName;
            ToNamespace = toNamespace;
            Instance = obj;
        }

        public string BuildTransferMethod()
        {
            if (Instance != null)
            {
                return BuildPropertyTextForFirst(Instance, ToClassName, FromClassName, ToNamespace, 0);
            }
            return string.Empty;
        }
        public string BuildClass()
        {
            int spaceNum = 0;
            StringHelper.SpaceString ss = new StringHelper.SpaceString();
            ss.AppendLine(spaceNum, "using System;");
            ss.AppendLine(spaceNum, "using System.Collections.Generic;");

            ss.AppendFormat(spaceNum, "namespace {0}", ToNamespace);
            ss.AppendLine();
            ss.AppendLine(spaceNum, "{");

            foreach (Type type in Instance.GetType().Assembly.GetTypes())
            {
                ss.Append(BuildClassText(spaceNum + 1, type));
            }
            ss.AppendLine();
            ss.AppendLine(spaceNum, "}");
            return ss.ToString();
        }

        #region Private Member

        #region Bulid Class
        private string BuildClassText(int spaceNum, Type type)
        {
            StringHelper.SpaceString ss = new StringHelper.SpaceString();
            ss.AppendFormat(spaceNum, "public class {0}", type.Name);
            ss.AppendLine();
            ss.AppendLine(spaceNum, "{");

            foreach (FieldInfo f in type.GetFields())
            {
                ss.Append(spaceNum + 1, BuildClassPropertyText(spaceNum + 1, f));
                ss.AppendLine();
            }

            ss.AppendLine();
            ss.AppendFormat(spaceNum + 1, "public {0}()", type.Name);
            ss.AppendLine();
            ss.AppendLine(spaceNum + 1, "{");
            ss.AppendLine();
            ss.AppendLine(spaceNum + 1, "}");

            ss.AppendLine();
            ss.AppendLine(spaceNum, "}");
            ss.AppendLine();

            return ss.ToString();
        }
        private string BuildClassPropertyText(int spaceNum, FieldInfo field)
        {
            string tmp = string.Empty;

            if (field.FieldType.FullName.StartsWith("System."))
            {
                tmp = string.Format("public {0} {1} {{ get; set; }}", field.FieldType.Name, field.Name);
            }
            else if (field.FieldType.IsArray)
            {
                tmp = string.Format("public List<{0}> {1} {{ get; set; }}", ReplaceArrayName(field.FieldType.Name), field.Name);
            }
            else if (field.FieldType.IsClass && field.FieldType.FullName.StartsWith("System.") == false)
            {
                tmp = string.Format("public {0} {1} {{ get; set; }}", field.FieldType.Name, field.Name);
            }

            return tmp;
        }

        #endregion

        #region Bulid Method
        private string BuildPropertyText(object obj, string toClass, string fromClass, string toNamespace, int spaceNum)
        {
            StringHelper.SpaceString ss = new StringHelper.SpaceString();

            foreach (FieldInfo f in obj.GetType().GetFields())
            {
                if (f.FieldType.FullName.StartsWith("System."))
                {
                    ss.AppendFormat(spaceNum + 1, "{0}.{2} = {1}.{2};", toClass, fromClass, f.Name);
                    ss.AppendLine();
                }
                else if (f.FieldType.IsArray)
                {
                    ss.Append(BuildArrayText(obj, toClass, fromClass, toNamespace, f, spaceNum));
                }
                else if (f.FieldType.IsClass && f.FieldType.FullName.StartsWith("System.") == false)
                {
                    ss.AppendLine();
                    ss.AppendFormat(spaceNum + 1, "if ({0}.{1} != null)", fromClass, f.Name);
                    ss.AppendLine();
                    ss.AppendLine(spaceNum + 1, "{");

                    object o = Activator.CreateInstance(FindType(f.FieldType.FullName));
                    ss.Append(spaceNum, BuildPropertyTextForClass(o, string.Format("{0}.{1}", toClass, f.Name), string.Format("{0}.{1}", fromClass, f.Name), toNamespace, spaceNum));
                    ss.AppendLine(spaceNum + 1, "}");
                }
            }

            return ss.ToString();
        }
        private string BuildPropertyTextForFirst(object obj, string toClass, string fromClass, string toNamespace, int spaceNum)
        {
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
        private string BuildArrayText(object obj, string toClass, string fromClass, string toNamespace, FieldInfo field, int spaceNum)
        {
            spaceNum++;
            string objName = ReplaceArrayName(field.FieldType.Name);
            string forVar = GetForeachName(objName); ;
            StringHelper.SpaceString ss = new StringHelper.SpaceString();

            ss.AppendLine();
            ss.AppendFormat(spaceNum, "{0}.{1} = new List<{2}.{3}>();", toClass, field.Name, toNamespace, objName);
            ss.AppendLine();
            ss.AppendFormat(spaceNum, "if ({0}.{1} != null)", fromClass, field.Name);
            ss.AppendLine();
            ss.AppendLine(spaceNum, "{");

            ss.AppendFormat(spaceNum + 1, "foreach ({0}.{1} {2} in {3}.{4})", FromNamespace, objName, forVar, fromClass, field.Name);
            ss.AppendLine();
            ss.AppendLine(spaceNum + 1, "{");

            object o = Activator.CreateInstance(FindType(field.FieldType.FullName));
            ss.Append(1, BuildPropertyTextForArray(o, string.Format("{0}.{1}", toClass, objName), forVar, string.Format("{0}.{1}", toNamespace, objName), spaceNum));
            //ss.Append(1, BuildPropertyTextForArray(o, string.Format("{0}.{1}", toClass, objName), forVar, string.Format("{0}.{1}", toNamespace, string.Empty), spaceNum));

            ss.AppendLine();
            ss.AppendFormat(spaceNum + 2, "{0}.{1}.Add({2});", toClass, field.Name, GetPrivateName(o.GetType().Name));

            ss.AppendLine();
            ss.AppendLine(spaceNum + 1, "}");
            ss.AppendLine(spaceNum, "}");

            return ss.ToString();
        }
        #endregion

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
        private Type FindType(string typeName)
        {
            typeName = typeName.Replace("[]", "");
            foreach (Type t in Instance.GetType().Assembly.GetTypes())
            {
                if (t.FullName == typeName)
                {
                    return t;
                }
            }
            return null;
        }
        #endregion
    }
}
