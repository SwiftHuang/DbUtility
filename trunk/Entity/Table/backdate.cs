using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类backdate 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class backdate : iTable
	{
		public backdate()
		{}
		public enum Fields
		{
			BK_CO_CODE,
			BK_USER,
			BK_RAN_NO,
			BK_EMP,
			BK_RAN_DATE,
			BK_CRE_DATE,
			BK_STATUS,
		}

		public static string TableName
		{
			get { return "backdate"; }
		}

		#region Model
		private String _bk_co_code;
		private String _bk_user;
		private String _bk_ran_no;
		private String _bk_emp;
		private DateTime _bk_ran_date;
		private DateTime _bk_cre_date;
		private String _bk_status;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BK_CO_CODE", TypeCode.String)]
		public String BK_CO_CODE
		{
			set{ _bk_co_code=value;}
			get{return _bk_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BK_USER", TypeCode.String)]
		public String BK_USER
		{
			set{ _bk_user=value;}
			get{return _bk_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BK_RAN_NO", TypeCode.String)]
		public String BK_RAN_NO
		{
			set{ _bk_ran_no=value;}
			get{return _bk_ran_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BK_EMP", TypeCode.String)]
		public String BK_EMP
		{
			set{ _bk_emp=value;}
			get{return _bk_emp;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BK_RAN_DATE", TypeCode.DateTime)]
		public DateTime BK_RAN_DATE
		{
			set{ _bk_ran_date=value;}
			get{return _bk_ran_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BK_CRE_DATE", TypeCode.DateTime)]
		public DateTime BK_CRE_DATE
		{
			set{ _bk_cre_date=value;}
			get{return _bk_cre_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BK_STATUS", TypeCode.String)]
		public String BK_STATUS
		{
			set{ _bk_status=value;}
			get{return _bk_status;}
		}
		#endregion Model

	}
}

