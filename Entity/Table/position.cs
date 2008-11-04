using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类position 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class position : iTable
	{
		public position()
		{}
		public enum Fields
		{
			POS_CO_CODE,
			POS_CODE,
			POS_DESC,
			POS_FEE_LEV1,
			POS_FEE_LEV2,
			POS_FEE_LEV3,
			POS_RATE_OUT,
			POS_RATE_DAILY,
			POS_RATE_MON,
			POS_RATE_OT,
			POS_MON_TOTAL,
			POS_MON_UTILIST,
			POS_MON_REV,
			POS_SAL_FROM,
			POS_SAL_TO,
			POS_DALIY_COST,
			POS_MON_COST,
			POS_CLASS,
			POS_PLAN,
		}

		public static string TableName
		{
			get { return "position"; }
		}

		#region Model
		private String _pos_co_code;
		private String _pos_code;
		private String _pos_desc;
		private Decimal? _pos_fee_lev1;
		private Decimal? _pos_fee_lev2;
		private Decimal? _pos_fee_lev3;
		private Decimal? _pos_rate_out;
		private Decimal? _pos_rate_daily;
		private Decimal? _pos_rate_mon;
		private Decimal? _pos_rate_ot;
		private Decimal? _pos_mon_total;
		private Decimal? _pos_mon_utilist;
		private Decimal? _pos_mon_rev;
		private Decimal? _pos_sal_from;
		private Decimal? _pos_sal_to;
		private Decimal? _pos_daliy_cost;
		private Decimal? _pos_mon_cost;
		private Decimal? _pos_class;
		private String _pos_plan;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_CO_CODE", TypeCode.String)]
		public String POS_CO_CODE
		{
			set{ _pos_co_code=value;}
			get{return _pos_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_CODE", TypeCode.String)]
		public String POS_CODE
		{
			set{ _pos_code=value;}
			get{return _pos_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_DESC", TypeCode.String)]
		public String POS_DESC
		{
			set{ _pos_desc=value;}
			get{return _pos_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_FEE_LEV1", TypeCode.Decimal)]
		public Decimal? POS_FEE_LEV1
		{
			set{ _pos_fee_lev1=value;}
			get{return _pos_fee_lev1;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_FEE_LEV2", TypeCode.Decimal)]
		public Decimal? POS_FEE_LEV2
		{
			set{ _pos_fee_lev2=value;}
			get{return _pos_fee_lev2;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_FEE_LEV3", TypeCode.Decimal)]
		public Decimal? POS_FEE_LEV3
		{
			set{ _pos_fee_lev3=value;}
			get{return _pos_fee_lev3;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_RATE_OUT", TypeCode.Decimal)]
		public Decimal? POS_RATE_OUT
		{
			set{ _pos_rate_out=value;}
			get{return _pos_rate_out;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_RATE_DAILY", TypeCode.Decimal)]
		public Decimal? POS_RATE_DAILY
		{
			set{ _pos_rate_daily=value;}
			get{return _pos_rate_daily;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_RATE_MON", TypeCode.Decimal)]
		public Decimal? POS_RATE_MON
		{
			set{ _pos_rate_mon=value;}
			get{return _pos_rate_mon;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_RATE_OT", TypeCode.Decimal)]
		public Decimal? POS_RATE_OT
		{
			set{ _pos_rate_ot=value;}
			get{return _pos_rate_ot;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_MON_TOTAL", TypeCode.Decimal)]
		public Decimal? POS_MON_TOTAL
		{
			set{ _pos_mon_total=value;}
			get{return _pos_mon_total;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_MON_UTILIST", TypeCode.Decimal)]
		public Decimal? POS_MON_UTILIST
		{
			set{ _pos_mon_utilist=value;}
			get{return _pos_mon_utilist;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_MON_REV", TypeCode.Decimal)]
		public Decimal? POS_MON_REV
		{
			set{ _pos_mon_rev=value;}
			get{return _pos_mon_rev;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_SAL_FROM", TypeCode.Decimal)]
		public Decimal? POS_SAL_FROM
		{
			set{ _pos_sal_from=value;}
			get{return _pos_sal_from;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_SAL_TO", TypeCode.Decimal)]
		public Decimal? POS_SAL_TO
		{
			set{ _pos_sal_to=value;}
			get{return _pos_sal_to;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_DALIY_COST", TypeCode.Decimal)]
		public Decimal? POS_DALIY_COST
		{
			set{ _pos_daliy_cost=value;}
			get{return _pos_daliy_cost;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_MON_COST", TypeCode.Decimal)]
		public Decimal? POS_MON_COST
		{
			set{ _pos_mon_cost=value;}
			get{return _pos_mon_cost;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_CLASS", TypeCode.Decimal)]
		public Decimal? POS_CLASS
		{
			set{ _pos_class=value;}
			get{return _pos_class;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("POS_PLAN", TypeCode.String)]
		public String POS_PLAN
		{
			set{ _pos_plan=value;}
			get{return _pos_plan;}
		}
		#endregion Model

	}
}

