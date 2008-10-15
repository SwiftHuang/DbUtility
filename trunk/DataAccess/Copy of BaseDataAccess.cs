using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using MySql.Data.MySqlClient;

using WongTung.DBUtility;
using WongTung.Common;

namespace WongTung.DataAccess
{
    public abstract class BaseDataAccess<T> where T : class, new()
    {
        private const string _SelectString = "SELECT * FROM {0} {1}";
        //private System.Web.Caching.Cache c = new System.Web.Caching.Cache();
        //public PropertyInfo[] ProInfos
        //{
        //    set { c["VINSON"] = value; }
        //    get
        //    {
        //        if (c["VINSON"] != null)
        //            return (PropertyInfo[])c["VINSON"];
        //        else
        //            return null;
        //    }
        //}
        protected string TableName { get; set; }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        protected void Add(T entity)
        {

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
            MySqlDataReader reader = GetDataReader(strWhere);
            //实例化一个List<>泛型集合
            List<T> DataList = new List<T>();

            T entity = Activator.CreateInstance<T>();
            PropertyInfo[] pp = null;
            //pp = typeof(T).GetProperties();
            if (WebCache.GetCache(entity.ToString()) == null)
            {
                pp = typeof(T).GetProperties();
                WebCache.Insert(entity.ToString(), pp);
            }
            else
                pp = (PropertyInfo[])WebCache.GetCache(entity.ToString());

            List<TableMapping.FieldInfo> lstFieldInfo = new List<TableMapping.FieldInfo>();
            foreach (PropertyInfo Property in pp)
            {
                foreach (TableMapping.FieldMappingAttribute Field in Property.GetCustomAttributes(typeof(TableMapping.FieldMappingAttribute), false))
                {
                    lstFieldInfo.Add(new TableMapping.FieldInfo(Property, Field.DataFieldName, Field.NullValue, Field.DataType));
                }
            }


            while (reader.Read())
            {
                //由于是是未知的类型,所以必须通过Activator.CreateInstance<T>()方法来依据T的类型动态创建数据实体对象
                T RowInstance = Activator.CreateInstance<T>();

                //通过反射取得对象所有的Property
                foreach (PropertyInfo Property in pp)
                {
                    //BindingFieldAttribute为自定义的Attribute,用于与数据库字段进行绑定
                    foreach (DataMapping.MappingAttribute FieldAttr in Property.GetCustomAttributes(typeof(TableMapping.FieldMappingAttribute), true))
                    {
                        //    try
                        //    {
                        //        //取得当前数据库字段的顺序
                        //        int Ordinal = reader.GetOrdinal(FieldAttr.DataFieldName);
                        //        if (reader.GetValue(Ordinal) != DBNull.Value)
                        //        {

                        //            //将DataReader读取出来的数据填充到对象实体的属性里
                        //            //if (reader[Property.Name].GetType() != typeof(bool))
                        //            //Property.SetValue(RowInstance, Convert.ChangeType(reader.GetValue(Ordinal), GetPropertyType(Property)), null);
                        //            //else
                        //            //Property.SetValue(RowInstance, Convert.ChangeType((reader[Property.Name].ToString().ToLower() == "false" ? "0" : "1"), GetPropertyType(Property)), null);
                        //        }
                        //    }
                        //    catch (Exception e)
                        //    {
                        //        throw e;
                        //    }
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
            MySqlDataReader reader = GetDataReader(strWhere);
            T entity = Activator.CreateInstance<T>();
            return DataMapping.ObjectHelper.FillCollection<T, List<T>>(entity.GetType(), reader);
        }
        /// <summary>
        /// 返回DataTable(建议用在Report)
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetTable(string strWhere)
        {
            MySqlDataReader reader = GetDataReader(strWhere);
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
        private Type GetPropertyType(PropertyInfo p)
        {
            if (p.PropertyType.IsGenericType)
            {
                if (p.PropertyType == typeof(Nullable<decimal>))
                    return typeof(decimal);
                if (p.PropertyType == typeof(Nullable<DateTime>))
                    return typeof(DateTime);
                if (p.PropertyType == typeof(Nullable<int>))
                    return typeof(int);
                return null;
            }
            else
                return p.PropertyType;
        }
        private MySqlDataReader GetDataReader(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(_SelectString, TableName, strWhere);
            return DbHelperMySQL.ExecuteReader(sb.ToString());
        }
        #endregion
    }
}
