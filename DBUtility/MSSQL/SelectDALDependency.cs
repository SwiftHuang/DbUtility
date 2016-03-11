using hwj.DBUtility.Interface;
using hwj.DBUtility.TableMapping;
using System;
using System.Collections.Generic;
using System.Data;

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

        #region Property

        protected string CommandText { get; set; }

        #endregion Property

        /// <summary>
        ///
        /// </summary>
        /// <param name="connectionString">数据连接字符串</param>
        protected internal SelectDALDependency(string connectionString)
            : this(connectionString, 30, Enums.LockType.None)
        { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="connectionString">数据连接字符串</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <param name="lockType">锁类型</param>
        protected internal SelectDALDependency(string connectionString, int timeout, Enums.LockType lockType)
            : base(connectionString, timeout, lockType)
        { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="connection"></param>
        protected SelectDALDependency(IConnection connection)
            : base(connection)
        {
            CommandText = Activator.CreateInstance<T>().GetCommandText();
        }

        #region Get Entity

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        public T GetEntity(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, Enums.LockType lockType)
        {
            return GetEntity(displayFields, filterParams, sortParams, new List<Enums.LockType>() { lockType });
        }

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <returns></returns>
        public override T GetEntity(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, List<Enums.LockType> lockTypes)
        {
            SqlEntity sqlEty = new SqlEntity();
            sqlEty.CommandTimeout = InnerConnection.DefaultCommandTimeout;
            sqlEty.LockType = lockTypes;
            sqlEty.CommandText = GenSelectSql.SelectSql(string.Format(GenerateSelectSql<T>._ViewSqlFormat, CommandText), displayFields, filterParams, sortParams, 1, lockTypes);
            sqlEty.Parameters = GenSelectSql.GenParameter(filterParams);

            return base.GetEntity(sqlEty);
        }

        #endregion Get Entity

        #region GetList

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="maxCount">返回最大记录数</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        public TS GetList(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, Enums.LockType lockType)
        {
            return GetList(displayFields, filterParams, sortParams, maxCount, new List<Enums.LockType>() { lockType });
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="maxCount">返回最大记录数</param>
        /// <param name="lockTypes">锁类型</param>
        /// <returns></returns>
        public override TS GetList(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, List<Enums.LockType> lockTypes)
        {
            SqlEntity sqlEty = new SqlEntity();
            sqlEty.CommandTimeout = InnerConnection.DefaultCommandTimeout;
            sqlEty.LockType = lockTypes;
            sqlEty.CommandText = GenSelectSql.SelectSql(string.Format(GenerateSelectSql<T>._ViewSqlFormat, CommandText), displayFields, filterParams, sortParams, maxCount, lockTypes);
            sqlEty.Parameters = GenSelectSql.GenParameter(filterParams);

            return base.GetList(sqlEty);
        }

        #endregion GetList

        #region DataTable

        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <param name="lockTypes">锁类型</param>
        /// <returns></returns>
        public override DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, string tableName, Enums.LockType lockType)
        {
            return GetDataTable(displayFields, filterParams, sortParams, maxCount, tableName, new List<Enums.LockType>() { lockType });
        }

        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <param name="lockTypes">锁类型</param>
        /// <returns></returns>
        public override DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, string tableName, List<Enums.LockType> lockTypes)
        {
            SqlEntity sqlEty = new SqlEntity();
            sqlEty.CommandTimeout = InnerConnection.DefaultCommandTimeout;
            sqlEty.LockType = base.InnerConnection.SelectLock;
            sqlEty.CommandText = GenSelectSql.SelectSql(string.Format(GenerateSelectSql<T>._ViewSqlFormat, CommandText), displayFields, filterParams, sortParams, maxCount, lockTypes);
            sqlEty.Parameters = GenSelectSql.GenParameter(filterParams);

            return base.GetDataTable(sqlEty, tableName);
        }

        #endregion DataTable

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