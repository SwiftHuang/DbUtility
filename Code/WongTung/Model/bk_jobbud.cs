using System;
namespace WongTung.Model
{
	/// <summary>
	/// 实体类bk_jobbud 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class bk_jobbud
	{
		public bk_jobbud()
		{}
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
		public string JOB_CO_CODE
		{
			set{ _job_co_code=value;}
			get{return _job_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JOB_CODE
		{
			set{ _job_code=value;}
			get{return _job_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JOB_SER
		{
			set{ _job_ser=value;}
			get{return _job_ser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JOB_POS
		{
			set{ _job_pos=value;}
			get{return _job_pos;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JOB_STAFF
		{
			set{ _job_staff=value;}
			get{return _job_staff;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? JOB_BUD
		{
			set{ _job_bud=value;}
			get{return _job_bud;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? JOB_NOR
		{
			set{ _job_nor=value;}
			get{return _job_nor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal JOB_NOR_EXP
		{
			set{ _job_nor_exp=value;}
			get{return _job_nor_exp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? JOB_OT
		{
			set{ _job_ot=value;}
			get{return _job_ot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? JOB_OT_EXP
		{
			set{ _job_ot_exp=value;}
			get{return _job_ot_exp;}
		}
		#endregion Model

	}
}

