using System;
using System.Collections.Generic;
using System.Text;
using hwj.DBUtility.TableMapping;
using System.Data.SqlClient;
using System.Data;

namespace hwj.DBUtility.MSSQL
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TS"></typeparam>
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
        /// <param name="lockType">锁类型</param>
        protected BaseSqlDAL(string connectionString, int timeout, Enums.LockType lockType)
            : base(connectionString, timeout, lockType)
        {
        }

        #region Get Entity
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="filterParam">条件参数</param>
        /// <returns></returns>
        public new T GetEntity(FilterParams filterParam)
        {
            return this.GetEntity(null, filterParam, null);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <returns></returns>
        public new T GetEntity(DisplayFields displayFields, FilterParams filterParam)
        {
            return this.GetEntity(displayFields, filterParam, null);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <returns></returns>
        public new T GetEntity(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            return base.GetEntity(displayFields, filterParam, sortParams, Enums.LockType.NoLock);
        }
        #endregion

        #region Get List
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <returns></returns>
        public new TS GetList()
        {
            return this.GetList(null, null, null, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <returns></returns>
        public new TS GetList(DisplayFields displayFields)
        {
            return this.GetList(displayFields, null, null, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <returns></returns>
        public new TS GetList(DisplayFields displayFields, FilterParams filterParam)
        {
            return this.GetList(displayFields, filterParam, null, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <returns></returns>
        public new TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            return this.GetList(displayFields, filterParam, sortParams, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <returns></returns>
        public new TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            return base.GetList(displayFields, filterParam, sortParams, maxCount, Enums.LockType.NoLock);
        }
        #endregion

        #region DataTable
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <returns></returns>
        public new DataTable GetDataTable()
        {
            return this.GetDataTable(null, null, null, null, string.Empty);
        }
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <returns></returns>
        public new DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            return this.GetDataTable(displayFields, filterParam, sortParams, maxCount, string.Empty);
        }
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <returns></returns>
        public new DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount, string tableName)
        {
            return base.GetDataTable(displayFields, filterParam, sortParams, maxCount, tableName);
        }
        #endregion
    }
}
