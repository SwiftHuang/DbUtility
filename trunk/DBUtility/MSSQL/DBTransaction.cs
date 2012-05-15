using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace hwj.DBUtility.MSSQL
{
    public class DBTransaction : System.Data.IDbTransaction
    {
        #region Property
        public SqlTransaction SqlTrans { get; private set; }
        public SqlConnection SqlConn { get; private set; }
        public int Timeout { get; set; }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public DBTransaction(string connectionString)
        {
            Timeout = 120;
            SqlConn = new SqlConnection(connectionString);
            SqlConn.Open();
            SqlTrans = SqlConn.BeginTransaction();
        }

        #region Public Member
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
        public SqlDataReader ExecuteReader(string SQLString, List<SqlParameter> cmdParms, int timeout)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                DbHelperSQL.PrepareCommand(cmd, SqlConn, SqlTrans, SQLString, cmdParms, timeout);

                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
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
