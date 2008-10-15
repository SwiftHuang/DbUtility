using System;
namespace WongTung.Model
{
	/// <summary>
	/// 实体类non 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class non
	{
		public non()
		{}
		#region Model
		private string _co_code;
		private string _staff_code;
		private DateTime _date;
		private string _type;
		private decimal? _annual;
		private decimal? _sick;
		private decimal? _admin;
		private decimal? _ot_pay;
		/// <summary>
		/// 
		/// </summary>
		public string CO_CODE
		{
			set{ _co_code=value;}
			get{return _co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string STAFF_CODE
		{
			set{ _staff_code=value;}
			get{return _staff_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime DATE
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TYPE
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ANNUAL
		{
			set{ _annual=value;}
			get{return _annual;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SICK
		{
			set{ _sick=value;}
			get{return _sick;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ADMIN
		{
			set{ _admin=value;}
			get{return _admin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OT_PAY
		{
			set{ _ot_pay=value;}
			get{return _ot_pay;}
		}
		#endregion Model

	}
}

