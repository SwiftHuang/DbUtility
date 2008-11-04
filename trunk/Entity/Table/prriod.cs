using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类prriod 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class prriod : iTable
	{
		public prriod()
		{}
		public enum Fields
		{
			PR_CO_CODE,
			PR_NO,
			PR_FROM,
			PR_TO,
		}

		public static string TableName
		{
			get { return "prriod"; }
		}

		#region Model
		private String _pr_co_code;
		private Decimal _pr_no;
		private String _pr_from;
		private String _pr_to;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PR_CO_CODE", TypeCode.String)]
		public String PR_CO_CODE
		{
			set{ _pr_co_code=value;}
			get{return _pr_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PR_NO", TypeCode.Decimal)]
		public Decimal PR_NO
		{
			set{ _pr_no=value;}
			get{return _pr_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PR_FROM", TypeCode.String)]
		public String PR_FROM
		{
			set{ _pr_from=value;}
			get{return _pr_from;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PR_TO", TypeCode.String)]
		public String PR_TO
		{
			set{ _pr_to=value;}
			get{return _pr_to;}
		}
		#endregion Model

	}
}

