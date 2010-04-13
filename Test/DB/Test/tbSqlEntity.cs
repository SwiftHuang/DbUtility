using System;
using System.Collections.Generic;
using System.Data;
using hwj.DBUtility;
using hwj.DBUtility.Entity;
using hwj.DBUtility.TableMapping;

namespace Acct.Entity
{
    /// <summary>
    /// SQL:SqlEntity
    /// </summary>
    [Serializable]
    public class tbSqlEntity : BaseSqlTable<tbSqlEntity>
    {
        public tbSqlEntity()
            : base(CommandText)
        { }
        public const string CommandText = @"select * from artx";

        public enum Fields
        {
            /// <summary>
            ///
            /// </summary>
            CompanyCode,
            /// <summary>
            ///
            /// </summary>
            ARTxNum,
            /// <summary>
            ///
            /// </summary>
            ARTxType,
            /// <summary>
            ///
            /// </summary>
            ItemType,
            /// <summary>
            ///
            /// </summary>
            ItemNum,
            /// <summary>
            ///
            /// </summary>
            GLTxNum,
            /// <summary>
            ///
            /// </summary>
            CltCode,
            /// <summary>
            ///
            /// </summary>
            CtrlGLCode,
            /// <summary>
            ///
            /// </summary>
            CalendarCode,
            /// <summary>
            ///
            /// </summary>
            PeriodPost,
            /// <summary>
            ///
            /// </summary>
            IssueOn,
            /// <summary>
            ///
            /// </summary>
            DueDate,
            /// <summary>
            ///
            /// </summary>
            ExRateCode,
            /// <summary>
            ///
            /// </summary>
            PayMethod,
            /// <summary>
            ///
            /// </summary>
            ARTxDesc,
            /// <summary>
            ///
            /// </summary>
            MasterPnr,
            /// <summary>
            ///
            /// </summary>
            BkgNum,
            /// <summary>
            ///
            /// </summary>
            BkgOwner,
            /// <summary>
            ///
            /// </summary>
            CurrTxn,
            /// <summary>
            ///
            /// </summary>
            AmtTxn,
            /// <summary>
            ///
            /// </summary>
            OAmtTxn,
            /// <summary>
            ///
            /// </summary>
            CurrPrm,
            /// <summary>
            ///
            /// </summary>
            AmtPrm,
            /// <summary>
            ///
            /// </summary>
            OAmtPrm,
            /// <summary>
            ///
            /// </summary>
            CurrSec,
            /// <summary>
            ///
            /// </summary>
            AmtSec,
            /// <summary>
            ///
            /// </summary>
            OAmtSec,
            /// <summary>
            ///
            /// </summary>
            CurrRpt,
            /// <summary>
            ///
            /// </summary>
            AmtRpt,
            /// <summary>
            ///
            /// </summary>
            OAmtRpt,
            /// <summary>
            ///
            /// </summary>
            SettleOn,
            /// <summary>
            ///
            /// </summary>
            Source,
            /// <summary>
            ///
            /// </summary>
            ARStatus,
            /// <summary>
            ///
            /// </summary>
            BranchCode,
            /// <summary>
            ///
            /// </summary>
            TeamCode,
            /// <summary>
            ///
            /// </summary>
            CustRef,
            /// <summary>
            ///
            /// </summary>
            PurgeRef,
            /// <summary>
            ///
            /// </summary>
            PurgeOn,
            /// <summary>
            ///
            /// </summary>
            PostOn,
            /// <summary>
            ///
            /// </summary>
            PostBy,
            /// <summary>
            ///
            /// </summary>
            CreateOn,
            /// <summary>
            ///
            /// </summary>
            CreateBy,
            /// <summary>
            ///
            /// </summary>
            UpdateOn,
            /// <summary>
            ///
            /// </summary>
            UpdateBy,
            /// <summary>
            ///
            /// </summary>
            LastPayDate,
            /// <summary>
            ///
            /// </summary>
            Void2Jba,
            /// <summary>
            ///
            /// </summary>
            DisputeCode,
        }

