using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace hwj.DBUtility.Interface
{
    public interface IBaseConnection : IDisposable
    {
        bool AutoCloseConnection { get; }

        string ConnectionString { get; }

        int DefaultCommandTimeout { get; }

        //IDbConnection InnerConnection { get; }

        //IDbTransaction InnerTransaction { get; }

        //Enums.LockType DefaultLock { get; set; }
        List<Enums.LockType> SelectLock { get; set; }

        List<Enums.LockType> UpdateLock { get; set; }

        Enums.TransactionState TransactionState { get; set; }

        List<LogEntity> LogList { get; }

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <typeparam name="T">表对象</typeparam>
        /// <param name="sqlEntity">SQL实体</param>
        /// <returns></returns>
        T GetEntity<T>(SqlEntity sqlEntity) where T : class, new();

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        T GetEntity<T>(string sql, List<IDbDataParameter> parameters) where T : class, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        T GetEntity<T>(string sql, List<IDbDataParameter> parameters, int timeout) where T : class, new();

        /// <summary>
        /// 通过事务，获取表集合
        /// </summary>
        /// <param name="sqlEntity">SQL实体</param>
        /// <returns></returns>
        TS GetList<T, TS>(SqlEntity sqlEntity)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new();

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        TS GetList<T, TS>(string sql, List<IDbDataParameter> parameters)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TS"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        TS GetList<T, TS>(string sql, List<IDbDataParameter> parameters, int timeout)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new();

        /// <summary>
        ///
        /// </summary>
        /// <param name="sqlList"></param>
        /// <returns></returns>
        int ExecuteSqlList(SqlList sqlList);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sqlEntity"></param>
        /// <returns></returns>
        int ExecuteSql(SqlEntity sqlEntity);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        int ExecuteSql(string sql, List<IDbDataParameter> parameters, int timeout);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sqlEntity"></param>
        /// <returns></returns>
        IDataReader ExecuteReader(SqlEntity sqlEntity);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        IDataReader ExecuteReader(string sql, List<IDbDataParameter> parameters, int timeout);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sqlEntity"></param>
        /// <returns></returns>
        object ExecuteScalar(SqlEntity sqlEntity);

        /// <summary>
        ///
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        object ExecuteScalar(string sql, List<IDbDataParameter> parameters, int timeout);

        /// <summary>
        /// 执行存储过程,返回Output参数的值。
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        Dictionary<string, object> ExecuteStoredProcedure(string sql, List<IDbDataParameter> parameters);

        /// <summary>
        /// 执行存储过程,返回Output参数的值。
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        Dictionary<string, object> ExecuteStoredProcedure(string sql, List<IDbDataParameter> parameters, int timeout);

        /// <summary>
        /// 执行存储过程,并返回DataTable。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        DataTable ExecuteStoredProcedureForDataTable(string sql, List<IDbDataParameter> parameters);

        /// <summary>
        /// 执行存储过程,并返回DataTable。
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        DataTable ExecuteStoredProcedureForDataTable(string sql, List<IDbDataParameter> parameters, int timeout);

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="timeout">超时时间(秒)</param>
        void BulkCopy(DataTable table, int timeout);

        void BeginTransaction();

        void BeginTransaction(IsolationLevel il);

        void CommitTransaction();

        void RollbackTransaction();

        void Dispose();
    }
}