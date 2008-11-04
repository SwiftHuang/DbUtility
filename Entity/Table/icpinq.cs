using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类icpinq 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class icpinq : iTable
	{
		public icpinq()
		{}
		public enum Fields
		{
			ICP_CO_CODE,
			ICP_OFFICE_CODE,
			ICP_OFFICE_NAME,
			ICP_EMP_CODE,
			ICP_EMP_NAME,
		}

		public static string TableName
		{
			get { return "icpinq"; }
		}

		#region Model
		private String _icp_co_code;
		private String _icp_office_code;
		private String _icp_office_name;
		private String _icp_emp_code;
		private String _icp_emp_name;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ICP_CO_CODE", TypeCode.String)]
		public String ICP_CO_CODE
		{
			set{ _icp_co_code=value;}
			get{return _icp_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ICP_OFFICE_CODE", TypeCode.String)]
		public String ICP_OFFICE_CODE
		{
			set{ _icp_office_code=value;}
			get{return _icp_office_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ICP_OFFICE_NAME", TypeCode.String)]
		public String ICP_OFFICE_NAME
		{
			set{ _icp_office_name=value;}
			get{return _icp_office_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ICP_EMP_CODE", TypeCode.String)]
		public String ICP_EMP_CODE
		{
			set{ _icp_emp_code=value;}
			get{return _icp_emp_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ICP_EMP_NAME", TypeCode.String)]
		public String ICP_EMP_NAME
		{
			set{ _icp_emp_name=value;}
			get{return _icp_emp_name;}
		}
		#endregion Model

	}
}

