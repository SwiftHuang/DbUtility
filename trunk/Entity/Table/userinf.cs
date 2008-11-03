using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类userinf 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class userinf
	{
		public userinf()
		{}
		public enum Fields{USER_CO_CODE,
USER_CODE,
USER_NAME,
USER_EMP_CODE,
USER_RAND,
USER_CURDATE,
USER_RAND_BACK,
USER_ACTIVATE,
USER_CHNAME,
}
		#region Model
		private string _user_co_code;
		private string _user_code;
		private string _user_name;
		private string _user_emp_code;
		private string _user_rand;
		private DateTime? _user_curdate;
		private string _user_rand_back;
		private string _user_activate;
		private string _user_chname;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_CO_CODE", TypeCode.String)]
		public string USER_CO_CODE
		{
			set{ _user_co_code=value;}
			get{return _user_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_CODE", TypeCode.String)]
		public string USER_CODE
		{
			set{ _user_code=value;}
			get{return _user_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_NAME", TypeCode.String)]
		public string USER_NAME
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_EMP_CODE", TypeCode.String)]
		public string USER_EMP_CODE
		{
			set{ _user_emp_code=value;}
			get{return _user_emp_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_RAND", TypeCode.String)]
		public string USER_RAND
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
		public string USER_RAND_BACK
		{
			set{ _user_rand_back=value;}
			get{return _user_rand_back;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_ACTIVATE", TypeCode.String)]
		public string USER_ACTIVATE
		{
			set{ _user_activate=value;}
			get{return _user_activate;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("USER_CHNAME", TypeCode.String)]
		public string USER_CHNAME
		{
			set{ _user_chname=value;}
			get{return _user_chname;}
		}
		#endregion Model

	}
}

