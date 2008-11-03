using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类temp_day_inq 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class temp_day_inq
	{
		public temp_day_inq()
		{}
		public enum Fields{TEM_CO_CODE,
TEM_STAFF_CODE,
TEM_WORK_DATE,
TEM_LINE_NO,
TEM_HOUR_TYPE,
TEM_APP_CODE,
TEM_SER_CODE,
TEM_JOB_CODE,
TEM_NOR_HOUR_0,
TEM_NOR_HOUR_1,
TEM_NOR_HOUR_2,
TEM_NOR_HOUR_3,
TEM_NOR_HOUR_4,
TEM_NOR_HOUR_5,
TEM_NOR_HOUR_6,
TEM_TYPE,
TEM_APP_FLAG,
}
		#region Model
		private string _tem_co_code;
		private string _tem_staff_code;
		private DateTime _tem_work_date;
		private decimal _tem_line_no;
		private string _tem_hour_type;
		private string _tem_app_code;
		private string _tem_ser_code;
		private string _tem_job_code;
		private decimal? _tem_nor_hour_0;
		private decimal? _tem_nor_hour_1;
		private decimal? _tem_nor_hour_2;
		private decimal? _tem_nor_hour_3;
		private decimal? _tem_nor_hour_4;
		private decimal? _tem_nor_hour_5;
		private decimal? _tem_nor_hour_6;
		private string _tem_type;
		private string _tem_app_flag;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_CO_CODE", TypeCode.String)]
		public string TEM_CO_CODE
		{
			set{ _tem_co_code=value;}
			get{return _tem_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_STAFF_CODE", TypeCode.String)]
		public string TEM_STAFF_CODE
		{
			set{ _tem_staff_code=value;}
			get{return _tem_staff_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_WORK_DATE", TypeCode.DateTime)]
		public DateTime TEM_WORK_DATE
		{
			set{ _tem_work_date=value;}
			get{return _tem_work_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_LINE_NO", TypeCode.Decimal)]
		public decimal TEM_LINE_NO
		{
			set{ _tem_line_no=value;}
			get{return _tem_line_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_HOUR_TYPE", TypeCode.String)]
		public string TEM_HOUR_TYPE
		{
			set{ _tem_hour_type=value;}
			get{return _tem_hour_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_APP_CODE", TypeCode.String)]
		public string TEM_APP_CODE
		{
			set{ _tem_app_code=value;}
			get{return _tem_app_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_SER_CODE", TypeCode.String)]
		public string TEM_SER_CODE
		{
			set{ _tem_ser_code=value;}
			get{return _tem_ser_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_JOB_CODE", TypeCode.String)]
		public string TEM_JOB_CODE
		{
			set{ _tem_job_code=value;}
			get{return _tem_job_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_0", TypeCode.Decimal)]
		public decimal? TEM_NOR_HOUR_0
		{
			set{ _tem_nor_hour_0=value;}
			get{return _tem_nor_hour_0;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_1", TypeCode.Decimal)]
		public decimal? TEM_NOR_HOUR_1
		{
			set{ _tem_nor_hour_1=value;}
			get{return _tem_nor_hour_1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_2", TypeCode.Decimal)]
		public decimal? TEM_NOR_HOUR_2
		{
			set{ _tem_nor_hour_2=value;}
			get{return _tem_nor_hour_2;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_3", TypeCode.Decimal)]
		public decimal? TEM_NOR_HOUR_3
		{
			set{ _tem_nor_hour_3=value;}
			get{return _tem_nor_hour_3;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_4", TypeCode.Decimal)]
		public decimal? TEM_NOR_HOUR_4
		{
			set{ _tem_nor_hour_4=value;}
			get{return _tem_nor_hour_4;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_5", TypeCode.Decimal)]
		public decimal? TEM_NOR_HOUR_5
		{
			set{ _tem_nor_hour_5=value;}
			get{return _tem_nor_hour_5;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_6", TypeCode.Decimal)]
		public decimal? TEM_NOR_HOUR_6
		{
			set{ _tem_nor_hour_6=value;}
			get{return _tem_nor_hour_6;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_TYPE", TypeCode.String)]
		public string TEM_TYPE
		{
			set{ _tem_type=value;}
			get{return _tem_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_APP_FLAG", TypeCode.String)]
		public string TEM_APP_FLAG
		{
			set{ _tem_app_flag=value;}
			get{return _tem_app_flag;}
		}
		#endregion Model

	}
}

