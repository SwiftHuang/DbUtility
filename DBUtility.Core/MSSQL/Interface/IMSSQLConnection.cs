using hwj.DBUtility.Interface;
using System.Data.SqlClient;

namespace hwj.DBUtility.MSSQL.Interface
{
    /// <summary>
    ///
    /// </summary>
    public interface IMSSQLConnection : IBaseConnection
    {
        /// <summary>
        /// 当前数据库连接
        /// </summary>
        SqlConnection InnerConnection { get; }

        /// <summary>
        /// 当前数据库连接的事务
        /// </summary>
        SqlTransaction InnerTransaction { get; }
    }
}