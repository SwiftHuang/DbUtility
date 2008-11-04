using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类ptl_job_tem 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ptl_job_tem : iTable
	{
		public ptl_job_tem()
		{}
		public enum Fields
		{
			TJ_CO_CODE,
			TJ_EMP_CODE,
			TJ_LAST_DATE,
			TJ_LAST_NUM,
			TJ_JOB_1,
			TJ_JOB_2,
			TJ_JOB_3,
			TJ_JOB_4,
			TJ_JOB_5,
			TJ_JOB_6,
			TJ_JOB_7,
			TJ_JOB_8,
			TJ_JOB_9,
			TJ_JOB_10,
			TJ_JOB_11,
			TJ_JOB_12,
			TJ_JOB_13,
			TJ_JOB_14,
			TJ_JOB_15,
			TJ_JOB_16,
			TJ_JOB_17,
			TJ_JOB_18,
			TJ_JOB_19,
			TJ_JOB_20,
		}

		public static string TableName
		{
			get { return "ptl_job_tem"; }
		}

		#region Model
		private String _tj_co_code;
		private String _tj_emp_code;
		private DateTime _tj_last_date;
		private Decimal _tj_last_num;
		private String _tj_job_1;
		private String _tj_job_2;
		private String _tj_job_3;
		private String _tj_job_4;
		private String _tj_job_5;
		private String _tj_job_6;
		private String _tj_job_7;
		private String _tj_job_8;
		private String _tj_job_9;
		private String _tj_job_10;
		private String _tj_job_11;
		private String _tj_job_12;
		private String _tj_job_13;
		private String _tj_job_14;
		private String _tj_job_15;
		private String _tj_job_16;
		private String _tj_job_17;
		private String _tj_job_18;
		private String _tj_job_19;
		private String _tj_job_20;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_CO_CODE", TypeCode.String)]
		public String TJ_CO_CODE
		{
			set{ _tj_co_code=value;}
			get{return _tj_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_EMP_CODE", TypeCode.String)]
		public String TJ_EMP_CODE
		{
			set{ _tj_emp_code=value;}
			get{return _tj_emp_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_LAST_DATE", TypeCode.DateTime)]
		public DateTime TJ_LAST_DATE
		{
			set{ _tj_last_date=value;}
			get{return _tj_last_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_LAST_NUM", TypeCode.Decimal)]
		public Decimal TJ_LAST_NUM
		{
			set{ _tj_last_num=value;}
			get{return _tj_last_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_1", TypeCode.String)]
		public String TJ_JOB_1
		{
			set{ _tj_job_1=value;}
			get{return _tj_job_1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_2", TypeCode.String)]
		public String TJ_JOB_2
		{
			set{ _tj_job_2=value;}
			get{return _tj_job_2;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_3", TypeCode.String)]
		public String TJ_JOB_3
		{
			set{ _tj_job_3=value;}
			get{return _tj_job_3;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_4", TypeCode.String)]
		public String TJ_JOB_4
		{
			set{ _tj_job_4=value;}
			get{return _tj_job_4;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_5", TypeCode.String)]
		public String TJ_JOB_5
		{
			set{ _tj_job_5=value;}
			get{return _tj_job_5;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_6", TypeCode.String)]
		public String TJ_JOB_6
		{
			set{ _tj_job_6=value;}
			get{return _tj_job_6;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_7", TypeCode.String)]
		public String TJ_JOB_7
		{
			set{ _tj_job_7=value;}
			get{return _tj_job_7;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_8", TypeCode.String)]
		public String TJ_JOB_8
		{
			set{ _tj_job_8=value;}
			get{return _tj_job_8;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_9", TypeCode.String)]
		public String TJ_JOB_9
		{
			set{ _tj_job_9=value;}
			get{return _tj_job_9;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_10", TypeCode.String)]
		public String TJ_JOB_10
		{
			set{ _tj_job_10=value;}
			get{return _tj_job_10;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_11", TypeCode.String)]
		public String TJ_JOB_11
		{
			set{ _tj_job_11=value;}
			get{return _tj_job_11;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_12", TypeCode.String)]
		public String TJ_JOB_12
		{
			set{ _tj_job_12=value;}
			get{return _tj_job_12;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_13", TypeCode.String)]
		public String TJ_JOB_13
		{
			set{ _tj_job_13=value;}
			get{return _tj_job_13;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_14", TypeCode.String)]
		public String TJ_JOB_14
		{
			set{ _tj_job_14=value;}
			get{return _tj_job_14;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_15", TypeCode.String)]
		public String TJ_JOB_15
		{
			set{ _tj_job_15=value;}
			get{return _tj_job_15;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_16", TypeCode.String)]
		public String TJ_JOB_16
		{
			set{ _tj_job_16=value;}
			get{return _tj_job_16;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_17", TypeCode.String)]
		public String TJ_JOB_17
		{
			set{ _tj_job_17=value;}
			get{return _tj_job_17;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_18", TypeCode.String)]
		public String TJ_JOB_18
		{
			set{ _tj_job_18=value;}
			get{return _tj_job_18;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_19", TypeCode.String)]
		public String TJ_JOB_19
		{
			set{ _tj_job_19=value;}
			get{return _tj_job_19;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TJ_JOB_20", TypeCode.String)]
		public String TJ_JOB_20
		{
			set{ _tj_job_20=value;}
			get{return _tj_job_20;}
		}
		#endregion Model

	}
}

