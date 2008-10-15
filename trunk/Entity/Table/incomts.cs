using System;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类incomts 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class incomts
	{
		public incomts()
		{}
		#region Model
		private string _ist_co_code;
		private string _ist_offcie_code;
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
		public string IST_CO_CODE
		{
			set{ _ist_co_code=value;}
			get{return _ist_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IST_OFFCIE_CODE
		{
			set{ _ist_offcie_code=value;}
			get{return _ist_offcie_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime IST_WORK_DATE
		{
			set{ _ist_work_date=value;}
			get{return _ist_work_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IST_USER_CODE
		{
			set{ _ist_user_code=value;}
			get{return _ist_user_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IST_USER_NAME
		{
			set{ _ist_user_name=value;}
			get{return _ist_user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IST_INPUT_OK
		{
			set{ _ist_input_ok=value;}
			get{return _ist_input_ok;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IST_APP
		{
			set{ _ist_app=value;}
			get{return _ist_app;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IST_NOR_HR
		{
			set{ _ist_nor_hr=value;}
			get{return _ist_nor_hr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IST_OT_HR
		{
			set{ _ist_ot_hr=value;}
			get{return _ist_ot_hr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IST_PERIOD
		{
			set{ _ist_period=value;}
			get{return _ist_period;}
		}
		#endregion Model

	}
}

