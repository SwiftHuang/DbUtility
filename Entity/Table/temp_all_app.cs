using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类temp_all_app 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class temp_all_app : iTable
	{
		public temp_all_app()
		{}
		public enum Fields
		{
			TEM_CO_CODE,
			TEM_STAFF_CODE,
			TEM_WORK_DATE,
			TEM_LINE_NO,
			TEM_HOUR_TYPE,
			TEM_APP_CODE,
			TEM_SER_CODE,
			TEM_JOB_CODE,
			TEM_BF_SUM,
			TEM_NOR_HOUR_0,
			TEM_NOR_HOUR_1,
			TEM_NOR_HOUR_2,
			TEM_NOR_HOUR_3,
			TEM_NOR_HOUR_4,
			TEM_NOR_HOUR_5,
			TEM_NOR_HOUR_6,
			TEM_TYPE,
			TEM_APP_FLAG,
			TEM_QUE,
			TEM_POS_CODE,
		}

		public static string TableName
		{
			get { return "temp_all_app"; }
		}

		#region Model
		private String _tem_co_code;
		private String _tem_staff_code;
		private DateTime? _tem_work_date;
		private Int32? _tem_line_no;
		private String _tem_hour_type;
		private String _tem_app_code;
		private String _tem_ser_code;
		private String _tem_job_code;
		private Decimal? _tem_bf_sum;
		private Decimal? _tem_nor_hour_0;
		private Decimal? _tem_nor_hour_1;
		private Decimal? _tem_nor_hour_2;
		private Decimal? _tem_nor_hour_3;
		private Decimal? _tem_nor_hour_4;
		private Decimal? _tem_nor_hour_5;
		private Decimal? _tem_nor_hour_6;
		private String _tem_type;
		private String _tem_app_flag;
		private String _tem_que;
		private String _tem_pos_code;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_CO_CODE", TypeCode.String)]
		public String TEM_CO_CODE
		{
			set{ _tem_co_code=value;}
			get{return _tem_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_STAFF_CODE", TypeCode.String)]
		public String TEM_STAFF_CODE
		{
			set{ _tem_staff_code=value;}
			get{return _tem_staff_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_WORK_DATE", TypeCode.DateTime)]
		public DateTime? TEM_WORK_DATE
		{
			set{ _tem_work_date=value;}
			get{return _tem_work_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_LINE_NO", TypeCode.Int32)]
		public Int32? TEM_LINE_NO
		{
			set{ _tem_line_no=value;}
			get{return _tem_line_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_HOUR_TYPE", TypeCode.String)]
		public String TEM_HOUR_TYPE
		{
			set{ _tem_hour_type=value;}
			get{return _tem_hour_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_APP_CODE", TypeCode.String)]
		public String TEM_APP_CODE
		{
			set{ _tem_app_code=value;}
			get{return _tem_app_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_SER_CODE", TypeCode.String)]
		public String TEM_SER_CODE
		{
			set{ _tem_ser_code=value;}
			get{return _tem_ser_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_JOB_CODE", TypeCode.String)]
		public String TEM_JOB_CODE
		{
			set{ _tem_job_code=value;}
			get{return _tem_job_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_BF_SUM", TypeCode.Decimal)]
		public Decimal? TEM_BF_SUM
		{
			set{ _tem_bf_sum=value;}
			get{return _tem_bf_sum;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_0", TypeCode.Decimal)]
		public Decimal? TEM_NOR_HOUR_0
		{
			set{ _tem_nor_hour_0=value;}
			get{return _tem_nor_hour_0;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_1", TypeCode.Decimal)]
		public Decimal? TEM_NOR_HOUR_1
		{
			set{ _tem_nor_hour_1=value;}
			get{return _tem_nor_hour_1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_2", TypeCode.Decimal)]
		public Decimal? TEM_NOR_HOUR_2
		{
			set{ _tem_nor_hour_2=value;}
			get{return _tem_nor_hour_2;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_3", TypeCode.Decimal)]
		public Decimal? TEM_NOR_HOUR_3
		{
			set{ _tem_nor_hour_3=value;}
			get{return _tem_nor_hour_3;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_4", TypeCode.Decimal)]
		public Decimal? TEM_NOR_HOUR_4
		{
			set{ _tem_nor_hour_4=value;}
			get{return _tem_nor_hour_4;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_5", TypeCode.Decimal)]
		public Decimal? TEM_NOR_HOUR_5
		{
			set{ _tem_nor_hour_5=value;}
			get{return _tem_nor_hour_5;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_6", TypeCode.Decimal)]
		public Decimal? TEM_NOR_HOUR_6
		{
			set{ _tem_nor_hour_6=value;}
			get{return _tem_nor_hour_6;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_TYPE", TypeCode.String)]
		public String TEM_TYPE
		{
			set{ _tem_type=value;}
			get{return _tem_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_APP_FLAG", TypeCode.String)]
		public String TEM_APP_FLAG
		{
			set{ _tem_app_flag=value;}
			get{return _tem_app_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_QUE", TypeCode.String)]
		public String TEM_QUE
		{
			set{ _tem_que=value;}
			get{return _tem_que;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_POS_CODE", TypeCode.String)]
		public String TEM_POS_CODE
		{
			set{ _tem_pos_code=value;}
			get{return _tem_pos_code;}
		}
		#endregion Model

	}
}

