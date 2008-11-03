using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// ʵ����holiday ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class holiday
	{
		public holiday()
		{}
		public enum Fields{HD_CO_CODE,
HD_EMP_CODE,
HD_LINE_NO,
HD_DATE,
HD_LEVE_CODE,
}
		#region Model
		private string _hd_co_code;
		private string _hd_emp_code;
		private decimal _hd_line_no;
		private DateTime? _hd_date;
		private string _hd_leve_code;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HD_CO_CODE", TypeCode.String)]
		public string HD_CO_CODE
		{
			set{ _hd_co_code=value;}
			get{return _hd_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HD_EMP_CODE", TypeCode.String)]
		public string HD_EMP_CODE
		{
			set{ _hd_emp_code=value;}
			get{return _hd_emp_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HD_LINE_NO", TypeCode.Decimal)]
		public decimal HD_LINE_NO
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
		public string HD_LEVE_CODE
		{
			set{ _hd_leve_code=value;}
			get{return _hd_leve_code;}
		}
		#endregion Model

	}
}
