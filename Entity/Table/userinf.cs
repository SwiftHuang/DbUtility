using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类userinf 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class userinf : iTable
	{
		public userinf()
		{}
		public enum Fields
		{
			USER_CO_CODE,
			USER_CODE,
			USER_NAME,
			USER_EMP_CODE,
			USER_RAND,
			USER_CURDATE,
			USER_RAND_BACK,
			USER_ACTIVATE,
			USER_CHNAME,
		}

		public static string TableName
		{
			get { return "userinf"; }
		}

		#region Model
		private String _user_co_code;
		private String _user_code;
		private String _user_name;
		private String _user_emp_code;
		private String _user_rand;
		private DateTime? _user_curdate;
		private String _user_rand_back;
		private String _user_activate;
		private String _user_chname;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_CO_CODE", TypeCode.String)]
		public String USER_CO_CODE
		{
			set{ _user_co_code=value;}
			get{return _user_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_CODE", TypeCode.String)]
		public String USER_CODE
		{
			set{ _user_code=value;}
			get{return _user_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_NAME", TypeCode.String)]
		public String USER_NAME
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_EMP_CODE", TypeCode.String)]
		public String USER_EMP_CODE
		{
			set{ _user_emp_code=value;}
			get{return _user_emp_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_RAND", TypeCode.String)]
		public String USER_RAND
		{
			set{ _user_rand=value;}
			get{return _user_rand;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_CURDATE", TypeCode.DateTime)]
		public DateTime? USER_CURDATE
		{
			set{ _user_curdate=value;}
			get{return _user_curdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_RAND_BACK", TypeCode.String)]
		public String USER_RAND_BACK
		{
			set{ _user_rand_back=value;}
			get{return _user_rand_back;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_ACTIVATE", TypeCode.String)]
		public String USER_ACTIVATE
		{
			set{ _user_activate=value;}
			get{return _user_activate;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_CHNAME", TypeCode.String)]
		public String USER_CHNAME
		{
			set{ _user_chname=value;}
			get{return _user_chname;}
		}
		#endregion Model

	}
}

