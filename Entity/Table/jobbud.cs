using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类jobbud 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class jobbud : iTable
	{
		public jobbud()
		{}
		public enum Fields
		{
			JOB_CO_CODE,
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

		public static string TableName
		{
			get { return "jobbud"; }
		}

		#region Model
		private String _job_co_code;
		private String _job_code;
		private String _job_ser;
		private String _job_pos;
		private String _job_staff;
		private Decimal? _job_bud;
		private Decimal? _job_nor;
		private Decimal? _job_nor_exp;
		private Decimal? _job_ot;
		private Decimal? _job_ot_exp;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_CO_CODE", TypeCode.String)]
		public String JOB_CO_CODE
		{
			set{ _job_co_code=value;}
			get{return _job_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_CODE", TypeCode.String)]
		public String JOB_CODE
		{
			set{ _job_code=value;}
			get{return _job_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_SER", TypeCode.String)]
		public String JOB_SER
		{
			set{ _job_ser=value;}
			get{return _job_ser;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_POS", TypeCode.String)]
		public String JOB_POS
		{
			set{ _job_pos=value;}
			get{return _job_pos;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_STAFF", TypeCode.String)]
		public String JOB_STAFF
		{
			set{ _job_staff=value;}
			get{return _job_staff;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_BUD", TypeCode.Decimal)]
		public Decimal? JOB_BUD
		{
			set{ _job_bud=value;}
			get{return _job_bud;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_NOR", TypeCode.Decimal)]
		public Decimal? JOB_NOR
		{
			set{ _job_nor=value;}
			get{return _job_nor;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_NOR_EXP", TypeCode.Decimal)]
		public Decimal? JOB_NOR_EXP
		{
			set{ _job_nor_exp=value;}
			get{return _job_nor_exp;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_OT", TypeCode.Decimal)]
		public Decimal? JOB_OT
		{
			set{ _job_ot=value;}
			get{return _job_ot;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("JOB_OT_EXP", TypeCode.Decimal)]
		public Decimal? JOB_OT_EXP
		{
			set{ _job_ot_exp=value;}
			get{return _job_ot_exp;}
		}
		#endregion Model

	}
}

