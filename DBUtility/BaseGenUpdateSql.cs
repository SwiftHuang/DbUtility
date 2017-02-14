﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility
{
    public abstract class BaseGenUpdateSql<T> : BaseGenSql<T> where T : BaseTable<T>, new()
    {
        protected const string _DeleteString = "DELETE FROM {0} {1};";
        protected const string _UpdateString = "UPDATE {0} SET {1} {2};";
        protected const string _InsertString = "INSERT INTO {0} ({1}) VALUES({2});";

        #region Public Functions

        #region Delete Sql
        /// <summary>
        /// 获取Delete Sql
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="filterParams">筛选条件</param>
        /// <returns></returns>
        public string DeleteSql(string tableName, FilterParams filterParams)
        {
            return string.Format(_DeleteString, tableName, GenFilterParamsSql(filterParams));
        }
        /// <summary>
        /// 彻底清除表的内容(重置自动增量)
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public abstract string TruncateSql(string tableName);
        #endregion

        #region Update Sql
        private void SetUpdateParam(ref UpdateParam up, FieldMappingInfo field, T entity, string paramName, out IDbDataParameter dbDataParameter)
        {
            bool existCustomSqlText = entity.ExistCustomSqlText(field.FieldName);
            object obj = field.Property.GetValue(entity, null);
            if (obj != null)
            {
                if (!Enums.DataHandlesFind(field.DataHandles, Enums.DataHandle.UnUpdate))
                {
                    if (existCustomSqlText)
                    {
                        string value = entity.GetCustomSqlTextValue(field.FieldName);
                        up.AddCustomParam(field.FieldName, value);
                    }
                    else
                    {
                        //if (!IsDatabaseDate(field.DataTypeCode, obj))
                        up.AddParam(field.FieldName, obj, paramName);
                        //else
                        //    up.AddParam(field.FieldName, DatabaseGetDateSql);
                    }
                }
            }
            else
            {
                if (!Enums.DataHandlesFind(field.DataHandles, Enums.DataHandle.UnNull))
                {
                    up.AddParam(field.FieldName, DBNull.Value, paramName);
                }
            }
            dbDataParameter = null;
            if (!existCustomSqlText)
            {
                dbDataParameter = GetSqlParameter(field, obj, paramName);
            }
        }
        internal abstract IDbDataParameter GetSqlParameter(FieldMappingInfo field, object value, string paramName);
        /// <summary>
        /// 获取Update Sql
        /// </summary>
        /// <param name="entity">表对象</param>
        /// <param name="filterParams">筛选条件</param>
        /// <returns></returns>
        internal string UpdateSql(T entity, FilterParams filterParams, out List<IDbDataParameter> dbDataParameters)
        {
            dbDataParameters = new List<IDbDataParameter>();
            UpdateParam up = new UpdateParam();
            int index = 0;
            if (entity.GetAssignedStatus())
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    if (entity.GetAssigned().IndexOf(f.FieldName) != -1)
                    {

                        IDbDataParameter dp = null;
                        SetUpdateParam(ref up, f, entity, "_P_" + index.ToString(), out dp);
                        if (dp != null)
                        {
                            dbDataParameters.Add(dp);
                        }
                        index++;
                    }
                }
            }
            else
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    IDbDataParameter dp = null;
                    SetUpdateParam(ref up, f, entity, "_P" + index.ToString(), out dp);
                    if (dp != null)
                    {
                        dbDataParameters.Add(dp);
                    }
                    index++;
                }
            }
            return UpdateSql(entity.GetTableName(), up, filterParams);
        }
        /// <summary>
        /// 获取Update Sql
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="updateParam">Update参数</param>
        /// <param name="filterParams">筛选参选</param>
        /// <returns></returns>
        internal string UpdateSql(string tableName, UpdateParam updateParam, FilterParams filterParams)
        {
            return string.Format(_UpdateString, tableName, GenFieldsSql(updateParam), GenFilterParamsSql(filterParams));
        }
        #endregion

        #region Insert Sql
        public abstract string InsertLastIDSql();
        public abstract string InsertSql(T entity, out List<IDbDataParameter> dbDataParameters);
        #endregion

        #endregion

        #region Protected Functions
        protected string GenFieldsSql(UpdateParam listParam)
        {
            if (listParam != null && listParam.Count > 0)
            {
                StringBuilder sbUpdate = new StringBuilder();
                foreach (SqlParam para in listParam)
                {
                    sbUpdate.Append(GetCondition(para, false, false));
                }
                return sbUpdate.ToString().TrimEnd(',');
            }
            else
                return string.Empty;
        }
        #endregion
    }
}
