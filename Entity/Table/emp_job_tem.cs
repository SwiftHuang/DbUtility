using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类emp_job_tem 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class emp_job_tem : iTable
	{
		public emp_job_tem()
		{}
		public enum Fields
		{
			EJ_CO_CODE,
			EJ_EMP_CODE,
			EJ_LAST_DATE,
			EJ_LAST_NUM,
			EJ_JOB_1,
			EJ_JOB_2,
			EJ_JOB_3,
			EJ_JOB_4,
			EJ_JOB_5,
			EJ_JOB_6,
			EJ_JOB_7,
			EJ_JOB_8,
			EJ_JOB_9,
			EJ_JOB_10,
			EJ_JOB_11,
			EJ_JOB_12,
			EJ_JOB_13,
			EJ_JOB_14,
			EJ_JOB_15,
			EJ_JOB_16,
			EJ_JOB_17,
			EJ_JOB_18,
			EJ_JOB_19,
			EJ_JOB_20,
		}

		public static string TableName
		{
			get { return "emp_job_tem"; }
		}

		#region Model
		private String _ej_co_code;
		private String _ej_emp_code;
		private DateTime _ej_last_date;
		private Decimal _ej_last_num;
		private String _ej_job_1;
		private String _ej_job_2;
		private String _ej_job_3;
		private String _ej_job_4;
		private String _ej_job_5;
		private String _ej_job_6;
		private String _ej_job_7;
		private String _ej_job_8;
		private String _ej_job_9;
		private String _ej_job_10;
		private String _ej_job_11;
		private String _ej_job_12;
		private String _ej_job_13;
		private String _ej_job_14;
		private String _ej_job_15;
		private String _ej_job_16;
		private String _ej_job_17;
		private String _ej_job_18;
		private String _ej_job_19;
		private String _ej_job_20;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_CO_CODE", TypeCode.String)]
		public String EJ_CO_CODE
		{
			set{ _ej_co_code=value;}
			get{return _ej_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_EMP_CODE", TypeCode.String)]
		public String EJ_EMP_CODE
		{
			set{ _ej_emp_code=value;}
			get{return _ej_emp_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_LAST_DATE", TypeCode.DateTime)]
		public DateTime EJ_LAST_DATE
		{
			set{ _ej_last_date=value;}
			get{return _ej_last_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_LAST_NUM", TypeCode.Decimal)]
		public Decimal EJ_LAST_NUM
		{
			set{ _ej_last_num=value;}
			get{return _ej_last_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_1", TypeCode.String)]
		public String EJ_JOB_1
		{
			set{ _ej_job_1=value;}
			get{return _ej_job_1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_2", TypeCode.String)]
		public String EJ_JOB_2
		{
			set{ _ej_job_2=value;}
			get{return _ej_job_2;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_3", TypeCode.String)]
		public String EJ_JOB_3
		{
			set{ _ej_job_3=value;}
			get{return _ej_job_3;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_4", TypeCode.String)]
		public String EJ_JOB_4
		{
			set{ _ej_job_4=value;}
			get{return _ej_job_4;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_5", TypeCode.String)]
		public String EJ_JOB_5
		{
			set{ _ej_job_5=value;}
			get{return _ej_job_5;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_6", TypeCode.String)]
		public String EJ_JOB_6
		{
			set{ _ej_job_6=value;}
			get{return _ej_job_6;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_7", TypeCode.String)]
		public String EJ_JOB_7
		{
			set{ _ej_job_7=value;}
			get{return _ej_job_7;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_8", TypeCode.String)]
		public String EJ_JOB_8
		{
			set{ _ej_job_8=value;}
			get{return _ej_job_8;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_9", TypeCode.String)]
		public String EJ_JOB_9
		{
			set{ _ej_job_9=value;}
			get{return _ej_job_9;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_10", TypeCode.String)]
		public String EJ_JOB_10
		{
			set{ _ej_job_10=value;}
			get{return _ej_job_10;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_11", TypeCode.String)]
		public String EJ_JOB_11
		{
			set{ _ej_job_11=value;}
			get{return _ej_job_11;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_12", TypeCode.String)]
		public String EJ_JOB_12
		{
			set{ _ej_job_12=value;}
			get{return _ej_job_12;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_13", TypeCode.String)]
		public String EJ_JOB_13
		{
			set{ _ej_job_13=value;}
			get{return _ej_job_13;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_14", TypeCode.String)]
		public String EJ_JOB_14
		{
			set{ _ej_job_14=value;}
			get{return _ej_job_14;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_15", TypeCode.String)]
		public String EJ_JOB_15
		{
			set{ _ej_job_15=value;}
			get{return _ej_job_15;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_16", TypeCode.String)]
		public String EJ_JOB_16
		{
			set{ _ej_job_16=value;}
			get{return _ej_job_16;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_17", TypeCode.String)]
		public String EJ_JOB_17
		{
			set{ _ej_job_17=value;}
			get{return _ej_job_17;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_18", TypeCode.String)]
		public String EJ_JOB_18
		{
			set{ _ej_job_18=value;}
			get{return _ej_job_18;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_19", TypeCode.String)]
		public String EJ_JOB_19
		{
			set{ _ej_job_19=value;}
			get{return _ej_job_19;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("EJ_JOB_20", TypeCode.String)]
		public String EJ_JOB_20
		{
			set{ _ej_job_20=value;}
			get{return _ej_job_20;}
		}
		#endregion Model

	}
}

