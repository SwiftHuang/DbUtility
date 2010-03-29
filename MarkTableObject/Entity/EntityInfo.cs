﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace hwj.MarkTableObject.Entity
{
    public class EntityInfo
    {
        public string EntityName { get; set; }
        public string TableName { get; set; }
        public string ConnectionString { get; set; }
        public string FileName { get; set; }
        public string NameSpace { get; set; }
        public ColumnInfos ColumnInfoList { get; set; }
        public ColumnInfos PKColumnInfoList { get; set; }
        public string PKColumnParam { get; set; }
        public string SPName { get; set; }
        public SPParamColumnInfos SPParamInfos { get; set; }
        public string SPParamString { get; set; }
        public ConnectionDataSourceType ConnType { get; set; }
        public DBModule Module { get; set; }
        public string CommandText { get; set; }
        /// <summary>
        /// 前缀字符
        /// </summary>
        public string PrefixChar { get; set; }

        public EntityInfo()
        {
            ColumnInfoList = new ColumnInfos();
        }

        public EntityInfo(ProjectInfo prjInfo, DBModule module, string tableName)
        {
            Module = module;
            ConnType = prjInfo.ConnectionDataSource;
            ConnectionString = prjInfo.ConnectionString;
            NameSpace = prjInfo.EntityNamespace;
            TableName = tableName;
            PrefixChar = prjInfo.EntityPrefixChar;

            EntityName = PrefixChar + TableName;
            FileName = string.Format("{0}\\{1}.cs", prjInfo.EntityPath.TrimEnd('\\'), EntityName);
        }
        public void InitColumnInfoList()
        {
            ColumnInfoList = BLL.MSSQL.BuilderColumn.GetColumnInfoForTable(this);
            InitColumnInfoList(ColumnInfoList);
        }
        public void InitColumnInfoList(ColumnInfos columnInfoList)
        {
            switch (this.ConnType)
            {
                case ConnectionDataSourceType.MSSQL:
                    StringBuilder sb = new StringBuilder();
                    PKColumnInfoList = new ColumnInfos();
                    ColumnInfoList = columnInfoList;

                    foreach (ColumnInfo c in ColumnInfoList)
                    {
                        if (c.IsKey)
                        {
                            PKColumnInfoList.Add(c);
                            sb.Append(FormatParam(c));
                        }
                    }
                    PKColumnParam = sb.ToString().TrimEnd(',').Trim();
                    break;
                case ConnectionDataSourceType.MYSQL:
                    break;
                case ConnectionDataSourceType.OleDb:
                    break;
                default:
                    break;
            }
        }

        public void InitSPParamString()
        {
            InitSPParamString(SPParamInfos);
        }
        public void InitSPParamString(SPParamColumnInfos spParamInfos)
        {
            if (spParamInfos != null)
            {
                StringBuilder sbSql = new StringBuilder();
                StringBuilder sb = new StringBuilder();
                foreach (SPParamColumnInfo c in spParamInfos)
                {
                    sb.Append(FormatSPParam(c));
                    sbSql.AppendFormat("@{0}, ", c.ParameterName);
                }
                SPParamString = sb.ToString().TrimEnd(',').Trim();
                CommandText = string.Format("EXEC {0} {1}", SPName, sbSql.ToString()).Trim().TrimEnd(',');
            }
        }
        private string FormatParam(ColumnInfo col)
        {
            string strType = col.DataType.Replace("System.", "");
            strType = strType.Substring(0, 1).ToLower() + strType.Substring(1);
            return string.Format(" {0} {1},", strType, col.ColumnName);
        }
        private string FormatSPParam(SPParamColumnInfo col)
        {
            string strType = string.Empty;
            switch (this.ConnType)
            {
                case ConnectionDataSourceType.MSSQL:
                    strType = DBType2NetTypeForMSSQL(col.DataType).ToString();
                    break;
                case ConnectionDataSourceType.MYSQL:
                    break;
                case ConnectionDataSourceType.OleDb:
                    break;
                default:
                    break;
            }
            strType = strType.Substring(0, 1).ToLower() + strType.Substring(1);
            return string.Format(" {0} {1},", strType, col.ParameterName);
        }
        private TypeCode DBType2NetTypeForMSSQL(string value)
        {
            value = value.ToUpper();
            if (value == SqlDbType.VarChar.ToString().ToUpper() || value == SqlDbType.Char.ToString().ToUpper()
                || value == SqlDbType.NVarChar.ToString().ToUpper() || value == SqlDbType.NChar.ToString().ToUpper()
                || value == SqlDbType.Date.ToString().ToUpper() || value == SqlDbType.DateTime.ToString().ToUpper())
                return TypeCode.String;
            else
                return TypeCode.Int32;
        }
    }
}