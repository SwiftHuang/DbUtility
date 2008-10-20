using System;
using System.Collections;
using WongTung.DBUtility.TableMapping;

namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类dailyts 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class dailyts  
	{
		public dailyts()
		{}
		#region Model
		private string _dt_co_code;
		private string _dt_staff_code;
		private DateTime _dt_work_date;
		private decimal _dt_line_no;
		private string _dt_app_code;
		private string _dt_job_code;
		private string _dt_ser_code;
		private decimal? _dt_nor_hour;
		private decimal? _dt_over_hour;
		private string _dt_type;
		private string _dt_period;
		private string _dt_submit;
		private string _dt_update;
		private string _dt_ramno;
		private DateTime _dt_update_date;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_CO_CODE", "", typeof(string))]
		public string DT_CO_CODE
		{
			set{ _dt_co_code=value;}
			get{return _dt_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_STAFF_CODE", "", typeof(string))]
		public string DT_STAFF_CODE
		{
			set{ _dt_staff_code=value;}
			get{return _dt_staff_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_WORK_DATE", "", typeof(DateTime))]
		public DateTime DT_WORK_DATE
		{
			set{ _dt_work_date=value;}
			get{return _dt_work_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_LINE_NO", "", typeof(decimal))]
		public decimal DT_LINE_NO
		{
			set{ _dt_line_no=value;}
			get{return _dt_line_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_APP_CODE", "", typeof(string))]
		public string DT_APP_CODE
		{
			set{ _dt_app_code=value;}
			get{return _dt_app_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_JOB_CODE", "", typeof(string))]
		public string DT_JOB_CODE
		{
			set{ _dt_job_code=value;}
			get{return _dt_job_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_SER_CODE", "", typeof(string))]
		public string DT_SER_CODE
		{
			set{ _dt_ser_code=value;}
			get{return _dt_ser_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_NOR_HOUR", "", typeof(decimal))]
		public decimal? DT_NOR_HOUR
		{
			set{ _dt_nor_hour=value;}
			get{return _dt_nor_hour;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_OVER_HOUR", "", typeof(decimal))]
		public decimal? DT_OVER_HOUR
		{
			set{ _dt_over_hour=value;}
			get{return _dt_over_hour;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_TYPE", "", typeof(string))]
		public string DT_TYPE
		{
			set{ _dt_type=value;}
			get{return _dt_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_PERIOD", "", typeof(string))]
		public string DT_PERIOD
		{
			set{ _dt_period=value;}
			get{return _dt_period;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_SUBMIT", "", typeof(string))]
		public string DT_SUBMIT
		{
			set{ _dt_submit=value;}
			get{return _dt_submit;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_UPDATE", "", typeof(string))]
		public string DT_UPDATE
		{
			set{ _dt_update=value;}
			get{return _dt_update;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_RAMNO", "", typeof(string))]
		public string DT_RAMNO
		{
			set{ _dt_ramno=value;}
			get{return _dt_ramno;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_UPDATE_DATE", "", typeof(DateTime))]
		public DateTime DT_UPDATE_DATE
		{
			set{ _dt_update_date=value;}
			get{return _dt_update_date;}
		}
		#endregion Model

	}
}

