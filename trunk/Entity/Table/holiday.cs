using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类holiday 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class holiday : iTable
	{
		public holiday()
		{}
		public enum Fields
		{
			HD_CO_CODE,
			HD_EMP_CODE,
			HD_LINE_NO,
			HD_DATE,
			HD_LEVE_CODE,
		}

		public static string TableName
		{
			get { return "holiday"; }
		}

		#region Model
		private String _hd_co_code;
		private String _hd_emp_code;
		private Decimal _hd_line_no;
		private DateTime? _hd_date;
		private String _hd_leve_code;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HD_CO_CODE", TypeCode.String)]
		public String HD_CO_CODE
		{
			set{ _hd_co_code=value;}
			get{return _hd_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HD_EMP_CODE", TypeCode.String)]
		public String HD_EMP_CODE
		{
			set{ _hd_emp_code=value;}
			get{return _hd_emp_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HD_LINE_NO", TypeCode.Decimal)]
		public Decimal HD_LINE_NO
		{
			set{ _hd_line_no=value;}
			get{return _hd_line_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HD_DATE", TypeCode.DateTime)]
		public DateTime? HD_DATE
		{
			set{ _hd_date=value;}
			get{return _hd_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HD_LEVE_CODE", TypeCode.String)]
		public String HD_LEVE_CODE
		{
			set{ _hd_leve_code=value;}
			get{return _hd_leve_code;}
		}
		#endregion Model

	}
}

