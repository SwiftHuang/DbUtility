using System;
using TableMapping;
namespace WongTung.Entity.Table.Model
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
		[FieldMapping("CO_CODE", "", typeof(string))]
		public string CO_CODE
		{
			set{ _co_code=value;}
			get{return _co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("STAFF_CODE", "", typeof(string))]
		public string STAFF_CODE
		{
			set{ _staff_code=value;}
			get{return _staff_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DATE", "", typeof(DateTime))]
		public DateTime DATE
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TYPE", "", typeof(string))]
		public string TYPE
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ANNUAL", "", typeof(decimal))]
		public decimal? ANNUAL
		{
			set{ _annual=value;}
			get{return _annual;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("SICK", "", typeof(decimal))]
		public decimal? SICK
		{
			set{ _sick=value;}
			get{return _sick;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ADMIN", "", typeof(decimal))]
		public decimal? ADMIN
		{
			set{ _admin=value;}
			get{return _admin;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("OT_PAY", "", typeof(decimal))]
		public decimal? OT_PAY
		{
			set{ _ot_pay=value;}
			get{return _ot_pay;}
		}
		#endregion Model

	}
}

