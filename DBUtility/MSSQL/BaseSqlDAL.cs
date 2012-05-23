using System;
using System.Collections.Generic;
using System.Text;
using hwj.DBUtility.TableMapping;
using System.Data.SqlClient;

namespace hwj.DBUtility.MSSQL
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TS"></typeparam>
    public abstract class BaseSqlDAL<T, TS> : SelectDALDependency<T, TS>
        where T : BaseSqlTable<T>, new()
        where TS : List<T>, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">数据连接字符串</param>
        protected BaseSqlDAL(string connectionString)
            : base(connectionString)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">数据连接字符串</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <param name="lockType">锁类型</param>
        protected BaseSqlDAL(string connectionString, int timeout, Enums.LockType lockType)
            : base(connectionString, timeout, lockType)
        {
        }

    }
}
