using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

using Profile.Common;

namespace Profile.Business.Profiles
{
    /// <summary>
    /// Customer
    /// </summary>
    public partial class Customer
    {
        #region ID和时间戳

        private int _ID = NEW_ENTITY_ID;
        private byte[] _TimeStamp = new byte[] { };

        /// <summary>
        /// 取得ID
        /// </summary>
        public override int ID
        {
            get { return _ID; }
        }
        /// <summary>
        /// 取得时间戳
        /// </summary>
        public override byte[] TimeStamp
        {
            get { return _TimeStamp; }
        }

        #endregion

        #region 成员

        private int _CustID;
        private string _FirstName;
        private string _LastName;
        private int _Sex;
        private DateTime _CreateOn;
        private string _CreateBy;
        private DateTime _UpdateOn;
        private string _UpdateBy;

        #endregion

        #region 属性

        /// <summary>
        /// 取得或设置CustID
        /// </summary>
        public int CustID
        {
            get { return _CustID; }
            set { _CustID = value; }
        }
        /// <summary>
        /// 取得或设置FirstName
        /// </summary>
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        /// <summary>
        /// 取得或设置LastName
        /// </summary>
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        /// <summary>
        /// 取得或设置Sex
        /// </summary>
        public int Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        /// <summary>
        /// 取得或设置CreateOn
        /// </summary>
        public DateTime CreateOn
        {
            get { return _CreateOn; }
            set { _CreateOn = value; }
        }
        /// <summary>
        /// 取得或设置CreateBy
        /// </summary>
        public string CreateBy
        {
            get { return _CreateBy; }
            set { _CreateBy = value; }
        }
        /// <summary>
        /// 取得或设置UpdateOn
        /// </summary>
        public DateTime UpdateOn
        {
            get { return _UpdateOn; }
            set { _UpdateOn = value; }
        }
        /// <summary>
        /// 取得或设置UpdateBy
        /// </summary>
        public string UpdateBy
        {
            get { return _UpdateBy; }
            set { _UpdateBy = value; }
        }

        #endregion
    }
}
