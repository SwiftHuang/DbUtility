using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

using Profile.Common;

namespace Profile.Business.Profiles
{
    /// <summary>
    /// User
    /// </summary>
    public partial class User
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

        private string _FirstName;
        private string _LastName;

        #endregion

        #region 属性

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

        #endregion
    }
}
