using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类emp_day_tem 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class emp_day_tem
	{
		public emp_day_tem()
		{}
		public enum Fields{ED_CO_CODE,
ED_EMP_CODE,
ED_JS_1,
ED_JS_2,
ED_JS_3,
ED_JS_4,
ED_JS_5,
ED_JS_6,
ED_JS_7,
ED_JS_8,
ED_JS_9,
ED_JS_10,
}
		#region Model
		private string _ed_co_code;
		private string _ed_emp_code;
		private string _ed_js_1;
		private string _ed_js_2;
		private string _ed_js_3;
		private string _ed_js_4;
		private string _ed_js_5;
		private string _ed_js_6;
		private string _ed_js_7;
		private string _ed_js_8;
		private string _ed_js_9;
		private string _ed_js_10;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ED_CO_CODE", TypeCode.String)]
		public string ED_CO_CODE
		{
			set{ _ed_co_code=value;}
			get{return _ed_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ED_EMP_CODE", TypeCode.String)]
		public string ED_EMP_CODE
		{
			set{ _ed_emp_code=value;}
			get{return _ed_emp_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ED_JS_1", TypeCode.String)]
		public string ED_JS_1
		{
			set{ _ed_js_1=value;}
			get{return _ed_js_1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ED_JS_2", TypeCode.String)]
		public string ED_JS_2
		{
			set{ _ed_js_2=value;}
			get{return _ed_js_2;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ED_JS_3", TypeCode.String)]
		public string ED_JS_3
		{
			set{ _ed_js_3=value;}
			get{return _ed_js_3;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ED_JS_4", TypeCode.String)]
		public string ED_JS_4
		{
			set{ _ed_js_4=value;}
			get{return _ed_js_4;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ED_JS_5", TypeCode.String)]
		public string ED_JS_5
		{
			set{ _ed_js_5=value;}
			get{return _ed_js_5;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ED_JS_6", TypeCode.String)]
		public string ED_JS_6
		{
			set{ _ed_js_6=value;}
			get{return _ed_js_6;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ED_JS_7", TypeCode.String)]
		public string ED_JS_7
		{
			set{ _ed_js_7=value;}
			get{return _ed_js_7;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ED_JS_8", TypeCode.String)]
		public string ED_JS_8
		{
			set{ _ed_js_8=value;}
			get{return _ed_js_8;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ED_JS_9", TypeCode.String)]
		public string ED_JS_9
		{
			set{ _ed_js_9=value;}
			get{return _ed_js_9;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ED_JS_10", TypeCode.String)]
		public string ED_JS_10
		{
			set{ _ed_js_10=value;}
			get{return _ed_js_10;}
		}
		#endregion Model

	}
}

