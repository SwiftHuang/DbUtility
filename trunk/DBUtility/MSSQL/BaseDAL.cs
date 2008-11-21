using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility.MSSQL
{
    public abstract class BaseDAL<T> where T : class, new()
    {
        protected DBUtility.MSSQL.GenerateSql<T> GenSql = new GenerateSql<T>();

        #region Property
        private string _sql;
        private SqlEntity _sqlEntity = new SqlEntity();
        public SqlEntity SqlEntity { get { return _sqlEntity; } }
        protected string TableName { get; set; }
        #endregion

        public bool Add(T entity)
        {
            _sqlEntity.Sql = GenSql.InsertSql(entity);
            _sqlEntity.Params = GenSql.GetParameter(entity);
            if (DbHelperSQL.ExecuteSql(_sqlEntity.Sql, _sqlEntity.Params) > 0)
                return true;
            else
                return false;
        }
        public Int64 GetInsertID()
        {
            return Convert.ToInt64(DbHelperSQL.GetSingle(GenSql.InsertLastIDSql()));
        }

        public bool Update(UpdateParam param)
        {
            return Update(param, null);
        }
        public bool Update(UpdateParam updateParam, WhereParam whereParam)
        {
            _sqlEntity.Sql = GenSql.UpdateSql(updateParam, whereParam);
            _sqlEntity.Params = GenSql.GetParameter(updateParam);
            _sqlEntity.Params.AddRange(GenSql.GetParameter(whereParam));
            if (DbHelperSQL.ExecuteSql(_sqlEntity.Sql, _sqlEntity.Params) > 0)
                return true;
            else
                return false;
        }
        public void Update(T entity, WhereParam whereParam, params Enum[] notUpdateParam)
        {
            _sql = GenSql.UpdateSql(entity, whereParam, notUpdateParam);
            DbHelperSQL.ExecuteSql(_sql);
        }

        public bool Delete()
        {
            return Delete(null);
        }
        public bool Delete(WhereParam whereParam)
        {
            _sql = GenSql.DeleteSql(whereParam);
            if (DbHelperSQL.ExecuteSql(_sql) > 0)
                return true;
            else
                return false;
        }

        public T GetEntity()
        {
            return GetEntity(null);
        }
        public T GetEntity(WhereParam whereParam)
        {
            return GetEntity(null, whereParam);
        }
        public T GetEntity(SelectFields selectFields, WhereParam whereParam)
        {
            _sqlEntity.Sql = GenSql.SelectSql(TableName, selectFields, whereParam, null, 1);
            _sqlEntity.Params = GenSql.GetParameter(whereParam);
            SqlDataReader reader = DbHelperSQL.ExecuteReader(_sqlEntity.Sql, _sqlEntity.Params);
            if (reader.HasRows)
                return CreateSingleEntity(reader);
            else
                return null;
        }

        public List<T> GetList()
        {
            return GetList(null, null, null, null);
        }
        public List<T> GetList(SelectFields selectFields)
        {
            return GetList(selectFields, null, null, null);
        }
        public List<T> GetList(SelectFields selectFields, WhereParam whereParam)
        {
            return GetList(selectFields, whereParam, null, null);
        }
        public List<T> GetList(SelectFields selectFields, WhereParam whereParam, OrderFields orderParam)
        {
            return GetList(selectFields, whereParam, orderParam, null);
        }
        public List<T> GetList(SelectFields selectFields, WhereParam whereParam, OrderFields orderParam, int? maxCount)
        {
            _sqlEntity.Sql = GenSql.SelectSql(TableName, selectFields, whereParam, orderParam, maxCount);
            _sqlEntity.Params = GenSql.GetParameter(whereParam);
            SqlDataReader reader = DbHelperSQL.ExecuteReader(_sqlEntity.Sql, _sqlEntity.Params);
            if (reader.HasRows)
                return CreateListEntity(reader);
            else
                return null;
        }

        public List<T> GetListPage(SelectFields selectFields, WhereParam whereParam, OrderFields orderParam, SelectFields PK, int pageNumber, int pageSize)
        {
            return GetListPage(selectFields, whereParam, orderParam, null, PK, pageNumber, pageSize);
        }
        public List<T> GetListPage(SelectFields selectFields, WhereParam whereParam, OrderFields orderParam, SelectFields groupParam, SelectFields PK, int pageNumber, int pageSize)
        {
            _sql = GenSql.SelectPageSql(TableName, selectFields, whereParam, orderParam, groupParam, PK, pageNumber, pageSize);
            SqlDataReader reader = DbHelperSQL.ExecuteReader(_sql);
            if (reader.HasRows)
                return CreateListEntity(reader);
            else
                return null;
        }

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
        public UInt32 RecordCount(WhereParam whereParam)
        {
            _sql = GenSql.SelectCountSql(TableName, whereParam);
            return Convert.ToUInt32(DbHelperSQL.GetSingle(_sql));
        }
        #endregion

        #region DataTable
        /// <summary>
        /// 返回DataTable(建议用于Report或自定义列表)
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable(SelectFields selectFields, WhereParam whereParam, OrderFields orderParam, int? maxCount)
        {
            _sql = GenSql.SelectSql(TableName, selectFields, whereParam, orderParam, maxCount);
            return CreateDataTable(DbHelperSQL.ExecuteReader(_sql));
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

                lstFieldInfo = FieldMappingInfo.GetFieldMapping(typeof(T));
                lstFieldInfo = SetFieldIndex(reader, lstFieldInfo);

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
                        {
                            f.Property.SetValue(RowInstance, obj, null);
                        }
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
