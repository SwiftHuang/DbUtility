using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类bk_jobbud 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class bk_jobbud
	{
		public bk_jobbud()
		{}
		public enum Fields{JOB_CO_CODE,
JOB_CODE,
JOB_SER,
JOB_POS,
JOB_STAFF,
JOB_BUD,
JOB_NOR,
JOB_NOR_EXP,
JOB_OT,
JOB_OT_EXP,
}
		#region Model
		private string _job_co_code;
		private string _job_code;
		private string _job_ser;
		private string _job_pos;
		private string _job_staff;
		private decimal? _job_bud;
		private decimal? _job_nor;
		private decimal _job_nor_exp;
		private decimal? _job_ot;
		private decimal? _job_ot_exp;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_CO_CODE", TypeCode.String)]
		public string JOB_CO_CODE
		{
			set{ _job_co_code=value;}
			get{return _job_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_CODE", TypeCode.String)]
		public string JOB_CODE
		{
			set{ _job_code=value;}
			get{return _job_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_SER", TypeCode.String)]
		public string JOB_SER
		{
			set{ _job_ser=value;}
			get{return _job_ser;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_POS", TypeCode.String)]
		public string JOB_POS
		{
			set{ _job_pos=value;}
			get{return _job_pos;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_STAFF", TypeCode.String)]
		public string JOB_STAFF
		{
			set{ _job_staff=value;}
			get{return _job_staff;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_BUD", TypeCode.Decimal)]
		public decimal? JOB_BUD
		{
			set{ _job_bud=value;}
			get{return _job_bud;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_NOR", TypeCode.Decimal)]
		public decimal? JOB_NOR
		{
			set{ _job_nor=value;}
			get{return _job_nor;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_NOR_EXP", TypeCode.Decimal)]
		public decimal JOB_NOR_EXP
		{
			set{ _job_nor_exp=value;}
			get{return _job_nor_exp;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_OT", TypeCode.Decimal)]
		public decimal? JOB_OT
		{
			set{ _job_ot=value;}
			get{return _job_ot;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_OT_EXP", TypeCode.Decimal)]
		public decimal? JOB_OT_EXP
		{
			set{ _job_ot_exp=value;}
			get{return _job_ot_exp;}
		}
		#endregion Model

	}
}

