using System;
using hwj.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类tbBloodInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class tbBloodInfo : iTable
	{
		public tbBloodInfo()
		{}
		public enum Fields
		{
			ID,
			HP_ID,
			Sick_ID,
			Lab_ID,
			Blooder,
			ArrivalTime,
			IsPass,
			VoidReason,
			VoidBy,
			Result1,
			Result2,
			Result3,
			CreateOn,
			CreateBy,
			UpdateOn,
			UpdateBy,
		}

		public static string TableName
		{
			get { return "tbBloodInfo"; }
		}

		#region Model
		private String _id;
		private Int32? _hp_id;
		private Decimal? _sick_id;
		private String _lab_id;
		private String _blooder;
		private DateTime? _arrivaltime;
		private String _ispass;
		private Int32? _voidreason;
		private String _voidby;
		private Decimal _result1;
		private Decimal _result2;
		private Decimal _result3;
		private DateTime? _createon;
		private String _createby;
		private DateTime? _updateon;
		private String _updateby;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ID", TypeCode.String)]
		public String ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("HP_ID", TypeCode.Int32)]
		public Int32? HP_ID
		{
			set{ _hp_id=value;}
			get{return _hp_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("Sick_ID", TypeCode.Decimal)]
		public Decimal? Sick_ID
		{
			set{ _sick_id=value;}
			get{return _sick_id;}
		}
		/// <summary>
		/// 实验编号(结果编号)
		/// </summary>
		[FieldMapping("Lab_ID", TypeCode.String)]
		public String Lab_ID
		{
			set{ _lab_id=value;}
			get{return _lab_id;}
		}
		/// <summary>
		/// 采血人
		/// </summary>
		[FieldMapping("Blooder", TypeCode.String)]
		public String Blooder
		{
			set{ _blooder=value;}
			get{return _blooder;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ArrivalTime", TypeCode.DateTime)]
		public DateTime? ArrivalTime
		{
			set{ _arrivaltime=value;}
			get{return _arrivaltime;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("IsPass", TypeCode.String)]
		public String IsPass
		{
			set{ _ispass=value;}
			get{return _ispass;}
		}
		/// <summary>
		/// 退回原因
		/// </summary>
		[FieldMapping("VoidReason", TypeCode.Int32)]
		public Int32? VoidReason
		{
			set{ _voidreason=value;}
			get{return _voidreason;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("VoidBy", TypeCode.String)]
		public String VoidBy
		{
			set{ _voidby=value;}
			get{return _voidby;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("Result1", TypeCode.Decimal)]
		public Decimal Result1
		{
			set{ _result1=value;}
			get{return _result1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("Result2", TypeCode.Decimal)]
		public Decimal Result2
		{
			set{ _result2=value;}
			get{return _result2;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("Result3", TypeCode.Decimal)]
		public Decimal Result3
		{
			set{ _result3=value;}
			get{return _result3;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CreateOn", TypeCode.DateTime)]
		public DateTime? CreateOn
		{
			set{ _createon=value;}
			get{return _createon;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CreateBy", TypeCode.String)]
		public String CreateBy
		{
			set{ _createby=value;}
			get{return _createby;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("UpdateOn", TypeCode.DateTime)]
		public DateTime? UpdateOn
		{
			set{ _updateon=value;}
			get{return _updateon;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("UpdateBy", TypeCode.String)]
		public String UpdateBy
		{
			set{ _updateby=value;}
			get{return _updateby;}
		}
		#endregion Model

	}
}

