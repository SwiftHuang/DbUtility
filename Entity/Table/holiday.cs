using System;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类holiday 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class holiday
	{
		public holiday()
		{}
		#region Model
		private string _hd_co_code;
		private string _hd_emp_code;
		private decimal _hd_line_no;
		private DateTime? _hd_date;
		private string _hd_leve_code;
		/// <summary>
		/// 
		/// </summary>
		public string HD_CO_CODE
		{
			set{ _hd_co_code=value;}
			get{return _hd_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HD_EMP_CODE
		{
			set{ _hd_emp_code=value;}
			get{return _hd_emp_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal HD_LINE_NO
		{
			set{ _hd_line_no=value;}
			get{return _hd_line_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? HD_DATE
		{
			set{ _hd_date=value;}
			get{return _hd_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HD_LEVE_CODE
		{
			set{ _hd_leve_code=value;}
			get{return _hd_leve_code;}
		}
		#endregion Model

	}
}

