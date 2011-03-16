using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace hwj.DBUtility.MSSQL
{
    public class BaseDataAccess<T> where T : class, new()
    {
        private string _connectionString = string.Empty;
        public string ConnectionString
        {
            get { return _connectionString; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("数据连接字符不能为空");
                else
                    _connectionString = value;
            }
        }
        protected SqlEntity _SqlEntity = null;
        public SqlEntity SqlEntity
        {
            get { return _SqlEntity; }
        }

        public BaseDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public bool ExecuteSqlTran(SqlList list)
        {
            return DbHelperSQL.ExecuteSqlTran(ConnectionString, list) > 0;
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteSql(string sql, List<SqlParameter> parameters)
        {
            return DbHelper.ExecuteSql(ConnectionString, sql, parameters);
        }
        /// <summary>
        /// 执行SQL语句，返回SqlDataReader
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql, List<SqlParameter> parameters)
        {
            return DbHelperSQL.ExecuteReader(ConnectionString, sql, parameters);
        }
        /// <summary>
        /// 执行SQL语句，返回Object
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, List<SqlParameter> parameters)
        {
            return DbHelperSQL.GetSingle(ConnectionString, sql, parameters);
        }
    }
}
