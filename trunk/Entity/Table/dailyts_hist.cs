using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类dailyts_hist 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class dailyts_hist : iTable
	{
		public dailyts_hist()
		{}
		public enum Fields
		{
			DT_CO_CODE,
			DT_STAFF_CODE,
			DT_WORK_DATE,
			DT_LINE_NO,
			DT_APP_CODE,
			DT_JOB_CODE,
			DT_SER_CODE,
			DT_NOR_HOUR,
			DT_OVER_HOUR,
			DT_TYPE,
			DT_PERIOD,
			DT_SUBMIT,
		}

		public static string TableName
		{
			get { return "dailyts_hist"; }
		}

		#region Model
		private String _dt_co_code;
		private String _dt_staff_code;
		private DateTime _dt_work_date;
		private Decimal _dt_line_no;
		private String _dt_app_code;
		private String _dt_job_code;
		private String _dt_ser_code;
		private Decimal? _dt_nor_hour;
		private Decimal? _dt_over_hour;
		private String _dt_type;
		private String _dt_period;
		private String _dt_submit;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_CO_CODE", TypeCode.String)]
		public String DT_CO_CODE
		{
			set{ _dt_co_code=value;}
			get{return _dt_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_STAFF_CODE", TypeCode.String)]
		public String DT_STAFF_CODE
		{
			set{ _dt_staff_code=value;}
			get{return _dt_staff_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_WORK_DATE", TypeCode.DateTime)]
		public DateTime DT_WORK_DATE
		{
			set{ _dt_work_date=value;}
			get{return _dt_work_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_LINE_NO", TypeCode.Decimal)]
		public Decimal DT_LINE_NO
		{
			set{ _dt_line_no=value;}
			get{return _dt_line_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_APP_CODE", TypeCode.String)]
		public String DT_APP_CODE
		{
			set{ _dt_app_code=value;}
			get{return _dt_app_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_JOB_CODE", TypeCode.String)]
		public String DT_JOB_CODE
		{
			set{ _dt_job_code=value;}
			get{return _dt_job_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_SER_CODE", TypeCode.String)]
		public String DT_SER_CODE
		{
			set{ _dt_ser_code=value;}
			get{return _dt_ser_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_NOR_HOUR", TypeCode.Decimal)]
		public Decimal? DT_NOR_HOUR
		{
			set{ _dt_nor_hour=value;}
			get{return _dt_nor_hour;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_OVER_HOUR", TypeCode.Decimal)]
		public Decimal? DT_OVER_HOUR
		{
			set{ _dt_over_hour=value;}
			get{return _dt_over_hour;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_TYPE", TypeCode.String)]
		public String DT_TYPE
		{
			set{ _dt_type=value;}
			get{return _dt_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_PERIOD", TypeCode.String)]
		public String DT_PERIOD
		{
			set{ _dt_period=value;}
			get{return _dt_period;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_SUBMIT", TypeCode.String)]
		public String DT_SUBMIT
		{
			set{ _dt_submit=value;}
			get{return _dt_submit;}
		}
		#endregion Model

	}
}

