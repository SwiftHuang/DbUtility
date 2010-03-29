using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace hwj.MarkTableObject
{
    public enum ConnectionDataSourceType
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

    public class Common
    {
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
            return string.Format("{0}\\{1}\\{2}.xml", Properties.Settings.Default.MainPath, Properties.Settings.Default.ProjectPath, key);
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

        public static void MsgError(string text, Exception ex)
        {
            MessageBox.Show(text);
        }
        public static void MsgInfo(string text)
        {
            MessageBox.Show(text);
        }
        public static void MsgWarn(string text, Exception ex)
        {
            MessageBox.Show(text);
        }
        public static void MsgWarn(string text)
        {
            MessageBox.Show(text);
        }
    }
}
