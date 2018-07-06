using hwj.DBUtility.MSSQL.Interface;
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
    public abstract class BaseDataAccess<T, TS>
        where T : BaseSqlTable<T>, new()
        where TS : List<T>, new()
    {
        //private const string Msg_InvalidConnection = "Invalid Connection!";

        #region Property

        private string _connectionString = string.Empty;

        public string ConnectionString
        {
            get { return _connectionString; }
            set
            {
                //if (string.IsNullOrEmpty(value))
                //    throw new Exception("数据连接字符不能为空");
                //else
                _connectionString = value;
            }
        }

        protected SqlEntity _SqlEntity = null;

        /// <summary>
        /// 显示执行的Sql实体
        /// </summary>
        public SqlEntity SqlEntity
        {
            get { return _SqlEntity; }
        }

        public IMSSQLConnection InnerConnection { get; set; }

        #endregion Property

        #region CTOR

        /// <summary>
        ///
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="timeout"></param>
        /// <param name="lockType"></param>
        protected BaseDataAccess(string connectionString, int timeout, Enums.LockType lockType)
            : this(new DbConnection(connectionString, timeout, lockType, false, true))
        { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="lockType"></param>
        protected BaseDataAccess(IMSSQLConnection connection)
        {
            ConnectionString = connection.ConnectionString;
            InnerConnection = connection;
        }

        #endregion CTOR

        #region Execute

        #region ExecuteSqlTran

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="list">多条SQL语句</param>
        /// <returns></returns>
        public bool ExecuteSqlTran(SqlList list)
        {
            return ExecuteSqlTran(list, InnerConnection.DefaultCommandTimeout);
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="list">多条SQL语句</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public bool ExecuteSqlTran(SqlList list, int timeout)
        {
            return DbHelperSQL.ExecuteSqlTran(ConnectionString, list, timeout) > 0;
        }

        #endregion ExecuteSqlTran

        #region ExecuteSql

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteSql(string sql)
        {
            return ExecuteSql(sql, null, InnerConnection.DefaultCommandTimeout);
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteSql(string sql, List<IDbDataParameter> parameters)
        {
            return ExecuteSql(sql, parameters, InnerConnection.DefaultCommandTimeout);
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public int ExecuteSql(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            //if (IsUseTrans())
            //{
            return InnerConnection.ExecuteSql(sql, parameters, timeout);
            //}
            //else
            //{
            //    return DbHelper.ExecuteSql(ConnectionString, sql, parameters, timeout);
            //}
            //throw new Exception(Msg_InvalidConnection);
        }

        /// <summary>
        /// 执行多条SQL语句，返回影响的记录数(方法内部不自动开启事务)
        /// </summary>
        /// <param name="sqlList"></param>
        /// <returns></returns>
        public int ExecuteSqlList(SqlList sqlList)
        {
            int cnt = 0;
            foreach (var sql in sqlList)
            {
                cnt = InnerConnection.ExecuteSql(sql) + cnt;
            }
            return cnt;
        }

        #endregion ExecuteSql

        #region ExecuteReader

        /// <summary>
        /// 执行SQL语句，返回SqlDataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, null, InnerConnection.DefaultCommandTimeout);
        }

        /// <summary>
        /// 执行SQL语句，返回SqlDataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string sql, List<IDbDataParameter> parameters)
        {
            return ExecuteReader(sql, parameters, InnerConnection.DefaultCommandTimeout);
        }

        /// <summary>
        /// 执行SQL语句，返回SqlDataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            //if (IsUseTrans())
            //{
            return InnerConnection.ExecuteReader(sql, parameters, timeout);
            //}
            //else
            //{
            //    return DbHelperSQL.ExecuteReader(ConnectionString, sql, parameters, timeout);
            //}
        }

        #endregion ExecuteReader

        #region ExecuteScalar

        /// <summary>
        /// 执行SQL语句，返回Object
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, null, InnerConnection.DefaultCommandTimeout);
        }

        /// <summary>
        /// 执行SQL语句，返回Object
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, List<IDbDataParameter> parameters)
        {
            return ExecuteScalar(sql, parameters, InnerConnection.DefaultCommandTimeout);
        }

        /// <summary>
        /// 执行SQL语句，返回Object
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            //if (IsUseTrans())
            //{
            return InnerConnection.ExecuteScalar(sql, parameters, timeout);
            //}
            //else
            //{
            //    return DbHelperSQL.GetSingle(ConnectionString, sql, parameters, timeout);
            //}
        }

        #endregion ExecuteScalar

        #region Stored Procedure

        /// <summary>
        /// 执行存储过程,返回Output参数的值。
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public Dictionary<string, object> ExecuteStoredProcedure(string sql, List<IDbDataParameter> parameters)
        {
            return ExecuteStoredProcedure(sql, parameters, InnerConnection.DefaultCommandTimeout);
        }

        /// <summary>
        /// 执行存储过程,返回Output参数的值。
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public Dictionary<string, object> ExecuteStoredProcedure(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            //if (IsUseTrans())
            //{
            return InnerConnection.ExecuteStoredProcedure(sql, parameters, timeout);
            //}
            //else
            //{
            //    return DbHelperSQL.GetSingle(ConnectionString, sql, parameters, timeout);
            //}
        }

        /// <summary>
        /// 执行存储过程,并返回DataTable。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable ExecuteStoredProcedureForDataTable(string sql, List<IDbDataParameter> parameters)
        {
            return ExecuteStoredProcedureForDataTable(sql, parameters, InnerConnection.DefaultCommandTimeout);
        }

        /// <summary>
        /// 执行存储过程,并返回DataTable。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public DataTable ExecuteStoredProcedureForDataTable(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            return InnerConnection.ExecuteStoredProcedureForDataTable(sql, parameters, timeout);
        }

        #endregion Stored Procedure

        #endregion Execute

        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        /// <returns></returns>
        abstract public DateTime GetServerDateTime();

        #region Get Entity

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="sqlEntity">SQL实体</param>
        /// <returns></returns>
        public T GetEntity(SqlEntity sqlEntity)
        {
            _SqlEntity = sqlEntity;
            return GetEntity(sqlEntity.CommandText, sqlEntity.Parameters, sqlEntity.CommandTimeout);
        }

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="filterParams">条件参数</param>
        /// <returns></returns>
        public T GetEntity(FilterParams filterParams)
        {
            return GetEntity(null, filterParams, null, InnerConnection.SelectLock);
        }

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="filterParams">条件参数</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        public T GetEntity(FilterParams filterParams, Enums.LockType lockType)
        {
            return GetEntity(null, filterParams, null, new List<Enums.LockType>() { lockType });
        }

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="filterParams">条件参数</param>
        /// <param name="lockTypes">锁类型</param>
        /// <returns></returns>
        public T GetEntity(FilterParams filterParams, List<Enums.LockType> lockTypes)
        {
            return GetEntity(null, filterParams, null, lockTypes);
        }

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <returns></returns>
        public T GetEntity(DisplayFields displayFields, FilterParams filterParams)
        {
            return GetEntity(displayFields, filterParams, null, InnerConnection.SelectLock);
        }

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        public T GetEntity(DisplayFields displayFields, FilterParams filterParams, Enums.LockType lockType)
        {
            return GetEntity(displayFields, filterParams, null, new List<Enums.LockType>() { lockType });
        }

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="lockTypes">锁类型</param>
        /// <returns></returns>
        public T GetEntity(DisplayFields displayFields, FilterParams filterParams, List<Enums.LockType> lockTypes)
        {
            return GetEntity(displayFields, filterParams, null, lockTypes);
        }

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <returns></returns>
        public T GetEntity(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams)
        {
            return GetEntity(displayFields, filterParams, sortParams, InnerConnection.SelectLock);
        }

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="lockTypes">锁类型</param>
        /// <returns></returns>
        abstract public T GetEntity(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, List<Enums.LockType> lockTypes);

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public T GetEntity(string sql, List<IDbDataParameter> parameters)
        {
            return GetEntity(sql, parameters, InnerConnection.DefaultCommandTimeout);
        }

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public T GetEntity(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            //if (IsUseTrans())
            //{
            return InnerConnection.GetEntity<T>(sql, parameters, timeout);
            //}
            //else
            //{
            //    IDataReader reader = ExecuteReader(sql, parameters, timeout);
            //    try
            //    {
            //        if (reader.Read())
            //            return GenerateEntity.CreateSingleEntity<T>(reader);
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
            //throw new Exception(Msg_InvalidConnection);
        }

        #endregion Get Entity

        #region Get List

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <returns></returns>
        public TS GetList()
        {
            return GetList(null, null, null, null, null);
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="sqlEntity">SQL实体</param>
        /// <returns></returns>
        public TS GetList(SqlEntity sqlEntity)
        {
            _SqlEntity = sqlEntity;
            return GetList(sqlEntity.CommandText, sqlEntity.Parameters, InnerConnection.DefaultCommandTimeout);
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <returns></returns>
        public TS GetList(DisplayFields displayFields)
        {
            return GetList(displayFields, null, null, null, InnerConnection.SelectLock);
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        public TS GetList(DisplayFields displayFields, Enums.LockType lockType)
        {
            return GetList(displayFields, new List<Enums.LockType>() { lockType });
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="lockTypes">锁类型</param>
        /// <returns></returns>
        public TS GetList(DisplayFields displayFields, List<Enums.LockType> lockTypes)
        {
            return GetList(displayFields, null, null, null, lockTypes);
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <returns></returns>
        public TS GetList(DisplayFields displayFields, FilterParams filterParams)
        {
            return GetList(displayFields, filterParams, null, null, InnerConnection.SelectLock);
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        public TS GetList(DisplayFields displayFields, FilterParams filterParams, Enums.LockType lockType)
        {
            return GetList(displayFields, filterParams, new List<Enums.LockType>() { lockType });
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="lockTypes">锁类型</param>
        /// <returns></returns>
        public TS GetList(DisplayFields displayFields, FilterParams filterParams, List<Enums.LockType> lockTypes)
        {
            return GetList(displayFields, filterParams, null, null, lockTypes);
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <returns></returns>
        public TS GetList(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams)
        {
            return GetList(displayFields, filterParams, sortParams, null, InnerConnection.SelectLock);
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        public TS GetList(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, Enums.LockType lockType)
        {
            return GetList(displayFields, filterParams, sortParams, new List<Enums.LockType>() { lockType });
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="lockTypes">锁类型</param>
        /// <returns></returns>
        public TS GetList(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, List<Enums.LockType> lockTypes)
        {
            return GetList(displayFields, filterParams, sortParams, null, lockTypes);
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <returns></returns>
        public TS GetList(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount)
        {
            return GetList(displayFields, filterParams, sortParams, maxCount, InnerConnection.SelectLock);
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        abstract public TS GetList(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, List<Enums.LockType> lockTypes);

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public TS GetList(string sql, List<IDbDataParameter> parameters)
        {
            return GetList(sql, parameters, InnerConnection.DefaultCommandTimeout);
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public TS GetList(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            //if (IsUseTrans())
            //{
            return InnerConnection.GetList<T, TS>(sql, parameters, timeout);
            //}
            //else
            //{
            //    IDataReader reader = ExecuteReader(sql, parameters, timeout);
            //    try
            //    {
            //        return GenerateEntity.CreateListEntity<T, TS>(reader);
            //    }
            //    catch
            //    { throw; }
            //    finally
            //    {
            //        if (!reader.IsClosed)
            //            reader.Close();
            //    }
            //}
            //throw new Exception(Msg_InvalidConnection);
        }

        #endregion Get List

        #region DataTable

        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            return GetDataTable(null, null, null, null);
        }

        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="sqlEntity">SQL实体</param>
        /// <param name="tableName">Data Table Name</param>
        /// <returns></returns>
        public DataTable GetDataTable(SqlEntity sqlEntity, string tableName)
        {
            _SqlEntity = sqlEntity;
            return GetDataTable(sqlEntity.CommandText, sqlEntity.Parameters, tableName);
        }

        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <returns></returns>
        public DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount)
        {
            return GetDataTable(displayFields, filterParams, sortParams, maxCount, string.Empty);
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
        public DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, string tableName)
        {
            return GetDataTable(displayFields, filterParams, sortParams, maxCount, tableName, InnerConnection.SelectLock);
        }

        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        abstract public DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, string tableName, Enums.LockType lockType);

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
        abstract public DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, string tableName, List<Enums.LockType> lockTypes);

        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, List<IDbDataParameter> parameters)
        {
            return GetDataTable(sql, parameters, string.Empty);
        }

        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, List<IDbDataParameter> parameters, string tableName)
        {
            return GetDataTable(sql, parameters, tableName, InnerConnection.DefaultCommandTimeout);
        }

        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, List<IDbDataParameter> parameters, string tableName, int timeout)
        {
            return GenerateEntity.CreateDataTable(ExecuteReader(sql, parameters, timeout), tableName);
        }

        #endregion DataTable

        //private Enums.LockType GetLockType(Enums.LockModule module, Enums.LockType lockType)
        //{
        //    if (IsUseTrans())
        //    {
        //        switch (module)
        //        {
        //            case Enums.LockModule.Select:
        //                return InnerConnection.SelectLock;
        //            case Enums.LockModule.Update:
        //                return InnerConnection.UpdateLock;
        //            default:
        //                return InnerConnection.SelectLock;
        //        }
        //    }
        //    else
        //    {
        //        return lockType;
        //    }
        //}
        //private bool IsUseTrans()
        //{
        //    if (InnerConnection.InnerTransaction != null && InnerConnection.InnerTransaction.Connection != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}