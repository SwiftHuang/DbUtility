using hwj.DBUtility.Core.Entity;
using hwj.DBUtility.Core.TableMapping;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;

namespace hwj.DBUtility.Core.MSSQL
{
    /// <summary>
    /// SQL:
    /// SELECT message_id AS Error, severity AS Severity,
    /// [Event Logged] = CASE is_event_logged WHEN 0 THEN 'No' ELSE 'Yes' END,
    /// text AS[Description]
    /// FROM sys.messages
    /// ORDER BY message_id
    ///
    /// URL:
    /// https://docs.microsoft.com/en-us/sql/relational-databases/errors-events/database-engine-events-and-errors?view=sql-server-ver15
    /// </summary>
    internal class DbExceptionHelper

    {
        public string TableName { get; }
        private List<FieldCheckInfo> FieldCheckInfos { get; set; }
        private List<FieldMappingInfo> FieldMappingInfos { get; set; }

        private DataTable dataTableData = null;

        //private SqlEntity sqlEntityData = null;
        private object baseTableData = null;

        public DbExceptionHelper(DataTable dateTable)
        {
            TableName = dateTable.TableName;
            dataTableData = dateTable;
            FieldCheckInfos = new List<FieldCheckInfo>();
            FieldMappingInfos = dateTable.ExtendedProperties[Common.FieldMappingsKey] as List<FieldMappingInfo>;
        }

        public DbExceptionHelper(SqlEntity sqlEntity)
        {
            TableName = sqlEntity.TableName;
            baseTableData = sqlEntity.DataEntity;
            FieldCheckInfos = new List<FieldCheckInfo>();
            FieldMappingInfos = FieldMappingInfo.GetFieldMapping(sqlEntity.GetType());
        }

        public DbExceptionHelper(string tableName, object baseTableObj)
        {
            TableName = tableName;
            baseTableData = baseTableObj;
            FieldCheckInfos = new List<FieldCheckInfo>();
            FieldMappingInfos = FieldMappingInfo.GetFieldMapping(baseTableObj.GetType());
        }

        public void CheckSqlException(ref SqlException ex)
        {
            if (baseTableData != null)
            {
                CheckSqlExceptionByBaseTable(ref ex);
            }
            else if (dataTableData != null)
            {
                CheckSqlExceptionByTable(ref ex);
            }
        }

        #region Private Method

        private void CheckSqlExceptionByTable(ref SqlException e)
        {
            if (dataTableData == null)
            {
                return;
            }

            if (e.Number == 4815)
            {
                foreach (DataColumn column in dataTableData.Columns)
                {
                    FieldMappingInfo field = FieldMappingInfos.Find(c => c.FieldName == column.ColumnName);
                    if (IsCheckingField(field))
                    {
                        foreach (DataRow row in dataTableData.Rows)
                        {
                            CheckingLengthByValue(field, row[column]);
                        }
                    }
                }
                string msg = GenCheckingResult();
                DbExceptionHelper.AddExData(ref e, Common.ExceptionFieldsKey, msg);
            }
        }

        private void CheckSqlExceptionByBaseTable(ref SqlException e)
        {
            if (baseTableData == null)
            {
                return;
            }

            if (e.Number == 8152 || e.Number == 8115)
            {
                foreach (FieldMappingInfo field in FieldMappingInfos)
                {
                    object value = field.Property.GetValue(baseTableData, null);
                    CheckingLengthByValue(field, value);
                }
                string msg = GenCheckingResult();
                DbExceptionHelper.AddExData(ref e, Common.ExceptionFieldsKey, msg);
            }
        }

        private string GenCheckingResult()
        {
            if (FieldCheckInfos.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("Table:{0},Fields:[", TableName);
                foreach (var field in FieldCheckInfos)
                {
                    sb.AppendFormat("{0}:{1}->{2},",
                        field.FieldInfo.FieldName,
                        field.FieldInfo.Size,
                        field.ValueLength);
                }
                return sb.ToString().TrimEnd(',') + "]";
            }
            return string.Empty;
        }

        private bool IsCheckingField(FieldMappingInfo fieldInfo)
        {
            if (fieldInfo == null || fieldInfo.Size == 0
                || fieldInfo.DataTypeCode == DbType.Boolean || fieldInfo.DataTypeCode == DbType.DateTime)
            {
                return false;
            }
            return true;
        }

        private void CheckingLengthByValue(FieldMappingInfo fieldInfo, object value)
        {
            if (value != null && IsCheckingField(fieldInfo))
            {
                FieldCheckInfo ci = null;
                string str = value.ToString();
                if (Common.IsNumType(fieldInfo.DataTypeCode) && str.IndexOf('.') >= 0)
                {
                    if (str.IndexOf('.') > fieldInfo.Size)
                    {
                        ci = new FieldCheckInfo()
                        {
                            FieldInfo = fieldInfo,
                            ValueLength = str.IndexOf('.'),
                        };
                    }
                }
                else
                {
                    if (str.Length > fieldInfo.Size)
                    {
                        ci = new FieldCheckInfo()
                        {
                            FieldInfo = fieldInfo,
                            ValueLength = str.Length,
                        };
                    }
                }

                if (ci != null)
                {
                    if (!FieldCheckInfos.Exists(c => c.FieldInfo.FieldName == ci.FieldInfo.FieldName))
                    {
                        FieldCheckInfos.Add(ci);
                    }
                }
            }
        }

        /// <summary>
        /// 检查字符长度是否与数据相符。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="tableName"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        //public static string FormatMsgFor8152(string tableName, object entity)
        //{
        //    string errFields = string.Empty;
        //    foreach (FieldMappingInfo field in FieldMappingInfo.GetFieldMapping(entity.GetType()))
        //    {
        //        if (field.Size != 0)
        //        {
        //            object value = field.Property.GetValue(entity, null);
        //            if (value != null)
        //            {
        //                string str = value.ToString();
        //                if (Common.IsNumType(field.DataTypeCode) && str.IndexOf('.') >= 0)
        //                {
        //                    if (str.IndexOf('.') > field.Size)
        //                    {
        //                        errFields += field.FieldName + "/";
        //                    }
        //                }
        //                else if (field.DataTypeCode == DbType.Boolean)
        //                {
        //                }
        //                else if (field.DataTypeCode == DbType.DateTime)
        //                {
        //                }
        //                else
        //                {
        //                    if (str.Length > field.Size)
        //                    {
        //                        errFields += field.FieldName + "/";
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    errFields = errFields.TrimEnd('/');
        //    if (!string.IsNullOrEmpty(errFields))
        //    {
        //        return string.Format("Table:{0};Field:{1};", tableName, errFields);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        #endregion Private Method

        /// <summary>
        /// 异常添加附加信息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="key"></param>
        /// <param name="message"></param>
        public static void AddExData(ref SqlException ex, string key, string message)
        {
            if (ex.Data != null)
            {
                if (ex.Data.Contains(key))
                {
                    object obj = ex.Data[key];
                    if (obj != null)
                    {
                        string tmpMsg = ex.Data[key].ToString();
                        message = string.Format("{0}\r\n{1}", tmpMsg, message);
                    }
                    ex.Data.Remove(key);
                }
                ex.Data.Add(key, message);
            }
        }
    }
}