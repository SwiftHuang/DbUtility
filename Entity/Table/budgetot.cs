using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类budgetot 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class budgetot : iTable
	{
		public budgetot()
		{}
		public enum Fields
		{
			BG_CO_CODE,
			BG_JOB_CODE,
			BG_SER_CODE,
			BG_POS,
			BG_HOUR,
			BG_EXP_BUDGET,
		}

		public static string TableName
		{
			get { return "budgetot"; }
		}

		#region Model
		private String _bg_co_code;
		private String _bg_job_code;
		private String _bg_ser_code;
		private String _bg_pos;
		private Decimal? _bg_hour;
		private Decimal? _bg_exp_budget;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BG_CO_CODE", TypeCode.String)]
		public String BG_CO_CODE
		{
			set{ _bg_co_code=value;}
			get{return _bg_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BG_JOB_CODE", TypeCode.String)]
		public String BG_JOB_CODE
		{
			set{ _bg_job_code=value;}
			get{return _bg_job_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BG_SER_CODE", TypeCode.String)]
		public String BG_SER_CODE
		{
			set{ _bg_ser_code=value;}
			get{return _bg_ser_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BG_POS", TypeCode.String)]
		public String BG_POS
		{
			set{ _bg_pos=value;}
			get{return _bg_pos;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BG_HOUR", TypeCode.Decimal)]
		public Decimal? BG_HOUR
		{
			set{ _bg_hour=value;}
			get{return _bg_hour;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("BG_EXP_BUDGET", TypeCode.Decimal)]
		public Decimal? BG_EXP_BUDGET
		{
			set{ _bg_exp_budget=value;}
			get{return _bg_exp_budget;}
		}
		#endregion Model

	}
}

