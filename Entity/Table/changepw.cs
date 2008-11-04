using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类changepw 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class changepw : iTable
	{
		public changepw()
		{}
		public enum Fields
		{
			CP_CO_CODE,
			CP_USER_CODE,
			CP_NEW_PWD,
		}

		public static string TableName
		{
			get { return "changepw"; }
		}

		#region Model
		private String _cp_co_code;
		private String _cp_user_code;
		private String _cp_new_pwd;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CP_CO_CODE", TypeCode.String)]
		public String CP_CO_CODE
		{
			set{ _cp_co_code=value;}
			get{return _cp_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CP_USER_CODE", TypeCode.String)]
		public String CP_USER_CODE
		{
			set{ _cp_user_code=value;}
			get{return _cp_user_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CP_NEW_PWD", TypeCode.String)]
		public String CP_NEW_PWD
		{
			set{ _cp_new_pwd=value;}
			get{return _cp_new_pwd;}
		}
		#endregion Model

	}
}

