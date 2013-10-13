using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using hwj.DBUtility.TableMapping;
using hwj.DBUtility.Interface;

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
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">数据连接字符串</param>
        internal protected SelectDALDependency(string connectionString)
            : this(connectionString, 30, Enums.LockType.None)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">数据连接字符串</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <param name="lockType">锁类型</param>
        internal protected SelectDALDependency(string connectionString, int timeout, Enums.LockType lockType)
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
        /// <param name="filterParam">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <returns></returns>
        public override T GetEntity(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, Enums.LockType lockType)
        {
            SqlEntity sqlEty = new SqlEntity();
            sqlEty.CommandTimeout = InnerConnection.DefaultCommandTimeout;
            sqlEty.LockType = lockType;
            sqlEty.CommandText = GenSelectSql.SelectSql(string.Format(GenerateSelectSql<T>._ViewSqlFormat, CommandText), displayFields, filterParam, sortParams, 1, lockType);
            sqlEty.Parameters = GenSelectSql.GenParameter(filterParam);

            return base.GetEntity(sqlEty);
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
        /// <param name="lockType">锁类型</param>    
        /// <returns></returns>
        public override TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount, Enums.LockType lockType)
        {
            SqlEntity sqlEty = new SqlEntity();
            sqlEty.CommandTimeout = InnerConnection.DefaultCommandTimeout;
            sqlEty.LockType = lockType;
            sqlEty.CommandText = GenSelectSql.SelectSql(string.Format(GenerateSelectSql<T>._ViewSqlFormat, CommandText), displayFields, filterParam, sortParams, maxCount, lockType);
            sqlEty.Parameters = GenSelectSql.GenParameter(filterParam);

            return base.GetList(sqlEty);
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
        public override DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount, string tableName, Enums.LockType lockType)
        {
            SqlEntity sqlEty = new SqlEntity();
            sqlEty.CommandTimeout = InnerConnection.DefaultCommandTimeout;
            sqlEty.LockType = base.InnerConnection.SelectLock;
            sqlEty.CommandText = GenSelectSql.SelectSql(string.Format(GenerateSelectSql<T>._ViewSqlFormat, CommandText), displayFields, filterParam, sortParams, maxCount, lockType);
            sqlEty.Parameters = GenSelectSql.GenParameter(filterParam);

            return base.GetDataTable(sqlEty, tableName);
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
