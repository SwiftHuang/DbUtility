using System;
using System.IO;
using System.Windows.Forms;

namespace hwj.MarkTableObject
{
    public enum DatabaseEnum
    {
        MSSQL,
        MYSQL,
        OleDb,
    }

    public enum DBModule
    {
        Table,
        View,
        SQL,
        SP,
    }

    public enum TemplateType
    {
        /// <summary>
        /// 旧有两层模板（静态方法）。
        /// </summary>
        Business,

        /// <summary>
        /// 一层DataAccess模板（实例化）。
        /// </summary>
        DataAccess,

        /// <summary>
        /// 一层DataAccess2.0模板（实例化）（推荐）。
        /// </summary>
        DataAccess2,
    }

    public class Common
    {
        public static string MainPath = string.Empty;

        public static Entity.ProjectInfo GetProjectInfoByKey(string key)
        {
            return GetProjectInfo(GetProjectFileName(key));
        }

        public static Entity.ProjectInfo GetProjectInfo(string fileName)
        {
            string xml = hwj.CommonLibrary.Object.FileHelper.ReadFile(fileName);
            return hwj.CommonLibrary.Object.SerializationHelper.FromXml<Entity.ProjectInfo>(xml);
        }

        public static string GetProjectFileName(string key)
        {
            return string.Format("{0}\\Project\\{1}.xml", MainPath, key);
        }

        public static void CreateFile(string fileName)
        {
            CreateFile(fileName, null);
        }

        public static void CreateFile(string fileName, string text)
        {
            if (!File.Exists(fileName))
            {
                string directory = Path.GetDirectoryName(fileName);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                else
                    using (File.Create(fileName)) { }
            }
            if (!string.IsNullOrEmpty(text))
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.UTF8))
                {
                    sw.Write(text);
                }
            }
        }

        public static void OpenPath(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                System.Diagnostics.Process.Start("Explorer.exe", path);
            }
        }

        public static void MsgError(string text, Exception ex)
        {
            MessageBox.Show(text, Properties.Resources.MsgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MsgInfo(string text)
        {
            MessageBox.Show(text, Properties.Resources.MsgInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MsgWarn(string text, Exception ex)
        {
            MessageBox.Show(text, Properties.Resources.MsgWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void MsgWarn(string text)
        {
            MessageBox.Show(text, Properties.Resources.MsgWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void InitTemplateCombox(System.Windows.Forms.ComboBox control)
        {
            control.Items.Add("DataAccess模板（实例化）");
            control.Items.Add("旧有两层模板（静态方法）");
            control.Items.Add("DataAccess 2.0模板（实例化）（推荐）");
            control.SelectedIndex = 0;
        }

        public static int GetComboxIndex(TemplateType type)
        {
            switch (type)
            {
                case TemplateType.Business:
                    return 1;
                case TemplateType.DataAccess:
                    return 0;
                case TemplateType.DataAccess2:
                default:
                    return 2;
            }
        }

        public static TemplateType GetTemplateTypeByComboxIndex(int index)
        {
            if(index==0)
            {
                return TemplateType.DataAccess;
            }
            else if(index==1)
            {
                return TemplateType.Business;
            }
            else
            {
                return TemplateType.DataAccess2;
            }
        }
    }

    public class GeneralMethodInfo
    {
        //bool Exists, bool Add, bool Update, bool Delete, bool GetEntity, bool Page, bool List, bool AllList
        public bool Exists { get; set; }

        public bool Add { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool GetEntity { get; set; }
        public bool Page { get; set; }
        public bool List { get; set; }
        public bool AllList { get; set; }

        public GeneralMethodInfo()
        {
            Exists = false;
            Add = false;
            Update = false;
            Delete = false;
            GetEntity = false;
            Page = false;
            List = false;
            AllList = false;
        }
    }
}