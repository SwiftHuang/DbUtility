using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类offices 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class offices : iTable
	{
		public offices()
		{}
		public enum Fields
		{
			OFF_CO_CODE,
			OFF_CODE,
			OFF_NAME,
			OFF_ENDORSE,
		}

		public static string TableName
		{
			get { return "offices"; }
		}

		#region Model
		private String _off_co_code;
		private String _off_code;
		private String _off_name;
		private String _off_endorse;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("OFF_CO_CODE", TypeCode.String)]
		public String OFF_CO_CODE
		{
			set{ _off_co_code=value;}
			get{return _off_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("OFF_CODE", TypeCode.String)]
		public String OFF_CODE
		{
			set{ _off_code=value;}
			get{return _off_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("OFF_NAME", TypeCode.String)]
		public String OFF_NAME
		{
			set{ _off_name=value;}
			get{return _off_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("OFF_ENDORSE", TypeCode.String)]
		public String OFF_ENDORSE
		{
			set{ _off_endorse=value;}
			get{return _off_endorse;}
		}
		#endregion Model

	}
}

