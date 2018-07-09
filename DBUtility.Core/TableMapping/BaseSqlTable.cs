using System;

namespace hwj.DBUtility.Core.TableMapping
{
    [Serializable]
    public abstract class BaseSqlTable<T> where T : class, new()
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