        #region Model
        private String _companycode;
        private String _artxnum;
        private String _artxtype;
        private String _itemtype;
        private String _itemnum;
        private String _gltxnum;
        private String _cltcode;
        private String _ctrlglcode;
        private String _calendarcode;
        private String _periodpost;
        private DateTime _issueon;
        private DateTime _duedate;
        private String _exratecode;
        private String _paymethod;
        private String _artxdesc;
        private String _masterpnr;
        private String _bkgnum;
        private String _bkgowner;
        private String _currtxn;
        private Decimal _amttxn;
        private Decimal _oamttxn;
        private String _currprm;
        private Decimal _amtprm;
        private Decimal _oamtprm;
        private String _currsec;
        private Decimal _amtsec;
        private Decimal _oamtsec;
        private String _currrpt;
        private Decimal _amtrpt;
        private Decimal _oamtrpt;
        private DateTime _settleon;
        private String _source;
        private String _arstatus;
        private String _branchcode;
        private String _teamcode;
        private String _custref;
        private String _purgeref;
        private DateTime _purgeon;
        private DateTime _poston;
        private String _postby;
        private DateTime _createon;
        private String _createby;
        private DateTime _updateon;
        private String _updateby;
        private DateTime _lastpaydate;
        private String _void2jba;
        private String _disputecode;
        /// <summary>
        /// [PK/Un-Null/char(2)]
        /// </summary>
        [FieldMapping("CompanyCode", DbType.String)]
        public String CompanyCode
        {
            set { _companycode = value; }
            get { return _companycode; }
        }
        /// <summary>
        /// [PK/Un-Null/char(10)]
        /// </summary>
        [FieldMapping("ARTxNum", DbType.String)]
        public String ARTxNum
        {
            set { _artxnum = value; }
            get { return _artxnum; }
        }
        /// <summary>
        /// [Un-Null/varchar(5)]
        /// </summary>
        [FieldMapping("ARTxType", DbType.String)]
        public String ARTxType
        {
            set { _artxtype = value; }
            get { return _artxtype; }
        }
        /// <summary>
        /// [Un-Null/varchar(5)]
        /// </summary>
        [FieldMapping("ItemType", DbType.String)]
        public String ItemType
        {
            set { _itemtype = value; }
            get { return _itemtype; }
        }
        /// <summary>
        /// [Un-Null/varchar(10)]
        /// </summary>
        [FieldMapping("ItemNum", DbType.String)]
        public String ItemNum
        {
            set { _itemnum = value; }
            get { return _itemnum; }
        }
        /// <summary>
        /// [Allow Null/varchar(10)]
        /// </summary>
        [FieldMapping("GLTxNum", DbType.String)]
        public String GLTxNum
        {
            set { _gltxnum = value; }
            get { return _gltxnum; }
        }
        /// <summary>
        /// [Un-Null/char(8)]
        /// </summary>
        [FieldMapping("CltCode", DbType.String)]
        public String CltCode
        {
            set { _cltcode = value; }
            get { return _cltcode; }
        }
        /// <summary>
        /// [Un-Null/varchar(20)]
        /// </summary>
        [FieldMapping("CtrlGLCode", DbType.String)]
        public String CtrlGLCode
        {
            set { _ctrlglcode = value; }
            get { return _ctrlglcode; }
        }
        /// <summary>
        /// [Un-Null/varchar(4)]
        /// </summary>
        [FieldMapping("CalendarCode", DbType.String)]
        public String CalendarCode
        {
            set { _calendarcode = value; }
            get { return _calendarcode; }
        }
        /// <summary>
        /// [Un-Null/varchar(4)]
        /// </summary>
        [FieldMapping("PeriodPost", DbType.String)]
        public String PeriodPost
        {
            set { _periodpost = value; }
            get { return _periodpost; }
        }
        /// <summary>
        /// [Un-Null/datetime(8)]
        /// </summary>
        [FieldMapping("IssueOn", DbType.DateTime)]
        public DateTime IssueOn
        {
            set { _issueon = value; }
            get { return _issueon; }
        }
        /// <summary>
        /// [Un-Null/datetime(8)]
        /// </summary>
        [FieldMapping("DueDate", DbType.DateTime)]
        public DateTime DueDate
        {
            set { _duedate = value; }
            get { return _duedate; }
        }
        /// <summary>
        /// [Un-Null/varchar(5)]
        /// </summary>
        [FieldMapping("ExRateCode", DbType.String)]
        public String ExRateCode
        {
            set { _exratecode = value; }
            get { return _exratecode; }
        }
        /// <summary>
        /// [Allow Null/varchar(4)]
        /// </summary>
        [FieldMapping("PayMethod", DbType.String)]
        public String PayMethod
        {
            set { _paymethod = value; }
            get { return _paymethod; }
        }
        /// <summary>
        /// [Allow Null/nvarchar(50)]
        /// </summary>
        [FieldMapping("ARTxDesc", DbType.String)]
        public String ARTxDesc
        {
            set { _artxdesc = value; }
            get { return _artxdesc; }
        }
        /// <summary>
        /// [Allow Null/varchar(10)]
        /// </summary>
        [FieldMapping("MasterPnr", DbType.String)]
        public String MasterPnr
        {
            set { _masterpnr = value; }
            get { return _masterpnr; }
        }
        /// <summary>
        /// [Allow Null/varchar(10)]
        /// </summary>
        [FieldMapping("BkgNum", DbType.String)]
        public String BkgNum
        {
            set { _bkgnum = value; }
            get { return _bkgnum; }
        }
        /// <summary>
        /// [Allow Null/varchar(10)]
        /// </summary>
        [FieldMapping("BkgOwner", DbType.String)]
        public String BkgOwner
        {
            set { _bkgowner = value; }
            get { return _bkgowner; }
        }
        /// <summary>
        /// [Un-Null/varchar(3)]
        /// </summary>
        [FieldMapping("CurrTxn", DbType.String)]
        public String CurrTxn
        {
            set { _currtxn = value; }
            get { return _currtxn; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("AmtTxn", DbType.Decimal)]
        public Decimal AmtTxn
        {
            set { _amttxn = value; }
            get { return _amttxn; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("OAmtTxn", DbType.Decimal)]
        public Decimal OAmtTxn
        {
            set { _oamttxn = value; }
            get { return _oamttxn; }
        }
        /// <summary>
        /// [Un-Null/varchar(3)]
        /// </summary>
        [FieldMapping("CurrPrm", DbType.String)]
        public String CurrPrm
        {
            set { _currprm = value; }
            get { return _currprm; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("AmtPrm", DbType.Decimal)]
        public Decimal AmtPrm
        {
            set { _amtprm = value; }
            get { return _amtprm; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("OAmtPrm", DbType.Decimal)]
        public Decimal OAmtPrm
        {
            set { _oamtprm = value; }
            get { return _oamtprm; }
        }
        /// <summary>
        /// [Un-Null/varchar(3)]
        /// </summary>
        [FieldMapping("CurrSec", DbType.String)]
        public String CurrSec
        {
            set { _currsec = value; }
            get { return _currsec; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("AmtSec", DbType.Decimal)]
        public Decimal AmtSec
        {
            set { _amtsec = value; }
            get { return _amtsec; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("OAmtSec", DbType.Decimal)]
        public Decimal OAmtSec
        {
            set { _oamtsec = value; }
            get { return _oamtsec; }
        }
        /// <summary>
        /// [Un-Null/varchar(3)]
        /// </summary>
        [FieldMapping("CurrRpt", DbType.String)]
        public String CurrRpt
        {
            set { _currrpt = value; }
            get { return _currrpt; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("AmtRpt", DbType.Decimal)]
        public Decimal AmtRpt
        {
            set { _amtrpt = value; }
            get { return _amtrpt; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("OAmtRpt", DbType.Decimal)]
        public Decimal OAmtRpt
        {
            set { _oamtrpt = value; }
            get { return _oamtrpt; }
        }
        /// <summary>
        /// [Allow Null/datetime(8)]
        /// </summary>
        [FieldMapping("SettleOn", DbType.DateTime)]
        public DateTime SettleOn
        {
            set { _settleon = value; }
            get { return _settleon; }
        }
        /// <summary>
        /// [Allow Null/varchar(1)]
        /// </summary>
        [FieldMapping("Source", DbType.String)]
        public String Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// [Allow Null/varchar(1)]
        /// </summary>
        [FieldMapping("ARStatus", DbType.String)]
        public String ARStatus
        {
            set { _arstatus = value; }
            get { return _arstatus; }
        }
        /// <summary>
        /// [Allow Null/varchar(1)]
        /// </summary>
        [FieldMapping("BranchCode", DbType.String)]
        public String BranchCode
        {
            set { _branchcode = value; }
            get { return _branchcode; }
        }
        /// <summary>
        /// [Un-Null/varchar(3)]
        /// </summary>
        [FieldMapping("TeamCode", DbType.String)]
        public String TeamCode
        {
            set { _teamcode = value; }
            get { return _teamcode; }
        }
        /// <summary>
        /// [Allow Null/nvarchar(20)]
        /// </summary>
        [FieldMapping("CustRef", DbType.String)]
        public String CustRef
        {
            set { _custref = value; }
            get { return _custref; }
        }
        /// <summary>
        /// [Allow Null/varchar(10)]
        /// </summary>
        [FieldMapping("PurgeRef", DbType.String)]
        public String PurgeRef
        {
            set { _purgeref = value; }
            get { return _purgeref; }
        }
        /// <summary>
        /// [Allow Null/datetime(8)]
        /// </summary>
        [FieldMapping("PurgeOn", DbType.DateTime)]
        public DateTime PurgeOn
        {
            set { _purgeon = value; }
            get { return _purgeon; }
        }
        /// <summary>
        /// [Allow Null/datetime(8)]
        /// </summary>
        [FieldMapping("PostOn", DbType.DateTime)]
        public DateTime PostOn
        {
            set { _poston = value; }
            get { return _poston; }
        }
        /// <summary>
        /// [Allow Null/varchar(50)]
        /// </summary>
        [FieldMapping("PostBy", DbType.String)]
        public String PostBy
        {
            set { _postby = value; }
            get { return _postby; }
        }
        /// <summary>
        /// [Un-Null/datetime(8)]
        /// </summary>
        [FieldMapping("CreateOn", DbType.DateTime)]
        public DateTime CreateOn
        {
            set { _createon = value; }
            get { return _createon; }
        }
        /// <summary>
        /// [Un-Null/varchar(10)]
        /// </summary>
        [FieldMapping("CreateBy", DbType.String)]
        public String CreateBy
        {
            set { _createby = value; }
            get { return _createby; }
        }
        /// <summary>
        /// [Un-Null/datetime(8)]
        /// </summary>
        [FieldMapping("UpdateOn", DbType.DateTime)]
        public DateTime UpdateOn
        {
            set { _updateon = value; }
            get { return _updateon; }
        }
        /// <summary>
        /// [Un-Null/varchar(10)]
        /// </summary>
        [FieldMapping("UpdateBy", DbType.String)]
        public String UpdateBy
        {
            set { _updateby = value; }
            get { return _updateby; }
        }
        /// <summary>
        /// [Allow Null/datetime(8)]
        /// </summary>
        [FieldMapping("LastPayDate", DbType.DateTime)]
        public DateTime LastPayDate
        {
            set { _lastpaydate = value; }
            get { return _lastpaydate; }
        }
        /// <summary>
        /// [Allow Null/varchar(10)]
        /// </summary>
        [FieldMapping("Void2Jba", DbType.String)]
        public String Void2Jba
        {
            set { _void2jba = value; }
            get { return _void2jba; }
        }
        /// <summary>
        /// [Allow Null/varchar(3)]
        /// </summary>
        [FieldMapping("DisputeCode", DbType.String)]
        public String DisputeCode
        {
            set { _disputecode = value; }
            get { return _disputecode; }
        }
        #endregion Model

    }
    public class tbSqlEntitys : BaseList<tbSqlEntity, tbSqlEntitys> { }
    public class tbSqlEntityPage : PageResult<tbSqlEntity, tbSqlEntitys> { }
}

