using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace hwj.DBUtility
{
    public class Common
    {
        public const string SqlInfoKey = "EX-SQLINFO";
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
