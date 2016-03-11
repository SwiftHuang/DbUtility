using hwj.DBUtility.Interface;
using hwj.DBUtility.TableMapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
        #region Property

        /// <summary>
        ///
        /// </summary>
        protected static GenerateSelectSql<T> GenSelectSql = new GenerateSelectSql<T>();

        /// <summary>
        ///
        /// </summary>
        protected static GenerateUpdateSql<T> GenUpdateSql = new GenerateUpdateSql<T>();

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

        #endregion Property

        /// <summary>
        ///
        /// </summary>
        /// <param name="connectionString">数据连接字符串</param>
        protected internal DALDependency(string connectionString)
            : this(connectionString, 30, Enums.LockType.None)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="connectionString">数据连接字符串</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <param name="defaultLock">锁类型</param>
        protected internal DALDependency(string connectionString, int timeout, Enums.LockType defaultLock)
            : base(connectionString, timeout, defaultLock)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="lockType"></param>
        protected DALDependency(IConnection connection)
            : base(connection)
        {
            TableName = Activator.CreateInstance<T>().GetTableName();
        }

        #region Insert

        /// <summary>
        /// 执行插入数据
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        public bool Add(T entity)
        {
            try
            {
                SqlEntity tmpSqlEty = AddSqlEntity(entity);
                _SqlEntity = tmpSqlEty;
                return ExecuteSql(tmpSqlEty.CommandText, tmpSqlEty.Parameters) > 0;
            }
            catch (SqlException ex)
            {
                CheckSqlException(ref ex, entity);
                throw;
            }
        }

        /// <summary>
        /// 执行插入数据,并返回标识值
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public decimal AddReturnIdentity(T entity)
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
            catch (SqlException ex)
            {
                CheckSqlException(ref ex, entity);
                throw;
            }
        }

        /// <summary>
        /// 获取增加的Sql对象
        /// </summary>
        /// <param name="entity">Table对象</param>
        /// <returns>Sql对象</returns>
        public static SqlEntity AddSqlEntity(T entity)
        {
            return new SqlEntity(GenUpdateSql.InsertSql(entity), GenUpdateSql.GenParameter(entity), entity.GetTableName(), entity);
        }

        ///// <summary>
        ///// 执行插入数据
        ///// </summary>
        ///// <param name="trans">事务实体</param>
        ///// <param name="entity">数据实体</param>
        ///// <returns></returns>
        //public static bool Add(DbTransaction trans, T entity)
        //{
        //    return ExecuteSqlByTrans(trans, AddSqlEntity(entity));
        //}
        /// <summary>
        /// 获取最后一次自增ID
        /// </summary>
        /// <returns></returns>
        public Int64 GetInsertID()
        {
            return Convert.ToInt64(ExecuteScalar(GenUpdateSql.InsertLastIDSql()));
        }

        #endregion Insert

        #region Update

        /// <summary>
        /// 获取更新的Sql对象
        /// </summary>
        /// <param name="updateParam">需要更新的字段</param>
        /// <param name="filterParams">需要更新的条件</param>
        /// <returns>Sql对象</returns>
        public static SqlEntity UpdateSqlEntity(UpdateParam updateParam, FilterParams filterParams)
        {
            SqlEntity sqlEty = new SqlEntity();
            List<IDbDataParameter> up = new List<IDbDataParameter>();
            up.AddRange(GenUpdateSql.GenParameter(updateParam));
            up.AddRange(GenUpdateSql.GenParameter(filterParams));

            sqlEty = new SqlEntity();
            sqlEty.CommandText = GenUpdateSql.UpdateSql(TableName, updateParam, filterParams);
            sqlEty.Parameters = up;
            //if (EnableSqlLog)
            //    return InsertSqlLog(se, "UPDATE");
            //else
            return sqlEty;
        }

        /// <summary>
        /// 获取更新的Sql对象
        /// </summary>
        /// <param name="entity">需要Table对象</param>
        /// <param name="filterParams">被更新的条件</param>
        /// <returns>Sql对象</returns>
        public static SqlEntity UpdateSqlEntity(T entity, FilterParams filterParams)
        {
            SqlEntity se = new SqlEntity();
            se.CommandText = GenUpdateSql.UpdateSql(entity, filterParams);
            se.Parameters = GenUpdateSql.GenParameter(entity);
            if (filterParams != null)
            {
                se.Parameters.AddRange(GenUpdateSql.GenParameter(filterParams));
            }
            return se;
        }

        /// <summary>
        /// 执行数据更新
        /// </summary>
        /// <param name="param">更新字段</param>
        /// <returns></returns>
        public bool Update(UpdateParam param)
        {
            return Update(param, null);
        }

        /// <summary>
        /// 执行数据更新
        /// </summary>
        /// <param name="updateParam">更新字段</param>
        /// <param name="filterParams">更新条件</param>
        /// <returns></returns>
        public bool Update(UpdateParam updateParam, FilterParams filterParams)
        {
            SqlEntity tmpSqlEty = UpdateSqlEntity(updateParam, filterParams);
            _SqlEntity = tmpSqlEty;
            return ExecuteSql(tmpSqlEty.CommandText, tmpSqlEty.Parameters) > 0;
        }

        /// <summary>
        /// 执行数据更新
        /// </summary>
        /// <param name="entity">更新实体</param>
        /// <param name="filterParams">更新条件</param>
        /// <returns></returns>
        public bool Update(T entity, FilterParams filterParams)
        {
            try
            {
                SqlEntity tmpSqlEty = UpdateSqlEntity(entity, filterParams);
                _SqlEntity = tmpSqlEty;
                return ExecuteSql(tmpSqlEty.CommandText, tmpSqlEty.Parameters) > 0;
            }
            catch (SqlException ex)
            {
                CheckSqlException(ref ex, entity);
                throw;
            }
        }

        ///// <summary>
        ///// 执行数据更新
        ///// </summary>
        ///// <param name="trans">事务实体</param>
        ///// <param name="entity">更新实体</param>
        ///// <param name="filterParam">更新条件</param>
        ///// <returns></returns>
        //public static bool Update(DbTransaction trans, T entity, FilterParams filterParam)
        //{
        //    SqlEntity tmpSqlEty = UpdateSqlEntity(entity, filterParam);
        //    return ExecuteSqlByTrans(trans, tmpSqlEty);
        //}
        ///// <summary>
        ///// 执行数据更新
        ///// </summary>
        ///// <param name="trans">事务实体</param>
        ///// <param name="updateParam">更新字段</param>
        ///// <param name="filterParam">更新条件</param>
        ///// <returns></returns>
        //public static bool Update(DbTransaction trans, UpdateParam updateParam, FilterParams filterParam)
        //{
        //    SqlEntity tmpSqlEty = UpdateSqlEntity(updateParam, filterParam);
        //    return ExecuteSqlByTrans(trans, tmpSqlEty);
        //}

        #endregion Update

        #region Delete

        /// <summary>
        /// 获取删除的Sql对象
        /// </summary>
        /// <param name="filterParams">被删除的条件</param>
        /// <returns>Sql对象</returns>
        public static SqlEntity DeleteSqlEntity(FilterParams filterParams)
        {
            //if (EnableSqlLog)
            //    return InsertSqlLog(new SqlEntity(GenUpdateSql.DeleteSql(TableName, filterParam), GenUpdateSql.GenParameter(filterParam)), "DELETE");
            //else
            SqlEntity sqlEty = new SqlEntity();
            sqlEty.CommandText = GenUpdateSql.DeleteSql(TableName, filterParams);
            sqlEty.Parameters = GenUpdateSql.GenParameter(filterParams);

            return sqlEty;
        }

        /// <summary>
        /// 删除全部记录
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            return Delete(new FilterParams());
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="filterParams">删除条件</param>
        /// <returns></returns>
        public bool Delete(FilterParams filterParams)
        {
            SqlEntity tmpSqlEty = DeleteSqlEntity(filterParams);
            _SqlEntity = tmpSqlEty;
            return ExecuteSql(tmpSqlEty.CommandText, tmpSqlEty.Parameters) > 0;
        }

        /// <summary>
        /// 彻底清除表的内容(重置自动增量),请慎用
        /// </summary>
        /// <returns></returns>
        public bool Truncate()
        {
            if (ExecuteSql(GenUpdateSql.TruncateSql(TableName)) > 0)
                return true;
            else
                return false;
        }

        ///// <summary>
        ///// 删除记录
        ///// </summary>
        ///// <param name="trans">事务实体</param>
        ///// <returns></returns>
        //public static bool Delete(DbTransaction trans)
        //{
        //    return Delete(trans);
        //}
        ///// <summary>
        ///// 删除记录
        ///// </summary>
        ///// <param name="trans">事务实体</param>
        ///// <param name="filterParam">删除条件</param>
        ///// <returns></returns>
        //public static bool Delete(DbTransaction trans, FilterParams filterParam)
        //{
        //    SqlEntity tmpSqlEty = DeleteSqlEntity(filterParam);
        //    return ExecuteSqlByTrans(trans, tmpSqlEty);
        //}

        #endregion Delete

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

        #endregion Sql Log

        #region Get Entity

        /// <summary>
        /// 获取表对象的Sql对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="lockType">锁类型</param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static SqlEntity GetEntitySqlEntity(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, Enums.LockType lockType, int commandTimeout)
        {
            return GetEntitySqlEntity(displayFields, filterParams, sortParams, new List<Enums.LockType>() { lockType }, commandTimeout);
        }

        /// <summary>
        /// 获取表对象的Sql对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="lockTypes">锁类型</param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static SqlEntity GetEntitySqlEntity(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, List<Enums.LockType> lockTypes, int commandTimeout)
        {
            SqlEntity sqlEty = new SqlEntity();
            sqlEty.CommandTimeout = commandTimeout;
            sqlEty.LockType = lockTypes;
            sqlEty.CommandText = GenSelectSql.SelectSql(TableName, displayFields, filterParams, sortParams, 1, lockTypes);
            sqlEty.Parameters = GenSelectSql.GenParameter(filterParams);

            return sqlEty;
        }

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        public T GetEntity(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, Enums.LockType lockType)
        {
            return GetEntity(displayFields, filterParams, sortParams, new List<Enums.LockType>() { lockType });
        }

        /// <summary>
        /// 获取表对象
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="lockTypes">锁类型</param>
        /// <returns></returns>
        public override T GetEntity(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, List<Enums.LockType> lockTypes)
        {
            SqlEntity sqlEty = new SqlEntity();
            sqlEty = GetEntitySqlEntity(displayFields, filterParams, sortParams, lockTypes, InnerConnection.DefaultCommandTimeout);

            return base.GetEntity(sqlEty);
        }

        #endregion Get Entity

        #region Get List

        public static SqlEntity GetListSqlEntity(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, Enums.LockType lockType, int commandTimeout)
        {
            return GetListSqlEntity(displayFields, filterParams, sortParams, maxCount, new List<Enums.LockType>() { lockType }, commandTimeout);
        }

        public static SqlEntity GetListSqlEntity(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, List<Enums.LockType> lockTypes, int commandTimeout)
        {
            SqlEntity sqlEty = new SqlEntity();
            sqlEty.CommandTimeout = commandTimeout;
            sqlEty.LockType = lockTypes;
            sqlEty.CommandText = GenSelectSql.SelectSql(TableName, displayFields, filterParams, sortParams, maxCount, lockTypes);
            sqlEty.Parameters = GenSelectSql.GenParameter(filterParams);

            return sqlEty;
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="maxCount">返回最大记录数</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        public TS GetList(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, Enums.LockType lockType)
        {
            return GetList(displayFields, filterParams, sortParams, maxCount, new List<Enums.LockType>() { lockType });
        }

        /// <summary>
        /// 获取表集合
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">查询条件</param>
        /// <param name="sortParams">排序方式</param>
        /// <param name="maxCount">返回最大记录数</param>
        /// <param name="lockTypes">锁类型</param>
        /// <returns></returns>
        public override TS GetList(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, List<Enums.LockType> lockTypes)
        {
            SqlEntity sqlEty = new SqlEntity();
            sqlEty = GetListSqlEntity(displayFields, filterParams, sortParams, maxCount, lockTypes, InnerConnection.DefaultCommandTimeout);

            return base.GetList(sqlEty);
        }

        public List<C> GetList<C>(Enum displayField, FilterParams filterParams, SortParams sortParams, int? maxCount, Enums.LockType lockType)
        {
            List<C> lst = new List<C>();
            DisplayFields df = new DisplayFields(displayField);
            SqlEntity sqlEty = new SqlEntity();
            sqlEty = GetListSqlEntity(df, filterParams, sortParams, maxCount, lockType, InnerConnection.DefaultCommandTimeout);

            IDataReader reader = ExecuteReader(sqlEty.CommandText, sqlEty.Parameters, sqlEty.CommandTimeout);
            try
            {
                while (reader.Read())
                {
                    object obj = reader[0];
                    if (obj != null && reader[0] is System.DBNull == false)
                    {
                        lst.Add((C)reader[0]);
                    }
                }
                return lst;
            }
            catch { throw; }
            finally
            {
                if (!reader.IsClosed) reader.Close();
            }
        }

        #endregion Get List

        #region Get Page

        /// <summary>
        /// 获取分页对象(单主键,以主键作为排序,支持分组)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParams">筛选条件</param>
        /// <param name="sortParams">排序(只能填一个字段)</param>
        /// <param name="PK">分页依据</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        public TS GetPage3(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, DisplayFields PK, int pageNumber, int pageSize, out int TotalCount)
        {
            return GetPage3(displayFields, filterParams, sortParams, null, PK, pageNumber, pageSize, out TotalCount);
        }

        /// <summary>
        /// 获取分页对象(单主键,以主键作为排序,支持分组)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParams">筛选条件</param>
        /// <param name="sortParams">排序(只能填一个字段)</param>
        /// <param name="groupParam">分组条件</param>
        /// <param name="PK">分页依据</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        public TS GetPage3(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, GroupParams groupParam, DisplayFields PK, int pageNumber, int pageSize, out int TotalCount)
        {
            return GetPage3(displayFields, filterParams, sortParams, groupParam, PK, pageNumber, pageSize, InnerConnection.DefaultCommandTimeout, out TotalCount);
        }

        /// <summary>
        /// 获取分页对象(单主键,以主键作为排序,支持分组)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParams">筛选条件</param>
        /// <param name="sortParams">排序(只能填一个字段)</param>
        /// <param name="groupParam">分组条件</param>
        /// <param name="PK">分页依据</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="times">超时时间(秒)</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        public TS GetPage3(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, GroupParams groupParam, DisplayFields PK, int pageNumber, int pageSize, int times, out int TotalCount)
        {
            SqlEntity tmpSqlEty = GenSelectSql.GetGroupPageSqlEntity(TableName, displayFields, filterParams, sortParams, groupParam, PK, pageNumber, pageSize);
            tmpSqlEty.CommandTimeout = InnerConnection.DefaultCommandTimeout;
            tmpSqlEty.LockType = new List<Enums.LockType>() { Enums.LockType.NoLock };

            _SqlEntity = tmpSqlEty;

            TotalCount = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                DbHelper.PrepareCommand(cmd, conn, null, tmpSqlEty);
                SqlParameter sp = new SqlParameter("@_PTotalCount", DbType.Int32);
                sp.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sp);
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    if (reader.HasRows)
                    {
                        TS result = GenerateEntity.CreateListEntity<T, TS>(reader);
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
        /// <param name="filterParams">筛选条件</param>
        /// <param name="sortParams">排序</param>
        /// <param name="PK">主键</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        public TS GetPage(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, DisplayFields PK, int pageNumber, int pageSize, out int TotalCount)
        {
            return GetPage(displayFields, filterParams, sortParams, PK, pageNumber, pageSize, InnerConnection.DefaultCommandTimeout, out TotalCount);
        }

        /// <summary>
        /// 获取分页对象(支持多主键、多排序)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParams">筛选条件</param>
        /// <param name="sortParams">排序</param>
        /// <param name="PK">主键</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        public TS GetPage(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, DisplayFields PK, int pageNumber, int pageSize, int timeout, out int TotalCount)
        {
            SqlEntity tmpSqlEty = GenSelectSql.GetPageSqlEntity(TableName, displayFields, filterParams, sortParams, PK, pageNumber, pageSize);
            tmpSqlEty.CommandTimeout = timeout;
            tmpSqlEty.LockType = new List<Enums.LockType>() { Enums.LockType.NoLock };

            _SqlEntity = tmpSqlEty;

            TotalCount = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                DbHelper.PrepareCommand(cmd, conn, null, tmpSqlEty);
                SqlParameter sp = new SqlParameter("@_RecordCount", DbType.Int32);
                sp.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sp);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                try
                {
                    if (reader.HasRows)
                    {
                        TS result = GenerateEntity.CreateListEntity<T, TS>(reader);
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

        /// <summary>
        /// 获取分页对象(支持多主键、多排序)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParams">筛选条件</param>
        /// <param name="sortParams">排序</param>
        /// <param name="PK">主键</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        public DataTable GetPageForTable(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, DisplayFields PK, int pageNumber, int pageSize, out int TotalCount)
        {
            return GetPageForTable(displayFields, filterParams, sortParams, PK, pageNumber, pageSize, InnerConnection.DefaultCommandTimeout, out TotalCount);
        }

        /// <summary>
        /// 获取分页对象(支持多主键、多排序)
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParams">筛选条件</param>
        /// <param name="sortParams">排序</param>
        /// <param name="PK">主键</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <param name="TotalCount">返回记录数</param>
        /// <returns></returns>
        public DataTable GetPageForTable(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, DisplayFields PK, int pageNumber, int pageSize, int timeout, out int TotalCount)
        {
            SqlEntity tmpSqlEty = GenSelectSql.GetPageSqlEntity(TableName, displayFields, filterParams, sortParams, PK, pageNumber, pageSize);
            tmpSqlEty.CommandTimeout = timeout;
            tmpSqlEty.LockType = new List<Enums.LockType>() { Enums.LockType.NoLock };

            _SqlEntity = tmpSqlEty;

            TotalCount = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                DbHelper.PrepareCommand(cmd, conn, null, tmpSqlEty);
                SqlParameter sp = new SqlParameter("@_RecordCount", DbType.Int32);
                sp.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sp);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                try
                {
                    if (reader.HasRows)
                    {
                        DataTable result = GenerateEntity.CreateDataTable(reader, TableName);
                        reader.Close();
                        if (cmd.Parameters.Count > 0)
                            TotalCount = int.Parse(cmd.Parameters["@_RecordCount"].Value.ToString());
                        cmd.Parameters.Clear();
                        return result;
                    }
                    else
                        return new DataTable(TableName);
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

        #endregion Get Page

        #region Record Count

        /// <summary>
        /// 返回表的记录数
        /// </summary>
        /// <returns></returns>
        public int RecordCount()
        {
            return RecordCount(null);
        }

        /// <summary>
        /// 返回表的记录数
        /// </summary>
        /// <param name="filterParams">条件参数</param>
        /// <returns>记录数</returns>
        public int RecordCount(FilterParams filterParams)
        {
            SqlEntity sqlEty = new SqlEntity();
            sqlEty.CommandTimeout = InnerConnection.DefaultCommandTimeout;
            sqlEty.LockType = InnerConnection.SelectLock;
            sqlEty.CommandText = GenSelectSql.SelectCountSql(TableName, filterParams);
            sqlEty.Parameters = GenSelectSql.GenParameter(filterParams);

            _SqlEntity = sqlEty;
            return Convert.ToInt32(ExecuteScalar(sqlEty.CommandText, sqlEty.Parameters));
        }

        /// <summary>
        /// 返回表的记录数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">条件参数</param>
        /// <returns></returns>
        public int RecordCount(string sql, List<IDbDataParameter> parameters)
        {
            return Convert.ToInt32(ExecuteScalar(sql, parameters));
        }

        #endregion Record Count

        #region DataTable

        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <param name="lockType">锁类型</param>
        /// <returns></returns>
        public override DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, string tableName, Enums.LockType lockType)
        {
            return GetDataTable(displayFields, filterParams, sortParams, maxCount, tableName, new List<Enums.LockType>() { lockType });
        }

        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="displayFields">返回指定字段</param>
        /// <param name="filterParams">条件参数</param>
        /// <param name="sortParams">排序参数</param>
        /// <param name="maxCount">返回记录数</param>
        /// <param name="tableName">Data Table Name</param>
        /// <param name="lockTypes">锁类型</param>
        /// <returns></returns>
        public override DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParams, SortParams sortParams, int? maxCount, string tableName, List<Enums.LockType> lockTypes)
        {
            SqlEntity sqlEty = new SqlEntity();
            sqlEty.CommandTimeout = InnerConnection.DefaultCommandTimeout;
            sqlEty.LockType = base.InnerConnection.SelectLock;
            sqlEty.CommandText = GenSelectSql.SelectSql(TableName, displayFields, filterParams, sortParams, maxCount, lockTypes);
            sqlEty.Parameters = GenSelectSql.GenParameter(filterParams);

            return base.GetDataTable(sqlEty, tableName);
        }

        ///// <summary>
        ///// 通过事务，返回DataTable(建议用于Report或自定义列表)
        ///// </summary>
        ///// <param name="trans">事务实体</param>
        ///// <param name="displayFields">返回指定字段</param>
        ///// <param name="filterParam">条件参数</param>
        ///// <param name="sortParams">排序参数</param>
        ///// <param name="maxCount">返回记录数</param>
        ///// <param name="tableName">Data Table Name</param>
        ///// <returns></returns>
        //public override DataTable GetDataTableByTran(DbTransaction trans, DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount, string tableName)
        //{
        //    SqlEntity tmpSqlEty = new SqlEntity(GenSelectSql.SelectSql(TableName, displayFields, filterParam, sortParams, maxCount, Enums.LockType.RowLock), GenSelectSql.GenParameter(filterParam));
        //    return base.GetDataTableByTran(trans, tmpSqlEty, tableName);
        //}

        #endregion DataTable

        #region Private Member

        private static void CheckSqlException(ref SqlException e, T entity)
        {
            if ((e.Number == 8152 || e.Number == 8115) && entity != null)
            {
                string fieldStr = DbHelperSQL.FormatMsgFor8152(entity.GetTableName(), entity);
                Common.AddExData(e.Data, fieldStr);
            }
            //}
            //return null;
        }

        //private static bool ExecuteSqlByTrans(DbTransaction trans, SqlEntity sqlEntity)
        //{
        //    if (trans != null)
        //    {
        //        return trans.ExecuteSql(sqlEntity) > 0;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        #endregion Private Member

        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        /// <returns></returns>
        public override DateTime GetServerDateTime()
        {
            DateTime tmpDateTime = DateTime.MinValue;
            object tmp = ExecuteScalar(GenSelectSql.SelectServerDateTime());

            if (tmp != null)
                DateTime.TryParse(tmp.ToString(), out tmpDateTime);
            return tmpDateTime;
        }
    }
}