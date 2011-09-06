using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility
{
    public abstract class BaseGenSelectSql<T> : BaseGenSql<T> where T : class, new()
    {
        protected const string _SelectCountString = "SELECT COUNT(1) FROM {0} (NOLOCK) {1};";

        #region Public Functions
        public abstract string SelectSql(string tableName, DisplayFields displayFields, FilterParams filterParam, SortParams orderParam, int? maxCount);

        #region Record Count Sql
        public string SelectCountSql(string tableName, FilterParams filterParam)
        {
            return string.Format(_SelectCountString, tableName, GenFilterParamsSql(filterParam));
        }
        #endregion

        #endregion

       
    }
}
