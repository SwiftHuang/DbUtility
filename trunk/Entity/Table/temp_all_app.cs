using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// ʵ����temp_all_app ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class temp_all_app
	{
		public temp_all_app()
		{}
		public enum Fields{TEM_CO_CODE,
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
		#region Model
		private string _tem_co_code;
		private string _tem_staff_code;
		private DateTime? _tem_work_date;
		private int? _tem_line_no;
		private string _tem_hour_type;
		private string _tem_app_code;
		private string _tem_ser_code;
		private string _tem_job_code;
		private decimal? _tem_bf_sum;
		private decimal? _tem_nor_hour_0;
		private decimal? _tem_nor_hour_1;
		private decimal? _tem_nor_hour_2;
		private decimal? _tem_nor_hour_3;
		private decimal? _tem_nor_hour_4;
		private decimal? _tem_nor_hour_5;
		private decimal? _tem_nor_hour_6;
		private string _tem_type;
		private string _tem_app_flag;
		private string _tem_que;
		private string _tem_pos_code;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_CO_CODE", TypeCode.String)]
		public string TEM_CO_CODE
		{
			set{ _tem_co_code=value;}
			get{return _tem_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_STAFF_CODE", TypeCode.String)]
		public string TEM_STAFF_CODE
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
		[FieldMapping("TEM_LINE_NO", TypeCode.Int)]
		public int? TEM_LINE_NO
		{
			set{ _tem_line_no=value;}
			get{return _tem_line_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_HOUR_TYPE", TypeCode.String)]
		public string TEM_HOUR_TYPE
		{
			set{ _tem_hour_type=value;}
			get{return _tem_hour_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_APP_CODE", TypeCode.String)]
		public string TEM_APP_CODE
		{
			set{ _tem_app_code=value;}
			get{return _tem_app_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_SER_CODE", TypeCode.String)]
		public string TEM_SER_CODE
		{
			set{ _tem_ser_code=value;}
			get{return _tem_ser_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_JOB_CODE", TypeCode.String)]
		public string TEM_JOB_CODE
		{
			set{ _tem_job_code=value;}
			get{return _tem_job_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_BF_SUM", TypeCode.Decimal)]
		public decimal? TEM_BF_SUM
		{
			set{ _tem_bf_sum=value;}
			get{return _tem_bf_sum;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_0", TypeCode.Decimal)]
		public decimal? TEM_NOR_HOUR_0
		{
			set{ _tem_nor_hour_0=value;}
			get{return _tem_nor_hour_0;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_1", TypeCode.Decimal)]
		public decimal? TEM_NOR_HOUR_1
		{
			set{ _tem_nor_hour_1=value;}
			get{return _tem_nor_hour_1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_2", TypeCode.Decimal)]
		public decimal? TEM_NOR_HOUR_2
		{
			set{ _tem_nor_hour_2=value;}
			get{return _tem_nor_hour_2;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_3", TypeCode.Decimal)]
		public decimal? TEM_NOR_HOUR_3
		{
			set{ _tem_nor_hour_3=value;}
			get{return _tem_nor_hour_3;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_4", TypeCode.Decimal)]
		public decimal? TEM_NOR_HOUR_4
		{
			set{ _tem_nor_hour_4=value;}
			get{return _tem_nor_hour_4;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_5", TypeCode.Decimal)]
		public decimal? TEM_NOR_HOUR_5
		{
			set{ _tem_nor_hour_5=value;}
			get{return _tem_nor_hour_5;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_NOR_HOUR_6", TypeCode.Decimal)]
		public decimal? TEM_NOR_HOUR_6
		{
			set{ _tem_nor_hour_6=value;}
			get{return _tem_nor_hour_6;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_TYPE", TypeCode.String)]
		public string TEM_TYPE
		{
			set{ _tem_type=value;}
			get{return _tem_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_APP_FLAG", TypeCode.String)]
		public string TEM_APP_FLAG
		{
			set{ _tem_app_flag=value;}
			get{return _tem_app_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_QUE", TypeCode.String)]
		public string TEM_QUE
		{
			set{ _tem_que=value;}
			get{return _tem_que;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TEM_POS_CODE", TypeCode.String)]
		public string TEM_POS_CODE
		{
			set{ _tem_pos_code=value;}
			get{return _tem_pos_code;}
		}
		#endregion Model

	}
}
