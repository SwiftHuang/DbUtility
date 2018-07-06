using System.Collections.Generic;
using System.Data;

namespace hwj.DBUtility
{
    public class LogEntity
    {
        public string CommandText { get; set; }
        public List<IDbDataParameter> Parameters { get; set; }
        public int CommandTimeout { get; set; }

        public LogEntity()
        {
        }

        public LogEntity(string commandText, List<IDbDataParameter> parameters, int commandTimeout)
        {
            CommandText = commandText;
            Parameters = parameters;
            CommandTimeout = commandTimeout;
        }
    }
}