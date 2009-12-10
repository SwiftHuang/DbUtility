using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hwj.DBUtility.MSSQL
{
    public class BaseDataAccess<T> where T : class, new()
    {
        private string _connectionString = string.Empty;
        public string ConnectionString
        {
            get { return _connectionString; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("数据连接字符不能为空");
                else
                    _connectionString = value;
            }
        }
        protected SqlEntity _SqlEntity = null;
        public SqlEntity SqlEntity
        {
            get { return _SqlEntity; }
        }

        public BaseDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
