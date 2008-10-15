using System;
namespace WongTung.Model
{
	/// <summary>
	/// 实体类userinf 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class userinf
	{
		public userinf()
		{}
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
		public string USER_CO_CODE
		{
			set{ _user_co_code=value;}
			get{return _user_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USER_CODE
		{
			set{ _user_code=value;}
			get{return _user_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USER_NAME
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USER_EMP_CODE
		{
			set{ _user_emp_code=value;}
			get{return _user_emp_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USER_RAND
		{
			set{ _user_rand=value;}
			get{return _user_rand;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? USER_CURDATE
		{
			set{ _user_curdate=value;}
			get{return _user_curdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USER_RAND_BACK
		{
			set{ _user_rand_back=value;}
			get{return _user_rand_back;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USER_ACTIVATE
		{
			set{ _user_activate=value;}
			get{return _user_activate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USER_CHNAME
		{
			set{ _user_chname=value;}
			get{return _user_chname;}
		}
		#endregion Model

	}
}

