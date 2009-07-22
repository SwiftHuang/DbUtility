using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace hwj.DBUtility
{
    public class SqlEntity
    {
        public object ShareObject = null;
        public object OriginalData = null;
        event EventHandler _solicitationEvent;
        public event EventHandler SolicitationEvent
        {
            add
            {
                _solicitationEvent += value;
            }
            remove
            {
                _solicitationEvent -= value;
            }
        }
        public void OnSolicitationEvent()
        {
            if (_solicitationEvent != null)
            {
                _solicitationEvent(this, new EventArgs());
            }
        }

        public Enums.EffentNextType EffentNextType { get; set; }
        public string CommandText { get; set; }
        public List<SqlParameter> Parameters { get; set; }
        public SqlEntity()
        {
            CommandText = string.Empty;
            Parameters = null;
            EffentNextType = Enums.EffentNextType.None;
        }
        public SqlEntity(string sqlText, List<SqlParameter> para)
        {
            CommandText = sqlText;
            Parameters = para;
            EffentNextType = Enums.EffentNextType.None;
        }
        public SqlEntity(string sqlText, List<SqlParameter> para, Enums.EffentNextType type)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
            this.EffentNextType = type;
        }
    }

    public class SqlList : List<SqlEntity> { }
}
