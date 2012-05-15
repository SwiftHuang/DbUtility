using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using hwj.DBUtility.TableMapping;
using System.Data;

namespace hwj.DBUtility.MSSQL
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TS"></typeparam>
    public abstract class BaseDataAccess<T, TS>
        where T : BaseSqlTable<T>, new()
        where TS : List<T>, new()
    {
        #region Property
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
        /// <summary>
        /// 显示执行的Sql实体
        /// </summary>
        public SqlEntity SqlEntity
        {
            get { return _SqlEntity; }
        }
        private int _Timeout = 120;
        /// <summary>
        /// 获取超时时间(秒)
        /// </summary>
        public int Timeout
        {
            get { return _Timeout; }
            //set { _Timeout = value; }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        protected BaseDataAccess(string connectionString)
            : this(connectionString, 120)
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="timeout"></param>
        protected BaseDataAccess(string connectionString, int timeout)
        {
            ConnectionString = connectionString;
            _Timeout = timeout;
        }

        #region Execute
        #region ExecuteSqlTran
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="list">多条SQL语句</param>
        /// <returns></returns>
        public bool ExecuteSqlTran(SqlList list)
        {
            return ExecuteSqlTran(list, Timeout);
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="list">多条SQL语句</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public bool ExecuteSqlTran(SqlList list, int timeout)
        {
            return DbHelperSQL.ExecuteSqlTran(ConnectionString, list, timeout) > 0;
        }
        #endregion

        #region ExecuteSql
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteSql(string sql)
        {
            return ExecuteSql(sql, null, Timeout);
        }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteSql(string sql, List<SqlParameter> parameters)
        {
            return ExecuteSql(sql, parameters, Timeout);
        }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public int ExecuteSql(string sql, List<SqlParameter> parameters, int timeout)
        {
            return DbHelper.ExecuteSql(ConnectionString, sql, parameters, timeout);
        }
        #endregion

        #region ExecuteReader
        /// <summary>
        /// 执行SQL语句，返回SqlDataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, null, Timeout);
        }
        /// <summary>
        /// 执行SQL语句，返回SqlDataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql, List<SqlParameter> parameters)
        {
            return ExecuteReader(sql, parameters, Timeout);
        }
        /// <summary>
        /// 执行SQL语句，返回SqlDataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql, List<SqlParameter> parameters, int timeout)
        {
            return DbHelperSQL.ExecuteReader(ConnectionString, sql, parameters, timeout);
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 执行SQL语句，返回Object
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, null, Timeout);
        }
        /// <summary>
        /// 执行SQL语句，返回Object
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, List<SqlParameter> parameters)
        {
            return ExecuteScalar(sql, parameters, Timeout);
        }
        /// <summary>
        /// 执行SQL语句，返回Object
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, List<SqlParameter> parameters, int timeout)
        {
            return DbHelperSQL.GetSingle(ConnectionString, sql, parameters, timeout);
        }
        #endregion
        #endregion

        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        /// <returns></returns>
        abstract public DateTime GetServerDateTime();

        #region Get Entity
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="sqlEntity">SQL实体</param>
        /// <returns></returns>
        protected T GetEntity(SqlEntity sqlEntity)
        {
            _SqlEntity = sqlEntity;
            return GetEntity(sqlEntity.CommandText, sqlEntity.Parameters, Timeout);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="filterParam">条件参数</param>
        /// <returns></returns>
        public T GetEntity(FilterParams filterParam)
        {
            return GetEntity(null, filterParam, null);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <returns></returns>
        public T GetEntity(DisplayFields displayFields, FilterParams filterParam)
        {
            return GetEntity(displayFields, filterParam, null);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <returns></returns>
        abstract public T GetEntity(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams);

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public T GetEntity(string sql, List<SqlParameter> parameters)
        {
            return GetEntity(sql, parameters, Timeout);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public T GetEntity(string sql, List<SqlParameter> parameters, int timeout)
        {
            SqlDataReader reader = ExecuteReader(sql, parameters, timeout);
            try
            {
                if (reader.HasRows)
                    return GenerateEntity<T, TS>.CreateSingleEntity(reader);
                else
                    return null;
            }
            catch
            { throw; }
            finally
            {
                if (!reader.IsClosed)
                    reader.Close();
            }
        }

        /// <summary>
        /// 通过事务，获取表对象
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="sqlEntity">SQL实体</param>
        /// <returns></returns>
        protected T GetEntityByTransaction(DBTransaction trans, SqlEntity sqlEntity)
        {
            _SqlEntity = sqlEntity;
            return GetEntityByTransaction(trans, sqlEntity.CommandText, sqlEntity.Parameters, Timeout);
        }

        /// <summary>
        /// 通过事务，获取表对象
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="filterParam">条件参数</param>
        /// <returns></returns>
        public T GetEntityByTransaction(DBTransaction trans, FilterParams filterParam)
        {
            return GetEntityByTransaction(trans, null, filterParam, null);
        }
        /// <summary>
        /// 通过事务，获取表对象
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <returns></returns>
        public T GetEntityByTransaction(DBTransaction trans, DisplayFields displayFields, FilterParams filterParam)
        {
            return GetEntityByTransaction(trans, displayFields, filterParam, null);
        }
        /// <summary>
        /// 通过事务，获取表对象
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <returns></returns>
        abstract public T GetEntityByTransaction(DBTransaction trans, DisplayFields displayFields, FilterParams filterParam, SortParams sortParams);

        /// <summary>
        /// 通过事务，获取表对象
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public T GetEntityByTransaction(DBTransaction trans, string sql, List<SqlParameter> parameters, int timeout)
        {
            SqlDataReader reader = trans.ExecuteReader(sql, parameters, timeout);
            try
            {
                if (reader.HasRows)
                    return GenerateEntity<T, TS>.CreateSingleEntity(reader);
                else
                    return null;
            }
            catch
            { throw; }
            finally
            {
                if (!reader.IsClosed)
                    reader.Close();
            }
        }
        #endregion

        #region Get List
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <returns></returns>
        public TS GetList()
        {
            return GetList(null, null, null, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="sqlEntity">SQL实体</param>
        /// <returns></returns>
        protected TS GetList(SqlEntity sqlEntity)
        {
            _SqlEntity = sqlEntity;
            return GetList(sqlEntity.CommandText, sqlEntity.Parameters, Timeout);
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <returns></returns>
        public TS GetList(DisplayFields displayFields)
        {
            return GetList(displayFields, null, null, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <returns></returns>
        public TS GetList(DisplayFields displayFields, FilterParams filterParam)
        {
            return GetList(displayFields, filterParam, null, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <returns></returns>
        public TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            return GetList(displayFields, filterParam, sortParams, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <returns></returns>
        abstract public TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount);

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public TS GetList(string sql, List<SqlParameter> parameters)
        {
            return GetList(sql, parameters, Timeout);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public TS GetList(string sql, List<SqlParameter> parameters, int timeout)
        {
            SqlDataReader reader = ExecuteReader(sql, parameters, timeout);
            try
            {
                if (reader.HasRows)
                    return GenerateEntity<T, TS>.CreateListEntity(reader);
                else
                    return new TS();
            }
            catch
            { throw; }
            finally
            {
                if (!reader.IsClosed)
                    reader.Close();
            }
        }

        /// <summary>
        /// 通过事务，获取表集合
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="sqlEntity">SQL实体</param>
        /// <returns></returns>
        protected TS GetListByTransaction(DBTransaction trans, SqlEntity sqlEntity)
        {
            _SqlEntity = sqlEntity;
            return GetListByTransaction(trans, sqlEntity.CommandText, sqlEntity.Parameters, Timeout);
        }
        /// <summary>
        /// 通过事务，获取表集合
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="displayFields">返回指定字段</param>
        /// <returns></returns>
        public TS GetListByTransaction(DBTransaction trans, DisplayFields displayFields)
        {
            return GetListByTransaction(trans, displayFields, null, null, null);
        }
        /// <summary>
        /// 通过事务，获取表集合
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <returns></returns>
        public TS GetListByTransaction(DBTransaction trans, DisplayFields displayFields, FilterParams filterParam)
        {
            return GetListByTransaction(trans, displayFields, filterParam, null, null);
        }
        /// <summary>
        /// 通过事务，获取表集合
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <returns></returns>
        public TS GetListByTransaction(DBTransaction trans, DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            return GetListByTransaction(trans, displayFields, filterParam, sortParams, null);
        }
        /// <summary>
        /// 通过事务，获取表集合
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <returns></returns>
        abstract public TS GetListByTransaction(DBTransaction trans, DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount);

        /// <summary>
        /// 通过事务，获取表集合
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public TS GetListByTransaction(DBTransaction trans, string sql, List<SqlParameter> parameters)
        {
            return GetListByTransaction(trans, sql, parameters, Timeout);
        }
        /// <summary>
        /// 通过事务，获取表集合
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public TS GetListByTransaction(DBTransaction trans, string sql, List<SqlParameter> parameters, int timeout)
        {
            if (trans != null)
            {
                SqlDataReader reader = trans.ExecuteReader(sql, parameters, timeout);
                try
                {
                    if (reader.HasRows)
                        return GenerateEntity<T, TS>.CreateListEntity(reader);
                    else
                        return null;
                }
                catch
                { throw; }
                finally
                {
                    if (!reader.IsClosed)
                        reader.Close();
                }
            }
            else
            {
                throw new Exception("Invalid DBTransaction");
            }
        }
        #endregion

        #region DataTable
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            return GetDataTable(null, null, null, null);
        }
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="sqlEntity">SQL实体</param>
        /// <param name="tableName">Data Table Name</param>
        /// <returns></returns>
        protected DataTable GetDataTable(SqlEntity sqlEntity, string tableName)
        {
            _SqlEntity = sqlEntity;
            return GetDataTable(sqlEntity.CommandText, sqlEntity.Parameters, tableName);
        }
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <returns></returns>
        public DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            return GetDataTable(displayFields, filterParam, sortParams, maxCount, string.Empty);
        }
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <returns></returns>
        abstract public DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount, string tableName);

        /// <summary>
        /// 通过事务，返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <returns></returns>
        public DataTable GetDataTableByTransaction(DBTransaction trans, DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            return GetDataTableByTransaction(trans, displayFields, filterParam, sortParams, maxCount, string.Empty);
        }
        /// <summary>
        /// 通过事务，返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <returns></returns>
        abstract public DataTable GetDataTableByTransaction(DBTransaction trans, DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount, string tableName);

        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, List<SqlParameter> parameters)
        {
            return GetDataTable(sql, parameters, string.Empty);
        }
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, List<SqlParameter> parameters, string tableName)
        {
            return GetDataTable(sql, parameters, tableName, Timeout);
        }
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, List<SqlParameter> parameters, string tableName, int timeout)
        {
            return GenerateEntity<T, TS>.CreateDataTable(ExecuteReader(sql, parameters, timeout), tableName);
        }

        /// <summary>
        /// 通过事务，返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="sqlEntity">SQL实体</param>
        /// <param name="tableName">Data Table Name</param>
        /// <returns></returns>
        protected DataTable GetDataTableByTransaction(DBTransaction trans, SqlEntity sqlEntity, string tableName)
        {
            _SqlEntity = sqlEntity;
            return GetDataTableByTransaction(trans, sqlEntity.CommandText, sqlEntity.Parameters, tableName);
        }
        /// <summary>
        /// 通过事务，返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        public DataTable GetDataTableByTransaction(DBTransaction trans, string sql, List<SqlParameter> parameters)
        {
            return GetDataTableByTransaction(trans, sql, parameters, string.Empty);
        }
        /// <summary>
        /// 通过事务，返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <returns></returns>
        public DataTable GetDataTableByTransaction(DBTransaction trans, string sql, List<SqlParameter> parameters, string tableName)
        {
            return GetDataTableByTransaction(trans, sql, parameters, tableName, Timeout);
        }
        /// <summary>
        /// 通过事务，返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="trans">事务实体</param>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        public DataTable GetDataTableByTransaction(DBTransaction trans, string sql, List<SqlParameter> parameters, string tableName, int timeout)
        {
            if (trans != null)
            {
                return GenerateEntity<T, TS>.CreateDataTable(trans.ExecuteReader(sql, parameters, timeout), tableName);
            }
            else
            {
                throw new Exception("Invalid DBTransaction");
            }
        }
        #endregion
    }
}
