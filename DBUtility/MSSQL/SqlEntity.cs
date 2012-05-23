using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace hwj.DBUtility
{
    public class SqlEntity
    {
        //public object ShareObject = null;
        //public object OriginalData = null;
        //event EventHandler _solicitationEvent;
        //public event EventHandler SolicitationEvent
        //{
        //    add
        //    {
        //        _solicitationEvent += value;
        //    }
        //    remove
        //    {
        //        _solicitationEvent -= value;
        //    }
        //}
        //public void OnSolicitationEvent()
        //{
        //    if (_solicitationEvent != null)
        //    {
        //        _solicitationEvent(this, new EventArgs());
        //    }
        //}

        #region Property
        public Enums.EffentNextType EffentNextType { get; set; }
        public string CommandText { get; set; }
        public List<SqlParameter> Parameters { get; set; }
        public object DataEntity { get; set; }
        public string TableName { get; set; }
        public Enums.LockType LockType { get; set; }
        #endregion

        public SqlEntity()
            : this(string.Empty, null, Enums.EffentNextType.None, null, null) { }
        public SqlEntity(string sqlText, List<SqlParameter> para)
            : this(sqlText, para, Enums.EffentNextType.None, null, null) { }
        public SqlEntity(string sqlText, List<SqlParameter> para, string tableName, object dataEntity)
            : this(sqlText, para, Enums.EffentNextType.None, tableName, dataEntity) { }
        public SqlEntity(string sqlText, List<SqlParameter> para, Enums.EffentNextType type, string tableName, object dataEntity)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
            this.EffentNextType = type;
            this.TableName = tableName;
            this.DataEntity = dataEntity;
        }
    }

    public class SqlList : List<SqlEntity> { }
}
