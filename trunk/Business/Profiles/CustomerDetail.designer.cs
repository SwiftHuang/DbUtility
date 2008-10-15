using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

using Profile.Common;

using Profile.Business.Profiles;

namespace Profile.Business.Profiles
{
    /// <summary>
    /// CustomerDetail
    /// </summary>
    public partial class CustomerDetail
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

        private int? _CustomerID;
        private EntityRef<Customer> _Customer;
        private string _Phone;
        private string _Address;

        #endregion

        #region 属性

        /// <summary>
        /// 取得对应Customer的ID
        /// </summary>
        public int? CustomerID
        {
            get { return _CustomerID; }
        }
        /// <summary>
        /// 取得对应的Customer
        /// </summary>
        public Customer Customer
        {
            get { return _Customer.Entity; }
            set
            {
                _Customer.Entity = value;
                _CustomerID = value == null ? 0 : value.ID;
            }
        }
        /// <summary>
        /// 取得或设置Phone
        /// </summary>
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        /// <summary>
        /// 取得或设置Address
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        #endregion
    }
}
