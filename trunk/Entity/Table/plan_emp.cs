using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类plan_emp 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class plan_emp
	{
		public plan_emp()
		{}
		public enum Fields{PLA_EMP_CO,
PLA_EMP_OFF,
PLA_EMP_POS,
PLA_EMP_CODE,
PLA_EMP_NUM,
PLA_EMP_NOR,
PLA_EMP_OT1,
PLA_EMP_OT2,
PLA_EMP_OT3,
PLA_EMP_T1,
PLA_EMP_T2,
PLA_EMP_T3,
}
		#region Model
		private string _pla_emp_co;
		private string _pla_emp_off;
		private string _pla_emp_pos;
		private string _pla_emp_code;
		private int _pla_emp_num;
		private decimal _pla_emp_nor;
		private decimal _pla_emp_ot1;
		private decimal _pla_emp_ot2;
		private decimal _pla_emp_ot3;
		private decimal _pla_emp_t1;
		private decimal _pla_emp_t2;
		private decimal _pla_emp_t3;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PLA_EMP_CO", TypeCode.String)]
		public string PLA_EMP_CO
		{
			set{ _pla_emp_co=value;}
			get{return _pla_emp_co;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PLA_EMP_OFF", TypeCode.String)]
		public string PLA_EMP_OFF
		{
			set{ _pla_emp_off=value;}
			get{return _pla_emp_off;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PLA_EMP_POS", TypeCode.String)]
		public string PLA_EMP_POS
		{
			set{ _pla_emp_pos=value;}
			get{return _pla_emp_pos;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PLA_EMP_CODE", TypeCode.String)]
		public string PLA_EMP_CODE
		{
			set{ _pla_emp_code=value;}
			get{return _pla_emp_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PLA_EMP_NUM", TypeCode.Int)]
		public int PLA_EMP_NUM
		{
			set{ _pla_emp_num=value;}
			get{return _pla_emp_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PLA_EMP_NOR", TypeCode.Decimal)]
		public decimal PLA_EMP_NOR
		{
			set{ _pla_emp_nor=value;}
			get{return _pla_emp_nor;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PLA_EMP_OT1", TypeCode.Decimal)]
		public decimal PLA_EMP_OT1
		{
			set{ _pla_emp_ot1=value;}
			get{return _pla_emp_ot1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PLA_EMP_OT2", TypeCode.Decimal)]
		public decimal PLA_EMP_OT2
		{
			set{ _pla_emp_ot2=value;}
			get{return _pla_emp_ot2;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PLA_EMP_OT3", TypeCode.Decimal)]
		public decimal PLA_EMP_OT3
		{
			set{ _pla_emp_ot3=value;}
			get{return _pla_emp_ot3;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PLA_EMP_T1", TypeCode.Decimal)]
		public decimal PLA_EMP_T1
		{
			set{ _pla_emp_t1=value;}
			get{return _pla_emp_t1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PLA_EMP_T2", TypeCode.Decimal)]
		public decimal PLA_EMP_T2
		{
			set{ _pla_emp_t2=value;}
			get{return _pla_emp_t2;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("PLA_EMP_T3", TypeCode.Decimal)]
		public decimal PLA_EMP_T3
		{
			set{ _pla_emp_t3=value;}
			get{return _pla_emp_t3;}
		}
		#endregion Model

	}
}

