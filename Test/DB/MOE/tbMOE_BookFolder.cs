using System;
using System.Data;
using hwj.DBUtility.Entity;
using hwj.DBUtility.TableMapping;

namespace Westminster.MOE.Entity.MOEDB.Table
{
    /// <summary>
    /// Table:MOE_BookFolder
    /// </summary>
    [Serializable]
    public class tbMOE_BookFolder : BaseTable<tbMOE_BookFolder>
    {
        public tbMOE_BookFolder()
            : base(DBTableName)
        { }
        public const string DBTableName = "MOE_BookFolder";


        public enum Fields
        {
            /// <summary>
            ///
            /// </summary>
            BFRef,
            /// <summary>
            ///
            /// </summary>
            OwnerBranch,
            /// <summary>
            ///
            /// </summary>
            OwnerTeam,
            /// <summary>
            ///
            /// </summary>
            OwnerStaff,
            /// <summary>
            ///
            /// </summary>
            BFStatus,
            /// <summary>
            ///
            /// </summary>
            DepartDate,
            /// <summary>
            ///
            /// </summary>
            Deadline,
            /// <summary>
            ///
            /// </summary>
            TourCode,
            /// <summary>
            ///
            /// </summary>
            CltCode,
            /// <summary>
            ///
            /// </summary>
            BillTo,
            /// <summary>
            ///
            /// </summary>
            CltAddr,
            /// <summary>
            ///
            /// </summary>
            Attn,
            /// <summary>
            ///
            /// </summary>
            Tel,
            /// <summary>
            ///
            /// </summary>
            Fax,
            /// <summary>
            ///
            /// </summary>
            Email,
            /// <summary>
            ///
            /// </summary>
            ContactPerson,
            /// <summary>
            ///
            /// </summary>
            BFSales,
            /// <summary>
            ///
            /// </summary>
            BFSalesTax,
            /// <summary>
            ///
            /// </summary>
            BFSalesFee,
            /// <summary>
            ///
            /// </summary>
            BFCost,
            /// <summary>
            ///
            /// </summary>
            BFCostTax,
            /// <summary>
            ///
            /// </summary>
            InvIssueOn,
            /// <summary>
            ///
            /// </summary>
            HasDeposit,
            /// <summary>
            ///
            /// </summary>
            HasCrCard,
            /// <summary>
            ///
            /// </summary>
            TktAirline,
            /// <summary>
            ///
            /// </summary>
            PaxNames,
            /// <summary>
            ///
            /// </summary>
            SrcRefs,
            /// <summary>
            ///
            /// </summary>
            CheckType,
            /// <summary>
            ///
            /// </summary>
            IssueSales,
            /// <summary>
            ///
            /// </summary>
            IssueSTax,
            /// <summary>
            ///
            /// </summary>
            IssueSFee,
            /// <summary>
            ///
            /// </summary>
            IssueCost,
            /// <summary>
            ///
            /// </summary>
            IssueCTax,
            /// <summary>
            ///
            /// </summary>
            Profit,
            /// <summary>
            ///
            /// </summary>
            ProfitWOTax,
            /// <summary>
            ///
            /// </summary>
            Yield,
            /// <summary>
            ///
            /// </summary>
            YieldWOTax,
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
            BFCostFee,
            /// <summary>
            ///
            /// </summary>
            IssueCFee,
        }

