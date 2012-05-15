using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility.MSSQL
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TS"></typeparam>
    public abstract class SelectDALDependency<T, TS> : BaseDataAccess<T, TS>
        where T : BaseSqlTable<T>, new()
        where TS : List<T>, new()
    {
        protected static GenerateSelectSql<T> GenSelectSql = new GenerateSelectSql<T>();
        private const string SqlFormat = "({0}) AS TEMPHWJ";

        #region Property
        protected string CommandText { get; set; }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString">数据连接字符串</param>
        protected SelectDALDependency(string ConnectionString)
            : base(ConnectionString)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">数据连接字符串</param>
        /// <param name="timeout">超时时间(秒)</param>
        protected SelectDALDependency(string connectionString, int timeout)
            : base(connectionString, timeout)
        { }

        #region Get Entity
        ///// <summary>
        ///// 获取表对象
        ///// </summary>
        ///// <returns></returns>
        //protected T GetEntity()
        //{
        //    return GetEntity(null);
        //}

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <returns></returns>
        public override T GetEntity(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            SqlEntity tmpSqlEty = new SqlEntity(GenSelectSql.SelectSql(string.Format(SqlFormat, CommandText), displayFields, filterParam, sortParams, 1), GenSelectSql.GenParameter(filterParam));
            //_SqlEntity = tmpSqlEty;
            return base.GetEntity(tmpSqlEty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="displayFields"></param>
        /// <param name="filterParam"></param>
        /// <param name="sortParams"></param>
        /// <returns></returns>
        public override T GetEntityByTransaction(DBTransaction trans, DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            SqlEntity tmpSqlEty = new SqlEntity(GenSelectSql.SelectSql(string.Format(SqlFormat, CommandText), displayFields, filterParam, sortParams, 1, false), GenSelectSql.GenParameter(filterParam));
            //_SqlEntity = tmpSqlEty;
            return base.GetEntityByTransaction(trans, tmpSqlEty);
        }

        #endregion

        #region GetList
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="maxCount">返回最大记录数</param>
        /// <returns></returns>
        public override TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            SqlEntity tmpSqlEty = new SqlEntity(GenSelectSql.SelectSql(string.Format(SqlFormat, CommandText), displayFields, filterParam, sortParams, maxCount, false), GenSelectSql.GenParameter(filterParam));
            //_SqlEntity = tmpSqlEty;
            return base.GetList(tmpSqlEty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="displayFields"></param>
        /// <param name="filterParam"></param>
        /// <param name="sortParams"></param>
        /// <param name="maxCount"></param>
        /// <returns></returns>
        public override TS GetListByTransaction(DBTransaction trans, DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            SqlEntity tmpSqlEty = new SqlEntity(GenSelectSql.SelectSql(string.Format(SqlFormat, CommandText), displayFields, filterParam, sortParams, maxCount, false), GenSelectSql.GenParameter(filterParam));
            //_SqlEntity = tmpSqlEty;
            return base.GetListByTransaction(trans, tmpSqlEty);
        }
        #endregion

        #region DataTable
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <returns></returns>
        public override DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount, string tableName)
        {
            SqlEntity tmpSqlEty = new SqlEntity(GenSelectSql.SelectSql(string.Format(SqlFormat, CommandText), displayFields, filterParam, sortParams, maxCount, false), GenSelectSql.GenParameter(filterParam));
            return base.GetDataTable(tmpSqlEty, tableName);
        }
        /// <summary>
        /// 通过事务，返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <returns></returns>
        public override DataTable GetDataTableByTransaction(DBTransaction trans, DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount, string tableName)
        {
            SqlEntity tmpSqlEty = new SqlEntity(GenSelectSql.SelectSql(string.Format(SqlFormat, CommandText), displayFields, filterParam, sortParams, maxCount, false), GenSelectSql.GenParameter(filterParam));
            return base.GetDataTableByTransaction(trans, tmpSqlEty, tableName);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DateTime GetServerDateTime()
        {
            DateTime tmpDateTime = DateTime.MinValue;
            object tmp = ExecuteScalar(GenSelectSql.SelectServerDateTime());

            if (tmp != null)
                DateTime.TryParse(tmp.ToString(), out tmpDateTime);
            return tmpDateTime;
        }

        
    }
}
