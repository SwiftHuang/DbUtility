using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace hwj.DBUtility.Interface
{
    public interface IConnection : IDisposable
    {
        string ConnectionString { get; }
        int DefaultCommandTimeout { get; }
        IDbConnection InnerConnection { get; }
        IDbTransaction InnerTransaction { get; }
        //Enums.LockType DefaultLock { get; set; }
        Enums.LockType SelectLock { get; set; }
        Enums.LockType UpdateLock { get; set; }
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

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Dispose();
    }
}
