using System;
using System.Collections.Generic;
using System.Data;
using hwj.DBUtility.MYSQL;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility.MSSQL
{
    public abstract class BaseDAL<T> where T : class, new()
    {
        protected DBUtility.MSSQL.GenerateSql<T> GenSql = new GenerateSql<T>();

        #region Property
        private string _sql = string.Empty;
        public string SqlCommand
        {
            get
            {
                return _sql;
            }
        }
        protected string TableName { get; set; }
        #endregion

        public void Add(T entity)
        {
            _sql = GenSql.InsertSql(entity);
           DbHelperSQL.ExecuteSql(_sql);
        }
        public Int64 Add_GetInsertID(T entity)
        {
            _sql = GenSql.InsertSql(entity) + GenSql.InsertLastIDSql();
            return Convert.ToInt64(DbHelperSQL.GetSingle(_sql));
        }

        public void Update(UpdateParam param)
        {
            Update(param, null);
        }
        public void Update(UpdateParam updateParam, WhereParam whereParam)
        {
            _sql = GenSql.UpdateSql(updateParam, whereParam);
            DbHelperSQL.ExecuteSql(_sql);
        }
        public void Delete()
        {
            Delete(null);
        }
        public void Delete(WhereParam whereParam)
        {
            _sql = GenSql.DeleteSql(whereParam);
            DbHelperSQL.ExecuteSql(_sql);
        }

        public T GetEntity()
        {
            return GetEntity(null);
        }
        public T GetEntity(WhereParam whereParam)
        {
            _sql = GenSql.SelectSql(TableName, null, whereParam, null, 1);
            IDataReader reader = DbHelperSQL.ExecuteReader(_sql);
            return CreateSingleEntity(reader);
        }

        public IList<T> GetList()
        {
            return GetList(null, null, null, null);
        }
        public IList<T> GetList(SelectFields selectFields)
        {
            return GetList(selectFields, null, null, null);
        }
        public IList<T> GetList(SelectFields selectFields, WhereParam whereParam)
        {
            return GetList(selectFields, whereParam, null, null);
        }
        public IList<T> GetList(SelectFields selectFields, WhereParam whereParam, OrderFields orderParam)
        {
            return GetList(selectFields, whereParam, orderParam, null);
        }
        public IList<T> GetList(SelectFields selectFields, WhereParam whereParam, OrderFields orderParam, int? maxCount)
        {
            _sql = GenSql.SelectSql(TableName, selectFields, whereParam, orderParam, maxCount);
            IDataReader reader = DbHelperSQL.ExecuteReader(_sql);
            return CreateListEntity(reader);
        }

        #region Record Count
        /// <summary>
        /// 返回表的记录数
        /// </summary>
        /// <returns></returns>
        public Int64 RecordCount()
        {
            return RecordCount(null);
        }
        /// <summary>
        /// 返回表的记录数
        /// </summary>
        /// <param name="whereParam">条件参数</param>
        /// <returns>记录数</returns>
        public Int64 RecordCount(WhereParam whereParam)
        {
            _sql = GenSql.SelectCountSql(TableName, whereParam);
            return Convert.ToInt64(DbHelperSQL.GetSingle(_sql));
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
                            f.Property.SetValue(RowInstance, Convert.ChangeType(obj, f.DataTypeCode), null);
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
