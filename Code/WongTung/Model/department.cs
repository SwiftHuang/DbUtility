using System;
namespace WongTung.Model
{
	/// <summary>
	/// 实体类department 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class department
	{
		public department()
		{}
		#region Model
		private string _dept_co_code;
		private string _dept_code;
		private string _dept_name;
		/// <summary>
		/// 
		/// </summary>
		public string DEPT_CO_CODE
		{
			set{ _dept_co_code=value;}
			get{return _dept_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEPT_CODE
		{
			set{ _dept_code=value;}
			get{return _dept_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DEPT_NAME
		{
			set{ _dept_name=value;}
			get{return _dept_name;}
		}
		#endregion Model

	}
}

