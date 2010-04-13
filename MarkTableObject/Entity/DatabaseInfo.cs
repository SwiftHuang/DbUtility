using System;
using System.Collections.Generic;
using System.Text;

namespace hwj.MarkTableObject.Entity
{
    [Serializable]
    public class DatabaseInfo
    {
        public DatabaseEnum DatabaseType { get; set; }
        public string ConnectionString { get; set; }
        public string DataSource { get; set; }
        public string ServerVersion { get; set; }
        public string VerificationType { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
    }
}
