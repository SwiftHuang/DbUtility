using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类job 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class job
	{
		public job()
		{}
		#region Model
		private string _job_co_code;
		private string _job_code;
		private string _job_name;
		private decimal? _job_con;
		private decimal? _job_open_bal_hour;
		private decimal? _job_ytd_hour;
		private decimal? _job_open_bal_amt;
		private decimal? _job_ytd_amt;
		private decimal? _job_rec;
		private decimal? _job_os_bal;
		private decimal? _job_bud_hour;
		private int _job_co_ord;
		private int _job_admin;
		private int _job_design;
		private int _job_lev1;
		private int _job_lev2;
		private int _job_lev3;
		private int _job_charge_out;
		private int _job_daily;
		private int _job_mon;
		private decimal? _job_period;
		private decimal? _job_period_val;
		private string _job_auth;
		private string _job_off_inchg_ad;
		private string _job_off_inchg_des;
		private string _job_auth_1;
		private string _job_auth_2;
		private string _job_auth_3;
		private string _job_auth_4;
		private string _job_auth_5;
		private int _job_index;
		private string _job_name_s;
		private string _job_name_t;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_CO_CODE", TypeCode.String)]
		public string JOB_CO_CODE
		{
			set{ _job_co_code=value;}
			get{return _job_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_CODE", TypeCode.String)]
		public string JOB_CODE
		{
			set{ _job_code=value;}
			get{return _job_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_NAME", TypeCode.String)]
		public string JOB_NAME
		{
			set{ _job_name=value;}
			get{return _job_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_CON", TypeCode.Decimal)]
		public decimal? JOB_CON
		{
			set{ _job_con=value;}
			get{return _job_con;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_OPEN_BAL_HOUR", TypeCode.Decimal)]
		public decimal? JOB_OPEN_BAL_HOUR
		{
			set{ _job_open_bal_hour=value;}
			get{return _job_open_bal_hour;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_YTD_HOUR", TypeCode.Decimal)]
		public decimal? JOB_YTD_HOUR
		{
			set{ _job_ytd_hour=value;}
			get{return _job_ytd_hour;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_OPEN_BAL_AMT", TypeCode.Decimal)]
		public decimal? JOB_OPEN_BAL_AMT
		{
			set{ _job_open_bal_amt=value;}
			get{return _job_open_bal_amt;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_YTD_AMT", TypeCode.Decimal)]
		public decimal? JOB_YTD_AMT
		{
			set{ _job_ytd_amt=value;}
			get{return _job_ytd_amt;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_REC", TypeCode.Decimal)]
		public decimal? JOB_REC
		{
			set{ _job_rec=value;}
			get{return _job_rec;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_OS_BAL", TypeCode.Decimal)]
		public decimal? JOB_OS_BAL
		{
			set{ _job_os_bal=value;}
			get{return _job_os_bal;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_BUD_HOUR", TypeCode.Decimal)]
		public decimal? JOB_BUD_HOUR
		{
			set{ _job_bud_hour=value;}
			get{return _job_bud_hour;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_CO_ORD", TypeCode.Int32)]
		public int JOB_CO_ORD
		{
			set{ _job_co_ord=value;}
			get{return _job_co_ord;}
		}
		/// <summary>
		/// 
		/// </summary>
        [FieldMapping("JOB_ADMIN", TypeCode.Int32)]
		public int JOB_ADMIN
		{
			set{ _job_admin=value;}
			get{return _job_admin;}
		}
		/// <summary>
		/// 
		/// </summary>
        [FieldMapping("JOB_DESIGN", TypeCode.Int32)]
		public int JOB_DESIGN
		{
			set{ _job_design=value;}
			get{return _job_design;}
		}
		/// <summary>
		/// 
		/// </summary>
        [FieldMapping("JOB_LEV1", TypeCode.Int32)]
		public int JOB_LEV1
		{
			set{ _job_lev1=value;}
			get{return _job_lev1;}
		}
		/// <summary>
		/// 
		/// </summary>
        [FieldMapping("JOB_LEV2", TypeCode.Int32)]
		public int JOB_LEV2
		{
			set{ _job_lev2=value;}
			get{return _job_lev2;}
		}
		/// <summary>
		/// 
		/// </summary>
        [FieldMapping("JOB_LEV3", TypeCode.Int32)]
		public int JOB_LEV3
		{
			set{ _job_lev3=value;}
			get{return _job_lev3;}
		}
		/// <summary>
		/// 
		/// </summary>
        [FieldMapping("JOB_CHARGE_OUT", TypeCode.Int32)]
		public int JOB_CHARGE_OUT
		{
			set{ _job_charge_out=value;}
			get{return _job_charge_out;}
		}
		/// <summary>
		/// 
		/// </summary>
        [FieldMapping("JOB_DAILY", TypeCode.Int32)]
		public int JOB_DAILY
		{
			set{ _job_daily=value;}
			get{return _job_daily;}
		}
		/// <summary>
		/// 
		/// </summary>
        [FieldMapping("JOB_MON", TypeCode.Int32)]
		public int JOB_MON
		{
			set{ _job_mon=value;}
			get{return _job_mon;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_PERIOD", TypeCode.Decimal)]
		public decimal? JOB_PERIOD
		{
			set{ _job_period=value;}
			get{return _job_period;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_PERIOD_VAL", TypeCode.Decimal)]
		public decimal? JOB_PERIOD_VAL
		{
			set{ _job_period_val=value;}
			get{return _job_period_val;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_AUTH", TypeCode.String)]
		public string JOB_AUTH
		{
			set{ _job_auth=value;}
			get{return _job_auth;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_OFF_INCHG_AD", TypeCode.String)]
		public string JOB_OFF_INCHG_AD
		{
			set{ _job_off_inchg_ad=value;}
			get{return _job_off_inchg_ad;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_OFF_INCHG_DES", TypeCode.String)]
		public string JOB_OFF_INCHG_DES
		{
			set{ _job_off_inchg_des=value;}
			get{return _job_off_inchg_des;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_AUTH_1", TypeCode.String)]
		public string JOB_AUTH_1
		{
			set{ _job_auth_1=value;}
			get{return _job_auth_1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_AUTH_2", TypeCode.String)]
		public string JOB_AUTH_2
		{
			set{ _job_auth_2=value;}
			get{return _job_auth_2;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_AUTH_3", TypeCode.String)]
		public string JOB_AUTH_3
		{
			set{ _job_auth_3=value;}
			get{return _job_auth_3;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_AUTH_4", TypeCode.String)]
		public string JOB_AUTH_4
		{
			set{ _job_auth_4=value;}
			get{return _job_auth_4;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_AUTH_5", TypeCode.String)]
		public string JOB_AUTH_5
		{
			set{ _job_auth_5=value;}
			get{return _job_auth_5;}
		}
		/// <summary>
		/// 
		/// </summary>
        [FieldMapping("JOB_INDEX", TypeCode.Int32)]
		public int JOB_INDEX
		{
			set{ _job_index=value;}
			get{return _job_index;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_NAME_S", TypeCode.String)]
		public string JOB_NAME_S
		{
			set{ _job_name_s=value;}
			get{return _job_name_s;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_NAME_T", TypeCode.String)]
		public string JOB_NAME_T
		{
			set{ _job_name_t=value;}
			get{return _job_name_t;}
		}
		#endregion Model

	}
}

