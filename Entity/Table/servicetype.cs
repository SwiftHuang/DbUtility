using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类servicetype 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class servicetype : iTable
	{
		public servicetype()
		{}
		public enum Fields
		{
			ST_CO_CODE,
			ST_JOB_CODE,
			ST_SER_CODE,
			ST_DESC,
			ST_DESC1,
			ST_DESC_T1,
			ST_DESC_S1,
			ST_DESC_T2,
			ST_DESC_S2,
		}

		public static string TableName
		{
			get { return "servicetype"; }
		}

		#region Model
		private String _st_co_code;
		private String _st_job_code;
		private String _st_ser_code;
		private String _st_desc;
		private String _st_desc1;
		private String _st_desc_t1;
		private String _st_desc_s1;
		private String _st_desc_t2;
		private String _st_desc_s2;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_CO_CODE", TypeCode.String)]
		public String ST_CO_CODE
		{
			set{ _st_co_code=value;}
			get{return _st_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_JOB_CODE", TypeCode.String)]
		public String ST_JOB_CODE
		{
			set{ _st_job_code=value;}
			get{return _st_job_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_SER_CODE", TypeCode.String)]
		public String ST_SER_CODE
		{
			set{ _st_ser_code=value;}
			get{return _st_ser_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_DESC", TypeCode.String)]
		public String ST_DESC
		{
			set{ _st_desc=value;}
			get{return _st_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_DESC1", TypeCode.String)]
		public String ST_DESC1
		{
			set{ _st_desc1=value;}
			get{return _st_desc1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_DESC_T1", TypeCode.String)]
		public String ST_DESC_T1
		{
			set{ _st_desc_t1=value;}
			get{return _st_desc_t1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_DESC_S1", TypeCode.String)]
		public String ST_DESC_S1
		{
			set{ _st_desc_s1=value;}
			get{return _st_desc_s1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_DESC_T2", TypeCode.String)]
		public String ST_DESC_T2
		{
			set{ _st_desc_t2=value;}
			get{return _st_desc_t2;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ST_DESC_S2", TypeCode.String)]
		public String ST_DESC_S2
		{
			set{ _st_desc_s2=value;}
			get{return _st_desc_s2;}
		}
		#endregion Model

	}
}

