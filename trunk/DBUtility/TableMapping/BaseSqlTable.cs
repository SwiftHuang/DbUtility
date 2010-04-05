using System;
using System.Collections.Generic;
using System.Text;

namespace hwj.DBUtility.TableMapping
{
    public class BaseSqlTable<T> where T : class, new()
    {
        private string CommandText = string.Empty;
        public BaseSqlTable()
        {

        }
        public BaseSqlTable(string commandText)
        {
            CommandText = commandText;
        }

        public string GetCommandText()
        {
            return CommandText;
        }
    }
}
