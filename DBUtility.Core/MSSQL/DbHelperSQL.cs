using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace hwj.DBUtility.Core.MSSQL
{
    /// <summary>
    /// 数据访问抽象基础类
    /// Copyright (C) 2004-2008 By LiTianPing
    /// </summary>
    public abstract class DbHelperSQL
    {
        /// <summary>
        /// DbHeplerSQL
        /// </summary>
        public DbHelperSQL()
        {
        }

        #region 公用方法

        /// <summary>
        /// 判断是否存在某表的某个字段
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="columnName">列名称</param>
        /// <returns>是否存在</returns>
        public static bool ColumnExists(string ConnectionString, string tableName, string columnName)
        {
            string sql = "select count(1) from syscolumns where [id]=object_id('" + tableName + "') and [name]='" + columnName + "'";
            object res = GetSingle(ConnectionString, sql);
            if (res == null)
            {
                return false;
            }
            return Convert.ToInt32(res) > 0;
        }

        public static int GetMaxID(string ConnectionString, string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = DbHelperSQL.GetSingle(ConnectionString, strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        public static bool Exists(string ConnectionString, string strSql)
        {
            object obj = DbHelperSQL.GetSingle(ConnectionString, strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 表是否存在
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static bool TabExists(string ConnectionString, string TableName)
        {
            string strsql = "select COUNT(1) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            //string strsql = "SELECT COUNT(1) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + TableName + "]') AND type in (N'U')";
            object obj = DbHelperSQL.GetSingle(ConnectionString, strsql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Exists(string ConnectionString, string strSql, List<IDbDataParameter> cmdParms)
        {
            object obj = DbHelperSQL.GetSingle(ConnectionString, strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ClearDatabaseLog(string ConnectionString, string databsae)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("exec sp_ClearDatabaseLog '" + databsae + "'", connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        #endregion 公用方法

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="ConnectionString">连接语句</param>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string ConnectionString, string SQLString)
        {
            return GetSingle(ConnectionString, SQLString, null, -1);
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="ConnectionString">连接语句</param>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="cmdParms">条件语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string ConnectionString, string SQLString, List<IDbDataParameter> cmdParms)
        {
            return GetSingle(ConnectionString, SQLString, cmdParms, -1);
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="connectionString">连接语句</param>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="cmdParms">条件语句</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string connectionString, string SQLString, List<IDbDataParameter> cmdParms, int timeout)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                using (IDbCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms, timeout);
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
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="ConnectionString">连接语句</param>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string ConnectionString, string SQLString)
        {
            return ExecuteSql(ConnectionString, SQLString, null, -1);
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="ConnectionString">连接语句</param>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="cmdParms">条件参数</param>
        /// <returns></returns>
        public static int ExecuteSql(string ConnectionString, string SQLString, List<IDbDataParameter> cmdParms)
        {
            return ExecuteSql(ConnectionString, SQLString, cmdParms, -1);
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="ConnectionString">连接语句</param>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="cmdParms">条件参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public static int ExecuteSql(string ConnectionString, string SQLString, List<IDbDataParameter> cmdParms, int timeout)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms, timeout);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="ConnectionString">连接语句</param>
        /// <param name="cmdList">多条SQL语句</param>
        /// <returns></returns>
        public static int ExecuteSqlTran(string ConnectionString, SqlList cmdList)
        {
            return ExecuteSqlTran(ConnectionString, cmdList, -1);
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="ConnectionString">连接语句</param>
        /// <param name="cmdList">多条SQL语句</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public static int ExecuteSqlTran(string ConnectionString, SqlList cmdList, int timeout)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    int index = 0;
                    try
                    {
                        int count = 0;
                        //循环
                        foreach (SqlEntity myDE in cmdList)
                        {
                            string cmdText = myDE.CommandText;
                            PrepareCommand(cmd, conn, trans, cmdText, myDE.Parameters, timeout);

                            if (myDE.EffentNextType == Enums.EffentNextType.WhenHaveContine || myDE.EffentNextType == Enums.EffentNextType.WhenNoHaveContine)
                            {
                                if (myDE.CommandText.ToLower().IndexOf("count(") == -1)
                                {
                                    trans.Rollback();
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
                                    trans.Rollback();
                                    return 0;
                                }
                                if (myDE.EffentNextType == Enums.EffentNextType.WhenNoHaveContine && isHave)
                                {
                                    trans.Rollback();
                                    return 0;
                                }
                                continue;
                            }
                            int val = cmd.ExecuteNonQuery();
                            count += val;

                            if (myDE.EffentNextType == Enums.EffentNextType.ExcuteEffectRows && val == 0)
                            {
                                trans.Rollback();
                                return 0;
                            }
                            cmd.Parameters.Clear();
                            index++;
                        }
                        trans.Commit();
                        return count;
                    }
                    catch (SqlException ex)
                    {
                        if (trans.Connection != null)
                        {
                            trans.Rollback();
                        }
                        DbExceptionHelper checking = new DbExceptionHelper(cmdList[index]);
                        checking.CheckSqlException(ref ex);
                        throw;
                    }
                    catch
                    {
                        if (trans.Connection != null)
                        {
                            trans.Rollback();
                        }
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="ConnectionString">连接语句</param>
        /// <param name="SQLString">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string ConnectionString, string SQLString)
        {
            return ExecuteReader(ConnectionString, SQLString, null);
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="ConnectionString">连接语句</param>
        /// <param name="SQLString">查询语句</param>
        /// <param name="cmdParms">查询条件</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string ConnectionString, string SQLString, List<IDbDataParameter> cmdParms)
        {
            return ExecuteReader(ConnectionString, SQLString, cmdParms, -1);
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="ConnectionString">连接语句</param>
        /// <param name="SQLString">查询语句</param>
        /// <param name="cmdParms">查询条件</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string ConnectionString, string SQLString, List<IDbDataParameter> cmdParms, int timeout)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms, timeout);

                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="ConnectionString">连接语句</param>
        /// <param name="SQLString">SQL语句</param>
        /// <returns></returns>
        public static DataSet Query(string ConnectionString, string SQLString)
        {
            return Query(ConnectionString, SQLString, null);
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="ConnectionString">连接语句</param>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="cmdParms">查询条件</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string ConnectionString, string SQLString, params SqlParameter[] cmdParms)
        {
            return Query(ConnectionString, SQLString, -1, cmdParms);
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="ConnectionString">连接语句</param>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <param name="cmdParms">查询条件</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string ConnectionString, string SQLString, int timeout, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand4Arry(cmd, connection, null, SQLString, cmdParms, timeout);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                    return ds;
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <param name="cmdList"></param>
        public static void ExecuteSqlTranWithIndentity(string ConnectionString, SqlList sqlList)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int indentity = 0;
                        //循环
                        foreach (SqlEntity myDE in sqlList)
                        {
                            foreach (IDbDataParameter q in myDE.Parameters)
                            {
                                if (q.Direction == ParameterDirection.InputOutput)
                                {
                                    q.Value = indentity;
                                }
                            }
                            PrepareCommand(cmd, conn, trans, myDE);
                            cmd.ExecuteNonQuery();
                            foreach (SqlParameter q in myDE.Parameters)
                            {
                                if (q.Direction == ParameterDirection.Output)
                                {
                                    indentity = Convert.ToInt32(q.Value);
                                }
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        #endregion 执行带参数的SQL语句

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader RunProcedure(string ConnectionString, string storedProcName, IDbDataParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataReader returnReader;
            connection.Open();
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return returnReader;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string ConnectionString, string storedProcName, IDbDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        public static DataSet RunProcedure(string ConnectionString, string storedProcName, IDbDataParameter[] parameters, string tableName, int timeout)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = timeout;
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDbDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(string ConnectionString, string storedProcName, IDbDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDbDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        #endregion 存储过程操作

        #region Private Function

        private static void PrepareCommand4Arry(IDbCommand cmd, IDbConnection conn, IDbTransaction trans, string cmdText, IDbDataParameter[] cmdParms, int timeout)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (timeout >= 0)
            {
                cmd.CommandTimeout = timeout;
            }
            else
            {
                cmd.CommandTimeout = 120;
            }

            if (trans != null)
                cmd.Transaction = trans;
            //cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                //防止多线程的时候，同时Add的错误
                SqlParameter[] clonedParameters = new SqlParameter[cmdParms.Length];
                for (int i = 0, j = cmdParms.Length; i < j; i++)
                {
                    clonedParameters[i] = (SqlParameter)((ICloneable)cmdParms[i]).Clone();
                }

                foreach (SqlParameter parameter in clonedParameters)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        internal static void PrepareCommand(IDbCommand cmd, IDbConnection conn, IDbTransaction trans, SqlEntity sqlEntity)
        {
            PrepareCommand(cmd, conn, trans, sqlEntity.CommandText, sqlEntity.Parameters, sqlEntity.CommandTimeout);
        }

        internal static void PrepareCommand(IDbCommand cmd, IDbConnection conn, IDbTransaction trans, string cmdText, List<IDbDataParameter> cmdParms, int timeout)
        {
            if (cmdParms != null)
            {
                PrepareCommand4Arry(cmd, conn, trans, cmdText, cmdParms.ToArray(), timeout);
            }
            else
            {
                PrepareCommand4Arry(cmd, conn, trans, cmdText, null, timeout);
            }
        }

        #endregion Private Function
    }
}