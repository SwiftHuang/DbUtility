using System;
using TestProject.DBUtility.Entity;

namespace TestProject
{
    public class TestCommon
    {
        public const string ConnString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBUtility;Integrated Security=True";
        //public const string ConnString = @"Data Source=db_83; Initial Catalog = MOE; Integrated Security = False; User ID=sa; Password=gzuat;MultipleActiveResultSets=true;";

        public static tbTestTable GenData(string key, bool isMissingField = false)
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

                Amt_Numeric = 333.33m,
                Desc_CN = "测试数据",


                Remark_CN = @"测试数据[]~!@#$%^&*()_+{}"":?><,./;'|",
                Remark_EN = @"Test Data[]~!@#$%^&*()_+{}"":?><,./;'|",
                XML_Data = "<TEST><DATA>测试数据</DATA></TEST>"
            };
            if (isMissingField == false)
            {
                dataRQ.Desc_EN = "Test Data";
                dataRQ.Amt_Int = 100;
            }

            return dataRQ;
        }
    }
}