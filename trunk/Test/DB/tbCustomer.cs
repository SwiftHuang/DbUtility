using System;
using System.Collections.Generic;
using System.Data;
using hwj.DBUtility;
using hwj.DBUtility.Entity;
using hwj.DBUtility.TableMapping;

namespace Test.DB.Entity
{
	/// <summary>
	/// 实体类tbCustomer 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class tbCustomer : BaseTable<tbCustomer>
	{
		public tbCustomer()
			: base(DBTableName)
		{
		}
		public const string DBTableName = "Customer";

		public enum Fields
		{
			/// <summary>
			///
			/// </summary>
			CompanyCode,
			/// <summary>
			///
			/// </summary>
			Cltcode,
			/// <summary>
			///
			/// </summary>
			Cltname,
			/// <summary>
			///
			/// </summary>
			TeamCode,
			/// <summary>
			///
			/// </summary>
			Masteracct,
			/// <summary>
			///
			/// </summary>
			Addr1,
			/// <summary>
			///
			/// </summary>
			Addr2,
			/// <summary>
			///
			/// </summary>
			Addr3,
			/// <summary>
			///
			/// </summary>
			Addr4,
			/// <summary>
			///
			/// </summary>
			Addr5,
			/// <summary>
			///
			/// </summary>
			Citycode,
			/// <summary>
			///
			/// </summary>
			Countrycode,
			/// <summary>
			///
			/// </summary>
			Postcode,
			/// <summary>
			///
			/// </summary>
			BillAddr1,
			/// <summary>
			///
			/// </summary>
			BillAddr2,
			/// <summary>
			///
			/// </summary>
			BillAddr3,
			/// <summary>
			///
			/// </summary>
			BillAddr4,
			/// <summary>
			///
			/// </summary>
			BillAddr5,
			/// <summary>
			///
			/// </summary>
			BillPostal,
			/// <summary>
			///
			/// </summary>
			BillCity,
			/// <summary>
			///
			/// </summary>
			BillCountry,
			/// <summary>
			///
			/// </summary>
			Phone1,
			/// <summary>
			///
			/// </summary>
			Phone2,
			/// <summary>
			///
			/// </summary>
			Fax1,
			/// <summary>
			///
			/// </summary>
			Fax2,
			/// <summary>
			///
			/// </summary>
			Title1,
			/// <summary>
			///
			/// </summary>
			Contact1,
			/// <summary>
			///
			/// </summary>
			Title2,
			/// <summary>
			///
			/// </summary>
			Contact2,
			/// <summary>
			///
			/// </summary>
			Currcode,
			/// <summary>
			///
			/// </summary>
			PayMethod,
			/// <summary>
			///
			/// </summary>
			PayTermType,
			/// <summary>
			///
			/// </summary>
			PayTermDays,
			/// <summary>
			///
			/// </summary>
			Controller,
			/// <summary>
			///
			/// </summary>
			BankGLAcct,
			/// <summary>
			///
			/// </summary>
			CtrlGLAcct,
			/// <summary>
			///
			/// </summary>
			SttGroup,
			/// <summary>
			///
			/// </summary>
			SttCopies,
			/// <summary>
			///
			/// </summary>
			Remarks,
			/// <summary>
			///
			/// </summary>
			Prftup,
			/// <summary>
			///
			/// </summary>
			Prftdown,
			/// <summary>
			///
			/// </summary>
			Category,
			/// <summary>
			///
			/// </summary>
			Email1,
			/// <summary>
			///
			/// </summary>
			Email2,
			/// <summary>
			///
			/// </summary>
			ExrateCode,
			/// <summary>
			///
			/// </summary>
			AcctStatus,
			/// <summary>
			///
			/// </summary>
			StatementAddr1,
			/// <summary>
			///
			/// </summary>
			StatementAddr2,
			/// <summary>
			///
			/// </summary>
			StatementAddr3,
			/// <summary>
			///
			/// </summary>
			StatementAddr4,
			/// <summary>
			///
			/// </summary>
			StatementAddr5,
			/// <summary>
			///
			/// </summary>
			BranchCode,
			/// <summary>
			///
			/// </summary>
			Internal,
			/// <summary>
			///
			/// </summary>
			GemsCode,
			/// <summary>
			///
			/// </summary>
			GemsCustCode,
			/// <summary>
			///
			/// </summary>
			Salesperson,
			/// <summary>
			///
			/// </summary>
			Deposit,
			/// <summary>
			///
			/// </summary>
			SalesGroup,
			/// <summary>
			///
			/// </summary>
			Createon,
			/// <summary>
			///
			/// </summary>
			Createby,
			/// <summary>
			///
			/// </summary>
			Updateon,
			/// <summary>
			///
			/// </summary>
			Updateby,
		}

		#region Model
		private String _companycode;
		private String _cltcode;
		private String _cltname;
		private String _teamcode;
		private String _masteracct;
		private String _addr1;
		private String _addr2;
		private String _addr3;
		private String _addr4;
		private String _addr5;
		private String _citycode;
		private String _countrycode;
		private String _postcode;
		private String _billaddr1;
		private String _billaddr2;
		private String _billaddr3;
		private String _billaddr4;
		private String _billaddr5;
		private String _billpostal;
		private String _billcity;
		private String _billcountry;
		private String _phone1;
		private String _phone2;
		private String _fax1;
		private String _fax2;
		private String _title1;
		private String _contact1;
		private String _title2;
		private String _contact2;
		private String _currcode;
		private String _paymethod;
		private String _paytermtype;
		private String _paytermdays;
		private String _controller;
		private String _bankglacct;
		private String _ctrlglacct;
		private String _sttgroup;
		private Int32 _sttcopies;
		private String _remarks;
		private Decimal _prftup;
		private Decimal _prftdown;
		private String _category;
		private String _email1;
		private String _email2;
		private String _exratecode;
		private String _acctstatus;
		private String _statementaddr1;
		private String _statementaddr2;
		private String _statementaddr3;
		private String _statementaddr4;
		private String _statementaddr5;
		private String _branchcode;
		private String _internal;
		private String _gemscode;
		private String _gemscustcode;
		private String _salesperson;
		private Decimal _deposit;
		private String _salesgroup;
		private DateTime _createon;
		private String _createby;
		private DateTime _updateon;
		private String _updateby;
		/// <summary>
		/// [PK/Un-Null/char(2)]
		/// </summary>
		[FieldMapping("CompanyCode", DbType.String)]
		public String CompanyCode
		{
			set{AddAssigned("CompanyCode"); _companycode=value;}
			get{return _companycode;}
		}
		/// <summary>
		/// [PK/Un-Null/varchar(8)]
		/// </summary>
		[FieldMapping("Cltcode", DbType.String)]
		public String Cltcode
		{
			set{AddAssigned("Cltcode"); _cltcode=value;}
			get{return _cltcode;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("Cltname", DbType.String)]
		public String Cltname
		{
			set{AddAssigned("Cltname"); _cltname=value;}
			get{return _cltname;}
		}
		/// <summary>
		/// [Allow Null/varchar(3)]
		/// </summary>
		[FieldMapping("TeamCode", DbType.String)]
		public String TeamCode
		{
			set{AddAssigned("TeamCode"); _teamcode=value;}
			get{return _teamcode;}
		}
		/// <summary>
		/// [Allow Null/varchar(8)]
		/// </summary>
		[FieldMapping("Masteracct", DbType.String)]
		public String Masteracct
		{
			set{AddAssigned("Masteracct"); _masteracct=value;}
			get{return _masteracct;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("Addr1", DbType.String)]
		public String Addr1
		{
			set{AddAssigned("Addr1"); _addr1=value;}
			get{return _addr1;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("Addr2", DbType.String)]
		public String Addr2
		{
			set{AddAssigned("Addr2"); _addr2=value;}
			get{return _addr2;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("Addr3", DbType.String)]
		public String Addr3
		{
			set{AddAssigned("Addr3"); _addr3=value;}
			get{return _addr3;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("Addr4", DbType.String)]
		public String Addr4
		{
			set{AddAssigned("Addr4"); _addr4=value;}
			get{return _addr4;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("Addr5", DbType.String)]
		public String Addr5
		{
			set{AddAssigned("Addr5"); _addr5=value;}
			get{return _addr5;}
		}
		/// <summary>
		/// [Allow Null/varchar(3)]
		/// </summary>
		[FieldMapping("Citycode", DbType.String)]
		public String Citycode
		{
			set{AddAssigned("Citycode"); _citycode=value;}
			get{return _citycode;}
		}
		/// <summary>
		/// [Allow Null/varchar(3)]
		/// </summary>
		[FieldMapping("Countrycode", DbType.String)]
		public String Countrycode
		{
			set{AddAssigned("Countrycode"); _countrycode=value;}
			get{return _countrycode;}
		}
		/// <summary>
		/// [Allow Null/varchar(10)]
		/// </summary>
		[FieldMapping("Postcode", DbType.String)]
		public String Postcode
		{
			set{AddAssigned("Postcode"); _postcode=value;}
			get{return _postcode;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("BillAddr1", DbType.String)]
		public String BillAddr1
		{
			set{AddAssigned("BillAddr1"); _billaddr1=value;}
			get{return _billaddr1;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("BillAddr2", DbType.String)]
		public String BillAddr2
		{
			set{AddAssigned("BillAddr2"); _billaddr2=value;}
			get{return _billaddr2;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("BillAddr3", DbType.String)]
		public String BillAddr3
		{
			set{AddAssigned("BillAddr3"); _billaddr3=value;}
			get{return _billaddr3;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("BillAddr4", DbType.String)]
		public String BillAddr4
		{
			set{AddAssigned("BillAddr4"); _billaddr4=value;}
			get{return _billaddr4;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("BillAddr5", DbType.String)]
		public String BillAddr5
		{
			set{AddAssigned("BillAddr5"); _billaddr5=value;}
			get{return _billaddr5;}
		}
		/// <summary>
		/// [Allow Null/varchar(10)]
		/// </summary>
		[FieldMapping("BillPostal", DbType.String)]
		public String BillPostal
		{
			set{AddAssigned("BillPostal"); _billpostal=value;}
			get{return _billpostal;}
		}
		/// <summary>
		/// [Allow Null/varchar(3)]
		/// </summary>
		[FieldMapping("BillCity", DbType.String)]
		public String BillCity
		{
			set{AddAssigned("BillCity"); _billcity=value;}
			get{return _billcity;}
		}
		/// <summary>
		/// [Allow Null/varchar(3)]
		/// </summary>
		[FieldMapping("BillCountry", DbType.String)]
		public String BillCountry
		{
			set{AddAssigned("BillCountry"); _billcountry=value;}
			get{return _billcountry;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(20)]
		/// </summary>
		[FieldMapping("Phone1", DbType.String)]
		public String Phone1
		{
			set{AddAssigned("Phone1"); _phone1=value;}
			get{return _phone1;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(20)]
		/// </summary>
		[FieldMapping("Phone2", DbType.String)]
		public String Phone2
		{
			set{AddAssigned("Phone2"); _phone2=value;}
			get{return _phone2;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(20)]
		/// </summary>
		[FieldMapping("Fax1", DbType.String)]
		public String Fax1
		{
			set{AddAssigned("Fax1"); _fax1=value;}
			get{return _fax1;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(20)]
		/// </summary>
		[FieldMapping("Fax2", DbType.String)]
		public String Fax2
		{
			set{AddAssigned("Fax2"); _fax2=value;}
			get{return _fax2;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("Title1", DbType.String)]
		public String Title1
		{
			set{AddAssigned("Title1"); _title1=value;}
			get{return _title1;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("Contact1", DbType.String)]
		public String Contact1
		{
			set{AddAssigned("Contact1"); _contact1=value;}
			get{return _contact1;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("Title2", DbType.String)]
		public String Title2
		{
			set{AddAssigned("Title2"); _title2=value;}
			get{return _title2;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("Contact2", DbType.String)]
		public String Contact2
		{
			set{AddAssigned("Contact2"); _contact2=value;}
			get{return _contact2;}
		}
		/// <summary>
		/// [Allow Null/varchar(3)]
		/// </summary>
		[FieldMapping("Currcode", DbType.String)]
		public String Currcode
		{
			set{AddAssigned("Currcode"); _currcode=value;}
			get{return _currcode;}
		}
		/// <summary>
		/// [Allow Null/varchar(5)]
		/// </summary>
		[FieldMapping("PayMethod", DbType.String)]
		public String PayMethod
		{
			set{AddAssigned("PayMethod"); _paymethod=value;}
			get{return _paymethod;}
		}
		/// <summary>
		/// [Allow Null/varchar(1)]
		/// </summary>
		[FieldMapping("PayTermType", DbType.String)]
		public String PayTermType
		{
			set{AddAssigned("PayTermType"); _paytermtype=value;}
			get{return _paytermtype;}
		}
		/// <summary>
		/// [Allow Null/varchar(4)]
		/// </summary>
		[FieldMapping("PayTermDays", DbType.String)]
		public String PayTermDays
		{
			set{AddAssigned("PayTermDays"); _paytermdays=value;}
			get{return _paytermdays;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(10)]
		/// </summary>
		[FieldMapping("Controller", DbType.String)]
		public String Controller
		{
			set{AddAssigned("Controller"); _controller=value;}
			get{return _controller;}
		}
		/// <summary>
		/// [Allow Null/varchar(20)]
		/// </summary>
		[FieldMapping("BankGLAcct", DbType.String)]
		public String BankGLAcct
		{
			set{AddAssigned("BankGLAcct"); _bankglacct=value;}
			get{return _bankglacct;}
		}
		/// <summary>
		/// [Allow Null/varchar(20)]
		/// </summary>
		[FieldMapping("CtrlGLAcct", DbType.String)]
		public String CtrlGLAcct
		{
			set{AddAssigned("CtrlGLAcct"); _ctrlglacct=value;}
			get{return _ctrlglacct;}
		}
		/// <summary>
		/// [Allow Null/varchar(5)]
		/// </summary>
		[FieldMapping("SttGroup", DbType.String)]
		public String SttGroup
		{
			set{AddAssigned("SttGroup"); _sttgroup=value;}
			get{return _sttgroup;}
		}
		/// <summary>
		/// [Allow Null/int(4)]
		/// </summary>
		[FieldMapping("SttCopies", DbType.Int32)]
		public Int32 SttCopies
		{
			set{AddAssigned("SttCopies"); _sttcopies=value;}
			get{return _sttcopies;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(150)]
		/// </summary>
		[FieldMapping("Remarks", DbType.String)]
		public String Remarks
		{
			set{AddAssigned("Remarks"); _remarks=value;}
			get{return _remarks;}
		}
		/// <summary>
		/// [Allow Null/numeric(9)]
		/// </summary>
		[FieldMapping("Prftup", DbType.Decimal)]
		public Decimal Prftup
		{
			set{AddAssigned("Prftup"); _prftup=value;}
			get{return _prftup;}
		}
		/// <summary>
		/// [Allow Null/numeric(9)]
		/// </summary>
		[FieldMapping("Prftdown", DbType.Decimal)]
		public Decimal Prftdown
		{
			set{AddAssigned("Prftdown"); _prftdown=value;}
			get{return _prftdown;}
		}
		/// <summary>
		/// [Allow Null/varchar(5)]
		/// </summary>
		[FieldMapping("Category", DbType.String)]
		public String Category
		{
			set{AddAssigned("Category"); _category=value;}
			get{return _category;}
		}
		/// <summary>
		/// [Allow Null/varchar(40)]
		/// </summary>
		[FieldMapping("Email1", DbType.String)]
		public String Email1
		{
			set{AddAssigned("Email1"); _email1=value;}
			get{return _email1;}
		}
		/// <summary>
		/// [Allow Null/varchar(40)]
		/// </summary>
		[FieldMapping("Email2", DbType.String)]
		public String Email2
		{
			set{AddAssigned("Email2"); _email2=value;}
			get{return _email2;}
		}
		/// <summary>
		/// [Allow Null/varchar(5)]
		/// </summary>
		[FieldMapping("ExrateCode", DbType.String)]
		public String ExrateCode
		{
			set{AddAssigned("ExrateCode"); _exratecode=value;}
			get{return _exratecode;}
		}
		/// <summary>
		/// [Allow Null/varchar(1)]
		/// </summary>
		[FieldMapping("AcctStatus", DbType.String)]
		public String AcctStatus
		{
			set{AddAssigned("AcctStatus"); _acctstatus=value;}
			get{return _acctstatus;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("StatementAddr1", DbType.String)]
		public String StatementAddr1
		{
			set{AddAssigned("StatementAddr1"); _statementaddr1=value;}
			get{return _statementaddr1;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("StatementAddr2", DbType.String)]
		public String StatementAddr2
		{
			set{AddAssigned("StatementAddr2"); _statementaddr2=value;}
			get{return _statementaddr2;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("StatementAddr3", DbType.String)]
		public String StatementAddr3
		{
			set{AddAssigned("StatementAddr3"); _statementaddr3=value;}
			get{return _statementaddr3;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("StatementAddr4", DbType.String)]
		public String StatementAddr4
		{
			set{AddAssigned("StatementAddr4"); _statementaddr4=value;}
			get{return _statementaddr4;}
		}
		/// <summary>
		/// [Allow Null/nvarchar(50)]
		/// </summary>
		[FieldMapping("StatementAddr5", DbType.String)]
		public String StatementAddr5
		{
			set{AddAssigned("StatementAddr5"); _statementaddr5=value;}
			get{return _statementaddr5;}
		}
		/// <summary>
		/// [Allow Null/varchar(1)]
		/// </summary>
		[FieldMapping("BranchCode", DbType.String)]
		public String BranchCode
		{
			set{AddAssigned("BranchCode"); _branchcode=value;}
			get{return _branchcode;}
		}
		/// <summary>
		/// [Allow Null/varchar(1)]
		/// </summary>
		[FieldMapping("Internal", DbType.String)]
		public String Internal
		{
			set{AddAssigned("Internal"); _internal=value;}
			get{return _internal;}
		}
		/// <summary>
		/// [Allow Null/varchar(8)]
		/// </summary>
		[FieldMapping("GemsCode", DbType.String)]
		public String GemsCode
		{
			set{AddAssigned("GemsCode"); _gemscode=value;}
			get{return _gemscode;}
		}
		/// <summary>
		/// [Allow Null/varchar(3)]
		/// </summary>
		[FieldMapping("GemsCustCode", DbType.String)]
		public String GemsCustCode
		{
			set{AddAssigned("GemsCustCode"); _gemscustcode=value;}
			get{return _gemscustcode;}
		}
		/// <summary>
		/// [Allow Null/varchar(5)]
		/// </summary>
		[FieldMapping("Salesperson", DbType.String)]
		public String Salesperson
		{
			set{AddAssigned("Salesperson"); _salesperson=value;}
			get{return _salesperson;}
		}
		/// <summary>
		/// [Allow Null/numeric(9)/Default:((0))]
		/// </summary>
		[FieldMapping("Deposit", DbType.Decimal)]
		public Decimal Deposit
		{
			set{AddAssigned("Deposit"); _deposit=value;}
			get{return _deposit;}
		}
		/// <summary>
		/// [Allow Null/varchar(8)]
		/// </summary>
		[FieldMapping("SalesGroup", DbType.String)]
		public String SalesGroup
		{
			set{AddAssigned("SalesGroup"); _salesgroup=value;}
			get{return _salesgroup;}
		}
		/// <summary>
		/// [Un-Null/datetime(8)]
		/// </summary>
		[FieldMapping("Createon", DbType.DateTime)]
		public DateTime Createon
		{
			set{AddAssigned("Createon"); _createon=value;}
			get{return _createon;}
		}
		/// <summary>
		/// [Un-Null/varchar(10)]
		/// </summary>
		[FieldMapping("Createby", DbType.String)]
		public String Createby
		{
			set{AddAssigned("Createby"); _createby=value;}
			get{return _createby;}
		}
		/// <summary>
		/// [Un-Null/datetime(8)]
		/// </summary>
		[FieldMapping("Updateon", DbType.DateTime)]
		public DateTime Updateon
		{
			set{AddAssigned("Updateon"); _updateon=value;}
			get{return _updateon;}
		}
		/// <summary>
		/// [Un-Null/varchar(10)]
		/// </summary>
		[FieldMapping("Updateby", DbType.String)]
		public String Updateby
		{
			set{AddAssigned("Updateby"); _updateby=value;}
			get{return _updateby;}
		}
		#endregion Model

	}
	public class tbCustomers : BaseList<tbCustomer, tbCustomers> { }
	public class tbCustomerPage : PageResult<tbCustomer, tbCustomers> { }
}

