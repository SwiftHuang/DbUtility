using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility
{
    public abstract class BaseGenSql<T> where T : BaseTable<T>
    {
        protected const string _DeleteString = "DELETE FROM {0} {1};";
        protected const string _SelectCountString = "SELECT COUNT(1) FROM {0} (NOLOCK) {1};";
        protected const string _UpdateString = "UPDATE {0} SET {1} {2};";
        protected const string _InsertString = "INSERT INTO {0} ({1}) VALUES({2});";
        protected const string _StringFormat = "'{0}'";
        protected const string _DecimalFormat = "{0}";

        #region Property
        protected string GetTableName()
        {
            return GetTableName(null);
        }
        protected string GetTableName(string tableName)
        {
            if (tableName != null && tableName != string.Empty)
                return tableName;
            else
                return typeof(T).Name.ToString().Trim();
        }
        protected string CheckSql(string str)
        {
            string s = string.Empty;
            if (str == null)
            {
                s = string.Empty;
            }
            else
            {
                s = str.Replace("'", "").Replace("*", "").Replace("select", "")
                       .Replace("where", "").Replace(";", "").Replace("drop", "").Replace("DROP", "").Replace("and", "").Replace("or", "").Replace("delete", "").Replace("asc", "").Replace("<", "").Replace(">", "").Replace("=", "").Replace(";", "").Replace("&", "").Replace("*", "");
            }
            return s;
        }

        #endregion

        #region Public Functions

        #region Delete Sql
        public string DeleteSql(FilterParams filterParam)
        {
            return string.Format(_DeleteString, GetTableName(), GenFilterParamsSql(filterParam));
        }
        public string DeleteBatchSql(FilterParams filterParam, string inSqlParam)
        {
            return string.Format(_DeleteString, GetTableName(), string.Format(GenFilterParamsSql(filterParam), inSqlParam));
        }
        /// <summary>
        /// 彻底清除表的内容(重置自动增量)
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public abstract string TruncateSql(string tableName);
        #endregion

        #region Update Sql
        public string UpdateSql(T entity, FilterParams filterParams)
        {
            UpdateParam up = new UpdateParam();
            if (entity.UseAssigned)
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    if (entity.Assigned.IndexOf(f.FieldName) != -1)
                    {
                        object obj = f.Property.GetValue(entity, null);
                        if (obj != null)
                        {
                            if (!f.DataHandles.Find(Enums.DataHandle.UnUpdate))
                                up.AddParam(f.FieldName, obj);
                        }
                        else
                        {
                            if (!f.DataHandles.Find(Enums.DataHandle.UnNull))
                                up.AddParam(f.FieldName, DBNull.Value);
                        }
                    }
                }
            }
            else
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    object obj = f.Property.GetValue(entity, null);
                    if (obj != null)
                    {
                        if (!f.DataHandles.Find(Enums.DataHandle.UnUpdate))
                            up.AddParam(f.FieldName, obj);
                    }
                    else
                    {
                        if (!f.DataHandles.Find(Enums.DataHandle.UnNull))
                            up.AddParam(f.FieldName, DBNull.Value);
                    }
                }
            }
            return UpdateSql(up, filterParams);
        }
        public string UpdateSql(UpdateParam updateParam, FilterParams whereParam)
        {
            return string.Format(_UpdateString, GetTableName(), GenFieldsSql(updateParam), GenFilterParamsSql(whereParam));
        }
        private bool FindName(string value, params Enum[] datasource)
        {
            foreach (Enum s in datasource)
            {
                if (value == s.ToString())
                    return true;
            }
            return false;
        }

        #endregion

        #region Insert Sql
        public abstract string InsertLastIDSql();
        public abstract string InsertSql(T entity);
        #endregion

        public abstract string SelectSql(string tableName, DisplayFields displayFields, FilterParams filterParam, SortParams orderParam, int? maxCount);

        #region Record Count Sql
        public string SelectCountSql(string tableName, FilterParams filterParam)
        {
            return string.Format(_SelectCountString, GetTableName(tableName), GenFilterParamsSql(filterParam));
        }
        #endregion

        #endregion

        #region Protected Functions
        protected bool IsNumType(DbType typeCode)
        {
            if (typeCode == DbType.Decimal || typeCode == DbType.Int16 || typeCode == DbType.Int32 || typeCode == DbType.Int64)
                return true;
            else
                return false;
        }
        protected bool IsDateType(DbType typeCode)
        {
            if (typeCode == DbType.DateTime)
                return true;
            else
                return false;
        }

        protected abstract string GetCondition(SqlParam para, bool isWhere, bool isPage);
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
        protected abstract string GenFilterParamsSql(FilterParams listParam, bool isPage);
        protected string GenFilterParamsSql(FilterParams listParam)
        {
            return GenFilterParamsSql(listParam, false);
        }
        protected string GenGroupParamsSql(GroupParams param)
        {
            return GenDisplayFieldsSql(param, true);
        }
        protected string GenDisplayFieldsSql(DisplayFields fields)
        {
            return GenDisplayFieldsSql(fields, false);
        }
        protected string GenDisplayFieldsSql(List<Enum> fields, bool isPage)
        {
            if (fields != null && fields.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Enum s in fields)
                {
                    sb.AppendFormat("[{0}]", s.ToString()).Append(',');
                }
                return sb.ToString().TrimEnd(',');
            }
            if (!isPage)
                return "*";
            else
                return "";
        }
        protected string GenSortParamsSql(SortParams orders)
        {
            return GenSortParamsSql(orders, false);
        }
        protected string GenSortParamsSql(SortParams orders, bool isPage)
        {
            if (orders != null)
            {
                StringBuilder sb = new StringBuilder();
                if (!isPage)
                    sb.Append("ORDER BY ");
                foreach (SortParam o in orders)
                {
                    sb.AppendFormat("[{0}] {1},", o.FieldName, o.OrderBy.ToSqlString());
                }
                return sb.ToString().TrimEnd(',');
            }
            else
                return string.Empty;
        }
        #endregion

        private static readonly int andL = Enums.Expression.AND.ToSqlString().Length;
        private static readonly int andR = Enums.Expression.OR.ToSqlString().Length;
        /// <summary>
        /// 格式化最后的表达式
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        internal string TrimSql(string sql)
        {
            if (sql.Substring(sql.Length - andL, andL) == Enums.Expression.AND.ToSqlString())
                sql = sql.Substring(0, sql.Length - andL);
            if (sql.Substring(sql.Length - andR, andR) == Enums.Expression.OR.ToSqlString())
                sql = sql.Substring(0, sql.Length - andR);
            return sql.TrimEnd(',');
        }
    }
}
