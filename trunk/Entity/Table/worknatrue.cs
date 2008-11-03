using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类worknatrue 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class worknatrue
	{
		public worknatrue()
		{}
		public enum Fields{WN_CO_CODE,
WN_CODE,
WN_DESC,
WN_DESC_T,
WN_DESC_S,
}
		#region Model
		private string _wn_co_code;
		private string _wn_code;
		private string _wn_desc;
		private string _wn_desc_t;
		private string _wn_desc_s;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("WN_CO_CODE", TypeCode.String)]
		public string WN_CO_CODE
		{
			set{ _wn_co_code=value;}
			get{return _wn_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("WN_CODE", TypeCode.String)]
		public string WN_CODE
		{
			set{ _wn_code=value;}
			get{return _wn_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("WN_DESC", TypeCode.String)]
		public string WN_DESC
		{
			set{ _wn_desc=value;}
			get{return _wn_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("WN_DESC_T", TypeCode.String)]
		public string WN_DESC_T
		{
			set{ _wn_desc_t=value;}
			get{return _wn_desc_t;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("WN_DESC_S", TypeCode.String)]
		public string WN_DESC_S
		{
			set{ _wn_desc_s=value;}
			get{return _wn_desc_s;}
		}
		#endregion Model

	}
}

