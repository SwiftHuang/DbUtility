using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类worknatrue 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class worknatrue : iTable
	{
		public worknatrue()
		{}
		public enum Fields
		{
			WN_CO_CODE,
			WN_CODE,
			WN_DESC,
			WN_DESC_T,
			WN_DESC_S,
		}

		public static string TableName
		{
			get { return "worknatrue"; }
		}

		#region Model
		private String _wn_co_code;
		private String _wn_code;
		private String _wn_desc;
		private String _wn_desc_t;
		private String _wn_desc_s;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("WN_CO_CODE", TypeCode.String)]
		public String WN_CO_CODE
		{
			set{ _wn_co_code=value;}
			get{return _wn_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("WN_CODE", TypeCode.String)]
		public String WN_CODE
		{
			set{ _wn_code=value;}
			get{return _wn_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("WN_DESC", TypeCode.String)]
		public String WN_DESC
		{
			set{ _wn_desc=value;}
			get{return _wn_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("WN_DESC_T", TypeCode.String)]
		public String WN_DESC_T
		{
			set{ _wn_desc_t=value;}
			get{return _wn_desc_t;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("WN_DESC_S", TypeCode.String)]
		public String WN_DESC_S
		{
			set{ _wn_desc_s=value;}
			get{return _wn_desc_s;}
		}
		#endregion Model

	}
}

