using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using hwj.DBUtility.Interface;

namespace hwj.DBUtility.MSSQL
{
    /// <summary>
    /// 
    /// </summary>
    public class DbConnection : IConnection, IDisposable
    {
        #region Property
        public string ConnectionString { get; private set; }
        /// <summary>
        /// 获取或设置在终止执行命令的尝试并生成错误之前的等待时间。
        /// </summary>
        public int DefaultCommandTimeout { get; private set; }
        public IDbTransaction InnerTransaction { get; private set; }
        public IDbConnection InnerConnection { get; private set; }

        //public Enums.LockType DefaultLock { get; set; }
        public Enums.LockType SelectLock { get; set; }
        public Enums.LockType UpdateLock { get; set; }
        public Enums.TransactionState TransactionState { get; set; }

        public bool LogSql { get; set; }
        public List<LogEntity> LogList { get; private set; }
        #endregion

        #region CTOR
        /// <summary>
        /// 数据库连接实体
        /// </summary>
        /// <param name="connectionString"></param>
        public DbConnection(string connectionString)
            : this(connectionString, 30, Enums.LockType.None)
        { }
        /// <summary>
        /// 数据库连接实体
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="timeout"></param>
        public DbConnection(string connectionString, int timeout, Enums.LockType defaultLock)
            : this(connectionString, timeout, defaultLock, false)
        {
        }
        /// <summary>
        /// 数据库连接实体
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="timeout"></param>
        public DbConnection(string connectionString, int timeout, Enums.LockType defaultLock, bool logSql)
        {
            ConnectionString = connectionString;
            DefaultCommandTimeout = timeout;
            InnerConnection = new SqlConnection(connectionString);

            SelectLock = Enums.LockType.UpdLock;
            UpdateLock = Enums.LockType.UpdLock;

            LogSql = logSql;
            if (logSql)
            {
                LogList = new List<LogEntity>();
            }
        }
        #endregion

        #region Public Execute Member
        #region ExecuteSqlList
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="sqlList">多条SQL语句</param>
        /// <returns></returns>
        public int ExecuteSqlList(SqlList sqlList)
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
                    DbHelperSQL.PrepareCommand(cmd, InnerTransaction.Connection, InnerTransaction, myDE);

                    int val = cmd.ExecuteNonQuery();
                    count += val;

                    cmd.Parameters.Clear();
                    index++;
                }

