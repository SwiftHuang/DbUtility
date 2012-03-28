using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility.MSSQL
{
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
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <returns></returns>
        protected T GetEntity()
        {
            return GetEntity(null);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="filterParam">查询条件</param>
        /// <returns></returns>
        protected T GetEntity(FilterParams filterParam)
        {
            return GetEntity(null, filterParam, null);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <returns></returns>
        protected T GetEntity(DisplayFields displayFields, FilterParams filterParam)
        {
            return GetEntity(displayFields, filterParam, null);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <returns></returns>
        protected T GetEntity(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            SqlEntity tmpSqlEty = new SqlEntity(GenSelectSql.SelectSql(string.Format(SqlFormat, CommandText), displayFields, filterParam, sortParams, 1), GenSelectSql.GenParameter(filterParam));
            _SqlEntity = tmpSqlEty;
            return base.GetEntity(tmpSqlEty.CommandText, tmpSqlEty.Parameters);
        }
        //protected T GetEntity(string sql, List<SqlParameter> parameters)
        //{
        //    SqlDataReader reader = DbHelper.ExecuteReader(ConnectionString, sql, parameters);
        //    try
        //    {
        //        if (reader.HasRows)
        //            return GenerateEntity<T, TS>.CreateSingleEntity(reader);
        //        else
        //            return null;
        //    }
        //    catch
        //    { throw; }
        //    finally
        //    {
        //        if (!reader.IsClosed)
        //            reader.Close();
        //    }
        //}
        #endregion

        #region GetList
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <returns></returns>
        protected TS GetList()
        {
            return GetList(null, null, null, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <returns></returns>
        protected TS GetList(DisplayFields displayFields)
        {
            return GetList(displayFields, null, null, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <returns></returns>
        protected TS GetList(DisplayFields displayFields, FilterParams filterParam)
        {
            return GetList(displayFields, filterParam, null, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <returns></returns>
        protected TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            return GetList(displayFields, filterParam, sortParams, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="maxCount">返回最大记录数</param>
        /// <returns></returns>
        protected TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            SqlEntity tmpSqlEty = new SqlEntity(GenSelectSql.SelectSql(string.Format(SqlFormat, CommandText), displayFields, filterParam, sortParams, maxCount, false), GenSelectSql.GenParameter(filterParam));
            _SqlEntity = tmpSqlEty;
            return base.GetList(tmpSqlEty.CommandText, tmpSqlEty.Parameters);
        }
        #endregion
    }
}
