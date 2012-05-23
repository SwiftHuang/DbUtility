using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace hwj.DBUtility.MSSQL
{
    /// <summary>
    /// 
    /// </summary>
    public class DbTransaction : System.Data.IDbTransaction
    {
        #region Property
        public SqlTransaction SqlTrans { get; private set; }
        public SqlConnection SqlConn { get; private set; }
        public int Timeout { get; set; }
        public Enums.LockType DefaultLock { get; set; }
        public Enums.LockType SelectLock { get; set; }
        public Enums.LockType UpdateLock { get; set; }
        #endregion

        /// <summary>
        /// SQL事务实体
        /// </summary>
        public DbTransaction()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public DbTransaction(string connectionString)
            : this(connectionString, 30)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="timeout"></param>
        public DbTransaction(string connectionString, int timeout)
        {
            DefaultLock = Enums.LockType.HoldLock;
            SelectLock = Enums.LockType.UpdLock;
            UpdateLock = Enums.LockType.UpdLock;
            Timeout = timeout;
            SqlConn = new SqlConnection(connectionString);
            SqlConn.Open();
            SqlTrans = SqlConn.BeginTransaction();
        }

        #region Public Member
        #region ExecuteSqlList
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlList"></param>
        /// <returns></returns>
        public int ExecuteSqlList(SqlList sqlList)
        {
            return ExecuteSqlList(sqlList, Timeout);
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="sqlList">多条SQL语句</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public int ExecuteSqlList(SqlList sqlList, int timeout)
        {
            if (SqlTrans == null)
            {
                return 0;
            }

            SqlCommand cmd = new SqlCommand();
            int index = 0;
            try
            {
                int count = 0;
                //循环
                foreach (SqlEntity myDE in sqlList)
                {
                    DbHelperSQL.PrepareCommand(cmd, SqlTrans.Connection, SqlTrans, myDE.CommandText, myDE.Parameters, timeout);

                    //if (myDE.EffentNextType == Enums.EffentNextType.WhenHaveContine || myDE.EffentNextType == Enums.EffentNextType.WhenNoHaveContine)
                    //{
                    //    if (myDE.CommandText.ToLower().IndexOf("count(") == -1)
                    //    {
                    //        SqlTrans.Rollback();
                    //        return 0;
                    //    }

                    //    object obj = cmd.ExecuteScalar();
                    //    bool isHave = false;
                    //    if (obj == null && obj == DBNull.Value)
                    //    {
                    //        isHave = false;
                    //    }
                    //    isHave = Convert.ToInt32(obj) > 0;

                    //    if (myDE.EffentNextType == Enums.EffentNextType.WhenHaveContine && !isHave)
                    //    {
                    //        SqlTrans.Rollback();
                    //        return 0;
                    //    }
                    //    if (myDE.EffentNextType == Enums.EffentNextType.WhenNoHaveContine && isHave)
                    //    {
                    //        SqlTrans.Rollback();
                    //        return 0;
                    //    }
                    //    continue;
                    //}
                    int val = cmd.ExecuteNonQuery();
                    count += val;

                    //if (myDE.EffentNextType == Enums.EffentNextType.ExcuteEffectRows && val == 0)
                    //{
                    //    SqlTrans.Rollback();
                    //    return 0;
                    //}
                    cmd.Parameters.Clear();
                    index++;
                }
                //SqlTrans.Commit();
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
        /// 
        /// </summary>
        /// <param name="sqlEntity"></param>
        /// <returns></returns>
        public int ExecuteSql(SqlEntity sqlEntity)
        {
            return ExecuteSql(sqlEntity, Timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlEntity"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public int ExecuteSql(SqlEntity sqlEntity, int timeout)
        {
            try
            {
                return ExecuteSql(sqlEntity.CommandText, sqlEntity.Parameters, timeout);
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
        /// 
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public int ExecuteSql(string SQLString, List<SqlParameter> cmdParms)
        {
            return ExecuteSql(SQLString, cmdParms, Timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="cmdParms"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public int ExecuteSql(string SQLString, List<SqlParameter> cmdParms, int timeout)
        {
            if (SqlTrans == null)
            {
                return 0;
            }

            using (SqlCommand cmd = new SqlCommand())
            {
                DbHelperSQL.PrepareCommand(cmd, SqlConn, SqlTrans, SQLString, cmdParms, timeout);

                int rows = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return rows;
            }
        }
        #endregion

        #region ExecuteReader
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string SQLString, List<SqlParameter> cmdParms)
        {
            return ExecuteReader(SQLString, cmdParms, Timeout);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="cmdParms"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string SQLString, List<SqlParameter> cmdParms, int timeout)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                DbHelperSQL.PrepareCommand(cmd, SqlConn, SqlTrans, SQLString, cmdParms, timeout);

                SqlDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="cmdParms">条件语句</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns>查询结果（object）</returns>
        public object ExecuteScalar(string SQLString, List<SqlParameter> cmdParms)
        {
            return ExecuteScalar(SQLString, cmdParms, Timeout);
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="cmdParms">条件语句</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns>查询结果（object）</returns>
        public object ExecuteScalar(string SQLString, List<SqlParameter> cmdParms, int timeout)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                DbHelperSQL.PrepareCommand(cmd, SqlConn, SqlTrans, SQLString, cmdParms, timeout);
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
        #endregion
        /*暂时没处理视图里面的锁，BaseSqlTable生成Select语句没进行锁的处理*/
        #region Get Entity
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filterParam"></param>
        /// <returns></returns>
        public T GetEntity<T>(FilterParams filterParam)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
        {
            return GetEntity<T>(null, filterParam, null, Enums.LockType.UpdLock);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="displayFields"></param>
        /// <param name="filterParam"></param>
        /// <returns></returns>
        public T GetEntity<T>(DisplayFields displayFields, FilterParams filterParam)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
        {
            return GetEntity<T>(displayFields, filterParam, null, Enums.LockType.UpdLock);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="displayFields"></param>
        /// <param name="filterParam"></param>
        /// <param name="sortParams"></param>
        /// <returns></returns>
        public T GetEntity<T>(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
             where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
        {
            return GetEntity<T>(displayFields, filterParam, sortParams, Enums.LockType.UpdLock);
        }
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
            SqlEntity sqlEty = null;
            GenerateSelectSql<T> genSelectSql = new GenerateSelectSql<T>();
            string tableName = GetTableName<T>();

            sqlEty = new SqlEntity(genSelectSql.SelectSql(tableName, displayFields, filterParam, sortParams, 1, lockType), genSelectSql.GenParameter(filterParam));
            return GetEntity<T>(sqlEty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlEntity"></param>
        /// <returns></returns>
        public T GetEntity<T>(SqlEntity sqlEntity)
            where T : class, new()
        {
            return GetEntity<T>(sqlEntity.CommandText, sqlEntity.Parameters);
        }

        /// <summary>
        /// 通过事务，获取表对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public T GetEntity<T>(string sql, List<SqlParameter> parameters)
            where T : class, new()
        {
            SqlDataReader reader = ExecuteReader(sql, parameters, Timeout);
            try
            {
                if (reader.HasRows)
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
        /// <returns></returns>
        public TS GetList<T, TS>(DisplayFields displayFields)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            return GetList<T, TS>(displayFields, null, null, null, Enums.LockType.RowLock);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="displayFields"></param>
        /// <param name="filterParam"></param>
        /// <returns></returns>
        public TS GetList<T, TS>(DisplayFields displayFields, FilterParams filterParam)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            return GetList<T, TS>(displayFields, filterParam, null, null, Enums.LockType.RowLock);
        }
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
            GenerateSelectSql<T> genSelectSql = new GenerateSelectSql<T>();
            string tableName = GetTableName<T>();
            SqlEntity tmpSqlEty = new SqlEntity(genSelectSql.SelectSql(tableName, displayFields, filterParam, sortParams, maxCount, lockType), genSelectSql.GenParameter(filterParam));

            return GetList<T, TS>(tmpSqlEty);
        }
        /// <summary>
        /// 通过事务，获取表集合
        /// </summary>
        /// <param name="sqlEntity">SQL实体</param>
        /// <returns></returns>
        protected TS GetList<T, TS>(SqlEntity sqlEntity)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            return GetList<T, TS>(sqlEntity.CommandText, sqlEntity.Parameters);
        }
        /// <summary>
        /// 通过事务，获取表集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public TS GetList<T, TS>(string sql, List<SqlParameter> parameters)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new()
        {
            SqlDataReader reader = ExecuteReader(sql, parameters, Timeout);
            try
            {
                if (reader.HasRows)
                {
                    return GenerateEntity.CreateListEntity<T, TS>(reader);
                }
                else
                {
                    return null;
                }
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
        #endregion

        #region IDbTransaction 成员

        public void Commit()
        {
            if (SqlTrans != null)
            {
                SqlTrans.Commit();
            }
            if (SqlConn != null)
            {
                SqlConn.Close();
            }
        }

        public System.Data.IDbConnection Connection
        {
            get { return SqlTrans.Connection; }
        }

        public System.Data.IsolationLevel IsolationLevel
        {
            get { return SqlTrans.IsolationLevel; }
        }

        public void Rollback()
        {
            if (SqlTrans != null)
            {
                SqlTrans.Rollback();
            }
            if (SqlConn != null)
            {
                SqlConn.Close();
            }
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            if (SqlTrans != null)
            {
                SqlTrans.Dispose();
            }
            if (SqlConn != null)
            {
                SqlConn.Close();
            }
        }

        #endregion
    }
}
