using System;
using System.Collections.Generic;
using System.Text;
using hwj.DBUtility.TableMapping;
using System.Data.SqlClient;

namespace hwj.DBUtility.MSSQL
{
    public abstract class BaseSqlDAL<T, TS> : SelectDALDependency<T, TS>
        where T : BaseSqlTable<T>, new()
        where TS : List<T>, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">数据连接字符串</param>
        protected BaseSqlDAL(string connectionString)
            : base(connectionString)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">数据连接字符串</param>
        /// <param name="timeout">超时时间(秒)</param>
        protected BaseSqlDAL(string connectionString, int timeout)
            : base(connectionString, timeout)
        {
        }

        #region Get Entity
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <returns></returns>
        public new T GetEntity()
        {
            return base.GetEntity();
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="filterParam">查询条件</param>
        /// <returns></returns>
        public new T GetEntity(FilterParams filterParam)
        {
            return base.GetEntity(filterParam);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <returns></returns>
        public new T GetEntity(DisplayFields displayFields, FilterParams filterParam)
        {
            return base.GetEntity(displayFields, filterParam);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <returns></returns>
        public new T GetEntity(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            return base.GetEntity(displayFields, filterParam, sortParams);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">条件参数</param>
        /// <returns></returns>
        public new T GetEntity(string sql, List<SqlParameter> parameters)
        {
            return base.GetEntity(sql, parameters);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">条件参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public new T GetEntity(string sql, List<SqlParameter> parameters, int timeout)
        {
            return base.GetEntity(sql, parameters, timeout);
        }
        #endregion

        #region GetList
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <returns></returns>
        public new TS GetList()
        {
            return base.GetList();
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <returns></returns>
        public new TS GetList(DisplayFields displayFields)
        {
            return base.GetList(displayFields);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <returns></returns>
        public new TS GetList(DisplayFields displayFields, FilterParams filterParam)
        {
            return base.GetList(displayFields, filterParam);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <returns></returns>
        public new TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            return base.GetList(displayFields, filterParam, sortParams);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="maxCount">返回最大记录数</param>
        /// <returns></returns>
        public new TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            return base.GetList(displayFields, filterParam, sortParams, maxCount);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">条件参数</param>
        /// <returns></returns>
        public new TS GetList(string sql, List<SqlParameter> parameters)
        {
            return base.GetList(sql, parameters);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">条件参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public new TS GetList(string sql, List<SqlParameter> parameters, int timeout)
        {
            return base.GetList(sql, parameters, timeout);
        }
        #endregion
    }
}
