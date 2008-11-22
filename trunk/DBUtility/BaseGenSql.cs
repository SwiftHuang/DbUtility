using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility
{
    public abstract class BaseGenSql<T>
    {
        protected const string _DeleteString = "DELETE FROM {0} {1};";
        protected const string _SelectCountString = "SELECT COUNT(*) FROM {0} {1};";
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
        #endregion

        #region Public Functions

        #region Delete Sql
        public string DeleteSql(FilterParam whereParam)
        {
            return string.Format(_DeleteString, GetTableName(), GenFilterSql(whereParam));
        }
        #endregion

        #region Update Sql
        public string UpdateSql(T entity, FilterParam whereParam, params Enum[] notUpdateParam)
        {
            UpdateParam up = new UpdateParam();
            foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
            {
                object obj = f.Property.GetValue(entity, null);
                if (obj != null)
                {
                    if (!FindName(f.FieldName, notUpdateParam))
                        up.AddParam(f.FieldName, obj);

                }
            }
            return UpdateSql(up, whereParam);
        }
        public string UpdateSql(UpdateParam updateParam, FilterParam whereParam)
        {
            return string.Format(_UpdateString, GetTableName(), GenerateFieldSql(updateParam), GenFilterSql(whereParam));
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

        public abstract string SelectSql(string tableName, DisplayFields selectFields, FilterParam whereParam, SortFields orderParam, int? maxCount);

        #region Record Count Sql
        public string SelectCountSql(string tableName, FilterParam whereParam)
        {
            return string.Format(_SelectCountString, GetTableName(tableName), GenFilterSql(whereParam));
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

        protected abstract string GetCondition(SqlParam para,bool isWhere);
        protected string GenerateFieldSql(UpdateParam listParam)
        {
            if (listParam != null && listParam.Count > 0)
            {
                StringBuilder sbUpdate = new StringBuilder();
                foreach (SqlParam para in listParam)
                {
                    sbUpdate.Append(GetCondition(para,false));
                }
                return sbUpdate.ToString().TrimEnd(',');
            }
            else
                return string.Empty;
        }
        protected abstract string GenFilterSql(FilterParam listParam,bool isPage);
        protected string GenFilterSql(FilterParam listParam)
        {
            return GenFilterSql(listParam, false);
        }
        protected string GenerateOrderByField(OrderParam o)
        {
            return string.Format("{0} {1},", o.FieldName, o.OrderBy.ToSqlString());
        }
        protected string GenerateSelectFieldsSql(DisplayFields fields)
        {
            return GenerateSelectFieldsSql(fields, false);
        }
        protected string GenerateSelectFieldsSql(DisplayFields fields, bool isPage)
        {
            if (fields != null && fields.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Enum s in fields)
                {
                    sb.Append(s.ToString()).Append(',');
                }
                return sb.ToString().TrimEnd(',');
            }
            if (!isPage)
                return "*";
            else
                return "";
        }
        protected string GenerateOrderByFieldsSql(SortFields orders)
        {
            return GenerateOrderByFieldsSql(orders, false);
        }
        protected string GenerateOrderByFieldsSql(SortFields orders, bool isPage)
        {
            if (orders != null)
            {
                StringBuilder sb = new StringBuilder();
                if (!isPage)
                    sb.Append("ORDER BY ");
                foreach (OrderParam o in orders)
                {
                    sb.Append(GenerateOrderByField(o));
                }
                return sb.ToString().TrimEnd(',');
            }
            else
                return string.Empty;
        }
        #endregion
    }
}
