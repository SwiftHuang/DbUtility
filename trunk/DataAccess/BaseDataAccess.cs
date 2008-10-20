using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using WongTung.DBUtility;
using WongTung.DBUtility.TableMapping;
using WongTung.Common;

namespace WongTung.DataAccess
{
    public abstract class BaseDataAccess<T> where T : class, new()
    {
        private const string _SelectString = "SELECT * FROM {0} {1}";
        private const string _InsertString = "INSERT INTO {0} ({1}) VALUE({2});";
        private const string _StringFormat = "'{0}',";
        private const string _DecimalFormat = "{0},";
        private string _sql = string.Empty;
        public string Sql
        { get { return _sql; } }
        public TimeSpan timeSpan { get; set; }
        protected string TableName { get; set; }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(T entity)
        {
            StringBuilder sbInsField = new StringBuilder();
            StringBuilder sbInsValue = new StringBuilder();

            foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(typeof(T)))
            {
                object obj = f.Property.GetValue(entity, null);
                if (obj != null)
                {
                    if (f.DataType == typeof(DateTime))
                    {
                        if (DateTime.MinValue != (DateTime)obj)
                        {
                            sbInsField.AppendFormat(_StringFormat, f.FieldName);
                            sbInsValue.AppendFormat(_StringFormat, Convert.ChangeType(obj, f.DataType));
                        }
                    }
                    else
                    {
                        sbInsField.AppendFormat(_StringFormat, f.FieldName);
                        if (f.DataType == typeof(Decimal) || f.DataType == typeof(Int16))
                            sbInsValue.AppendFormat(_DecimalFormat, Convert.ChangeType(obj, f.DataType));
                        else
                            sbInsValue.AppendFormat(_StringFormat, Convert.ChangeType(obj, f.DataType));
                    }
                }
            }
            string s = string.Format(_InsertString, entity.GetType().Name, sbInsField.ToString().TrimEnd(','), sbInsValue.ToString().TrimEnd(','));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        protected void Update(T entity)
        {
        }
        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //protected void Delete();
        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //protected static T GetEntity();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<T> GetList(string strWhere)
        {
            IDataReader reader = GetDataReader(strWhere);

            List<T> DataList = new List<T>();
            List<FieldMappingInfo> lstFieldInfo = new List<FieldMappingInfo>();

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
                                f.Property.SetValue(RowInstance, Convert.ChangeType(obj, f.DataType), null);
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

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(_SelectString, TableName, strWhere);
            _sql = sb.ToString();
            IDataReader r = DbHelperMySQL.ExecuteReader(_sql);

            timeSpan = DateTime.Now - s;
            return r;
        }
        private List<FieldMappingInfo> SetFieldIndex(IDataReader reader, List<FieldMappingInfo> list)
        {
            List<FieldMappingInfo> datalist = new List<FieldMappingInfo>();
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
