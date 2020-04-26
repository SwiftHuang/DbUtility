using System;
using TestProject.Core.DBUtility.Entity;

namespace TestProject.Core
{
    public class TestCommon
    {
        public const string ConnString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBUtility;Integrated Security=True";

        public static tbTestTable GenData(string key)
        {
            DateTime createOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            tbTestTable dataRQ = new tbTestTable()
            {
                Key_EN = key.PadRight(10, ' '),
                Key_CN = "键值".PadRight(10, ' '),
                CreateOn = createOn,
                Boolean = false,
                Amt_Decimal = 222.22m,
                Amt_Float = 999999999999999f,
                Amt_Int = 100,
                Amt_Numeric = 333.33m,
                Desc_CN = "测试数据",
                Desc_EN = "Test Data",

                Remark_CN = @"测试数据[]~!@#$%^&*()_+{}"":?><,./;'|",
                Remark_EN = @"Test Data[]~!@#$%^&*()_+{}"":?><,./;'|",
                XML_Data = "<TEST><DATA>测试数据</DATA></TEST>"
            };

            return dataRQ;
        }
    }
}