                return count;
            }
            catch (Exception ex)
            {
                Exception newEx = DbHelperSQL.CheckSqlException(ex, sqlList[index]);
                if (newEx == null)
                {
                    throw;
                }
                else
                {
                    throw newEx;
                }
            }
        }
        #endregion

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
            catch (Exception ex)
            {
                Exception newEx = DbHelperSQL.CheckSqlException(ex, sqlEntity);
                if (newEx == null)
                {
                    throw;
                }
                else
                {
                    throw newEx;
                }
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
            AddLog(sql, parameters, timeout);
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    DbHelperSQL.PrepareCommand(cmd, InnerConnection, InnerTransaction, sql, parameters, timeout);

                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
            }
            catch (SqlException ex)
            {
                string msg = FormatExMessage(ex.Message, sql, parameters, timeout);
                throw new Exception(msg, ex);
            }
        }
        #endregion

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

                    SqlDataReader myReader = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                    return myReader;
                }
            }
            catch (SqlException ex)
            {
                string msg = FormatExMessage(ex.Message, sql, parameters, timeout);
                throw new Exception(msg, ex);
            }
        }
        #endregion

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
            AddLog(sql, parameters, timeout);
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    DbHelperSQL.PrepareCommand(cmd, InnerConnection, InnerTransaction, sql, parameters, timeout);
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
                string msg = FormatExMessage(ex.Message, sql, parameters, timeout);
                throw new Exception(msg, ex);
            }
        }
        #endregion
        #endregion

        #region Public Get Entity/List Member
        /*暂时没处理视图里面的锁，BaseSqlTable生成Select语句没进行锁的处理*/
        #region Get Entity
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="displayFields"></param>
        /// <param name="filterParam"></param>
        /// <param name="sortParams"></param>
        /// <param name="lockType"></param>
        /// <returns></returns>
        public T GetEntity<T>(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, Enums.LockType lockType)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
        {
            return GetEntity<T>(displayFields, filterParam, sortParams, lockType, DefaultCommandTimeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="displayFields"></param>
        /// <param name="filterParam"></param>
        /// <param name="sortParams"></param>
        /// <param name="lockType"></param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public T GetEntity<T>(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, Enums.LockType lockType, int timeout)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
        {
            SqlEntity sqlEty = null;
            GenerateSelectSql<T> genSelectSql = new GenerateSelectSql<T>();
            string tableName = GetTableName<T>();

            sqlEty = new SqlEntity();
            sqlEty.LockType = lockType;
            sqlEty.CommandTimeout = timeout;
            sqlEty.CommandText = genSelectSql.SelectSql(tableName, displayFields, filterParam, sortParams, 1, lockType);
            sqlEty.Parameters = genSelectSql.GenParameter(filterParam);

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

        #endregion

        /*暂时没处理视图里面的锁，BaseSqlTable生成Select语句没进行锁的处理*/
        #region Get List
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="displayFields"></param>
        /// <param name="filterParam"></param>
        /// <param name="sortParams"></param>
        /// <returns></returns>
        public TS GetList<T, TS>(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            return GetList<T, TS>(displayFields, filterParam, sortParams, null, Enums.LockType.RowLock);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="displayFields"></param>
        /// <param name="filterParam"></param>
        /// <param name="sortParams"></param>
        /// <param name="maxCount"></param>
        /// <returns></returns>
        public TS GetList<T, TS>(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            return GetList<T, TS>(displayFields, filterParam, sortParams, maxCount, Enums.LockType.RowLock);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="displayFields"></param>
        /// <param name="filterParam"></param>
        /// <param name="sortParams"></param>
        /// <param name="maxCount"></param>
        /// <param name="lockType"></param>
        /// <returns></returns>
        public TS GetList<T, TS>(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount, Enums.LockType lockType)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            return GetList<T, TS>(displayFields, filterParam, sortParams, maxCount, lockType, DefaultCommandTimeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="displayFields"></param>
        /// <param name="filterParam"></param>
        /// <param name="sortParams"></param>
        /// <param name="maxCount"></param>
        /// <param name="lockType"></param>
        /// <returns></returns>
        public TS GetList<T, TS>(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount, Enums.LockType lockType, int timeout)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            GenerateSelectSql<T> genSelectSql = new GenerateSelectSql<T>();
            string tableName = GetTableName<T>();

            SqlEntity sqlEty = new SqlEntity();
            sqlEty.CommandTimeout = timeout;
            sqlEty.LockType = lockType;
            sqlEty.CommandText = genSelectSql.SelectSql(tableName, displayFields, filterParam, sortParams, maxCount, lockType);
            sqlEty.Parameters = genSelectSql.GenParameter(filterParam);

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
        /// <returns></returns>
        public TS GetList<T, TS>(string sql, List<IDbDataParameter> parameters, int timeout)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            IDataReader reader = ExecuteReader(sql, parameters, DefaultCommandTimeout);
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
        #endregion
        #endregion

        #region Public Transaction Member
        /// <summary>
        /// 打开事务
        /// </summary>
        public void BeginTransaction()
        {
            if (InnerConnection == null)
            {
                InnerConnection = new SqlConnection(ConnectionString);
            }
            if (InnerConnection.State != ConnectionState.Open)
            {
                InnerConnection.Open();
            }
            InnerTransaction = InnerConnection.BeginTransaction();
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
            if (InnerTransaction != null)
            {
                InnerTransaction.Rollback();
            }
            if (InnerConnection != null)
            {
                InnerConnection.Close();
            }
            TransactionState = Enums.TransactionState.None;
        }
        #endregion

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
        private string FormatExMessage(string message, string sql, List<IDbDataParameter> parameters, int timeout)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(message);
            sb.AppendFormat("CommandTimeout:{0}", timeout);
            sb.AppendLine();
            sb.AppendFormat("CommandText:{0}", sql);
            sb.AppendLine();
            sb.AppendLine("Parameter:");
            foreach (IDbDataParameter p in parameters)
            {
                sb.AppendFormat("{{{0}={1}}}", p.ParameterName, p.Value);
                sb.AppendLine();
            }

            return sb.ToString();
        }
        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
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
                if (LogList != null)
                {
                    LogList = null;
                }
            }
            TransactionState = Enums.TransactionState.None;
        }

        #endregion

    }
}
