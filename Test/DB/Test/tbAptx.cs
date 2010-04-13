using System;
using System.Collections.Generic;
using System.Data;
using hwj.DBUtility;
using hwj.DBUtility.Entity;
using hwj.DBUtility.TableMapping;

namespace Acct.Entity
{
    /// <summary>
    /// Table:Aptx
    /// </summary>
    [Serializable]
    public class tbAptx : BaseTable<tbAptx>
    {
        public tbAptx()
            : base(DBTableName)
        { }
        public const string DBTableName = "Aptx";


        public enum Fields
        {
            /// <summary>
            ///
            /// </summary>
            CompanyCode,
            /// <summary>
            ///
            /// </summary>
            APTxNum,
            /// <summary>
            ///
            /// </summary>
            APTxType,
            /// <summary>
            ///
            /// </summary>
            DocType,
            /// <summary>
            ///
            /// </summary>
            DocNum,
            /// <summary>
            ///
            /// </summary>
            GLTxNum,
            /// <summary>
            ///
            /// </summary>
            SuppCode,
            /// <summary>
            ///
            /// </summary>
            SuppRef,
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
            DocDate,
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
            APTxDesc,
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
            BranchCode,
            /// <summary>
            ///
            /// </summary>
            TeamCode,
            /// <summary>
            ///
            /// </summary>
            APStatus,
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
        }

