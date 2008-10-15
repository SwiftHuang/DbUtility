using System;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类workstage 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class workstage
	{
		public workstage()
		{}
		#region Model
		private string _wt_co_code;
		private string _wt_code;
		private string _wt_desc;
		private string _wt_desc_t;
		private string _wt_desc_s;
		/// <summary>
		/// 
		/// </summary>
		public string WT_CO_CODE
		{
			set{ _wt_co_code=value;}
			get{return _wt_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WT_CODE
		{
			set{ _wt_code=value;}
			get{return _wt_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WT_DESC
		{
			set{ _wt_desc=value;}
			get{return _wt_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WT_DESC_T
		{
			set{ _wt_desc_t=value;}
			get{return _wt_desc_t;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WT_DESC_S
		{
			set{ _wt_desc_s=value;}
			get{return _wt_desc_s;}
		}
		#endregion Model

	}
}

