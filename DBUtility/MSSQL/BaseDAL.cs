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
    public class BaseDAL<T, TS> : DALDependency<T, TS>
        where T : BaseTable<T>, new()
        where TS : List<T>, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        protected BaseDAL(string ConnectionString)
            : this(ConnectionString, 120, Enums.LockType.NoLock)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="timeout"></param>
        /// <param name="lockType"></param>
        protected BaseDAL(string connectionString, int timeout, Enums.LockType lockType)
            : base(connectionString, timeout, lockType)
        { }

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

        #region Insert
        /// <summary>
        /// 执行插入数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public new bool Add(T entity)
        {
            return base.Add(entity);
        }
        /// <summary>
        /// 执行插入数据,并返回标识值
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public new decimal AddReturnIdentity(T entity)
        {
            return base.AddReturnIdentity(entity);
        }
        /// <summary>
        /// 获取最后一次自增ID
        /// </summary>
        /// <returns></returns>
        public new Int64 GetInsertID()
        {
            return base.GetInsertID();
        }
        #endregion

        #region Update
        /// <summary>
        /// 执行数据更新
        /// </summary>
        /// <param name="param">更新字段</param>
        /// <returns></returns>
        public new bool Update(UpdateParam param)
        {
            return base.Update(param);
        }
        /// <summary>
        /// 执行数据更新
        /// </summary>
        /// <param name="updateParam">更新字段</param>
        /// <param name="filterParams">更新条件</param>
        /// <returns></returns>
        public new bool Update(UpdateParam updateParam, FilterParams filterParams)
        {
            return base.Update(updateParam, filterParams);
        }
        /// <summary>
        /// 执行数据更新
        /// </summary>
        /// <param name="entity">更新实体</param>
        /// <param name="filterParams">更新条件</param>
        /// <returns></returns>
        public new bool Update(T entity, FilterParams filterParams)
        {
            return base.Update(entity, filterParams);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除全部记录
        /// </summary>
        /// <returns></returns>
        public new bool Delete()
        {
            return base.Delete();
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="filterParams">删除条件</param>
        /// <returns></returns>
        public new bool Delete(FilterParams filterParams)
        {
            return base.Delete(filterParams);
        }

        /// <summary>
        /// 彻底清除表的内容(重置自动增量),请慎用
        /// </summary>
        /// <returns></returns>
        public new bool Truncate()
        {
            return base.Truncate();
        }
        #endregion

        #region Get Page
        /// <summary>
        /// 获取分页对象(单主键,以主键作为排序,支持分组)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParams">筛选条件</param>
        /// <param name="sortParams">排序(只能填一个字段)</param>
        /// <param name="PK">分页依据</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        public new TS GetPage3(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, DisplayFields PK, int pageNumber, int pageSize, out int TotalCount)
        {
            return base.GetPage3(displayFields, filterParams, sortParams, PK, pageNumber, pageSize, out TotalCount);
        }
        /// <summary>
        /// 获取分页对象(单主键,以主键作为排序,支持分组)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParams">筛选条件</param>
        /// <param name="sortParams">排序(只能填一个字段)</param>
        /// <param name="groupParams">分组条件</param>
        /// <param name="PK">分页依据</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        public new TS GetPage3(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, GroupParams groupParams, DisplayFields PK, int pageNumber, int pageSize, out int TotalCount)
        {
            return base.GetPage3(displayFields, filterParams, sortParams, groupParams, PK, pageNumber, pageSize, out TotalCount);
        }
        /// <summary>
        /// 获取分页对象(单主键,以主键作为排序,支持分组)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParams">筛选条件</param>
        /// <param name="sortParams">排序(只能填一个字段)</param>
        /// <param name="groupParams">分组条件</param>
        /// <param name="PK">分页依据</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="times">超时时间(秒)</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        public new TS GetPage3(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, GroupParams groupParams, DisplayFields PK, int pageNumber, int pageSize, int times, out int TotalCount)
        {
            return base.GetPage3(displayFields, filterParams, sortParams, groupParams, PK, pageNumber, pageSize, times, out TotalCount);
        }

        /// <summary>
        /// 获取分页对象(支持多主键、多排序)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParams">筛选条件</param>
        /// <param name="sortParams">排序</param>
        /// <param name="PK">主键</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        public new TS GetPage(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, DisplayFields PK, int pageNumber, int pageSize, out int TotalCount)
        {
            return base.GetPage(displayFields, filterParams, sortParams, PK, pageNumber, pageSize, out TotalCount);
        }
        /// <summary>
        /// 获取分页对象(支持多主键、多排序)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParams">筛选条件</param>
        /// <param name="sortParams">排序</param>
        /// <param name="PK">主键</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        public new TS GetPage(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, DisplayFields PK, int pageNumber, int pageSize, int timeout, out int TotalCount)
        {
            return base.GetPage(displayFields, filterParams, sortParams, PK, pageNumber, pageSize, timeout, out TotalCount);
        }
        #endregion

        #region Record Count
        /// <summary>
        /// 返回表的记录数
        /// </summary>
        /// <returns></returns>
        public new int RecordCount()
        {
            return base.RecordCount();
        }
        /// <summary>
        /// 返回表的记录数
        /// </summary>
        /// <param name="filterParams">条件参数</param>
        /// <returns>记录数</returns>
        public new int RecordCount(FilterParams filterParams)
        {
            return base.RecordCount(filterParams);
        }
        /// <summary>
        /// 返回表的记录数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">条件参数</param>
        /// <returns></returns>
        public new int RecordCount(string sql, List<IDbDataParameter> parameters)
        {
            return base.RecordCount(sql, parameters);
        }
        #endregion

    }
}
