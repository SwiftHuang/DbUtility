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
            : this(connectionString, 120, Enums.LockType.NoLock)
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
        /// <param name="filterParams">条件参数</param>
        /// <returns></returns>
        public new T GetEntity(FilterParams filterParams)
        {
            return this.GetEntity(null, filterParams, null);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <returns></returns>
        public new T GetEntity(DisplayFields displayFields, FilterParams filterParams)
        {
            return this.GetEntity(displayFields, filterParams, null);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <returns></returns>
        public new T GetEntity(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams)
        {
            return base.GetEntity(displayFields, filterParams, sortParams, Enums.LockType.NoLock);
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
        /// <param name="filterParams">条件参数</param>
        /// <returns></returns>
        public new TS GetList(DisplayFields displayFields, FilterParams filterParams)
        {
            return this.GetList(displayFields, filterParams, null, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <returns></returns>
        public new TS GetList(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams)
        {
            return this.GetList(displayFields, filterParams, sortParams, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <returns></returns>
        public new TS GetList(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount)
        {
            return base.GetList(displayFields, filterParams, sortParams, maxCount, Enums.LockType.NoLock);
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
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <returns></returns>
        public new DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount)
        {
            return this.GetDataTable(displayFields, filterParams, sortParams, maxCount, string.Empty);
        }
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <returns></returns>
        public new DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, string tableName)
        {
            return base.GetDataTable(displayFields, filterParams, sortParams, maxCount, tableName, Enums.LockType.NoLock);
        }
        #endregion
    }
}
