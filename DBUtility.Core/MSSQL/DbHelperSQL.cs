using hwj.DBUtility.Core.TableMapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace hwj.DBUtility.Core.MSSQL
{
    /// <summary>
    /// ���ݷ��ʳ��������
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

        #region ���÷���

        /// <summary>
        /// �ж��Ƿ����ĳ���ĳ���ֶ�
        /// </summary>
        /// <param name="tableName">������</param>
        /// <param name="columnName">������</param>
        /// <returns>�Ƿ����</returns>
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
        /// ���Ƿ����
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
                    catch (System.Data.SqlClient.SqlException e)
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

        #endregion ���÷���

        #region ִ�д�������SQL���

        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="ConnectionString">�������</param>
        /// <param name="SQLString">SQL���</param>
        /// <returns>��ѯ�����object��</returns>
        public static object GetSingle(string ConnectionString, string SQLString)
        {
            return GetSingle(ConnectionString, SQLString, null, -1);
        }

        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="ConnectionString">�������</param>
        /// <param name="SQLString">SQL���</param>
        /// <param name="cmdParms">�������</param>
        /// <returns>��ѯ�����object��</returns>
        public static object GetSingle(string ConnectionString, string SQLString, List<IDbDataParameter> cmdParms)
        {
            return GetSingle(ConnectionString, SQLString, cmdParms, -1);
        }

        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="connectionString">�������</param>
        /// <param name="SQLString">SQL���</param>
        /// <param name="cmdParms">�������</param>
        /// <param name="timeout">��ʱʱ��(��)</param>
        /// <returns>��ѯ�����object��</returns>
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
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="ConnectionString">�������</param>
        /// <param name="SQLString">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public static int ExecuteSql(string ConnectionString, string SQLString)
        {
            return ExecuteSql(ConnectionString, SQLString, null, -1);
        }

        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="ConnectionString">�������</param>
        /// <param name="SQLString">SQL���</param>
        /// <param name="cmdParms">��������</param>
        /// <returns></returns>
        public static int ExecuteSql(string ConnectionString, string SQLString, List<IDbDataParameter> cmdParms)
        {
            return ExecuteSql(ConnectionString, SQLString, cmdParms, -1);
        }

        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="ConnectionString">�������</param>
        /// <param name="SQLString">SQL���</param>
        /// <param name="cmdParms">��������</param>
        /// <param name="timeout">��ʱʱ��(��)</param>
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
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="ConnectionString">�������</param>
        /// <param name="cmdList">����SQL���</param>
        /// <returns></returns>
        public static int ExecuteSqlTran(string ConnectionString, SqlList cmdList)
        {
            return ExecuteSqlTran(ConnectionString, cmdList, -1);
        }

        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="ConnectionString">�������</param>
        /// <param name="cmdList">����SQL���</param>
        /// <param name="timeout">��ʱʱ��(��)</param>
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
                        //ѭ��
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
                        CheckSqlException(ref ex, cmdList[index]);
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
        /// ִ�в�ѯ��䣬����SqlDataReader ( ע�⣺���ø÷�����һ��Ҫ��SqlDataReader����Close )
        /// </summary>
        /// <param name="ConnectionString">�������</param>
        /// <param name="SQLString">��ѯ���</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string ConnectionString, string SQLString)
        {
            return ExecuteReader(ConnectionString, SQLString, null);
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����SqlDataReader ( ע�⣺���ø÷�����һ��Ҫ��SqlDataReader����Close )
        /// </summary>
        /// <param name="ConnectionString">�������</param>
        /// <param name="SQLString">��ѯ���</param>
        /// <param name="cmdParms">��ѯ����</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string ConnectionString, string SQLString, List<IDbDataParameter> cmdParms)
        {
            return ExecuteReader(ConnectionString, SQLString, cmdParms, -1);
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����SqlDataReader ( ע�⣺���ø÷�����һ��Ҫ��SqlDataReader����Close )
        /// </summary>
        /// <param name="ConnectionString">�������</param>
        /// <param name="SQLString">��ѯ���</param>
        /// <param name="cmdParms">��ѯ����</param>
        /// <param name="timeout">��ʱʱ��(��)</param>
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
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="ConnectionString">�������</param>
        /// <param name="SQLString">SQL���</param>
        /// <returns></returns>
        public static DataSet Query(string ConnectionString, string SQLString)
        {
            return Query(ConnectionString, SQLString, null);
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="ConnectionString">�������</param>
        /// <param name="SQLString">SQL���</param>
        /// <param name="cmdParms">��ѯ����</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string ConnectionString, string SQLString, params SqlParameter[] cmdParms)
        {
            return Query(ConnectionString, SQLString, -1, cmdParms);
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="ConnectionString">�������</param>
        /// <param name="SQLString">SQL���</param>
        /// <param name="timeout">��ʱʱ��(��)</param>
        /// <param name="cmdParms">��ѯ����</param>
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
                    catch (System.Data.SqlClient.SqlException ex)
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
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
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
                        //ѭ��
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

        #endregion ִ�д�������SQL���

        #region �洢���̲���

        /// <summary>
        /// ִ�д洢���̣�����SqlDataReader ( ע�⣺���ø÷�����һ��Ҫ��SqlDataReader����Close )
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
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
        /// ִ�д洢����
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="tableName">DataSet����еı���</param>
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
        /// ���� SqlCommand ����(��������һ���������������һ������ֵ)
        /// </summary>
        /// <param name="connection">���ݿ�����</param>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDbDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // ���δ����ֵ���������,���������DBNull.Value.
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
        /// ִ�д洢���̣�����Ӱ�������
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="rowsAffected">Ӱ�������</param>
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
        /// ���� SqlCommand ����ʵ��(��������һ������ֵ)
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>SqlCommand ����ʵ��</returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDbDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        #endregion �洢���̲���

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
                //��ֹ���̵߳�ʱ��ͬʱAdd�Ĵ���
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

        internal static void CheckSqlException(ref SqlException e, SqlEntity entity)
        {
            if (e.Number == 8152 && entity != null && entity.DataEntity != null)
            {
                string fieldStr = FormatMsgFor8152(entity.TableName, entity.DataEntity);
                e.Data.Add(Common.ExceptionFieldsKey, fieldStr);
            }
        }

        //private static void FormatSqlEx(string SQLString, List<SqlParameter> cmdParms, ref SqlException e)
        //{
        //    try
        //    {
        //        SqlEntityXml sex = new SqlEntityXml(SQLString, cmdParms);
        //        e.HelpLink = sex.ToXml();
        //    }
        //    catch { }
        //}
        /// <summary>
        /// ����ַ������Ƿ������������
        /// </summary>
        /// <param name="e"></param>
        /// <param name="tableName"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal static string FormatMsgFor8152(string tableName, object entity)
        {
            string errFields = string.Empty;
            foreach (FieldMappingInfo field in FieldMappingInfo.GetFieldMapping(entity.GetType()))
            {
                if (field.Size != 0)
                {
                    object value = field.Property.GetValue(entity, null);
                    if (value != null)
                    {
                        string str = value.ToString();
                        if (Common.IsNumType(field.DataTypeCode) && str.IndexOf('.') >= 0)
                        {
                            if (str.IndexOf('.') > field.Size)
                            {
                                errFields += field.FieldName + "/";
                            }
                        }
                        else if (field.DataTypeCode == DbType.Boolean)
                        {
                        }
                        else if (field.DataTypeCode == DbType.DateTime)
                        {
                        }
                        else
                        {
                            if (str.Length > field.Size)
                            {
                                errFields += field.FieldName + "/";
                            }
                        }
                    }
                }
            }

            errFields = errFields.TrimEnd('/');
            if (!string.IsNullOrEmpty(errFields))
            {
                return string.Format("Table:{0};Field:{1};", tableName, errFields);
            }
            else
            {
                return null;
            }
        }

        #endregion Private Function
    }
}