using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类non 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class non : iTable
	{
		public non()
		{}
		public enum Fields
		{
			CO_CODE,
			STAFF_CODE,
			DATE,
			TYPE,
			ANNUAL,
			SICK,
			ADMIN,
			OT_PAY,
		}

		public static string TableName
		{
			get { return "non"; }
		}

		#region Model
		private String _co_code;
		private String _staff_code;
		private DateTime _date;
		private String _type;
		private Decimal? _annual;
		private Decimal? _sick;
		private Decimal? _admin;
		private Decimal? _ot_pay;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CO_CODE", TypeCode.String)]
		public String CO_CODE
		{
			set{ _co_code=value;}
			get{return _co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("STAFF_CODE", TypeCode.String)]
		public String STAFF_CODE
		{
			set{ _staff_code=value;}
			get{return _staff_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("DATE", TypeCode.DateTime)]
		public DateTime DATE
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("TYPE", TypeCode.String)]
		public String TYPE
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ANNUAL", TypeCode.Decimal)]
		public Decimal? ANNUAL
		{
			set{ _annual=value;}
			get{return _annual;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("SICK", TypeCode.Decimal)]
		public Decimal? SICK
		{
			set{ _sick=value;}
			get{return _sick;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("ADMIN", TypeCode.Decimal)]
		public Decimal? ADMIN
		{
			set{ _admin=value;}
			get{return _admin;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("OT_PAY", TypeCode.Decimal)]
		public Decimal? OT_PAY
		{
			set{ _ot_pay=value;}
			get{return _ot_pay;}
		}
		#endregion Model

	}
}

