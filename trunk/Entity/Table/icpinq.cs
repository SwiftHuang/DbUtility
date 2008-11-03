using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// ʵ����icpinq ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class icpinq
	{
		public icpinq()
		{}
		public enum Fields{ICP_CO_CODE,
ICP_OFFICE_CODE,
ICP_OFFICE_NAME,
ICP_EMP_CODE,
ICP_EMP_NAME,
}
		#region Model
		private string _icp_co_code;
		private string _icp_office_code;
		private string _icp_office_name;
		private string _icp_emp_code;
		private string _icp_emp_name;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ICP_CO_CODE", TypeCode.String)]
		public string ICP_CO_CODE
		{
			set{ _icp_co_code=value;}
			get{return _icp_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ICP_OFFICE_CODE", TypeCode.String)]
		public string ICP_OFFICE_CODE
		{
			set{ _icp_office_code=value;}
			get{return _icp_office_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ICP_OFFICE_NAME", TypeCode.String)]
		public string ICP_OFFICE_NAME
		{
			set{ _icp_office_name=value;}
			get{return _icp_office_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ICP_EMP_CODE", TypeCode.String)]
		public string ICP_EMP_CODE
		{
			set{ _icp_emp_code=value;}
			get{return _icp_emp_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ICP_EMP_NAME", TypeCode.String)]
		public string ICP_EMP_NAME
		{
			set{ _icp_emp_name=value;}
			get{return _icp_emp_name;}
		}
		#endregion Model

	}
}
