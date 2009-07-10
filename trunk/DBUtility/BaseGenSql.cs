using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility
{
    public abstract class BaseGenSql<T> where T : BaseTable<T>, new()
    {
        protected const string _DeleteString = "DELETE FROM {0} {1};";
        protected const string _SelectCountString = "SELECT COUNT(1) FROM {0} (NOLOCK) {1};";
        protected const string _UpdateString = "UPDATE {0} SET {1} {2};";
        protected const string _InsertString = "INSERT INTO {0} ({1}) VALUES({2});";
        protected const string _StringFormat = "'{0}'";
        protected const string _DecimalFormat = "{0}";
        protected static string _FieldFormat = string.Empty;
        /// <summary>
        /// 获取数据库SQL
        /// </summary>
        protected string DatabaseGetDateSql = string.Empty;

        private static readonly int andL = Enums.Expression.AND.ToSqlString().Length;
        private static readonly int andR = Enums.Expression.OR.ToSqlString().Length;

        #region Public Functions

        #region Delete Sql
        /// <summary>
        /// 获取Delete Sql
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="filterParam">筛选条件</param>
        /// <returns></returns>
        public string DeleteSql(string tableName, FilterParams filterParam)
        {
            return string.Format(_DeleteString, tableName, GenFilterParamsSql(filterParam));
        }
        /// <summary>
        /// 彻底清除表的内容(重置自动增量)
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public abstract string TruncateSql(string tableName);
        #endregion

        #region Update Sql
        private void SetUpdateParam(ref UpdateParam up, FieldMappingInfo field, T entity)
        {
            object obj = field.Property.GetValue(entity, null);
            if (obj != null)
            {
                if (!field.DataHandles.Find(Enums.DataHandle.UnUpdate))
                {
                    if (!IsDatabaseDate(field.DataTypeCode, obj))
                        up.AddParam(field.FieldName, obj);
                    else
                        up.AddParam(field.FieldName, DatabaseGetDateSql);
                }
            }
            else
            {
                if (!field.DataHandles.Find(Enums.DataHandle.UnNull))
                    up.AddParam(field.FieldName, DBNull.Value);
            }
        }
        /// <summary>
        /// 获取Update Sql
        /// </summary>
        /// <param name="entity">表对象</param>
        /// <param name="filterParams">筛选条件</param>
        /// <returns></returns>
        internal string UpdateSql(T entity, FilterParams filterParams)
        {
            UpdateParam up = new UpdateParam();
            if (entity.GetAssignedStatus())
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    if (entity.GetAssigned().IndexOf(f.FieldName) != -1)
                    {
                        SetUpdateParam(ref up, f, entity);
                    }
                }
            }
            else
            {
                foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
                {
                    SetUpdateParam(ref up, f, entity);
                }
            }
            return UpdateSql(entity.GetTableName(), up, filterParams);
        }
        /// <summary>
        /// 获取Update Sql
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="updateParam">Update参数</param>
        /// <param name="filterParam">筛选参选</param>
        /// <returns></returns>
        internal string UpdateSql(string tableName, UpdateParam updateParam, FilterParams filterParam)
        {
            return string.Format(_UpdateString, tableName, GenFieldsSql(updateParam), GenFilterParamsSql(filterParam));
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
            return string.Format(_SelectCountString, tableName, GenFilterParamsSql(filterParam));
        }
        #endregion

        #endregion

        #region Protected Functions
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
                    sb.AppendFormat(_FieldFormat, s.ToString()).Append(',');
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
                    sb.AppendFormat(_FieldFormat + " {1},", o.FieldName, o.OrderBy.ToSqlString());
                }
                return sb.ToString().TrimEnd(',');
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// 格式化最后的表达式
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected string TrimSql(string sql)
        {
            if (sql.Substring(sql.Length - andL, andL) == Enums.Expression.AND.ToSqlString())
                sql = sql.Substring(0, sql.Length - andL);
            if (sql.Substring(sql.Length - andR, andR) == Enums.Expression.OR.ToSqlString())
                sql = sql.Substring(0, sql.Length - andR);
            return sql.TrimEnd(',');
        }
        /// <summary>
        /// 检查非法字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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
        protected bool IsDatabaseDate(SqlParam param)
        {
            if (param.FieldValue is DateTime && Convert.ToDateTime(param.FieldValue) == SqlParam.DatabaseDate)
                return true;
            return false;
        }
        protected bool IsDatabaseDate(System.Data.DbType dbType, object value)
        {
            if (IsDateType(dbType) && Convert.ToDateTime(value) == SqlParam.DatabaseDate)
                return true;
            else
                return false;
        }
        #endregion
    }
}
