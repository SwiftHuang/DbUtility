using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;

namespace hwj.DBUtility
{
    public class Common
    {
        public const string SqlInfoKey = "EX-SQLINFO";
        internal static void AddExData(IDictionary data, string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                string tmpStr = null;
                object tmp = data[Common.SqlInfoKey];
                if (data.Contains(Common.SqlInfoKey))
                {
                    tmpStr = data[Common.SqlInfoKey].ToString();
                    data.Remove(Common.SqlInfoKey);
                }
                if (!string.IsNullOrEmpty(tmpStr))
                {
                    tmpStr = string.Format("{0}\r\n{1}", msg, tmpStr);
                }
                else
                {
                    tmpStr = msg;
                }
                data.Add(Common.SqlInfoKey, tmpStr);
            }
        }
        public static string GetExData(Exception ex)
        {
            if (ex != null && ex.Data != null && ex.Data.Count > 0)
            {
                if (ex.Data.Contains(SqlInfoKey))
                {
                    return ex.Data[SqlInfoKey].ToString();
                }
            }
            return string.Empty;
        }
        public static bool IsNumType(DbType typeCode)
        {
            if (typeCode == DbType.Decimal || typeCode == DbType.Int16 || typeCode == DbType.Int32 || typeCode == DbType.Int64
                || typeCode == DbType.Double || typeCode == DbType.Single || typeCode == DbType.UInt16 || typeCode == DbType.UInt32 || typeCode == DbType.UInt64)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