        #region Model
        private String _bfref;
        private String _ownerbranch;
        private String _ownerteam;
        private String _ownerstaff;
        private String _bfstatus;
        private DateTime _departdate;
        private DateTime _deadline;
        private String _tourcode;
        private String _cltcode;
        private String _billto;
        private String _cltaddr;
        private String _attn;
        private String _tel;
        private String _fax;
        private String _email;
        private String _contactperson;
        private Decimal _bfsales;
        private Decimal _bfsalestax;
        private Decimal _bfsalesfee;
        private Decimal _bfcost;
        private Decimal _bfcosttax;
        private DateTime _invissueon;
        private String _hasdeposit;
        private String _hascrcard;
        private String _tktairline;
        private String _paxnames;
        private String _srcrefs;
        private String _checktype;
        private Decimal _issuesales;
        private Decimal _issuestax;
        private Decimal _issuesfee;
        private Decimal _issuecost;
        private Decimal _issuectax;
        private Decimal _profit;
        private Decimal _profitwotax;
        private Decimal _yield;
        private Decimal _yieldwotax;
        private DateTime _createon;
        private String _createby;
        private DateTime _updateon;
        private String _updateby;
        private Decimal _bfcostfee;
        private Decimal _issuecfee;
        /// <summary>
        /// [PK/Un-Null/char(10)]
        /// </summary>
        [FieldMapping("BFRef", DbType.AnsiStringFixedLength, 10)]
        public String BFRef
        {
            set { AddAssigned("BFRef"); _bfref = value; }
            get { return _bfref; }
        }
        /// <summary>
        /// [Un-Null/char(1)/Default:('')]
        /// </summary>
        [FieldMapping("OwnerBranch", DbType.AnsiStringFixedLength, 1)]
        public String OwnerBranch
        {
            set { AddAssigned("OwnerBranch"); _ownerbranch = value; }
            get { return _ownerbranch; }
        }
        /// <summary>
        /// [Un-Null/char(3)]
        /// </summary>
        [FieldMapping("OwnerTeam", DbType.AnsiStringFixedLength, 3)]
        public String OwnerTeam
        {
            set { AddAssigned("OwnerTeam"); _ownerteam = value; }
            get { return _ownerteam; }
        }
        /// <summary>
        /// [Un-Null/varchar(10)]
        /// </summary>
        [FieldMapping("OwnerStaff", DbType.AnsiString, 10)]
        public String OwnerStaff
        {
            set { AddAssigned("OwnerStaff"); _ownerstaff = value; }
            get { return _ownerstaff; }
        }
        /// <summary>
        /// [Allow Null/char(1)/Default:((0))]
        /// </summary>
        [FieldMapping("BFStatus", DbType.AnsiStringFixedLength, 1)]
        public String BFStatus
        {
            set { AddAssigned("BFStatus"); _bfstatus = value; }
            get { return _bfstatus; }
        }
        /// <summary>
        /// [Allow Null/datetime(8)]
        /// </summary>
        [FieldMapping("DepartDate", DbType.DateTime, 8)]
        public DateTime DepartDate
        {
            set { AddAssigned("DepartDate"); _departdate = value; }
            get { return _departdate; }
        }
        /// <summary>
        /// [Allow Null/datetime(8)]
        /// </summary>
        [FieldMapping("Deadline", DbType.DateTime, 8)]
        public DateTime Deadline
        {
            set { AddAssigned("Deadline"); _deadline = value; }
            get { return _deadline; }
        }
        /// <summary>
        /// [Allow Null/nvarchar(30)]
        /// </summary>
        [FieldMapping("TourCode", DbType.String, 30)]
        public String TourCode
        {
            set { AddAssigned("TourCode"); _tourcode = value; }
            get { return _tourcode; }
        }
        /// <summary>
        /// [Allow Null/varchar(10)]
        /// </summary>
        [FieldMapping("CltCode", DbType.AnsiString, 10)]
        public String CltCode
        {
            set { AddAssigned("CltCode"); _cltcode = value; }
            get { return _cltcode; }
        }
        /// <summary>
        /// [Allow Null/nvarchar(100)]
        /// </summary>
        [FieldMapping("BillTo", DbType.String, 100)]
        public String BillTo
        {
            set { AddAssigned("BillTo"); _billto = value; }
            get { return _billto; }
        }
        /// <summary>
        /// [Allow Null/nvarchar(300)]
        /// </summary>
        [FieldMapping("CltAddr", DbType.String, 300)]
        public String CltAddr
        {
            set { AddAssigned("CltAddr"); _cltaddr = value; }
            get { return _cltaddr; }
        }
        /// <summary>
        /// [Allow Null/nvarchar(100)]
        /// </summary>
        [FieldMapping("Attn", DbType.String, 100)]
        public String Attn
        {
            set { AddAssigned("Attn"); _attn = value; }
            get { return _attn; }
        }
        /// <summary>
        /// [Allow Null/nvarchar(20)]
        /// </summary>
        [FieldMapping("Tel", DbType.String, 20)]
        public String Tel
        {
            set { AddAssigned("Tel"); _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// [Allow Null/nvarchar(20)]
        /// </summary>
        [FieldMapping("Fax", DbType.String, 20)]
        public String Fax
        {
            set { AddAssigned("Fax"); _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// [Allow Null/varchar(50)]
        /// </summary>
        [FieldMapping("Email", DbType.AnsiString, 50)]
        public String Email
        {
            set { AddAssigned("Email"); _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// [Allow Null/nvarchar(50)]
        /// </summary>
        [FieldMapping("ContactPerson", DbType.String, 50)]
        public String ContactPerson
        {
            set { AddAssigned("ContactPerson"); _contactperson = value; }
            get { return _contactperson; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("BFSales", DbType.Decimal, 14)]
        public Decimal BFSales
        {
            set { AddAssigned("BFSales"); _bfsales = value; }
            get { return _bfsales; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("BFSalesTax", DbType.Decimal, 14)]
        public Decimal BFSalesTax
        {
            set { AddAssigned("BFSalesTax"); _bfsalestax = value; }
            get { return _bfsalestax; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("BFSalesFee", DbType.Decimal, 14)]
        public Decimal BFSalesFee
        {
            set { AddAssigned("BFSalesFee"); _bfsalesfee = value; }
            get { return _bfsalesfee; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("BFCost", DbType.Decimal, 14)]
        public Decimal BFCost
        {
            set { AddAssigned("BFCost"); _bfcost = value; }
            get { return _bfcost; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("BFCostTax", DbType.Decimal, 14)]
        public Decimal BFCostTax
        {
            set { AddAssigned("BFCostTax"); _bfcosttax = value; }
            get { return _bfcosttax; }
        }
        /// <summary>
        /// [Allow Null/datetime(8)]
        /// </summary>
        [FieldMapping("InvIssueOn", DbType.DateTime, 8)]
        public DateTime InvIssueOn
        {
            set { AddAssigned("InvIssueOn"); _invissueon = value; }
            get { return _invissueon; }
        }
        /// <summary>
        /// [Un-Null/char(1)/Default:('N')]
        /// </summary>
        [FieldMapping("HasDeposit", DbType.AnsiStringFixedLength, 1)]
        public String HasDeposit
        {
            set { AddAssigned("HasDeposit"); _hasdeposit = value; }
            get { return _hasdeposit; }
        }
        /// <summary>
        /// [Un-Null/char(1)/Default:('N')]
        /// </summary>
        [FieldMapping("HasCrCard", DbType.AnsiStringFixedLength, 1)]
        public String HasCrCard
        {
            set { AddAssigned("HasCrCard"); _hascrcard = value; }
            get { return _hascrcard; }
        }
        /// <summary>
        /// [Un-Null/varchar(5)/Default:('')]
        /// </summary>
        [FieldMapping("TktAirline", DbType.AnsiString, 5)]
        public String TktAirline
        {
            set { AddAssigned("TktAirline"); _tktairline = value; }
            get { return _tktairline; }
        }
        /// <summary>
        /// [Un-Null/nvarchar(1000)/Default:('')]
        /// </summary>
        [FieldMapping("PaxNames", DbType.String, 1000)]
        public String PaxNames
        {
            set { AddAssigned("PaxNames"); _paxnames = value; }
            get { return _paxnames; }
        }
        /// <summary>
        /// [Un-Null/varchar(1000)/Default:('')]
        /// </summary>
        [FieldMapping("SrcRefs", DbType.AnsiString, 1000)]
        public String SrcRefs
        {
            set { AddAssigned("SrcRefs"); _srcrefs = value; }
            get { return _srcrefs; }
        }
        /// <summary>
        /// [Un-Null/char(1)/Default:('N')]
        /// </summary>
        [FieldMapping("CheckType", DbType.AnsiStringFixedLength, 1)]
        public String CheckType
        {
            set { AddAssigned("CheckType"); _checktype = value; }
            get { return _checktype; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("IssueSales", DbType.Decimal, 14)]
        public Decimal IssueSales
        {
            set { AddAssigned("IssueSales"); _issuesales = value; }
            get { return _issuesales; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("IssueSTax", DbType.Decimal, 14)]
        public Decimal IssueSTax
        {
            set { AddAssigned("IssueSTax"); _issuestax = value; }
            get { return _issuestax; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("IssueSFee", DbType.Decimal, 14)]
        public Decimal IssueSFee
        {
            set { AddAssigned("IssueSFee"); _issuesfee = value; }
            get { return _issuesfee; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("IssueCost", DbType.Decimal, 14)]
        public Decimal IssueCost
        {
            set { AddAssigned("IssueCost"); _issuecost = value; }
            get { return _issuecost; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("IssueCTax", DbType.Decimal, 14)]
        public Decimal IssueCTax
        {
            set { AddAssigned("IssueCTax"); _issuectax = value; }
            get { return _issuectax; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("Profit", DbType.Decimal, 14)]
        public Decimal Profit
        {
            set { AddAssigned("Profit"); _profit = value; }
            get { return _profit; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("ProfitWOTax", DbType.Decimal, 14)]
        public Decimal ProfitWOTax
        {
            set { AddAssigned("ProfitWOTax"); _profitwotax = value; }
            get { return _profitwotax; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("Yield", DbType.Decimal, 14)]
        public Decimal Yield
        {
            set { AddAssigned("Yield"); _yield = value; }
            get { return _yield; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("YieldWOTax", DbType.Decimal, 14)]
        public Decimal YieldWOTax
        {
            set { AddAssigned("YieldWOTax"); _yieldwotax = value; }
            get { return _yieldwotax; }
        }
        /// <summary>
        /// [Un-Null/datetime(8)]
        /// </summary>
        [FieldMapping("CreateOn", DbType.DateTime, 8)]
        public DateTime CreateOn
        {
            set { AddAssigned("CreateOn"); _createon = value; }
            get { return _createon; }
        }
        /// <summary>
        /// [Un-Null/varchar(10)]
        /// </summary>
        [FieldMapping("CreateBy", DbType.AnsiString, 10)]
        public String CreateBy
        {
            set { AddAssigned("CreateBy"); _createby = value; }
            get { return _createby; }
        }
        /// <summary>
        /// [Un-Null/datetime(8)]
        /// </summary>
        [FieldMapping("UpdateOn", DbType.DateTime, 8)]
        public DateTime UpdateOn
        {
            set { AddAssigned("UpdateOn"); _updateon = value; }
            get { return _updateon; }
        }
        /// <summary>
        /// [Un-Null/varchar(10)]
        /// </summary>
        [FieldMapping("UpdateBy", DbType.AnsiString, 10)]
        public String UpdateBy
        {
            set { AddAssigned("UpdateBy"); _updateby = value; }
            get { return _updateby; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("BFCostFee", DbType.Decimal, 14)]
        public Decimal BFCostFee
        {
            set { AddAssigned("BFCostFee"); _bfcostfee = value; }
            get { return _bfcostfee; }
        }
        /// <summary>
        /// [Un-Null/decimal(16,2)/Default:((0))]
        /// </summary>
        [FieldMapping("IssueCFee", DbType.Decimal, 14)]
        public Decimal IssueCFee
        {
            set { AddAssigned("IssueCFee"); _issuecfee = value; }
            get { return _issuecfee; }
        }
        #endregion Model

    }
    [Serializable]
    public class tbMOE_BookFolders : BaseList<tbMOE_BookFolder, tbMOE_BookFolders> { }
    public class tbMOE_BookFolderPage : PageResult<tbMOE_BookFolder, tbMOE_BookFolders> { }
}

