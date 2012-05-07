using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace hwj.DBUtility.MSSQL
{
    public class TransactionHelper : System.Data.IDbTransaction
    {
        public SqlTransaction SqlTrans { get; private set; }
        public SqlConnection SqlConn { get; private set; }

        public TransactionHelper(string connectionString)
        {
            SqlConn = new SqlConnection(connectionString);
            SqlConn.Open();
            SqlTrans = SqlConn.BeginTransaction();
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="cmdList">多条SQL语句</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public int ExecuteSqlTran(SqlList cmdList, int timeout)
        {
            if (SqlTrans == null)
            {
                return 0;
            }

            using (SqlTrans)
            {
                if (SqlTrans.Connection != null && SqlTrans.Connection.State == ConnectionState.Closed)
                {
                    SqlTrans.Connection.Open();
                }

                SqlCommand cmd = new SqlCommand();
                int index = 0;
                try
                {
                    int count = 0;
                    //循环
                    foreach (SqlEntity myDE in cmdList)
                    {
                        string cmdText = myDE.CommandText;
                        DbHelperSQL.PrepareCommand(cmd, SqlTrans.Connection, SqlTrans, cmdText, myDE.Parameters, timeout);

                        if (myDE.EffentNextType == Enums.EffentNextType.WhenHaveContine || myDE.EffentNextType == Enums.EffentNextType.WhenNoHaveContine)
                        {
                            if (myDE.CommandText.ToLower().IndexOf("count(") == -1)
                            {
                                SqlTrans.Rollback();
                                return 0;
                            }

                            object obj = cmd.ExecuteScalar();
                            bool isHave = false;
                            if (obj == null && obj == DBNull.Value)
                            {
                                isHave = false;
                            }
                            isHave = Convert.ToInt32(obj) > 0;

                            if (myDE.EffentNextType == Enums.EffentNextType.WhenHaveContine && !isHave)
                            {
                                SqlTrans.Rollback();
                                return 0;
                            }
                            if (myDE.EffentNextType == Enums.EffentNextType.WhenNoHaveContine && isHave)
                            {
                                SqlTrans.Rollback();
                                return 0;
                            }
                            continue;
                        }
                        int val = cmd.ExecuteNonQuery();
                        count += val;

                        if (myDE.EffentNextType == Enums.EffentNextType.ExcuteEffectRows && val == 0)
                        {
                            SqlTrans.Rollback();
                            return 0;
                        }
                        cmd.Parameters.Clear();
                        index++;
                    }
                    SqlTrans.Commit();
                    return count;
                }
                catch (Exception ex)
                {
                    if (SqlTrans.Connection != null)
                    {
                        SqlTrans.Rollback();
                    }

                    Exception newEx = DbHelperSQL.CheckSqlException(ex, cmdList[index]);
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
        }

        #region IDbTransaction 成员

        public void Commit()
        {
            SqlTrans.Commit();
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
            SqlTrans.Rollback();
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            SqlTrans.Dispose();
        }

        #endregion
    }
}