        #region Model
        private String _companycode;
        private String _aptxnum;
        private String _aptxtype;
        private String _doctype;
        private String _docnum;
        private String _gltxnum;
        private String _suppcode;
        private String _suppref;
        private String _ctrlglcode;
        private String _calendarcode;
        private String _periodpost;
        private DateTime _docdate;
        private DateTime _duedate;
        private String _exratecode;
        private String _paymethod;
        private String _aptxdesc;
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
        private String _branchcode;
        private String _teamcode;
        private String _apstatus;
        private String _purgeref;
        private DateTime _purgeon;
        private DateTime _poston;
        private String _postby;
        private DateTime _createon;
        private String _createby;
        private DateTime _updateon;
        private String _updateby;
        private DateTime _lastpaydate;
        /// <summary>
        /// [PK/Un-Null/char(2)]
        /// </summary>
        [FieldMapping("CompanyCode", DbType.String)]
        public String CompanyCode
        {
            set{ AddAssigned("CompanyCode"); _companycode=value; }
            get{ return _companycode; }
        }
        /// <summary>
        /// [PK/Un-Null/char(10)]
        /// </summary>
        [FieldMapping("APTxNum", DbType.String)]
        public String APTxNum
        {
            set{ AddAssigned("APTxNum"); _aptxnum=value; }
            get{ return _aptxnum; }
        }
        /// <summary>
        /// [Un-Null/varchar(5)]
        /// </summary>
        [FieldMapping("APTxType", DbType.String)]
        public String APTxType
        {
            set{ AddAssigned("APTxType"); _aptxtype=value; }
            get{ return _aptxtype; }
        }
        /// <summary>
        /// [Un-Null/varchar(5)]
        /// </summary>
        [FieldMapping("DocType", DbType.String)]
        public String DocType
        {
            set{ AddAssigned("DocType"); _doctype=value; }
            get{ return _doctype; }
        }
        /// <summary>
        /// [Un-Null/varchar(20)]
        /// </summary>
        [FieldMapping("DocNum", DbType.String)]
        public String DocNum
        {
            set{ AddAssigned("DocNum"); _docnum=value; }
            get{ return _docnum; }
        }
        /// <summary>
        /// [Allow Null/varchar(10)]
        /// </summary>
        [FieldMapping("GLTxNum", DbType.String)]
        public String GLTxNum
        {
            set{ AddAssigned("GLTxNum"); _gltxnum=value; }
            get{ return _gltxnum; }
        }
        /// <summary>
        /// [Un-Null/char(8)]
        /// </summary>
        [FieldMapping("SuppCode", DbType.String)]
        public String SuppCode
        {
            set{ AddAssigned("SuppCode"); _suppcode=value; }
            get{ return _suppcode; }
        }
        /// <summary>
        /// [Allow Null/nvarchar(50)/Default:('')]
        /// </summary>
        [FieldMapping("SuppRef", DbType.String)]
        public String SuppRef
        {
            set{ AddAssigned("SuppRef"); _suppref=value; }
            get{ return _suppref; }
        }
        /// <summary>
        /// [Un-Null/varchar(20)]
        /// </summary>
        [FieldMapping("CtrlGLCode", DbType.String)]
        public String CtrlGLCode
        {
            set{ AddAssigned("CtrlGLCode"); _ctrlglcode=value; }
            get{ return _ctrlglcode; }
        }
        /// <summary>
        /// [Un-Null/varchar(4)]
        /// </summary>
        [FieldMapping("CalendarCode", DbType.String)]
        public String CalendarCode
        {
            set{ AddAssigned("CalendarCode"); _calendarcode=value; }
            get{ return _calendarcode; }
        }
        /// <summary>
        /// [Un-Null/varchar(4)]
        /// </summary>
        [FieldMapping("PeriodPost", DbType.String)]
        public String PeriodPost
        {
            set{ AddAssigned("PeriodPost"); _periodpost=value; }
            get{ return _periodpost; }
        }
        /// <summary>
        /// [Un-Null/datetime(8)]
        /// </summary>
        [FieldMapping("DocDate", DbType.DateTime)]
        public DateTime DocDate
        {
            set{ AddAssigned("DocDate"); _docdate=value; }
            get{ return _docdate; }
        }
        /// <summary>
        /// [Un-Null/datetime(8)]
        /// </summary>
        [FieldMapping("DueDate", DbType.DateTime)]
        public DateTime DueDate
        {
            set{ AddAssigned("DueDate"); _duedate=value; }
            get{ return _duedate; }
        }
        /// <summary>
        /// [Un-Null/varchar(5)]
        /// </summary>
        [FieldMapping("ExRateCode", DbType.String)]
        public String ExRateCode
        {
            set{ AddAssigned("ExRateCode"); _exratecode=value; }
            get{ return _exratecode; }
        }
        /// <summary>
        /// [Allow Null/varchar(4)]
        /// </summary>
        [FieldMapping("PayMethod", DbType.String)]
        public String PayMethod
        {
            set{ AddAssigned("PayMethod"); _paymethod=value; }
            get{ return _paymethod; }
        }
        /// <summary>
        /// [Allow Null/nvarchar(50)]
        /// </summary>
        [FieldMapping("APTxDesc", DbType.String)]
        public String APTxDesc
        {
            set{ AddAssigned("APTxDesc"); _aptxdesc=value; }
            get{ return _aptxdesc; }
        }
        /// <summary>
        /// [Allow Null/varchar(10)]
        /// </summary>
        [FieldMapping("MasterPnr", DbType.String)]
        public String MasterPnr
        {
            set{ AddAssigned("MasterPnr"); _masterpnr=value; }
            get{ return _masterpnr; }
        }
        /// <summary>
        /// [Allow Null/varchar(10)]
        /// </summary>
        [FieldMapping("BkgNum", DbType.String)]
        public String BkgNum
        {
            set{ AddAssigned("BkgNum"); _bkgnum=value; }
            get{ return _bkgnum; }
        }
        /// <summary>
        /// [Allow Null/varchar(10)]
        /// </summary>
        [FieldMapping("BkgOwner", DbType.String)]
        public String BkgOwner
        {
            set{ AddAssigned("BkgOwner"); _bkgowner=value; }
            get{ return _bkgowner; }
        }
        /// <summary>
        /// [Un-Null/varchar(3)]
        /// </summary>
        [FieldMapping("CurrTxn", DbType.String)]
        public String CurrTxn
        {
            set{ AddAssigned("CurrTxn"); _currtxn=value; }
            get{ return _currtxn; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("AmtTxn", DbType.Decimal)]
        public Decimal AmtTxn
        {
            set{ AddAssigned("AmtTxn"); _amttxn=value; }
            get{ return _amttxn; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("OAmtTxn", DbType.Decimal)]
        public Decimal OAmtTxn
        {
            set{ AddAssigned("OAmtTxn"); _oamttxn=value; }
            get{ return _oamttxn; }
        }
        /// <summary>
        /// [Un-Null/varchar(3)]
        /// </summary>
        [FieldMapping("CurrPrm", DbType.String)]
        public String CurrPrm
        {
            set{ AddAssigned("CurrPrm"); _currprm=value; }
            get{ return _currprm; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("AmtPrm", DbType.Decimal)]
        public Decimal AmtPrm
        {
            set{ AddAssigned("AmtPrm"); _amtprm=value; }
            get{ return _amtprm; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("OAmtPrm", DbType.Decimal)]
        public Decimal OAmtPrm
        {
            set{ AddAssigned("OAmtPrm"); _oamtprm=value; }
            get{ return _oamtprm; }
        }
        /// <summary>
        /// [Un-Null/varchar(3)]
        /// </summary>
        [FieldMapping("CurrSec", DbType.String)]
        public String CurrSec
        {
            set{ AddAssigned("CurrSec"); _currsec=value; }
            get{ return _currsec; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("AmtSec", DbType.Decimal)]
        public Decimal AmtSec
        {
            set{ AddAssigned("AmtSec"); _amtsec=value; }
            get{ return _amtsec; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("OAmtSec", DbType.Decimal)]
        public Decimal OAmtSec
        {
            set{ AddAssigned("OAmtSec"); _oamtsec=value; }
            get{ return _oamtsec; }
        }
        /// <summary>
        /// [Un-Null/varchar(3)]
        /// </summary>
        [FieldMapping("CurrRpt", DbType.String)]
        public String CurrRpt
        {
            set{ AddAssigned("CurrRpt"); _currrpt=value; }
            get{ return _currrpt; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("AmtRpt", DbType.Decimal)]
        public Decimal AmtRpt
        {
            set{ AddAssigned("AmtRpt"); _amtrpt=value; }
            get{ return _amtrpt; }
        }
        /// <summary>
        /// [Un-Null/decimal(17)]
        /// </summary>
        [FieldMapping("OAmtRpt", DbType.Decimal)]
        public Decimal OAmtRpt
        {
            set{ AddAssigned("OAmtRpt"); _oamtrpt=value; }
            get{ return _oamtrpt; }
        }
        /// <summary>
        /// [Allow Null/datetime(8)]
        /// </summary>
        [FieldMapping("SettleOn", DbType.DateTime)]
        public DateTime SettleOn
        {
            set{ AddAssigned("SettleOn"); _settleon=value; }
            get{ return _settleon; }
        }
        /// <summary>
        /// [Allow Null/varchar(1)]
        /// </summary>
        [FieldMapping("Source", DbType.String)]
        public String Source
        {
            set{ AddAssigned("Source"); _source=value; }
            get{ return _source; }
        }
        /// <summary>
        /// [Allow Null/varchar(1)]
        /// </summary>
        [FieldMapping("BranchCode", DbType.String)]
        public String BranchCode
        {
            set{ AddAssigned("BranchCode"); _branchcode=value; }
            get{ return _branchcode; }
        }
        /// <summary>
        /// [Un-Null/varchar(3)]
        /// </summary>
        [FieldMapping("TeamCode", DbType.String)]
        public String TeamCode
        {
            set{ AddAssigned("TeamCode"); _teamcode=value; }
            get{ return _teamcode; }
        }
        /// <summary>
        /// [Allow Null/varchar(1)/Default:('N')]
        /// </summary>
        [FieldMapping("APStatus", DbType.String)]
        public String APStatus
        {
            set{ AddAssigned("APStatus"); _apstatus=value; }
            get{ return _apstatus; }
        }
        /// <summary>
        /// [Allow Null/varchar(10)]
        /// </summary>
        [FieldMapping("PurgeRef", DbType.String)]
        public String PurgeRef
        {
            set{ AddAssigned("PurgeRef"); _purgeref=value; }
            get{ return _purgeref; }
        }
        /// <summary>
        /// [Allow Null/datetime(8)]
        /// </summary>
        [FieldMapping("PurgeOn", DbType.DateTime)]
        public DateTime PurgeOn
        {
            set{ AddAssigned("PurgeOn"); _purgeon=value; }
            get{ return _purgeon; }
        }
        /// <summary>
        /// [Allow Null/datetime(8)]
        /// </summary>
        [FieldMapping("PostOn", DbType.DateTime)]
        public DateTime PostOn
        {
            set{ AddAssigned("PostOn"); _poston=value; }
            get{ return _poston; }
        }
        /// <summary>
        /// [Allow Null/varchar(50)]
        /// </summary>
        [FieldMapping("PostBy", DbType.String)]
        public String PostBy
        {
            set{ AddAssigned("PostBy"); _postby=value; }
            get{ return _postby; }
        }
        /// <summary>
        /// [Un-Null/datetime(8)]
        /// </summary>
        [FieldMapping("CreateOn", DbType.DateTime)]
        public DateTime CreateOn
        {
            set{ AddAssigned("CreateOn"); _createon=value; }
            get{ return _createon; }
        }
        /// <summary>
        /// [Un-Null/varchar(10)]
        /// </summary>
        [FieldMapping("CreateBy", DbType.String)]
        public String CreateBy
        {
            set{ AddAssigned("CreateBy"); _createby=value; }
            get{ return _createby; }
        }
        /// <summary>
        /// [Un-Null/datetime(8)]
        /// </summary>
        [FieldMapping("UpdateOn", DbType.DateTime)]
        public DateTime UpdateOn
        {
            set{ AddAssigned("UpdateOn"); _updateon=value; }
            get{ return _updateon; }
        }
        /// <summary>
        /// [Un-Null/varchar(10)]
        /// </summary>
        [FieldMapping("UpdateBy", DbType.String)]
        public String UpdateBy
        {
            set{ AddAssigned("UpdateBy"); _updateby=value; }
            get{ return _updateby; }
        }
        /// <summary>
        /// [Allow Null/datetime(8)]
        /// </summary>
        [FieldMapping("LastPayDate", DbType.DateTime)]
        public DateTime LastPayDate
        {
            set{ AddAssigned("LastPayDate"); _lastpaydate=value; }
            get{ return _lastpaydate; }
        }
        #endregion Model

    }
    public class tbAptxs : BaseList<tbAptx, tbAptxs> { }
    public class tbAptxPage : PageResult<tbAptx, tbAptxs> { }
}

