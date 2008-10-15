using System;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类backspecial 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class backspecial
	{
		public backspecial()
		{}
		#region Model
		private string _bs_co_code;
		private string _bs_code;
		private DateTime? _bs_date;
		private DateTime? _bs_curdate;
		/// <summary>
		/// 
		/// </summary>
		public string BS_CO_CODE
		{
			set{ _bs_co_code=value;}
			get{return _bs_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BS_CODE
		{
			set{ _bs_code=value;}
			get{return _bs_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BS_DATE
		{
			set{ _bs_date=value;}
			get{return _bs_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BS_CURDATE
		{
			set{ _bs_curdate=value;}
			get{return _bs_curdate;}
		}
		#endregion Model

	}
}

