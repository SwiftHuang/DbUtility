using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类prriod 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class prriod
	{
		public prriod()
		{}
		#region Model
		private string _pr_co_code;
		private decimal _pr_no;
		private string _pr_from;
		private string _pr_to;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PR_CO_CODE", TypeCode.String)]
		public string PR_CO_CODE
		{
			set{ _pr_co_code=value;}
			get{return _pr_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PR_NO", TypeCode.Decimal)]
		public decimal PR_NO
		{
			set{ _pr_no=value;}
			get{return _pr_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PR_FROM", TypeCode.String)]
		public string PR_FROM
		{
			set{ _pr_from=value;}
			get{return _pr_from;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PR_TO", TypeCode.String)]
		public string PR_TO
		{
			set{ _pr_to=value;}
			get{return _pr_to;}
		}
		#endregion Model

	}
}

