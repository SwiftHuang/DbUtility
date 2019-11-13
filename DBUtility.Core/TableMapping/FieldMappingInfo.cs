using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace hwj.DBUtility.Core.TableMapping
{
    public class FieldMappingInfo
    {
        public FieldMappingInfo(FieldMappingInfo fieldMappingInfo)
        {
            Property = fieldMappingInfo.Property;
            FieldName = fieldMappingInfo.FieldName;
            NullValue = fieldMappingInfo.NullValue;
            DataTypeCode = fieldMappingInfo.DataTypeCode;
            FieldIndex = fieldMappingInfo.FieldIndex;
            DataHandles = fieldMappingInfo.DataHandles;
            Size = 0;
        }
        public FieldMappingInfo(PropertyInfo property, string fieldName, DbType typeCode, object nullValue, int size, Enums.DataHandle[] dataHandles, int fieldIndex)
        {
            Property = property;
            FieldName = fieldName;
            NullValue = nullValue;
            DataTypeCode = typeCode;
            FieldIndex = fieldIndex;
            DataHandles = dataHandles;
            Size = size;
        }

        #region Property

        public PropertyInfo Property { get; set; }
        public string FieldName { get; set; }
        public DbType DataTypeCode { get; set; }
        public object NullValue { get; set; }
        public int FieldIndex { get; set; }
        private Enums.DataHandle[] _dataHandles;
        public Enums.DataHandle[] DataHandles
        {
            get { return _dataHandles; }
            private set
            {
                _dataHandles = value;
                SetDataHandles();
            }
        }
        public int Size { get; set; }
        /// <summary>
        /// 不插入该字段
        /// </summary>
        public bool IsUnInsert { get; set; }

        /// <summary>
        /// 不更新该字段
        /// </summary>
        public bool IsUnUpdate { get; set; }

        /// <summary>
        /// 该字段不允许为Null
        /// </summary>
        public bool IsUnNull { get; set; }
        #endregion Property

        #region Public Functions

        public static List<FieldMappingInfo> GetFieldMapping(Type type)
        {
            return DBCache.GetCache(type);
            //string entityID = type.ToString();
            //List<FieldMappingInfo> lstFieldInfo = new List<FieldMappingInfo>();

            //if (DBCache.GetCache(entityID) == null)
            //{
            //    foreach (PropertyInfo Property in type.GetProperties())
            //    {
            //        foreach (FieldMappingAttribute field in Property.GetCustomAttributes(typeof(FieldMappingAttribute), false))
            //        {
            //            lstFieldInfo.Add(new FieldMappingInfo(Property, field.DataFieldName, field.DataTypeCode, field.NullValue, field.Size, field.DataHandles, -1));
            //        }
            //    }
            //    DBCache.SetCache(entityID, lstFieldInfo);
            //}
            //else
            //    lstFieldInfo = (List<FieldMappingInfo>)DBCache.GetCache(entityID);

            //return lstFieldInfo;
        }

        public static FieldMappingInfo GetFieldInfo(Type type, string fieldName)
        {
            if (type == null || string.IsNullOrEmpty(fieldName))
            {
                return null;
            }

            foreach (FieldMappingInfo f in FieldMappingInfo.GetFieldMapping(type))
            {
                if (f.FieldName == fieldName)
                    return f;
            }
            return null;
        }

        public FieldMappingInfo Clone()
        {
            return (this.MemberwiseClone() as FieldMappingInfo);
        }

        private void SetDataHandles()
        {
            this.IsUnInsert = DataHandlesFind(this.DataHandles, Enums.DataHandle.UnInsert);
            this.IsUnUpdate = DataHandlesFind(this.DataHandles, Enums.DataHandle.UnUpdate);
            this.IsUnNull = DataHandlesFind(this.DataHandles, Enums.DataHandle.UnNull);
        }
        #endregion Public Functions

        private static bool DataHandlesFind(Enums.DataHandle[] handles, Enums.DataHandle dataHandle)
        {
            if (handles == null || handles.Length == 0)
                return false;
            foreach (Enums.DataHandle dh in handles)
            {
                if (dh == dataHandle)
                    return true;
            }
            return false;
        }
    }
}