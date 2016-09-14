using hwj.DBUtility.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace hwj.DBUtility.MSSQL
{
    /// <summary>
    ///
    /// </summary>
    public class DbConnection : IConnection, IDisposable
    {
        #region Property

        private bool disposed = false;

        public string ConnectionString { get; private set; }

        /// <summary>
        /// 获取或设置在终止执行命令的尝试并生成错误之前的等待时间。
        /// </summary>
        public int DefaultCommandTimeout { get; private set; }

        public IDbTransaction InnerTransaction { get; private set; }

        public IDbConnection InnerConnection { get; private set; }

        //public Enums.LockType DefaultLock { get; set; }
        public List<Enums.LockType> SelectLock { get; set; }

        public List<Enums.LockType> UpdateLock { get; set; }

        public Enums.TransactionState TransactionState { get; set; }

        public bool LogSql { get; set; }

        public List<LogEntity> LogList { get; private set; }

        public bool AutoCloseConnection { get; private set; }

        #endregion Property

        #region CTOR

        /// <summary>
        /// 数据库连接实体(默认超时时间为30秒)
        /// </summary>
        /// <param name="connectionString"></param>
        public DbConnection(string connectionString)
            : this(connectionString, 30, Enums.LockType.None)
        { }

        /// <summary>
        /// 数据库连接实体(默认超时时间为30秒)
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="autoCloseConnection">每次调用重新创建新的连接，使用后自动关闭</param>
        public DbConnection(string connectionString, bool autoCloseConnection)
            : this(connectionString, 30, Enums.LockType.None, false, autoCloseConnection)
        { }

        /// <summary>
        /// 数据库连接实体
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="timeout">超时时间(单位:秒)</param>
        /// <param name="defaultSelectLock">默认锁的类型</param>
        public DbConnection(string connectionString, int timeout, Enums.LockType defaultSelectLock)
            : this(connectionString, timeout, defaultSelectLock, false)
        {
        }

        /// <summary>
        /// 数据库连接实体
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="timeout">超时时间(单位:秒)</param>
        /// <param name="defaultSelectLock">默认锁的类型</param>
        /// <param name="logSql">记录Sql</param>
        public DbConnection(string connectionString, int timeout, Enums.LockType defaultSelectLock, bool logSql)
            : this(connectionString, timeout, defaultSelectLock, logSql, false)
        {
        }

        /// <summary>
        /// 数据库连接实体
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="timeout">超时时间(单位:秒)</param>
        /// <param name="defaultSelectLock">默认锁的类型</param>
        /// <param name="logSql">记录Sql</param>
        /// <param name="autoCloseConnection">每次调用重新创建新的连接，使用后自动关闭</param>
        public DbConnection(string connectionString, int timeout, Enums.LockType defaultSelectLock, bool logSql, bool autoCloseConnection)
            : this(connectionString, timeout, new List<Enums.LockType>() { defaultSelectLock }, logSql, autoCloseConnection)
        {
        }

        /// <summary>
        /// 数据库连接实体
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="timeout">超时时间(单位:秒)</param>
        /// <param name="defaultSelectLocks">默认锁的类型</param>
        /// <param name="logSql">记录Sql</param>
        /// <param name="autoCloseConnection">每次调用重新创建新的连接，使用后自动关闭</param>
        public DbConnection(string connectionString, int timeout, List<Enums.LockType> defaultSelectLocks, bool logSql, bool autoCloseConnection)
        {
            ConnectionString = connectionString;
            DefaultCommandTimeout = timeout;
            InnerConnection = new SqlConnection(connectionString);
            if (InnerConnection.ConnectionTimeout > DefaultCommandTimeout)
            {
                DefaultCommandTimeout = InnerConnection.ConnectionTimeout;
            }

            SelectLock = defaultSelectLocks;// Enums.LockType.UpdLock;
            UpdateLock = new List<Enums.LockType>() { Enums.LockType.UpdLock };

            LogSql = logSql;
            if (logSql)
            {
                LogList = new List<LogEntity>();
            }

            AutoCloseConnection = autoCloseConnection;
        }

        //~DbConnection()
        //{
        //    Dispose(false);
        //}

        #endregion CTOR

        #region Public Execute Member

        #region ExecuteSqlList

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="sqlList">多条SQL语句</param>
        /// <returns></returns>
        public int ExecuteSqlList(SqlList sqlList)
        {
            if (AutoCloseConnection)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        return ExecuteSqlList(conn, tran, sqlList);
                    }
                }
            }
            else
            {
                return ExecuteSqlList(InnerConnection, InnerTransaction, sqlList);
            }
        }

        public int ExecuteSqlList(IDbConnection connection, IDbTransaction transaction, SqlList sqlList)
        {
            SqlCommand cmd = new SqlCommand();
            int index = 0;
            try
            {
                int count = 0;
                //循环
                foreach (SqlEntity myDE in sqlList)
                {
                    AddLog(myDE);
                    DbHelperSQL.PrepareCommand(cmd, connection, transaction, myDE);

                    int val = cmd.ExecuteNonQuery();
                    count += val;

                    cmd.Parameters.Clear();
                    index++;
                }

                return count;
            }
            catch (SqlException ex)
            {
                DbHelperSQL.CheckSqlException(ref ex, sqlList[index]);
                throw;
            }
        }

        #endregion ExecuteSqlList

        #region ExecuteSql

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sqlEntity"></param>
        /// <returns></returns>
        public int ExecuteSql(SqlEntity sqlEntity)
        {
            try
            {
                return ExecuteSql(sqlEntity.CommandText, sqlEntity.Parameters, sqlEntity.CommandTimeout);
            }
            catch (SqlException ex)
            {
                DbHelperSQL.CheckSqlException(ref ex, sqlEntity);
                throw;
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteSql(string sql, List<IDbDataParameter> parameters)
        {
            return ExecuteSql(sql, parameters, DefaultCommandTimeout);
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public int ExecuteSql(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            if (AutoCloseConnection)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    return ExecuteSql(conn, null, sql, parameters, timeout);
                }
            }
            else
            {
                return ExecuteSql(InnerConnection, InnerTransaction, sql, parameters, timeout);
            }
        }

        private int ExecuteSql(IDbConnection connection, IDbTransaction transaction, string sql, List<IDbDataParameter> parameters, int timeout)
        {
            AddLog(sql, parameters, timeout);
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    DbHelperSQL.PrepareCommand(cmd, connection, transaction, sql, parameters, timeout);

                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
            }
            catch (SqlException ex)
            {
                AddExData(ref ex, sql, parameters, timeout);
                throw;
                //string msg = FormatExMessage(ex.Message, sql, parameters, timeout);
                //throw new Exception(msg, ex);
            }
        }

        #endregion ExecuteSql

        #region ExecuteReader

        /// <summary>
        ///
        /// </summary>
        /// <param name="sqlEntity"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(SqlEntity sqlEntity)
        {
            return ExecuteReader(sqlEntity.CommandText, sqlEntity.Parameters, sqlEntity.CommandTimeout);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string sql, List<IDbDataParameter> parameters)
        {
            return ExecuteReader(sql, parameters, DefaultCommandTimeout);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            AddLog(sql, parameters, timeout);
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    DbHelperSQL.PrepareCommand(cmd, InnerConnection, InnerTransaction, sql, parameters, timeout);
                    SqlDataReader myReader;
                    if (AutoCloseConnection)
                    {
                        myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    }
                    else
                    {
                        myReader = cmd.ExecuteReader();
                    }

                    cmd.Parameters.Clear();
                    return myReader;
                }
            }
            catch (SqlException ex)
            {
                AddExData(ref ex, sql, parameters, timeout);
                throw;
                //string msg = FormatExMessage(ex.Message, sql, parameters, timeout);
                //throw new Exception(msg, ex);
            }
        }

        #endregion ExecuteReader

        #region ExecuteScalar

        /// <summary>
        ///
        /// </summary>
        /// <param name="sqlEntity"></param>
        /// <returns></returns>
        public object ExecuteScalar(SqlEntity sqlEntity)
        {
            return ExecuteScalar(sqlEntity.CommandText, sqlEntity.Parameters, sqlEntity.CommandTimeout);
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">条件语句</param>
        /// <returns>查询结果（object）</returns>
        public object ExecuteScalar(string sql, List<IDbDataParameter> parameters)
        {
            return ExecuteScalar(sql, parameters, DefaultCommandTimeout);
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">条件语句</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns>查询结果（object）</returns>
        public object ExecuteScalar(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            if (AutoCloseConnection)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    return ExecuteScalar(conn, null, sql, parameters, timeout);
                }
            }
            else
            {
                return ExecuteScalar(InnerConnection, InnerTransaction, sql, parameters, timeout);
            }
        }

        private object ExecuteScalar(IDbConnection connection, IDbTransaction transaction, string sql, List<IDbDataParameter> parameters, int timeout)
        {
            AddLog(sql, parameters, timeout);
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    DbHelperSQL.PrepareCommand(cmd, connection, transaction, sql, parameters, timeout);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
            }
            catch (SqlException ex)
            {
                AddExData(ref ex, sql, parameters, timeout);
                throw;
                //string msg = FormatExMessage(ex.Message, sql, parameters, timeout);
                //throw new Exception(msg, ex);
            }
        }

        #endregion ExecuteScalar

        #region Stored Procedure

        /// <summary>
        ///执行存储过程,返回Output参数的值。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Dictionary<string, object> ExecuteStoredProcedure(string sql, List<IDbDataParameter> parameters)
        {
            return ExecuteStoredProcedure(sql, parameters, DefaultCommandTimeout);
        }

        /// <summary>
        ///执行存储过程,返回Output参数的值。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public Dictionary<string, object> ExecuteStoredProcedure(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            if (AutoCloseConnection)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    return ExecuteStoredProcedure(conn, null, sql, parameters, timeout);
                }
            }
            else
            {
                return ExecuteStoredProcedure(InnerConnection, InnerTransaction, sql, parameters, timeout);
            }
        }

        private Dictionary<string, object> ExecuteStoredProcedure(IDbConnection connection, IDbTransaction transaction, string sql, List<IDbDataParameter> parameters, int timeout)
        {
            AddLog(sql, parameters, timeout);
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DbHelperSQL.PrepareCommand(cmd, connection, transaction, sql, parameters, timeout);
                    cmd.ExecuteNonQuery();

                    Dictionary<string, object> lst = new Dictionary<string, object>();
                    foreach (IDbDataParameter p in parameters)
                    {
                        if (p.Direction != ParameterDirection.Input)
                        {
                            lst.Add(p.ParameterName, cmd.Parameters[p.ParameterName].Value);
                        }
                    }
                    cmd.Parameters.Clear();
                    return lst;
                }
            }
            catch (SqlException ex)
            {
                AddExData(ref ex, sql, parameters, timeout);
                throw;
                //string msg = FormatExMessage(ex.Message, sql, parameters, timeout);
                //throw new Exception(msg, ex);
            }
        }

        /// <summary>
        ///执行存储过程,并返回DataTable。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable ExecuteStoredProcedureForDataTable(string sql, List<IDbDataParameter> parameters)
        {
            return ExecuteStoredProcedureForDataTable(sql, parameters, DefaultCommandTimeout);
        }

        /// <summary>
        ///执行存储过程,并返回DataTable。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public DataTable ExecuteStoredProcedureForDataTable(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            if (AutoCloseConnection)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    return ExecuteStoredProcedureForDataTable(conn, null, sql, parameters, timeout);
                }
            }
            else
            {
                return ExecuteStoredProcedureForDataTable(InnerConnection, InnerTransaction, sql, parameters, timeout);
            }
        }

        private DataTable ExecuteStoredProcedureForDataTable(IDbConnection connection, IDbTransaction transaction, string sql, List<IDbDataParameter> parameters, int timeout)
        {
            AddLog(sql, parameters, timeout);
            SqlDataReader reader = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DbHelperSQL.PrepareCommand(cmd, connection, transaction, sql, parameters, timeout);

                    if (AutoCloseConnection)
                    {
                        reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    }
                    else
                    {
                        reader = cmd.ExecuteReader();
                    }

                    cmd.Parameters.Clear();

                    if (reader != null && reader.HasRows)
                        return GenerateEntity.CreateDataTable(reader);
                    else
                        return null;
                }
            }
            catch (SqlException ex)
            {
                AddExData(ref ex, sql, parameters, timeout);
                throw;
                //string msg = FormatExMessage(ex.Message, sql, parameters, timeout);
                //throw new Exception(msg, ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
            }
        }

        #endregion Stored Procedure

        #endregion Public Execute Member

        #region Public Get Entity/List Member

        /*暂时没处理视图里面的锁，BaseSqlTable生成Select语句没进行锁的处理*/

        #region Get Entity

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="displayFields"></param>
        /// <param name="filterParams"></param>
        /// <param name="sortParams"></param>
        /// <param name="lockType"></param>
        /// <returns></returns>
        public T GetEntity<T>(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, Enums.LockType lockType)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
        {
            return GetEntity<T>(displayFields, filterParams, sortParams, lockType, DefaultCommandTimeout);
        }

        /// <summary>
        ///获取表对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="lockType">锁类型</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public T GetEntity<T>(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, Enums.LockType lockType, int timeout)
                 where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
        {
            return GetEntity<T>(displayFields, filterParams, sortParams, new List<Enums.LockType>() { lockType }, timeout);
        }

        /// <summary>
        ///获取表对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="lockTypes">锁类型</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public T GetEntity<T>(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, List<Enums.LockType> lockTypes, int timeout)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
        {
            SqlEntity sqlEty = null;
            GenerateSelectSql<T> genSelectSql = new GenerateSelectSql<T>();
            string tableName = GetTableName<T>();

            sqlEty = new SqlEntity();
            sqlEty.LockType = lockTypes;
            sqlEty.CommandTimeout = timeout;
            sqlEty.CommandText = genSelectSql.SelectSql(tableName, displayFields, filterParams, sortParams, 1, lockTypes);
            sqlEty.Parameters = genSelectSql.GenParameter(filterParams);

            return GetEntity<T>(sqlEty);
        }

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <typeparam name="T">表对象</typeparam>
        /// <param name="sqlEntity">SQL实体</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public T GetEntity<T>(SqlEntity sqlEntity)
            where T : class, new()
        {
            return GetEntity<T>(sqlEntity.CommandText, sqlEntity.Parameters, sqlEntity.CommandTimeout);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T GetEntity<T>(string sql, List<IDbDataParameter> parameters)
            where T : class, new()
        {
            return GetEntity<T>(sql, parameters, DefaultCommandTimeout);
        }

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <typeparam name="T">表对象</typeparam>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public T GetEntity<T>(string sql, List<IDbDataParameter> parameters, int timeout)
            where T : class, new()
        {
            IDataReader reader = ExecuteReader(sql, parameters, timeout);
            try
            {
                if (reader.Read())
                    return GenerateEntity.CreateSingleEntity<T>(reader);
                else
                    return null;
            }
            catch
            { throw; }
            finally
            {
                if (!reader.IsClosed)
                    reader.Close();
            }
        }

        #endregion Get Entity

        /*暂时没处理视图里面的锁，BaseSqlTable生成Select语句没进行锁的处理*/

        #region Get List

        /// <summary>
        ///获取表集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <returns></returns>
        public TS GetList<T, TS>(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            return GetList<T, TS>(displayFields, filterParams, sortParams, null, Enums.LockType.RowLock);
        }

        /// <summary>
        ///获取表集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="maxCount">返回最大记录数</param>
        /// <returns></returns>
        public TS GetList<T, TS>(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            return GetList<T, TS>(displayFields, filterParams, sortParams, maxCount, Enums.LockType.RowLock);
        }

        /// <summary>
        ///获取表集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="maxCount">返回最大记录数</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        public TS GetList<T, TS>(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, Enums.LockType lockType)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            return GetList<T, TS>(displayFields, filterParams, sortParams, maxCount, lockType, DefaultCommandTimeout);
        }

        /// <summary>
        ///获取表集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="maxCount">返回最大记录数</param>
        /// <param name="lockType">锁类型</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public TS GetList<T, TS>(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, Enums.LockType lockType, int timeout)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            return GetList<T, TS>(displayFields, filterParams, sortParams, maxCount, new List<Enums.LockType>() { lockType }, timeout);
        }

        /// <summary>
        ///获取表集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="maxCount">返回最大记录数</param>
        /// <param name="lockTypes">锁类型</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public TS GetList<T, TS>(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, List<Enums.LockType> lockTypes, int timeout)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            GenerateSelectSql<T> genSelectSql = new GenerateSelectSql<T>();
            string tableName = GetTableName<T>();

            SqlEntity sqlEty = new SqlEntity();
            sqlEty.CommandTimeout = timeout;
            sqlEty.LockType = lockTypes;
            sqlEty.CommandText = genSelectSql.SelectSql(tableName, displayFields, filterParams, sortParams, maxCount, lockTypes);
            sqlEty.Parameters = genSelectSql.GenParameter(filterParams);

            return GetList<T, TS>(sqlEty);
        }

        /// <summary>
        /// 通过事务，获取表集合
        /// </summary>
        /// <param name="sqlEntity">SQL实体</param>
        /// <returns></returns>
        public TS GetList<T, TS>(SqlEntity sqlEntity)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            return GetList<T, TS>(sqlEntity.CommandText, sqlEntity.Parameters, sqlEntity.CommandTimeout);
        }

        /// <summary>
        /// 通过事务，获取表集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public TS GetList<T, TS>(string sql, List<IDbDataParameter> parameters)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            return GetList<T, TS>(sql, parameters, DefaultCommandTimeout);
        }

        /// <summary>
        /// 通过事务，获取表集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public TS GetList<T, TS>(string sql, List<IDbDataParameter> parameters, int timeout)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            IDataReader reader = ExecuteReader(sql, parameters, timeout);
            try
            {
                return GenerateEntity.CreateListEntity<T, TS>(reader);
            }
            catch
            { throw; }
            finally
            {
                if (!reader.IsClosed)
                    reader.Close();
            }
        }

        #endregion Get List

        #endregion Public Get Entity/List Member

        #region Public Transaction Member

        /// <summary>
        /// 打开事务
        /// </summary>
        public void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.ReadCommitted);
        }

        /// <summary>
        /// 打开事务
        /// </summary>
        /// <param name="il">指定连接的事务锁定行为</param>
        public void BeginTransaction(IsolationLevel il)
        {
            if (InnerConnection == null)
            {
                InnerConnection = new SqlConnection(ConnectionString);
            }
            if (InnerConnection.State != ConnectionState.Open)
            {
                InnerConnection.Open();
            }
            InnerTransaction = InnerConnection.BeginTransaction(il);
            TransactionState = Enums.TransactionState.Begin;
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction()
        {
            if (InnerTransaction != null)
            {
                InnerTransaction.Commit();
            }
            if (InnerConnection != null)
            {
                InnerConnection.Close();
            }
            TransactionState = Enums.TransactionState.None;
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTransaction()
        {
            if (InnerTransaction != null && InnerTransaction.Connection != null)
            {
                if (TransactionState == Enums.TransactionState.Begin)
                {
                    InnerTransaction.Rollback();
                }
            }
            if (InnerConnection != null)
            {
                InnerConnection.Close();
            }
            TransactionState = Enums.TransactionState.None;
        }

        #endregion Public Transaction Member

        #region Private Member

        private string GetTableName<T>() where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
        {
            string tableName = string.Empty;
            if (typeof(T).BaseType == typeof(hwj.DBUtility.TableMapping.BaseTable<T>))
            {
                tableName = Activator.CreateInstance<T>().GetCommandText();
            }
            else if (typeof(T).BaseType == typeof(hwj.DBUtility.TableMapping.BaseSqlTable<T>))
            {
                string cmdTxt = Activator.CreateInstance<T>().GetCommandText();
                tableName = string.Format(GenerateSelectSql<T>._ViewSqlFormat, cmdTxt);
            }
            return tableName;
        }

        private void AddLog(SqlEntity sqlEntity)
        {
            if (LogSql && sqlEntity != null)
            {
                AddLog(sqlEntity.CommandText, sqlEntity.Parameters, sqlEntity.CommandTimeout);
            }
        }

        private void AddLog(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            if (LogSql)
            {
                LogList.Add(new LogEntity(sql, parameters, timeout));
            }
        }

        private void AddExData(ref SqlException sqlEx, string sql, List<IDbDataParameter> parameters, int timeout)
        {
            if (sqlEx.Data != null)
            {
                string msg = FormatExMessage(sql, parameters, timeout);
                sqlEx.Data.Add(Common.SqlInfoKey, msg);
            }
        }

        private string FormatExMessage(string sql, List<IDbDataParameter> parameters, int timeout)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CommandTimeout:{0};CommandText:{1};", timeout, string.IsNullOrEmpty(sql) ? sql : sql.TrimEnd(';'));
            if (parameters != null)
            {
                sb.Append("Parameter:");
                foreach (IDbDataParameter p in parameters)
                {
                    sb.AppendFormat("{{{0}={1}}},", p.ParameterName, p.Value);
                }
            }
            return sb.ToString().TrimEnd(',');
        }

        #endregion Private Member

        #region IDisposable 成员

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (LogList != null)
                    {
                        LogList = null;
                    }
                }

                if (InnerTransaction != null)
                {
                    InnerTransaction.Dispose();
                    InnerTransaction = null;
                }
                if (InnerConnection != null)
                {
                    //InnerConnection.Close();
                    InnerConnection.Dispose();
                    InnerConnection = null;
                }

                TransactionState = Enums.TransactionState.None;
                this.disposed = true;
            }
        }

        #endregion IDisposable 成员
    }
}