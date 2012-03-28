using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility.MSSQL
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TS"></typeparam>
    public abstract class DALDependency<T, TS> : BaseDataAccess<T, TS>
        where T : BaseTable<T>, new()
        where TS : List<T>, new()
    {
        /// <summary>
        /// 
        /// </summary>
        protected static GenerateSelectSql<T> GenSelectSql = new GenerateSelectSql<T>();
        /// <summary>
        /// 
        /// </summary>
        protected static GenerateUpdateSql<T> GenUpdateSql = new GenerateUpdateSql<T>();

        #region Property
        private static string _TableName;
        protected static string TableName
        {
            get
            {
                if (_TableName == null)
                {
                    T t = new T();
                    _TableName = t.GetTableName();
                }
                return _TableName;
            }
            set { _TableName = value; }
        }
        //private static bool _EnableSqlLog = false;
        //public static bool EnableSqlLog
        //{
        //    get { return _EnableSqlLog; }
        //    set { _EnableSqlLog = value; }
        //}
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">数据连接字符串</param>
        protected DALDependency(string connectionString)
            : base(connectionString)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString">数据连接字符串</param>
        /// <param name="timeout">超时时间(秒)</param>
        protected DALDependency(string connectionString, int timeout)
            : base(connectionString, timeout)
        {

        }

        #region Insert
        /// <summary>
        /// 执行插入数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected bool Add(T entity)
        {
            try
            {
                SqlEntity tmpSqlEty = AddSqlEntity(entity);
                _SqlEntity = tmpSqlEty;
                return ExecuteSql(tmpSqlEty.CommandText, tmpSqlEty.Parameters) > 0;
            }
            catch (Exception ex)
            {
                Exception newEx = CheckSqlException(ex, entity);
                if (newEx != null)
                {
                    throw newEx;
                }
                else
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// 执行插入数据,并返回标识值
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected decimal AddReturnIdentity(T entity)
        {
            try
            {
                SqlEntity tmpSqlEty = AddSqlEntity(entity);
                _SqlEntity = tmpSqlEty;
                object obj = ExecuteScalar(string.Format("{0}SELECT SCOPE_IDENTITY() as 'SCOPE_IDENTITY()';", tmpSqlEty.CommandText), tmpSqlEty.Parameters);
                if (obj is decimal)
                {
                    return (decimal)obj;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Exception newEx = CheckSqlException(ex, entity);
                if (newEx != null)
                {
                    throw newEx;
                }
                else
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// 获取增加的Sql对象
        /// </summary>
        /// <param name="entity">Table对象</param>
        /// <returns>Sql对象</returns>
        public static SqlEntity AddSqlEntity(T entity)
        {
            //if (EnableSqlLog)
            //    return InsertSqlLog(new SqlEntity(GenUpdateSql.InsertSql(entity), GenUpdateSql.GenParameter(entity)), "INSERT");
            //else
            return new SqlEntity(GenUpdateSql.InsertSql(entity), GenUpdateSql.GenParameter(entity), entity.GetTableName(), entity);
        }
        /// <summary>
        /// 获取最后一次自增ID
        /// </summary>
        /// <returns></returns>
        protected Int64 GetInsertID()
        {
            return Convert.ToInt64(ExecuteScalar(GenUpdateSql.InsertLastIDSql()));
        }
        #endregion

        #region Update
        /// <summary>
        /// 获取更新的Sql对象
        /// </summary>
        /// <param name="updateParam">需要更新的字段</param>
        /// <param name="filterParam">需要更新的条件</param>
        /// <returns>Sql对象</returns>
        public static SqlEntity UpdateSqlEntity(UpdateParam updateParam, FilterParams filterParam)
        {
            SqlEntity se = new SqlEntity();
            List<SqlParameter> sp = new List<SqlParameter>();
            sp.AddRange(GenUpdateSql.GenParameter(updateParam));
            sp.AddRange(GenUpdateSql.GenParameter(filterParam));
            se = new SqlEntity(GenUpdateSql.UpdateSql(TableName, updateParam, filterParam), sp);
            //if (EnableSqlLog)
            //    return InsertSqlLog(se, "UPDATE");
            //else
            return se;
        }
        /// <summary>
        /// 获取更新的Sql对象
        /// </summary>
        /// <param name="entity">需要Table对象</param>
        /// <param name="filterParam">被更新的条件</param>
        /// <returns>Sql对象</returns>
        public static SqlEntity UpdateSqlEntity(T entity, FilterParams filterParam)
        {
            SqlEntity se = new SqlEntity();
            se.CommandText = GenUpdateSql.UpdateSql(entity, filterParam);
            se.Parameters = GenUpdateSql.GenParameter(entity);
            if (filterParam != null)
                se.Parameters.AddRange(GenUpdateSql.GenParameter(filterParam));
            //if (EnableSqlLog)
            //    return InsertSqlLog(se, "UPDATE");
            //else
            return se;
        }

        /// <summary>
        /// 执行数据更新
        /// </summary>
        /// <param name="param">更新字段</param>
        /// <returns></returns>
        protected bool Update(UpdateParam param)
        {
            return Update(param, null);
        }
        /// <summary>
        /// 执行数据更新
        /// </summary>
        /// <param name="updateParam">更新字段</param>
        /// <param name="filterParam">更新条件</param>
        /// <returns></returns>
        protected bool Update(UpdateParam updateParam, FilterParams filterParam)
        {
            //_SqlEntity = UpdateSqlEntity(updateParam, filterParam);
            SqlEntity tmpSqlEty = UpdateSqlEntity(updateParam, filterParam);
            _SqlEntity = tmpSqlEty;
            return ExecuteSql(tmpSqlEty.CommandText, tmpSqlEty.Parameters) > 0;
        }
        /// <summary>
        /// 执行数据更新
        /// </summary>
        /// <param name="entity">更新实体</param>
        /// <param name="filterParam">更新条件</param>
        /// <returns></returns>
        protected bool Update(T entity, FilterParams filterParam)
        {
            try
            {
                //_SqlEntity = UpdateSqlEntity(entity, filterParam);
                SqlEntity tmpSqlEty = UpdateSqlEntity(entity, filterParam);
                _SqlEntity = tmpSqlEty;
                return ExecuteSql(tmpSqlEty.CommandText, tmpSqlEty.Parameters) > 0;
            }
            catch (Exception ex)
            {
                Exception newEx = CheckSqlException(ex, entity);
                if (newEx != null)
                {
                    throw newEx;
                }
                else
                {
                    throw;
                }
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// 获取删除的Sql对象
        /// </summary>
        /// <param name="filterParam">被删除的条件</param>
        /// <returns>Sql对象</returns>
        public static SqlEntity DeleteSqlEntity(FilterParams filterParam)
        {
            //if (EnableSqlLog)
            //    return InsertSqlLog(new SqlEntity(GenUpdateSql.DeleteSql(TableName, filterParam), GenUpdateSql.GenParameter(filterParam)), "DELETE");
            //else
            return new SqlEntity(GenUpdateSql.DeleteSql(TableName, filterParam), GenUpdateSql.GenParameter(filterParam));
        }

        /// <summary>
        /// 删除全部记录
        /// </summary>
        /// <returns></returns>
        protected bool Delete()
        {
            return Delete(null);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="filterParam">删除条件</param>
        /// <returns></returns>
        protected bool Delete(FilterParams filterParam)
        {
            //_SqlEntity = DeleteSqlEntity(filterParam);
            SqlEntity tmpSqlEty = DeleteSqlEntity(filterParam);
            _SqlEntity = tmpSqlEty;
            return ExecuteSql(tmpSqlEty.CommandText, tmpSqlEty.Parameters) > 0;
        }

        /// <summary>
        /// 彻底清除表的内容(重置自动增量),请慎用
        /// </summary>
        /// <returns></returns>
        protected bool Truncate()
        {
            if (ExecuteSql(GenUpdateSql.TruncateSql(TableName)) > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region Sql Log
        //private const string SqlParamsFormat = "{0}={1}$";
        //private const string InsertSqlLogFormat = "INSERT INTO tbSqlLog VALUES(@Table,@Type,@SQL,@Param,getdate())";
        ///// <summary>
        ///// 记录Sql Log
        ///// </summary>
        ///// <param name="cmd"></param>
        //private static SqlEntity InsertSqlLog(SqlEntity sqlEntity, string type)
        //{
        //    try
        //    {
        //        List<SqlParameter> lstP = new List<SqlParameter>();
        //        lstP.Add(new SqlParameter("@Table", TableName));
        //        lstP.Add(new SqlParameter("@Type", type));
        //        lstP.Add(new SqlParameter("@SQL", sqlEntity.CommandText));
        //        lstP.Add(new SqlParameter("@Param", Params2String(sqlEntity)));

        //        DbHelper.ExecuteSql(InsertSqlLogFormat, lstP);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return sqlEntity;
        //}
        //private static string Params2String(SqlEntity sqlEntity)
        //{
        //    if (sqlEntity.Parameters != null)
        //    {
        //        string s = "";
        //        foreach (SqlParameter p in sqlEntity.Parameters)
        //        {
        //            s += string.Format(SqlParamsFormat, p.ParameterName, p.Value);
        //        }
        //        return s;
        //    }
        //    else
        //        return string.Empty;
        //}
        #endregion

        #region Get Entity
        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        /// <returns></returns>
        protected DateTime GetServerDateTime()
        {
            DateTime tmpDateTime = DateTime.MinValue;
            object tmp = ExecuteScalar(GenSelectSql.SelectServerDateTime());

            if (tmp != null)
                DateTime.TryParse(tmp.ToString(), out tmpDateTime);
            return tmpDateTime;
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <returns></returns>
        protected T GetEntity()
        {
            return GetEntity(null);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="filterParam">查询条件</param>
        /// <returns></returns>
        protected T GetEntity(FilterParams filterParam)
        {
            return GetEntity(null, filterParam, null);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <returns></returns>
        protected T GetEntity(DisplayFields displayFields, FilterParams filterParam)
        {
            return GetEntity(displayFields, filterParam, null);
        }
        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <returns></returns>
        protected T GetEntity(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            SqlEntity tmpSqlEty = new SqlEntity(GenSelectSql.SelectSql(TableName, displayFields, filterParam, sortParams, 1), GenSelectSql.GenParameter(filterParam));
            _SqlEntity = tmpSqlEty;

            return base.GetEntity(tmpSqlEty.CommandText, tmpSqlEty.Parameters);
        }

        #endregion

        #region Get List
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <returns></returns>
        protected TS GetList()
        {
            return GetList(null, null, null, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <returns></returns>
        protected TS GetList(DisplayFields displayFields)
        {
            return GetList(displayFields, null, null, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <returns></returns>
        protected TS GetList(DisplayFields displayFields, FilterParams filterParam)
        {
            return GetList(displayFields, filterParam, null, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <returns></returns>
        protected TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            return GetList(displayFields, filterParam, sortParams, null);
        }
        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParam">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="maxCount">返回最大记录数</param>
        /// <returns></returns>
        protected TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            SqlEntity tmpSqlEty = new SqlEntity(GenSelectSql.SelectSql(TableName, displayFields, filterParam, sortParams, maxCount), GenSelectSql.GenParameter(filterParam));
            _SqlEntity = tmpSqlEty;
            return base.GetList(tmpSqlEty.CommandText, tmpSqlEty.Parameters);
        }

        #endregion

        #region Get Page
        /// <summary>
        /// 获取分页对象(单主键,以主键作为排序,支持分组)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParam">筛选条件</param>
        /// <param name="sortParams">排序(只能填一个字段)</param>
        /// <param name="PK">分页依据</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        protected TS GetPage3(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, DisplayFields PK, int pageNumber, int pageSize, out int TotalCount)
        {
            return GetPage3(displayFields, filterParam, sortParams, null, PK, pageNumber, pageSize, out TotalCount);
        }
        /// <summary>
        /// 获取分页对象(单主键,以主键作为排序,支持分组)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParam">筛选条件</param>
        /// <param name="sortParams">排序(只能填一个字段)</param>
        /// <param name="groupParam">分组条件</param>
        /// <param name="PK">分页依据</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        protected TS GetPage3(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, GroupParams groupParam, DisplayFields PK, int pageNumber, int pageSize, out int TotalCount)
        {
            return GetPage3(displayFields, filterParam, sortParams, groupParam, PK, pageNumber, pageSize, Timeout, out TotalCount);
        }
        /// <summary>
        /// 获取分页对象(单主键,以主键作为排序,支持分组)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParam">筛选条件</param>
        /// <param name="sortParams">排序(只能填一个字段)</param>
        /// <param name="groupParam">分组条件</param>
        /// <param name="PK">分页依据</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="times">超时时间(秒)</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        protected TS GetPage3(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, GroupParams groupParam, DisplayFields PK, int pageNumber, int pageSize, int times, out int TotalCount)
        {
            //_SqlEntity = GenSelectSql.GetGroupPageSqlEntity(TableName, displayFields, filterParam, sortParams, groupParam, PK, pageNumber, pageSize);
            SqlEntity tmpSqlEty = GenSelectSql.GetGroupPageSqlEntity(TableName, displayFields, filterParam, sortParams, groupParam, PK, pageNumber, pageSize);
            _SqlEntity = tmpSqlEty;

            TotalCount = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                DbHelper.PrepareCommand(cmd, conn, null, tmpSqlEty.CommandText, tmpSqlEty.Parameters, times);
                SqlParameter sp = new SqlParameter("@_PTotalCount", DbType.Int32);
                sp.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sp);
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (reader.HasRows)
                    {
                        TS result = GenerateEntity<T, TS>.CreateListEntity(reader);
                        reader.Close();
                        if (cmd.Parameters.Count > 0)
                            TotalCount = int.Parse(cmd.Parameters["@_PTotalCount"].Value.ToString());
                        cmd.Parameters.Clear();
                        return result;
                    }
                    else
                        return new TS();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (!reader.IsClosed)
                        reader.Close();
                }
            }
        }

        /// <summary>
        /// 获取分页对象(支持多主键、多排序)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParam">筛选条件</param>
        /// <param name="sortParams">排序</param>
        /// <param name="PK">主键</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        protected TS GetPage(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, DisplayFields PK, int pageNumber, int pageSize, out int TotalCount)
        {
            return GetPage(displayFields, filterParam, sortParams, PK, pageNumber, pageSize, Timeout, out TotalCount);
        }
        /// <summary>
        /// 获取分页对象(支持多主键、多排序)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParam">筛选条件</param>
        /// <param name="sortParams">排序</param>
        /// <param name="PK">主键</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        protected TS GetPage(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, DisplayFields PK, int pageNumber, int pageSize, int timeout, out int TotalCount)
        {
            //_SqlEntity = GenSelectSql.GetPageSqlEntity(TableName, displayFields, filterParam, sortParams, PK, pageNumber, pageSize);
            SqlEntity tmpSqlEty = GenSelectSql.GetPageSqlEntity(TableName, displayFields, filterParam, sortParams, PK, pageNumber, pageSize);
            _SqlEntity = tmpSqlEty;

            TotalCount = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                DbHelper.PrepareCommand(cmd, conn, null, tmpSqlEty.CommandText, tmpSqlEty.Parameters, timeout);
                SqlParameter sp = new SqlParameter("@_RecordCount", DbType.Int32);
                sp.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sp);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                try
                {
                    if (reader.HasRows)
                    {
                        TS result = GenerateEntity<T, TS>.CreateListEntity(reader);
                        reader.Close();
                        if (cmd.Parameters.Count > 0)
                            TotalCount = int.Parse(cmd.Parameters["@_RecordCount"].Value.ToString());
                        cmd.Parameters.Clear();
                        return result;
                    }
                    else
                        return new TS();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (!reader.IsClosed)
                        reader.Close();
                }
            }
        }
        #endregion

        #region Record Count
        /// <summary>
        /// 返回表的记录数
        /// </summary>
        /// <returns></returns>
        protected int RecordCount()
        {
            return RecordCount(null);
        }
        /// <summary>
        /// 返回表的记录数
        /// </summary>
        /// <param name="filterParam">条件参数</param>
        /// <returns>记录数</returns>
        protected int RecordCount(FilterParams filterParam)
        {
            //_SqlEntity = new SqlEntity(GenSelectSql.SelectCountSql(TableName, filterParam), GenSelectSql.GenParameter(filterParam));
            SqlEntity tmpSqlEty = new SqlEntity(GenSelectSql.SelectCountSql(TableName, filterParam), GenSelectSql.GenParameter(filterParam));
            _SqlEntity = tmpSqlEty;
            return Convert.ToInt32(ExecuteScalar(tmpSqlEty.CommandText, tmpSqlEty.Parameters));
        }
        /// <summary>
        /// 返回表的记录数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">条件参数</param>
        /// <returns></returns>
        protected int RecordCount(string sql, List<SqlParameter> parameters)
        {
            return Convert.ToInt32(ExecuteScalar(sql, parameters));
        }
        #endregion

        #region DataTable
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <returns></returns>
        protected DataTable GetDataTable()
        {
            return GetDataTable(null, null, null, null);
        }
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="displayFields"></param>
        /// <param name="filterParam"></param>
        /// <param name="sortParams"></param>
        /// <param name="maxCount"></param>
        /// <returns></returns>
        protected DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            return GetDataTable(displayFields, filterParam, sortParams, maxCount, string.Empty);
        }

        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="displayFields"></param>
        /// <param name="filterParam"></param>
        /// <param name="sortParams"></param>
        /// <param name="maxCount"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        protected DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount, string tableName)
        {
            SqlEntity tmpSqlEty = new SqlEntity(GenSelectSql.SelectSql(TableName, displayFields, filterParam, sortParams, maxCount), GenSelectSql.GenParameter(filterParam));
            _SqlEntity = tmpSqlEty;
            return GetDataTable(tmpSqlEty.CommandText, tmpSqlEty.Parameters, tableName);
        }

        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        protected DataTable GetDataTable(string sql, List<SqlParameter> cmdParams)
        {
            return GetDataTable(sql, cmdParams, string.Empty);
        }
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="cmdParams">SQL参数</param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        protected DataTable GetDataTable(string sql, List<SqlParameter> cmdParams, string tableName)
        {
            return GetDataTable(sql, cmdParams, tableName, Timeout);
        }
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="cmdParams">SQL参数</param>
        /// <param name="tableName"></param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns></returns>
        protected DataTable GetDataTable(string sql, List<SqlParameter> cmdParams, string tableName, int timeout)
        {
            return GenerateEntity<T, TS>.CreateDataTable(ExecuteReader(sql, cmdParams, timeout), tableName);
        }
        #endregion

        private static Exception CheckSqlException(Exception e, T entity)
        {
            if (e is SqlException)
            {
                int num = ((SqlException)e).Number;
                if ((num == 8152 || num == 8115) && entity != null)
                {
                    return DbHelperSQL.Check8152(e, entity.GetTableName(), entity);
                }
            }
            return null;
        }


    }
}
