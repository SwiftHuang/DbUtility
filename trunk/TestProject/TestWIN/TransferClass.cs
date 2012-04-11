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
                return BuildPropertyText(Instance, true, 0);
                //foreach (FieldInfo f in Instance.GetType().GetFields())
                //{
                //    if (f.FieldType.FullName.StartsWith("System."))
                //    {
                //        ss.AppendFormat("{0}.{2} = {1}.{2};", ToClassName, FromClassName, f.Name);
                //        ss.AppendLine();
                //    }
                //    else if (f.FieldType.IsArray)
                //    {
                //        ss.Append(BuildArrayText(Instance, f));
                //    }
                //}
            }
            return string.Empty;
        }
        private string BuildPropertyText(object obj, bool firstClass, int spaceNum)
        {
            spaceNum = spaceNum + 1;
            StringHelper.SpaceString ss = new StringHelper.SpaceString();
            if (firstClass)
            {
                ss.AppendFormat(spaceNum, "{0}.{1} {2} = new {0}.{1}();", ToNamespace, obj.GetType().Name, ToClassName);
                ss.AppendLine();
                ss.AppendFormat(spaceNum, "if ({0} != null)", FromClassName);
                ss.AppendLine();
                ss.AppendLine(spaceNum, "{");
            }
            else
            {
                ss.AppendFormat(spaceNum, "{0}.{1} = new {2}.{1}();", ToClassName, obj.GetType().Name, ToNamespace);
                ss.AppendLine();
            }
            foreach (FieldInfo f in obj.GetType().GetFields())
            {
                if (f.FieldType.FullName.StartsWith("System."))
                {
                    ss.AppendFormat(spaceNum + 1, "{0}.{2} = {1}.{2};", ToClassName, FromClassName, f.Name);
                    ss.AppendLine();
                }
                else if (f.FieldType.IsArray)
                {
                    ss.Append(BuildArrayText(obj, f, spaceNum));
                }
                else if (f.FieldType.IsClass && f.FieldType.FullName.StartsWith("System.") == false)
                {
                    ss.AppendLine();
                    ss.AppendFormat(spaceNum + 1, "if ({0}.{1} != null)", FromClassName, f.Name);
                    ss.AppendLine();
                    ss.AppendLine(spaceNum + 1, "{");

                    object o = Activator.CreateInstance(FindType(f.FieldType.FullName));
                    ss.AppendLine(spaceNum + 1, BuildPropertyText(o, false, spaceNum));

                    ss.AppendLine();
                    ss.AppendLine(spaceNum + 1, "}");
                }
            }

            if (firstClass)
            {
                ss.AppendLine(spaceNum, "}");
            }
            return ss.ToString();
        }
        private string BuildArrayText(object obj, FieldInfo field, int spaceNum)
        {
            spaceNum++;
            StringHelper.SpaceString ss = new StringHelper.SpaceString();

            ss.AppendLine();
            ss.AppendFormat(spaceNum, "{0}.{1} = new List<{2}.{3}>();", ToClassName, field.Name, ToNamespace, field.FieldType.Name.Replace("[]", ""));
            ss.AppendLine();
            ss.AppendFormat(spaceNum, "if ({0}.{1} != null)", FromClassName, field.Name);
            ss.AppendLine();
            ss.AppendLine(spaceNum, "{");
            ss.AppendFormat(spaceNum + 1, "foreach ({0}.{1} {2} in {3}.{4})", FromNamespace, field.FieldType.Name.Replace("[]", ""), "_" + field.FieldType.Name.Replace("[]", ""), FromClassName, field.Name);
            ss.AppendLine();
            ss.AppendLine(spaceNum + 1, "{");

            object o = Activator.CreateInstance(FindType(field.FieldType.FullName));
            ss.Append(BuildPropertyText(o, false, spaceNum));

            ss.AppendLine(spaceNum + 1, "}");
            ss.AppendLine(spaceNum, "}");

            return ss.ToString();
        }
        private string GetPrivateName(string name)
        {
            return "_" + name;
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
    }
}
