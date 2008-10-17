using System;
using TableMapping;
namespace WongTung.Entity.Table.Model
{
	/// <summary>
	/// 实体类incomts_hist 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class incomts_hist
	{
		public incomts_hist()
		{}
		#region Model
		private string _ist_co_code;
		private string _ist_office_code;
		private DateTime _ist_work_date;
		private string _ist_user_code;
		private string _ist_user_name;
		private string _ist_input_ok;
		private string _ist_app;
		private decimal? _ist_nor_hr;
		private decimal? _ist_ot_hr;
		private string _ist_period;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("IST_CO_CODE", "", typeof(string))]
		public string IST_CO_CODE
		{
			set{ _ist_co_code=value;}
			get{return _ist_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("IST_OFFICE_CODE", "", typeof(string))]
		public string IST_OFFICE_CODE
		{
			set{ _ist_office_code=value;}
			get{return _ist_office_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("IST_WORK_DATE", "", typeof(DateTime))]
		public DateTime IST_WORK_DATE
		{
			set{ _ist_work_date=value;}
			get{return _ist_work_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("IST_USER_CODE", "", typeof(string))]
		public string IST_USER_CODE
		{
			set{ _ist_user_code=value;}
			get{return _ist_user_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("IST_USER_NAME", "", typeof(string))]
		public string IST_USER_NAME
		{
			set{ _ist_user_name=value;}
			get{return _ist_user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("IST_INPUT_OK", "", typeof(string))]
		public string IST_INPUT_OK
		{
			set{ _ist_input_ok=value;}
			get{return _ist_input_ok;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("IST_APP", "", typeof(string))]
		public string IST_APP
		{
			set{ _ist_app=value;}
			get{return _ist_app;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("IST_NOR_HR", "", typeof(decimal))]
		public decimal? IST_NOR_HR
		{
			set{ _ist_nor_hr=value;}
			get{return _ist_nor_hr;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("IST_OT_HR", "", typeof(decimal))]
		public decimal? IST_OT_HR
		{
			set{ _ist_ot_hr=value;}
			get{return _ist_ot_hr;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("IST_PERIOD", "", typeof(string))]
		public string IST_PERIOD
		{
			set{ _ist_period=value;}
			get{return _ist_period;}
		}
		#endregion Model

	}
}

