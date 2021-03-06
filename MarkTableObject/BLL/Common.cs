﻿using System;
using System.Collections.Generic;
using System.Text;
using hwj.MarkTableObject.Entity;
using System.Data;

namespace hwj.MarkTableObject.BLL
{
    public static class Common
    {
        public static string GetStringValue(object value)
        {
            if (value != null)
                return value.ToString();
            else
                return null;
        }
        public static int GetIntValue(object value)
        {
            if (value != null)
                return int.Parse(value.ToString());
            else
                return 0;
        }
        public static bool GetBoolValue(object value)
        {
            bool bl = false;
            if (value != null)
            {
                bool.TryParse(value.ToString(), out bl);
                return bl;
            }
            else
                return false;
        }

        public static ColumnInfo GetColumnInfo(DataRow dataRow)
        {
            ColumnInfo c = new ColumnInfo();
            c.ColumnName = BLL.Common.GetStringValue(dataRow["ColumnName"]);
            c.ColumnOrdinal = BLL.Common.GetIntValue(dataRow["ColumnOrdinal"]);
            c.ColumnSize = BLL.Common.GetIntValue(dataRow["ColumnSize"]);
            c.NumericPrecision = BLL.Common.GetIntValue(dataRow["NumericPrecision"]);
            c.NumericScale = BLL.Common.GetIntValue(dataRow["NumericScale"]);
            c.DataType = BLL.Common.GetStringValue(dataRow["DataType"]);
            c.ProviderType = BLL.Common.GetStringValue(dataRow["ProviderType"]);

            c.IsLong = BLL.Common.GetBoolValue(dataRow["IsLong"]);
            c.AllowDBNull = BLL.Common.GetBoolValue(dataRow["AllowDBNull"]);
            c.IsReadOnly = BLL.Common.GetBoolValue(dataRow["IsReadOnly"]);
            c.IsRowVersion = BLL.Common.GetBoolValue(dataRow["IsRowVersion"]);

            c.IsUnique = BLL.Common.GetBoolValue(dataRow["IsUnique"]);
            c.IsKey = BLL.Common.GetBoolValue(dataRow["IsKey"]);
            c.IsAutoIncrement = BLL.Common.GetBoolValue(dataRow["IsAutoIncrement"]);

            c.BaseSchemaName = BLL.Common.GetStringValue(dataRow["BaseSchemaName"]);
            c.BaseCatalogName = BLL.Common.GetStringValue(dataRow["BaseCatalogName"]);
            c.BaseTableName = BLL.Common.GetStringValue(dataRow["BaseTableName"]);
            c.BaseColumnName = BLL.Common.GetStringValue(dataRow["BaseColumnName"]);
            return c;
        }

        public static SPParamColumnInfo GetSPParamColumnInfo(DataRow row)
        {
            SPParamColumnInfo c = new SPParamColumnInfo();
            c.IsResult = BLL.Common.GetStringValue(row["IS_RESULT"]);
            c.ParameterName = BLL.Common.GetStringValue(row["PARAMETER_NAME"]).Replace("@", string.Empty);
            c.DataType = BLL.Common.GetStringValue(row["DATA_TYPE"]);
            c.ParameterMode = BLL.Common.GetStringValue(row["PARAMETER_MODE"]);
            return c;
        }

        public static string GetNamespace(this string @namespace, bool isNetCore)
        {
            if (!isNetCore)
                return @namespace;
            return @namespace.Replace("hwj.DBUtility", "hwj.DBUtility.Core");
        }
    }
}
