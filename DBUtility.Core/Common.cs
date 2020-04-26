using System;
using System.Data;

namespace hwj.DBUtility.Core
{
    public class Common
    {
        public const string SqlInfoKey = "DBUtility-SqlInfo";
        public const string ExceptionFieldsKey = "DBUtility-ExceptionFields";
        public const string FieldMappingsKey = "FieldMappings";

        //internal static void AddExData(IDictionary data, string msg)
        //{
        //    if (!string.IsNullOrEmpty(msg))
        //    {
        //        string tmpStr = null;
        //        //object tmp = data[Common.SqlInfoKey];
        //        if (data.Contains(Common.SqlInfoKey))
        //        {
        //            tmpStr = data[Common.SqlInfoKey].ToString();
        //            data.Remove(Common.SqlInfoKey);
        //        }
        //        if (!string.IsNullOrEmpty(tmpStr))
        //        {
        //            tmpStr = string.Format("{0}\r\n\r\n{1}", msg, tmpStr);
        //        }
        //        else
        //        {
        //            tmpStr = msg;
        //        }
        //        data.Add(Common.SqlInfoKey, tmpStr);
        //    }
        //}

        /// <summary>
        /// 获取异常附加信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetExData(Exception ex)
        {
            return GetExData(ex, SqlInfoKey);
        }

        /// <summary>
        ///获取异常附加信息
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetExData(Exception ex, object key)
        {
            if (ex != null && ex.Data != null && ex.Data.Count > 0)
            {
                if (ex.Data.Contains(key))
                {
                    return ex.Data[key].ToString();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 判断是否数字类型
        /// </summary>
        /// <param name="typeCode"></param>
        /// <returns></returns>
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

        internal static bool IsDateType(DbType typeCode)
        {
            if (typeCode == DbType.DateTime)
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