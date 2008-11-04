using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类workstage 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class workstage : iTable
	{
		public workstage()
		{}
		public enum Fields
		{
			WT_CO_CODE,
			WT_CODE,
			WT_DESC,
			WT_DESC_T,
			WT_DESC_S,
		}

		public static string TableName
		{
			get { return "workstage"; }
		}

		#region Model
		private String _wt_co_code;
		private String _wt_code;
		private String _wt_desc;
		private String _wt_desc_t;
		private String _wt_desc_s;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("WT_CO_CODE", TypeCode.String)]
		public String WT_CO_CODE
		{
			set{ _wt_co_code=value;}
			get{return _wt_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("WT_CODE", TypeCode.String)]
		public String WT_CODE
		{
			set{ _wt_code=value;}
			get{return _wt_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("WT_DESC", TypeCode.String)]
		public String WT_DESC
		{
			set{ _wt_desc=value;}
			get{return _wt_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("WT_DESC_T", TypeCode.String)]
		public String WT_DESC_T
		{
			set{ _wt_desc_t=value;}
			get{return _wt_desc_t;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("WT_DESC_S", TypeCode.String)]
		public String WT_DESC_S
		{
			set{ _wt_desc_s=value;}
			get{return _wt_desc_s;}
		}
		#endregion Model

	}
}

