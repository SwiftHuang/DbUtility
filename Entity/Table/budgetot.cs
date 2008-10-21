using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类budgetot 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class budgetot
	{
		public budgetot()
		{}
		#region Model
		private string _bg_co_code;
		private string _bg_job_code;
		private string _bg_ser_code;
		private string _bg_pos;
		private decimal? _bg_hour;
		private decimal? _bg_exp_budget;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BG_CO_CODE", TypeCode.String)]
		public string BG_CO_CODE
		{
			set{ _bg_co_code=value;}
			get{return _bg_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BG_JOB_CODE", TypeCode.String)]
		public string BG_JOB_CODE
		{
			set{ _bg_job_code=value;}
			get{return _bg_job_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BG_SER_CODE", TypeCode.String)]
		public string BG_SER_CODE
		{
			set{ _bg_ser_code=value;}
			get{return _bg_ser_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BG_POS", TypeCode.String)]
		public string BG_POS
		{
			set{ _bg_pos=value;}
			get{return _bg_pos;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BG_HOUR", TypeCode.Decimal)]
		public decimal? BG_HOUR
		{
			set{ _bg_hour=value;}
			get{return _bg_hour;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BG_EXP_BUDGET", TypeCode.Decimal)]
		public decimal? BG_EXP_BUDGET
		{
			set{ _bg_exp_budget=value;}
			get{return _bg_exp_budget;}
		}
		#endregion Model

	}
}

