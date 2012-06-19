using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using hwj.DBUtility.TableMapping;
using System.Data;
using hwj.DBUtility.Interface;

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
        public IConnection InnerConnection { get; set; }
        #endregion

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
        protected BaseDataAccess(IConnection connection)
        {
            ConnectionString = connection.ConnectionString;
            InnerConnection = connection;
        }
        #endregion

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
        #endregion

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
        #endregion

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
        #endregion

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
        #endregion
        #endregion

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
        protected T GetEntity(SqlEntity sqlEntity)
        {
            _SqlEntity = sqlEntity;
            return GetEntity(sqlEntity.CommandText, sqlEntity.Parameters, sqlEntity.CommandTimeout);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="filterParam">条件参数</param>
        /// <returns></returns>
        protected T GetEntity(FilterParams filterParam)
        {
            return GetEntity(null, filterParam, null, InnerConnection.SelectLock);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="filterParam">条件参数</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        protected T GetEntity(FilterParams filterParam, Enums.LockType lockType)
        {
            return GetEntity(null, filterParam, null, lockType);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <returns></returns>
        protected T GetEntity(DisplayFields displayFields, FilterParams filterParam)
        {
            return GetEntity(displayFields, filterParam, null, InnerConnection.SelectLock);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        protected T GetEntity(DisplayFields displayFields, FilterParams filterParam, Enums.LockType lockType)
        {
            return GetEntity(displayFields, filterParam, null, lockType);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <returns></returns>
        protected T GetEntity(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            return GetEntity(displayFields, filterParam, sortParams, InnerConnection.SelectLock);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        abstract protected T GetEntity(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, Enums.LockType lockType);

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        protected T GetEntity(string sql, List<IDbDataParameter> parameters)
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
        protected T GetEntity(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            //if (IsUseTrans())
            //{
            return InnerConnection.GetEntity<T>(sql, parameters);
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
        #endregion

        #region Get List
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
        /// <param name="sqlEntity">SQL实体</param>
        /// <returns></returns>
        protected TS GetList(SqlEntity sqlEntity)
        {
            _SqlEntity = sqlEntity;
            return GetList(sqlEntity.CommandText, sqlEntity.Parameters, InnerConnection.DefaultCommandTimeout);
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <returns></returns>
        protected TS GetList(DisplayFields displayFields)
        {
            return GetList(displayFields, null, null, null, InnerConnection.SelectLock);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        protected TS GetList(DisplayFields displayFields, Enums.LockType lockType)
        {
            return GetList(displayFields, null, null, null, lockType);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <returns></returns>
        protected TS GetList(DisplayFields displayFields, FilterParams filterParam)
        {
            return GetList(displayFields, filterParam, null, null, InnerConnection.SelectLock);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        protected TS GetList(DisplayFields displayFields, FilterParams filterParam, Enums.LockType lockType)
        {
            return GetList(displayFields, filterParam, null, null, lockType);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <returns></returns>
        protected TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            return GetList(displayFields, filterParam, sortParams, null, InnerConnection.SelectLock);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        protected TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, Enums.LockType lockType)
        {
            return GetList(displayFields, filterParam, sortParams, null, lockType);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <returns></returns>
        protected TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            return GetList(displayFields, filterParam, sortParams, maxCount, InnerConnection.SelectLock);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        abstract protected TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount, Enums.LockType lockType);

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        protected TS GetList(string sql, List<IDbDataParameter> parameters)
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
        protected TS GetList(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            //if (IsUseTrans())
            //{
            return InnerConnection.GetList<T, TS>(sql, parameters);
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
        #endregion

        #region DataTable
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <returns></returns>
        protected DataTable GetDataTable()
        {
            return GetDataTable(null, null, null, null);
        }
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="sqlEntity">SQL实体</param>
        /// <param name="tableName">Data Table Name</param>
        /// <returns></returns>
        protected DataTable GetDataTable(SqlEntity sqlEntity, string tableName)
        {
            _SqlEntity = sqlEntity;
            return GetDataTable(sqlEntity.CommandText, sqlEntity.Parameters, tableName);
        }
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <returns></returns>
        protected DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            return GetDataTable(displayFields, filterParam, sortParams, maxCount, string.Empty);
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
        abstract protected DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount, string tableName);

        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        protected DataTable GetDataTable(string sql, List<IDbDataParameter> parameters)
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
        protected DataTable GetDataTable(string sql, List<IDbDataParameter> parameters, string tableName)
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
        protected DataTable GetDataTable(string sql, List<IDbDataParameter> parameters, string tableName, int timeout)
        {
            return GenerateEntity.CreateDataTable(ExecuteReader(sql, parameters, timeout), tableName);
        }
        #endregion

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
