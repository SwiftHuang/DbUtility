using System;
namespace WongTung.Model
{
	/// <summary>
	/// 实体类icpinq 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class icpinq
	{
		public icpinq()
		{}
		#region Model
		private string _icp_co_code;
		private string _icp_office_code;
		private string _icp_office_name;
		private string _icp_emp_code;
		private string _icp_emp_name;
		/// <summary>
		/// 
		/// </summary>
		public string ICP_CO_CODE
		{
			set{ _icp_co_code=value;}
			get{return _icp_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ICP_OFFICE_CODE
		{
			set{ _icp_office_code=value;}
			get{return _icp_office_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ICP_OFFICE_NAME
		{
			set{ _icp_office_name=value;}
			get{return _icp_office_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ICP_EMP_CODE
		{
			set{ _icp_emp_code=value;}
			get{return _icp_emp_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ICP_EMP_NAME
		{
			set{ _icp_emp_name=value;}
			get{return _icp_emp_name;}
		}
		#endregion Model

	}
}

