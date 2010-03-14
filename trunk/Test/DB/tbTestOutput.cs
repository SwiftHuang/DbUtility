using System;
using System.Collections.Generic;
using System.Data;
using hwj.DBUtility;
using hwj.DBUtility.Entity;
using hwj.DBUtility.TableMapping;

namespace Test.DB.Entity
{
    /// <summary>
    /// 实体类tbTestOutput 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class tbTestOutput : BaseTable<tbTestOutput>
    {
        public tbTestOutput()
            : base(DBTableName)
        {
        }
        public const string DBTableName = "TestOutput";

        public enum Fields
        {
            /// <summary>
            ///
            /// </summary>
            ID,
            /// <summary>
            ///
            /// </summary>
            Name,
            /// <summary>
            ///
            /// </summary>
            Status,
            /// <summary>
            /// 
            /// </summary>
            Amount,
        }

        #region Model
        private Int32 _id;
        private String _name;
        private String _status;
        private Decimal _amount;
        /// <summary>
        /// [PK/Un-Null/int(4)]
        /// </summary>
        [FieldMapping("ID", DbType.Int32, Enums.DataHandle.UnInsert, Enums.DataHandle.UnUpdate)]
        public Int32 ID
        {
            set { AddAssigned("ID"); _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// [Allow Null/varchar(50)]
        /// </summary>
        [FieldMapping("Name", DbType.String)]
        public String Name
        {
            set { AddAssigned("Name"); _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// [Allow Null/char(1)/Default:('N')]
        /// </summary>
        [FieldMapping("Status", DbType.String)]
        public String Status
        {
            set { AddAssigned("Status"); _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// [Allow Null/char(1)/Default:('N')]
        /// </summary>
        [FieldMapping("Amount", DbType.Decimal)]
        public Decimal Amount
        {
            set { AddAssigned("Amount"); _amount = value; }
            get { return _amount; }
        }
        #endregion Model

    }
    public class tbTestOutputs : BaseList<tbTestOutput, tbTestOutputs> { }
    public class tbTestOutputPage : PageResult<tbTestOutput, tbTestOutputs> { }
}

