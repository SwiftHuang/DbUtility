using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility.MSSQL
{
    public abstract class BaseDAL<T, L>
        where T : BaseTable<T>, new()
        where L : List<T>, new()
    {
        protected static GenerateSql<T> GenSql = new GenerateSql<T>();

        #region Property
        protected SqlEntity _SqlEntity = null;
        public SqlEntity SqlEntity
        {
            get { return _SqlEntity; }
        }
        protected static string TableName { get; set; }
        private static bool _EnableSqlLog = false;
        public static bool EnableSqlLog { get { return _EnableSqlLog; } set { _EnableSqlLog = value; } }
        #endregion
        #region  Insert
        /// <summary>
        /// 执行插入数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(T entity)
        {
            _SqlEntity = AddSqlEntity(entity);
            if (DbHelper.ExecuteSql(SqlEntity.CommandText, SqlEntity.Parameters) > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 获取增加的Sql对象
        /// </summary>
        /// <param name="entity">Table对象</param>
        /// <returns>Sql对象</returns>
        public static SqlEntity AddSqlEntity(T entity)
        {
            if (EnableSqlLog)
                return InsertSqlLog(new SqlEntity(GenSql.InsertSql(entity), GenSql.GenParameter(entity)), "INSERT");
            else
                return new SqlEntity(GenSql.InsertSql(entity), GenSql.GenParameter(entity));
        }
        public Int64 GetInsertID()
        {
            return Convert.ToInt64(DbHelper.GetSingle(GenSql.InsertLastIDSql()));
        }
        #endregion

        #region Update
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
        /// 获取更新的Sql对象
        /// </summary>
        /// <param name="updateParam">需要更新的字段</param>
        /// <param name="filterParam">需要更新的条件</param>
        /// <returns>Sql对象</returns>
        public static SqlEntity UpdateSqlEntity(UpdateParam updateParam, FilterParams filterParam)
        {
            SqlEntity se = new SqlEntity();
            List<SqlParameter> sp = new List<SqlParameter>();
            sp.AddRange(GenSql.GenParameter(updateParam));
            sp.AddRange(GenSql.GenParameter(filterParam));
            se = new SqlEntity(GenSql.UpdateSql(updateParam, filterParam), sp);
            if (EnableSqlLog)
                return InsertSqlLog(se, "UPDATE");
            else
                return se;
        }
        public bool Update(UpdateParam updateParam, FilterParams filterParam)
        {
            _SqlEntity = UpdateSqlEntity(updateParam, filterParam);
            if (DbHelper.ExecuteSql(SqlEntity.CommandText, SqlEntity.Parameters) > 0)
                return true;
            else
                return false;
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
            se.CommandText = GenSql.UpdateSql(entity, filterParam);
            se.Parameters = GenSql.GenParameter(entity);
            se.Parameters.AddRange(GenSql.GenParameter(filterParam));
            if (EnableSqlLog)
                return InsertSqlLog(se, "UPDATE");
            else
                return se;
        }
        public bool Update(T entity, FilterParams filterParam)
        {
            _SqlEntity = UpdateSqlEntity(entity, filterParam);
            if (DbHelper.ExecuteSql(SqlEntity.CommandText, SqlEntity.Parameters) > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region Delete
        public bool Delete()
        {
            return Delete(null);
        }
        /// <summary>
        /// 获取删除的Sql对象
        /// </summary>
        /// <param name="filterParam">被删除的条件</param>
        /// <returns>Sql对象</returns>
        public static SqlEntity DeleteSqlEntity(FilterParams filterParam)
        {
            if (EnableSqlLog)
                return InsertSqlLog(new SqlEntity(GenSql.DeleteSql(filterParam), GenSql.GenParameter(filterParam)), "DELETE");
            else
                return new SqlEntity(GenSql.DeleteSql(filterParam), GenSql.GenParameter(filterParam));
        }
        public bool Delete(FilterParams filterParam)
        {
            _SqlEntity = DeleteSqlEntity(filterParam);
            if (DbHelper.ExecuteSql(SqlEntity.CommandText, SqlEntity.Parameters) > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 彻底清除表的内容(重置自动增量)
        /// </summary>
        /// <returns></returns>
        public bool Truncate()
        {
            if (DbHelper.ExecuteSql(GenSql.TruncateSql(TableName)) > 0)
                return true;
            else
                return false;
        }
        #endregion

        private const string SqlParamsFormat = "{0}={1}$";
        private const string InsertSqlLogFormat = "INSERT INTO tbSqlLog VALUES('{0}','{1}','{2}','{3}',getdate())";
        /// <summary>
        /// 记录Sql Log
        /// </summary>
        /// <param name="cmd"></param>
        private static SqlEntity InsertSqlLog(SqlEntity sqlEntity, string type)
        {
            try
            {
                DbHelper.ExecuteSql(string.Format(InsertSqlLogFormat, TableName, type, sqlEntity.CommandText, Params2String(sqlEntity)));
            }
            catch
            {
                throw;
            }
            return sqlEntity;
        }
        private static string Params2String(SqlEntity sqlEntity)
        {
            string s = "";
            foreach (SqlParameter p in sqlEntity.Parameters)
            {
                s += string.Format(SqlParamsFormat, p.ParameterName, p.Value);
            }
            return s;
        }

        #region Get Entity
        public T GetEntity()
        {
            return GetEntity(null);
        }
        public T GetEntity(FilterParams filterParam)
        {
            return GetEntity(null, filterParam, null);
        }
        public T GetEntity(DisplayFields displayFields, FilterParams filterParam)
        {
            return GetEntity(displayFields, filterParam, null);
        }
        public T GetEntity(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            _SqlEntity = new SqlEntity(GenSql.SelectSql(TableName, displayFields, filterParam, sortParams, 1), GenSql.GenParameter(filterParam));
            SqlDataReader reader = DbHelper.ExecuteReader(SqlEntity.CommandText, SqlEntity.Parameters);
            if (reader.HasRows)
                return CreateSingleEntity(reader);
            else
                return null;
        }
        #endregion

        #region Get List
        public L GetList()
        {
            return GetList(null, null, null, null);
        }
        public L GetList(DisplayFields displayFields)
        {
            return GetList(displayFields, null, null, null);
        }
        public L GetList(DisplayFields displayFields, FilterParams filterParam)
        {
            return GetList(displayFields, filterParam, null, null);
        }
        public L GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            return GetList(displayFields, filterParam, sortParams, null);
        }
        public L GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            _SqlEntity = new SqlEntity(GenSql.SelectSql(TableName, displayFields, filterParam, sortParams, maxCount), GenSql.GenParameter(filterParam));
            SqlDataReader reader = DbHelper.ExecuteReader(SqlEntity.CommandText, SqlEntity.Parameters);
            if (reader.HasRows)
                return CreateListEntity(reader);
            else
                return new L();
        }
        #endregion

        #region Get Page
        /// <summary>
        /// 获取分页对象
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParam">筛选条件</param>
        /// <param name="sortParams">排序(只能填一个字段)</param>
        /// <param name="PK">分页依据</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        public L GetListPage(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, DisplayFields PK, int pageNumber, int pageSize)
        {
            return GetListPage(displayFields, filterParam, sortParams, null, PK, pageNumber, pageSize);
        }
        /// <summary>
        /// 获取分页对象
        /// </summary>
        /// <param name="displayFields">显示字段</param>
        /// <param name="filterParam">筛选条件</param>
        /// <param name="sortParams">排序(只能填一个字段)</param>
        /// <param name="groupParam">分组条件</param>
        /// <param name="PK">分页依据</param>
        /// <param name="pageNumber">页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        public L GetListPage(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, GroupParams groupParam, DisplayFields PK, int pageNumber, int pageSize)
        {
            _SqlEntity = new SqlEntity();
            _SqlEntity.CommandText = GenSql.SelectPageSql(TableName, displayFields, filterParam, sortParams, groupParam, PK, pageNumber, pageSize);
            SqlDataReader reader = DbHelper.ExecuteReader(SqlEntity.CommandText);
            if (reader.HasRows)
                return CreateListEntity(reader);
            else
                return null;
        }
        #endregion

        #region Record Count
        /// <summary>
        /// 返回表的记录数
        /// </summary>
        /// <returns></returns>
        public UInt32 RecordCount()
        {
            return RecordCount(null);
        }
        /// <summary>
        /// 返回表的记录数
        /// </summary>
        /// <param name="whereParam">条件参数</param>
        /// <returns>记录数</returns>
        public UInt32 RecordCount(FilterParams filterParam)
        {
            _SqlEntity = new SqlEntity(GenSql.SelectCountSql(TableName, filterParam), GenSql.GenParameter(filterParam));
            return Convert.ToUInt32(DbHelper.GetSingle(SqlEntity.CommandText, SqlEntity.Parameters));
        }
        #endregion

        #region DataTable
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            _SqlEntity = new SqlEntity(GenSql.SelectSql(TableName, displayFields, filterParam, sortParams, maxCount), GenSql.GenParameter(filterParam));
            return CreateDataTable(DbHelper.ExecuteReader(SqlEntity.CommandText, SqlEntity.Parameters));
        }
        #endregion

        #region Protected Functions
        protected DataTable CreateDataTable(IDataReader reader)
        {
            try
            {
                DataTable dataTable = new DataTable();//建一个新的实例

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    DataColumn mydc = new DataColumn();//关键的一步
                    mydc.DataType = reader.GetFieldType(i);
                    mydc.ColumnName = reader.GetName(i);

                    dataTable.Columns.Add(mydc);//关键的第二步
                }

                while (reader.Read())
                {

                    DataRow mydr = dataTable.NewRow();//关键的第三步
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        mydr[i] = reader[i].ToString();
                    }

                    dataTable.Rows.Add(mydr);//关键的第四步
                    mydr = null;
                }
                return dataTable;//别忘了要返回datatable，否则出错
            }
            catch { throw; }
            finally { reader.Close(); }
        }
        protected T CreateSingleEntity(IDataReader reader)
        {
            try
            {
                IList<FieldMappingInfo> lstFieldInfo = new List<FieldMappingInfo>();
                lstFieldInfo = FieldMappingInfo.GetFieldMapping(typeof(T));
                lstFieldInfo = SetFieldIndex(reader, lstFieldInfo);

                reader.Read();
                return CreateEntityNotClose(reader, lstFieldInfo);
            }
            catch
            { throw; }
            finally
            { reader.Close(); }
        }
        protected L CreateListEntity(IDataReader reader)
        {
            try
            {
                L DataList = new L();
                IList<FieldMappingInfo> lstFieldInfo = new List<FieldMappingInfo>();
                lstFieldInfo = SetFieldIndex(reader, FieldMappingInfo.GetFieldMapping(typeof(T)));

                while (reader.Read())
                {
                    DataList.Add(CreateEntityNotClose(reader, lstFieldInfo));
                }
                return DataList;
            }
            catch
            {
                throw;
            }
            finally
            { reader.Close(); }
        }
        #endregion

        #region Private Functions
        private T CreateEntityNotClose(IDataReader reader, IList<FieldMappingInfo> lstFieldInfo)
        {
            T RowInstance = new T();
            RowInstance.UseAssigned = false;
            foreach (FieldMappingInfo f in lstFieldInfo)
            {
                try
                {
                    //取得当前数据库字段的顺序
                    if (f.FieldIndex != -1)
                    {
                        object obj = reader.GetValue(f.FieldIndex);
                        if (obj != DBNull.Value)
                            f.Property.SetValue(RowInstance, obj, null);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return RowInstance;
        }
        private IList<FieldMappingInfo> SetFieldIndex(IDataReader reader, IList<FieldMappingInfo> list)
        {
            IList<FieldMappingInfo> datalist = new List<FieldMappingInfo>();
            foreach (FieldMappingInfo f in list)
            {
                try
                {
                    f.FieldIndex = reader.GetOrdinal(f.FieldName);
                }
                catch (IndexOutOfRangeException)
                {
                    f.FieldIndex = -1;
                }
                datalist.Add(f);
            }
            return datalist;

        }
        #endregion
    }
}
