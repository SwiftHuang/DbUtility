using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类department 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class department
	{
		public department()
		{}
		public enum Fields{DEPT_CO_CODE,
DEPT_CODE,
DEPT_NAME,
}
		#region Model
		private string _dept_co_code;
		private string _dept_code;
		private string _dept_name;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DEPT_CO_CODE", TypeCode.String)]
		public string DEPT_CO_CODE
		{
			set{ _dept_co_code=value;}
			get{return _dept_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DEPT_CODE", TypeCode.String)]
		public string DEPT_CODE
		{
			set{ _dept_code=value;}
			get{return _dept_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DEPT_NAME", TypeCode.String)]
		public string DEPT_NAME
		{
			set{ _dept_name=value;}
			get{return _dept_name;}
		}
		#endregion Model

	}
}

