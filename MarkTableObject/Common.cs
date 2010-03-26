using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
        SP,
    }

    public class Common
    {
        public static Entity.ProjectInfo GetProjectInfo(string fileName)
        {
            string xml = hwj.CommonLibrary.Object.FileHelper.ReadFile(fileName);
            return hwj.CommonLibrary.Object.SerializationHelper.FromXml<Entity.ProjectInfo>(xml);
        }
        public static string GetProjectFileName(string key)
        {
            return string.Format("{0}\\{1}.xml", Properties.Settings.Default.ProjectPath, key);
        }
        public static void CreateFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                string directory = Path.GetDirectoryName(fileName);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                else
                    using (File.Create(fileName)) { }
            }
        }
    }
}
