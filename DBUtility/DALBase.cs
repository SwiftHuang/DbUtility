using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using WongTung.DBUtility.TableMapping;

namespace WongTung.DBUtility
{
    public abstract class DALBase<T> where T : class, new()
    {
        #region Property
        private string _sql = string.Empty;
        public string Sql
        { get { return _sql; } }
        public TimeSpan timeSpan { get; set; }
        protected string TableName { get; set; }
        #endregion

        public void Add(T entity)
        {
            _sql = GenerateSql<T>.InsertSql(entity);
        }
        public void Update(IList<SqlParam> updatePara, IList<SqlParam> wherePara)
        {
            _sql = GenerateSql<T>.UpdateSql(updatePara, wherePara);
        }
        public void Delete(IList<SqlParam> wherePara)
        {
            _sql = GenerateSql<T>.DeleteSql(wherePara);
        }
        public IList<T> GetList(string strWhere)
        {
            IDataReader reader = GetDataReader(strWhere);

            IList<T> DataList = new List<T>();
            IList<FieldMappingInfo> lstFieldInfo = new List<FieldMappingInfo>();

            lstFieldInfo = FieldMappingInfo.GetFieldMapping(typeof(T));
            lstFieldInfo = SetFieldIndex(reader, lstFieldInfo);

            while (reader.Read())
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
                //将数据实体对象add到泛型集合中
                DataList.Add(RowInstance);
            }
            reader.Close();
            return DataList;
        }
        public List<T> GetList2(string strWhere)
        {
            IDataReader reader = GetDataReader(strWhere);
            T entity = new T();
            return DataMapping.ObjectHelper.FillCollection<T, List<T>>(entity.GetType(), reader);
        }
        /// <summary>
        /// 返回DataTable(建议用在Report)
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetTable(string strWhere)
        {
            IDataReader reader = GetDataReader(strWhere);
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

            reader.Close();
            return dataTable;//别忘了要返回datatable，否则出错
        }

        #region Private Functions
        private IDataReader GetDataReader(string strWhere)
        {
            DateTime s = DateTime.Now;
            if (TableName != null && TableName != string.Empty)
                _sql = GenerateSql<T>.SelectSql(strWhere, TableName);
            else
                _sql = GenerateSql<T>.SelectSql(strWhere);
            IDataReader r = DbHelperMySQL.ExecuteReader(_sql);

            timeSpan = DateTime.Now - s;
            return r;
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
