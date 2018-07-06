using System.Collections.Generic;
using System.Data;

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

        /// <summary>
        /// SQL语句
        /// </summary>
        public string CommandText { get; set; }

        /// <summary>
        /// SQL参数
        /// </summary>
        public List<IDbDataParameter> Parameters { get; set; }

        public object DataEntity { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 锁
        /// </summary>
        public List<Enums.LockType> LockType { get; set; }

        /// <summary>
        /// 获取或设置在终止执行命令的尝试并生成错误之前的等待时间。(默认为30秒)
        /// </summary>
        public int CommandTimeout { get; set; }

        #endregion Property

        public SqlEntity()
            : this(string.Empty, null, Enums.EffentNextType.None, null, null) { }

        //public SqlEntity(string sqlText, List<IDbDataParameter> para)
        //    : this(sqlText, para, Enums.EffentNextType.None, null, null) { }
        public SqlEntity(string sqlText, List<IDbDataParameter> para, string tableName, object dataEntity)
            : this(sqlText, para, Enums.EffentNextType.None, tableName, dataEntity) { }

        protected SqlEntity(string sqlText, List<IDbDataParameter> para, Enums.EffentNextType type, string tableName, object dataEntity)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
            this.EffentNextType = type;
            this.TableName = tableName;
            this.DataEntity = dataEntity;
            this.CommandTimeout = 30;
        }
    }

    public class SqlList : List<SqlEntity> { }
}