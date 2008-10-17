using System;
using TableMapping;
namespace WongTung.Entity.Table.Model
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
		[FieldMapping("PR_CO_CODE", "", typeof(string))]
		public string PR_CO_CODE
		{
			set{ _pr_co_code=value;}
			get{return _pr_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PR_NO", "", typeof(decimal))]
		public decimal PR_NO
		{
			set{ _pr_no=value;}
			get{return _pr_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PR_FROM", "", typeof(string))]
		public string PR_FROM
		{
			set{ _pr_from=value;}
			get{return _pr_from;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PR_TO", "", typeof(string))]
		public string PR_TO
		{
			set{ _pr_to=value;}
			get{return _pr_to;}
		}
		#endregion Model

	}
}

