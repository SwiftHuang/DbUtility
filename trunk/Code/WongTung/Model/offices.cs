using System;
namespace WongTung.Model
{
	/// <summary>
	/// 实体类offices 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class offices
	{
		public offices()
		{}
		#region Model
		private string _off_co_code;
		private string _off_code;
		private string _off_name;
		private string _off_endorse;
		/// <summary>
		/// 
		/// </summary>
		public string OFF_CO_CODE
		{
			set{ _off_co_code=value;}
			get{return _off_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OFF_CODE
		{
			set{ _off_code=value;}
			get{return _off_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OFF_NAME
		{
			set{ _off_name=value;}
			get{return _off_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OFF_ENDORSE
		{
			set{ _off_endorse=value;}
			get{return _off_endorse;}
		}
		#endregion Model

	}
}

