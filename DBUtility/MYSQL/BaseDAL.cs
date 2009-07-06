using System;
using System.Collections.Generic;
using System.Data;
using hwj.DBUtility.TableMapping;
using MySql.Data.MySqlClient;

namespace hwj.DBUtility.MYSQL
{
    public abstract class BaseDAL<T> where T : BaseTable, new()
    {
        GenerateSql<T> GenSql = new GenerateSql<T>();
        #region Property
        protected SqlEntity _SqlEntity = null;
        public SqlEntity SqlEntity
        {
            get { return _SqlEntity; }
        }
        protected string TableName { get; set; }
        #endregion

        public bool Add(T entity)
        {
            _SqlEntity = new SqlEntity(GenSql.InsertSql(entity), GenSql.GenParameter(entity));
            if (DbHelper.ExecuteSql(SqlEntity.Sql, SqlEntity.Parameters) > 0)
                return true;
            else
                return false;
        }
        public Int64 GetInsertID()
        {
            return Convert.ToInt64(DbHelper.GetSingle(GenSql.InsertLastIDSql()));
        }

        public bool Update(UpdateParam param)
        {
            return Update(param, null);
        }
        public bool Update(UpdateParam updateParam, FilterParams whereParam)
        {
            List<MySqlParameter> sp = new List<MySqlParameter>();
            sp.AddRange(GenSql.GenParameter(updateParam));
            sp.AddRange(GenSql.GenParameter(whereParam));
            _SqlEntity = new SqlEntity(GenSql.UpdateSql(TableName, updateParam, whereParam), sp);
            if (DbHelper.ExecuteSql(SqlEntity.Sql, SqlEntity.Parameters) > 0)
                return true;
            else
                return false;
        }
        public void Update(T entity, FilterParams filterParams)
        {
            _SqlEntity.Sql = GenSql.UpdateSql(entity, filterParams);
            _SqlEntity.Parameters = GenSql.GenParameter(entity);
            _SqlEntity.Parameters.AddRange(GenSql.GenParameter(filterParams));
            DbHelper.ExecuteSql(SqlEntity.Sql, SqlEntity.Parameters);
        }

        public bool Delete()
        {
            return Delete(null);
        }
        public bool Delete(FilterParams whereParam)
        {
            _SqlEntity = new SqlEntity(GenSql.DeleteSql(TableName, whereParam), GenSql.GenParameter(whereParam));
            if (DbHelper.ExecuteSql(SqlEntity.Sql, SqlEntity.Parameters) > 0)
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

        public T GetEntity()
        {
            return GetEntity(null);
        }
        public T GetEntity(FilterParams whereParam)
        {
            return GetEntity(null, whereParam);
        }
        public T GetEntity(DisplayFields selectFields, FilterParams whereParam)
        {
            _SqlEntity = new SqlEntity(GenSql.SelectSql(TableName, selectFields, whereParam, null, 1), GenSql.GenParameter(whereParam));
            MySqlDataReader reader = DbHelper.ExecuteReader(SqlEntity.Sql, SqlEntity.Parameters);
            if (reader.HasRows)
                return CreateSingleEntity(reader);
            else
                return null;
        }

        public List<T> GetList()
        {
            return GetList(null, null, null, null);
        }
        public List<T> GetList(DisplayFields selectFields)
        {
            return GetList(selectFields, null, null, null);
        }
        public List<T> GetList(DisplayFields selectFields, FilterParams whereParam)
        {
            return GetList(selectFields, whereParam, null, null);
        }
        public List<T> GetList(DisplayFields selectFields, FilterParams whereParam, SortParams orderParam)
        {
            return GetList(selectFields, whereParam, orderParam, null);
        }
        public List<T> GetList(DisplayFields selectFields, FilterParams whereParam, SortParams orderParam, int? maxCount)
        {
            _SqlEntity = new SqlEntity(GenSql.SelectSql(TableName, selectFields, whereParam, orderParam, maxCount), GenSql.GenParameter(whereParam));
            MySqlDataReader reader = DbHelper.ExecuteReader(SqlEntity.Sql, SqlEntity.Parameters);
            if (reader.HasRows)
                return CreateListEntity(reader);
            else
                return null;
        }

        //public List<T> GetListPage(DisplayFields selectFields, FilterParam whereParam, SortFields orderParam, DisplayFields PK, int pageNumber, int pageSize)
        //{
        //    return GetListPage(selectFields, whereParam, orderParam, null, PK, pageNumber, pageSize);
        //}
        //public List<T> GetListPage(DisplayFields selectFields, FilterParam whereParam, SortFields orderParam, DisplayFields groupParam, DisplayFields PK, int pageNumber, int pageSize)
        //{
        //    _SqlEntity.Sql = GenSql.SelectPageSql(TableName, selectFields, whereParam, orderParam, groupParam, PK, pageNumber, pageSize);
        //    SqlDataReader reader = DbHelper.ExecuteReader(SqlEntity.Sql);
        //    if (reader.HasRows)
        //        return CreateListEntity(reader);
        //    else
        //        return null;
        //}

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
        public UInt32 RecordCount(FilterParams whereParam)
        {
            _SqlEntity = new SqlEntity(GenSql.SelectCountSql(TableName, whereParam), null);
            return Convert.ToUInt32(DbHelper.GetSingle(SqlEntity.Sql));
        }
        #endregion

        #region DataTable
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable(DisplayFields selectFields, FilterParams whereParam, SortParams orderParam, int? maxCount)
        {
            _SqlEntity = new SqlEntity(GenSql.SelectSql(TableName, selectFields, whereParam, orderParam, maxCount), GenSql.GenParameter(whereParam));
            return CreateDataTable(DbHelper.ExecuteReader(SqlEntity.Sql, SqlEntity.Parameters));
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
        protected List<T> CreateListEntity(IDataReader reader)
        {
            try
            {
                List<T> DataList = new List<T>();
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
