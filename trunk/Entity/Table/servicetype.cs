using System;
using TableMapping;
namespace WongTung.Entity.Table.Model
{
	/// <summary>
	/// 实体类servicetype 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class servicetype
	{
		public servicetype()
		{}
		#region Model
		private string _st_co_code;
		private string _st_job_code;
		private string _st_ser_code;
		private string _st_desc;
		private string _st_desc1;
		private string _st_desc_t1;
		private string _st_desc_s1;
		private string _st_desc_t2;
		private string _st_desc_s2;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_CO_CODE", "", typeof(string))]
		public string ST_CO_CODE
		{
			set{ _st_co_code=value;}
			get{return _st_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_JOB_CODE", "", typeof(string))]
		public string ST_JOB_CODE
		{
			set{ _st_job_code=value;}
			get{return _st_job_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_SER_CODE", "", typeof(string))]
		public string ST_SER_CODE
		{
			set{ _st_ser_code=value;}
			get{return _st_ser_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_DESC", "", typeof(string))]
		public string ST_DESC
		{
			set{ _st_desc=value;}
			get{return _st_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_DESC1", "", typeof(string))]
		public string ST_DESC1
		{
			set{ _st_desc1=value;}
			get{return _st_desc1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_DESC_T1", "", typeof(string))]
		public string ST_DESC_T1
		{
			set{ _st_desc_t1=value;}
			get{return _st_desc_t1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_DESC_S1", "", typeof(string))]
		public string ST_DESC_S1
		{
			set{ _st_desc_s1=value;}
			get{return _st_desc_s1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_DESC_T2", "", typeof(string))]
		public string ST_DESC_T2
		{
			set{ _st_desc_t2=value;}
			get{return _st_desc_t2;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_DESC_S2", "", typeof(string))]
		public string ST_DESC_S2
		{
			set{ _st_desc_s2=value;}
			get{return _st_desc_s2;}
		}
		#endregion Model

	}
}

