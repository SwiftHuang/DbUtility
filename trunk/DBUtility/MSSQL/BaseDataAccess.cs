using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using hwj.DBUtility.TableMapping;

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
        #region Property
        private string _connectionString = string.Empty;
        public string ConnectionString
        {
            get { return _connectionString; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("数据连接字符不能为空");
                else
                    _connectionString = value;
            }
        }
        protected SqlEntity _SqlEntity = null;
        /// <summary>
        /// 显示执行的Sql实体
        /// </summary>
        protected SqlEntity SqlEntity
        {
            get { return _SqlEntity; }
        }
        private int _Timeout = 120;
        /// <summary>
        /// 获取超时时间(秒)
        /// </summary>
        public int Timeout
        {
            get { return _Timeout; }
            //set { _Timeout = value; }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        protected BaseDataAccess(string connectionString)
            : this(connectionString, 120)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="timeout"></param>
        protected BaseDataAccess(string connectionString, int timeout)
        {
            ConnectionString = connectionString;
            _Timeout = timeout;
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="list">多条SQL语句</param>
        /// <returns></returns>
        public bool ExecuteSqlTran(SqlList list)
        {
            return ExecuteSqlTran(list, Timeout);
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

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteSql(string sql)
        {
            return ExecuteSql(sql, null, Timeout);
        }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteSql(string sql, List<SqlParameter> parameters)
        {
            return ExecuteSql(sql, parameters, Timeout);
        }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public int ExecuteSql(string sql, List<SqlParameter> parameters, int timeout)
        {
            return DbHelper.ExecuteSql(ConnectionString, sql, parameters, timeout);
        }

        /// <summary>
        /// 执行SQL语句，返回SqlDataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, null, Timeout);
        }
        /// <summary>
        /// 执行SQL语句，返回SqlDataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql, List<SqlParameter> parameters)
        {
            return ExecuteReader(sql, parameters, Timeout);
        }
        /// <summary>
        /// 执行SQL语句，返回SqlDataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql, List<SqlParameter> parameters, int timeout)
        {
            return DbHelperSQL.ExecuteReader(ConnectionString, sql, parameters, timeout);
        }

        /// <summary>
        /// 执行SQL语句，返回Object
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, null, Timeout);
        }
        /// <summary>
        /// 执行SQL语句，返回Object
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, List<SqlParameter> parameters)
        {
            return ExecuteScalar(sql, parameters, Timeout);
        }
        /// <summary>
        /// 执行SQL语句，返回Object
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, List<SqlParameter> parameters, int timeout)
        {
            return DbHelperSQL.GetSingle(ConnectionString, sql, parameters, timeout);
        }

        #region Get Entity
       /// <summary>
        /// 获取表对象
       /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">条件参数</param>
       /// <returns></returns>
        protected T GetEntity(string sql, List<SqlParameter> parameters)
        {
            return GetEntity(sql, parameters, Timeout);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">条件参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        protected T GetEntity(string sql, List<SqlParameter> parameters, int timeout)
        {
            SqlDataReader reader = ExecuteReader(sql, parameters, timeout);
            try
            {
                if (reader.HasRows)
                    return GenerateEntity<T, TS>.CreateSingleEntity(reader);
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

        #region Get List
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">条件参数</param>
        /// <returns></returns>
        protected TS GetList(string sql, List<SqlParameter> parameters)
        {
            return GetList(sql, parameters, Timeout);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">条件参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        protected TS GetList(string sql, List<SqlParameter> parameters, int timeout)
        {
            SqlDataReader reader = ExecuteReader(sql, parameters, timeout);
            try
            {
                if (reader.HasRows)
                    return GenerateEntity<T, TS>.CreateListEntity(reader);
                else
                    return new TS();
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
    }
}
