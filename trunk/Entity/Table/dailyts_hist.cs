using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// ʵ����dailyts_hist ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class dailyts_hist
	{
		public dailyts_hist()
		{}
		public enum Fields{DT_CO_CODE,
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
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_CO_CODE", TypeCode.String)]
		public string DT_CO_CODE
		{
			set{ _dt_co_code=value;}
			get{return _dt_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_STAFF_CODE", TypeCode.String)]
		public string DT_STAFF_CODE
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
		public decimal DT_LINE_NO
		{
			set{ _dt_line_no=value;}
			get{return _dt_line_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_APP_CODE", TypeCode.String)]
		public string DT_APP_CODE
		{
			set{ _dt_app_code=value;}
			get{return _dt_app_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_JOB_CODE", TypeCode.String)]
		public string DT_JOB_CODE
		{
			set{ _dt_job_code=value;}
			get{return _dt_job_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_SER_CODE", TypeCode.String)]
		public string DT_SER_CODE
		{
			set{ _dt_ser_code=value;}
			get{return _dt_ser_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_NOR_HOUR", TypeCode.Decimal)]
		public decimal? DT_NOR_HOUR
		{
			set{ _dt_nor_hour=value;}
			get{return _dt_nor_hour;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_OVER_HOUR", TypeCode.Decimal)]
		public decimal? DT_OVER_HOUR
		{
			set{ _dt_over_hour=value;}
			get{return _dt_over_hour;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_TYPE", TypeCode.String)]
		public string DT_TYPE
		{
			set{ _dt_type=value;}
			get{return _dt_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_PERIOD", TypeCode.String)]
		public string DT_PERIOD
		{
			set{ _dt_period=value;}
			get{return _dt_period;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DT_SUBMIT", TypeCode.String)]
		public string DT_SUBMIT
		{
			set{ _dt_submit=value;}
			get{return _dt_submit;}
		}
		#endregion Model

	}
}
