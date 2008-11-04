using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类outstanding_temp 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class outstanding_temp : iTable
	{
		public outstanding_temp()
		{}
		public enum Fields
		{
			NUM,
			OUT_OFF_CODE,
			OUT_OFF_NAME,
			OUT_EMP_CODE,
			OUT_EMP_NAME,
			OUT_DAY,
			OUT_POS_CLASS,
			OUT_POS_CODE,
			OUT_UPDATE_DATE,
		}

		public static string TableName
		{
			get { return "outstanding_temp"; }
		}

		#region Model
		private Decimal _num;
		private String _out_off_code;
		private String _out_off_name;
		private String _out_emp_code;
		private String _out_emp_name;
		private DateTime? _out_day;
		private Decimal? _out_pos_class;
		private String _out_pos_code;
		private DateTime? _out_update_date;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("NUM", TypeCode.Decimal)]
		public Decimal NUM
		{
			set{ _num=value;}
			get{return _num;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("OUT_OFF_CODE", TypeCode.String)]
		public String OUT_OFF_CODE
		{
			set{ _out_off_code=value;}
			get{return _out_off_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("OUT_OFF_NAME", TypeCode.String)]
		public String OUT_OFF_NAME
		{
			set{ _out_off_name=value;}
			get{return _out_off_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("OUT_EMP_CODE", TypeCode.String)]
		public String OUT_EMP_CODE
		{
			set{ _out_emp_code=value;}
			get{return _out_emp_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("OUT_EMP_NAME", TypeCode.String)]
		public String OUT_EMP_NAME
		{
			set{ _out_emp_name=value;}
			get{return _out_emp_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("OUT_DAY", TypeCode.DateTime)]
		public DateTime? OUT_DAY
		{
			set{ _out_day=value;}
			get{return _out_day;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("OUT_POS_CLASS", TypeCode.Decimal)]
		public Decimal? OUT_POS_CLASS
		{
			set{ _out_pos_class=value;}
			get{return _out_pos_class;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("OUT_POS_CODE", TypeCode.String)]
		public String OUT_POS_CODE
		{
			set{ _out_pos_code=value;}
			get{return _out_pos_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("OUT_UPDATE_DATE", TypeCode.DateTime)]
		public DateTime? OUT_UPDATE_DATE
		{
			set{ _out_update_date=value;}
			get{return _out_update_date;}
		}
		#endregion Model

	}
}

