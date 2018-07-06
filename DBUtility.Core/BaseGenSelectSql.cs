namespace hwj.DBUtility
{
    public abstract class BaseGenSelectSql<T> : BaseGenSql<T> where T : class, new()
    {
        protected const string _SelectCountString = "SELECT COUNT(1) FROM {0} (NOLOCK) {1};";

        #region Public Functions

        /// <summary>
        ///
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="displayFields"></param>
        /// <param name="filterParams"></param>
        /// <param name="orderParam"></param>
        /// <param name="maxCount"></param>
        /// <returns></returns>
        public abstract string SelectSql(string tableName, DisplayFields displayFields, FilterParams filterParams, SortParams orderParam, int? maxCount);

        #region Record Count Sql

        public string SelectCountSql(string tableName, FilterParams filterParams)
        {
            return string.Format(_SelectCountString, tableName, GenFilterParamsSql(filterParams));
        }

        #endregion Record Count Sql

        #endregion Public Functions
    }
}