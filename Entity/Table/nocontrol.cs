using System;
using TableMapping;
namespace WongTung.Entity.Table.Model
{
	/// <summary>
	/// 实体类nocontrol 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class nocontrol
	{
		public nocontrol()
		{}
		#region Model
		private string _no_co_code;
		private string _no_code;
		private string _no_desc;
		private decimal? _no_sta_no;
		private decimal? _no_seq_no;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("NO_CO_CODE", "", typeof(string))]
		public string NO_CO_CODE
		{
			set{ _no_co_code=value;}
			get{return _no_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("NO_CODE", "", typeof(string))]
		public string NO_CODE
		{
			set{ _no_code=value;}
			get{return _no_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("NO_DESC", "", typeof(string))]
		public string NO_DESC
		{
			set{ _no_desc=value;}
			get{return _no_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("NO_STA_NO", "", typeof(decimal))]
		public decimal? NO_STA_NO
		{
			set{ _no_sta_no=value;}
			get{return _no_sta_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("NO_SEQ_NO", "", typeof(decimal))]
		public decimal? NO_SEQ_NO
		{
			set{ _no_seq_no=value;}
			get{return _no_seq_no;}
		}
		#endregion Model

	}
}

