using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类leave_bak 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class leave_bak : iTable
	{
		public leave_bak()
		{}
		public enum Fields
		{
			CO_CODE,
			LEVAE_CODE,
			LEVAE_DESC,
		}

		public static string TableName
		{
			get { return "leave_bak"; }
		}

		#region Model
		private String _co_code;
		private String _levae_code;
		private String _levae_desc;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CO_CODE", TypeCode.String)]
		public String CO_CODE
		{
			set{ _co_code=value;}
			get{return _co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("LEVAE_CODE", TypeCode.String)]
		public String LEVAE_CODE
		{
			set{ _levae_code=value;}
			get{return _levae_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("LEVAE_DESC", TypeCode.String)]
		public String LEVAE_DESC
		{
			set{ _levae_desc=value;}
			get{return _levae_desc;}
		}
		#endregion Model

	}
}

