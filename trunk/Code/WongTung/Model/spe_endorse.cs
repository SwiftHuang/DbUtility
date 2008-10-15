using System;
namespace WongTung.Model
{
	/// <summary>
	/// 实体类spe_endorse 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class spe_endorse
	{
		public spe_endorse()
		{}
		#region Model
		private string _spe_code;
		private string _spe_cre_emp;
		private DateTime? _spe_cre_date;
		/// <summary>
		/// 
		/// </summary>
		public string SPE_CODE
		{
			set{ _spe_code=value;}
			get{return _spe_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPE_CRE_EMP
		{
			set{ _spe_cre_emp=value;}
			get{return _spe_cre_emp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SPE_CRE_DATE
		{
			set{ _spe_cre_date=value;}
			get{return _spe_cre_date;}
		}
		#endregion Model

	}
}

