using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类holiday_date 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class holiday_date
	{
		public holiday_date()
		{}
		public enum Fields{HO_CO_CODE,
HO_LOC,
HO_CODE,
HO_DATE_START,
HO_DATE_END,
HO_DESC,
}
		#region Model
		private string _ho_co_code;
		private string _ho_loc;
		private string _ho_code;
		private DateTime _ho_date_start;
		private DateTime _ho_date_end;
		private string _ho_desc;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HO_CO_CODE", TypeCode.String)]
		public string HO_CO_CODE
		{
			set{ _ho_co_code=value;}
			get{return _ho_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HO_LOC", TypeCode.String)]
		public string HO_LOC
		{
			set{ _ho_loc=value;}
			get{return _ho_loc;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HO_CODE", TypeCode.String)]
		public string HO_CODE
		{
			set{ _ho_code=value;}
			get{return _ho_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HO_DATE_START", TypeCode.DateTime)]
		public DateTime HO_DATE_START
		{
			set{ _ho_date_start=value;}
			get{return _ho_date_start;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HO_DATE_END", TypeCode.DateTime)]
		public DateTime HO_DATE_END
		{
			set{ _ho_date_end=value;}
			get{return _ho_date_end;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HO_DESC", TypeCode.String)]
		public string HO_DESC
		{
			set{ _ho_desc=value;}
			get{return _ho_desc;}
		}
		#endregion Model

	}
}

