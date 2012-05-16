using System;
using System.Collections.Generic;
using System.Data;
using hwj.DBUtility;
using hwj.DBUtility.Entity;
using hwj.DBUtility.TableMapping;

namespace Test.DB.Entity
{
    /// <summary>
    /// Table:Admin_User
    /// </summary>
    [Serializable]
    public class tbAdmin_User : BaseTable<tbAdmin_User>
    {
        public tbAdmin_User()
            : base(DBTableName)
        { }
        public const string DBTableName = "Admin_User";


        public enum Fields
        {
            /// <summary>
            ///
            /// </summary>
            Account_ID,
            /// <summary>
            ///
            /// </summary>
            Login_Account,
            /// <summary>
            ///
            /// </summary>
            Amount1,
            /// <summary>
            ///
            /// </summary>
            Amount2,
            /// <summary>
            ///
            /// </summary>
            Amount3,
            /// <summary>
            ///
            /// </summary>
            Amount4,
            /// <summary>
            ///
            /// </summary>
            Amount5,
            /// <summary>
            ///
            /// </summary>
            Amount6,
            /// <summary>
            ///
            /// </summary>
            Amount7,
            /// <summary>
            ///
            /// </summary>
            Amount8,
            /// <summary>
            ///
            /// </summary>
            DateTimeTest,
        }

        #region Model
        private Int32 _account_id;
        private String _login_account;
        private Decimal _amount1;
        private Decimal _amount2;
        private Int16 _amount3;
        private Byte _amount4;
        private Int64 _amount5;
        private Boolean _amount6;
        private Double _amount7;
        private Int32 _amount8;
        private DateTime _datetimetest;
        /// <summary>
        /// [PK/Un-Null/int(10)]
        /// </summary>
        [FieldMapping("Account_ID", DbType.Int32, 10, Enums.DataHandle.UnInsert, Enums.DataHandle.UnUpdate)]
        public Int32 Account_ID
        {
            set { AddAssigned("Account_ID"); _account_id = value; }
            get { return _account_id; }
        }
        /// <summary>
        /// [Un-Null/nvarchar(30)]
        /// </summary>
        [FieldMapping("Login_Account", DbType.String, 30)]
        public String Login_Account
        {
            set { AddAssigned("Login_Account"); _login_account = value; }
            get { return _login_account; }
        }
        /// <summary>
        /// [Allow Null/decimal(4,2)]
        /// </summary>
        [FieldMapping("Amount1", DbType.Decimal, 2)]
        public Decimal Amount1
        {
            set { AddAssigned("Amount1"); _amount1 = value; }
            get { return _amount1; }
        }
        /// <summary>
        /// [Allow Null/decimal(5,2)]
        /// </summary>
        [FieldMapping("Amount2", DbType.Decimal, 3)]
        public Decimal Amount2
        {
            set { AddAssigned("Amount2"); _amount2 = value; }
            get { return _amount2; }
        }
        /// <summary>
        /// [Allow Null/smallint(5)]
        /// </summary>
        [FieldMapping("Amount3", DbType.Int16, 5)]
        public Int16 Amount3
        {
            set { AddAssigned("Amount3"); _amount3 = value; }
            get { return _amount3; }
        }
        /// <summary>
        /// [Allow Null/tinyint(1)]
        /// </summary>
        [FieldMapping("Amount4", DbType.Byte, 1)]
        public Byte Amount4
        {
            set { AddAssigned("Amount4"); _amount4 = value; }
            get { return _amount4; }
        }
        /// <summary>
        /// [Allow Null/bigint(19)]
        /// </summary>
        [FieldMapping("Amount5", DbType.Int64, 19)]
        public Int64 Amount5
        {
            set { AddAssigned("Amount5"); _amount5 = value; }
            get { return _amount5; }
        }
        /// <summary>
        /// [Allow Null/bit(1)]
        /// </summary>
        [FieldMapping("Amount6", DbType.Boolean, 1)]
        public Boolean Amount6
        {
            set { AddAssigned("Amount6"); _amount6 = value; }
            get { return _amount6; }
        }
        /// <summary>
        /// [Allow Null/float(15)]
        /// </summary>
        [FieldMapping("Amount7", DbType.Double, 15)]
        public Double Amount7
        {
            set { AddAssigned("Amount7"); _amount7 = value; }
            get { return _amount7; }
        }
        /// <summary>
        /// [Allow Null/int(10)]
        /// </summary>
        [FieldMapping("Amount8", DbType.Int32, 10)]
        public Int32 Amount8
        {
            set { AddAssigned("Amount8"); _amount8 = value; }
            get { return _amount8; }
        }
        /// <summary>
        /// [Allow Null/datetime(8)]
        /// </summary>
        [FieldMapping("DateTimeTest", DbType.DateTime, 8)]
        public DateTime DateTimeTest
        {
            set { AddAssigned("DateTimeTest"); _datetimetest = value; }
            get { return _datetimetest; }
        }
        #endregion Model

    }
    [Serializable]
    public class tbAdmin_Users : BaseList<tbAdmin_User, tbAdmin_Users> { }
    public class tbAdmin_UserPage : PageResult<tbAdmin_User, tbAdmin_Users> { }
}

