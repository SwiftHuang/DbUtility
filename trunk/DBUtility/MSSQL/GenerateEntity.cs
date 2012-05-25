using System;
using System.Collections.Generic;
using System.Data;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility.MSSQL
{
    public class GenerateEntity
    {
        #region Protected Functions
        internal static DataTable CreateDataTable(IDataReader reader)
        {
            return CreateDataTable(reader, string.Empty);
        }
        internal static DataTable CreateDataTable(IDataReader reader, string tableName)
        {
            try
            {
                DataTable dataTable = new DataTable(tableName);//建一个新的实例

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
                        mydr[i] = reader[i];
                    }

                    dataTable.Rows.Add(mydr);//关键的第四步
                    mydr = null;
                }
                return dataTable;//别忘了要返回datatable，否则出错
            }
            catch { throw; }
            finally
            {
                if (!reader.IsClosed) reader.Close();
            }
        }
        internal static T CreateSingleEntity<T>(IDataReader reader) where T : class, new()
        {
            IList<FieldMappingInfo> lstFieldInfo = new List<FieldMappingInfo>();
            lstFieldInfo = FieldMappingInfo.GetFieldMapping(typeof(T));
            lstFieldInfo = SetFieldIndex(reader, lstFieldInfo);

            //reader.Read();
            return CreateEntityNotClose<T>(reader, lstFieldInfo);
        }
        internal static TS CreateListEntity<T, TS>(IDataReader reader)
            where T : class, new()
            where TS : List<T>, new()
        {
            TS DataList = new TS();
            IList<FieldMappingInfo> lstFieldInfo = new List<FieldMappingInfo>();
            lstFieldInfo = SetFieldIndex(reader, FieldMappingInfo.GetFieldMapping(typeof(T)));

            while (reader.Read())
            {
                DataList.Add(CreateEntityNotClose<T>(reader, lstFieldInfo));
            }
            return DataList;
        }
        #endregion

        #region Private Functions
        private static T CreateEntityNotClose<T>(IDataReader reader, IList<FieldMappingInfo> lstFieldInfo) where T : class, new()
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
        private static IList<FieldMappingInfo> SetFieldIndex(IDataReader reader, IList<FieldMappingInfo> list)
        {
            IList<FieldMappingInfo> datalist = new List<FieldMappingInfo>();
            foreach (FieldMappingInfo f in list)
            {
                try
                {
                    f.FieldIndex = reader.GetOrdinal(f.FieldName);
                    //Clone的原因在于在多线程的环境下，因为共用了同一个Cache的FieldMappingInfo List对象，所以造成相同地址的内容被改变的情况
                    datalist.Add(f.Clone());

                    if (reader.FieldCount == datalist.Count)
                        break;
                }
                catch (IndexOutOfRangeException)
                {
                    //f.FieldIndex = -1;
                }
            }
            return datalist;
        }
        #endregion
    }
}
