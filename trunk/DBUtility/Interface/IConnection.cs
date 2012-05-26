﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace hwj.DBUtility.Interface
{
    public interface IConnection //: System.Data.IDbConnection
    {
        string ConnectionString { get; }
        int DefaultConnectionTimeout { get; }
        IDbConnection InnerConnection { get; }
        IDbTransaction InnerTransaction { get; }
        Enums.LockType DefaultLock { get; set; }
        Enums.LockType SelectLock { get; set; }
        Enums.LockType UpdateLock { get; set; }

        T GetEntity<T>(string sql, List<IDbDataParameter> parameters) where T : class, new();
        TS GetList<T, TS>(string sql, List<IDbDataParameter> parameters)
            where T : hwj.DBUtility.TableMapping.BaseSqlTable<T>, new()
            where TS : List<T>, new();

        int ExecuteSqlList(SqlList sqlList, int timeout);

        int ExecuteSql(string sql, List<IDbDataParameter> parameters, int timeout);
        IDataReader ExecuteReader(string sql, List<IDbDataParameter> parameters, int timeout);
        object ExecuteScalar(string sql, List<IDbDataParameter> parameters, int timeout);

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}