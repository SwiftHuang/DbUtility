using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类non_hist 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class non_hist
	{
		public non_hist()
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
		[FieldMapping("CO_CODE", TypeCode.String)]
		public string CO_CODE
		{
			set{ _co_code=value;}
			get{return _co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("STAFF_CODE", TypeCode.String)]
		public string STAFF_CODE
		{
			set{ _staff_code=value;}
			get{return _staff_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DATE", TypeCode.DateTime)]
		public DateTime DATE
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TYPE", TypeCode.String)]
		public string TYPE
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ANNUAL", TypeCode.Decimal)]
		public decimal? ANNUAL
		{
			set{ _annual=value;}
			get{return _annual;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("SICK", TypeCode.Decimal)]
		public decimal? SICK
		{
			set{ _sick=value;}
			get{return _sick;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ADMIN", TypeCode.Decimal)]
		public decimal? ADMIN
		{
			set{ _admin=value;}
			get{return _admin;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("OT_PAY", TypeCode.Decimal)]
		public decimal? OT_PAY
		{
			set{ _ot_pay=value;}
			get{return _ot_pay;}
		}
		#endregion Model

	}
}

