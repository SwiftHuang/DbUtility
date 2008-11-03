using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类company 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class company
	{
		public company()
		{}
		public enum Fields{CO_CODE,
CO_SCR_NAME,
CO_RPT_NAME,
CO_LB_DATE,
CO_LE_DATE,
CO_CB_DATE,
CO_CE_DATE,
CO_CURR,
CO_PERIOD_FROM,
CO_PERIOD_TO,
}
		#region Model
		private string _co_code;
		private string _co_scr_name;
		private string _co_rpt_name;
		private DateTime? _co_lb_date;
		private DateTime? _co_le_date;
		private DateTime? _co_cb_date;
		private DateTime? _co_ce_date;
		private string _co_curr;
		private DateTime? _co_period_from;
		private DateTime? _co_period_to;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CO_CODE", TypeCode.String)]
		public string CO_CODE
		{
			set{ _co_code=value;}
			get{return _co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CO_SCR_NAME", TypeCode.String)]
		public string CO_SCR_NAME
		{
			set{ _co_scr_name=value;}
			get{return _co_scr_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CO_RPT_NAME", TypeCode.String)]
		public string CO_RPT_NAME
		{
			set{ _co_rpt_name=value;}
			get{return _co_rpt_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CO_LB_DATE", TypeCode.DateTime)]
		public DateTime? CO_LB_DATE
		{
			set{ _co_lb_date=value;}
			get{return _co_lb_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CO_LE_DATE", TypeCode.DateTime)]
		public DateTime? CO_LE_DATE
		{
			set{ _co_le_date=value;}
			get{return _co_le_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CO_CB_DATE", TypeCode.DateTime)]
		public DateTime? CO_CB_DATE
		{
			set{ _co_cb_date=value;}
			get{return _co_cb_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CO_CE_DATE", TypeCode.DateTime)]
		public DateTime? CO_CE_DATE
		{
			set{ _co_ce_date=value;}
			get{return _co_ce_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CO_CURR", TypeCode.String)]
		public string CO_CURR
		{
			set{ _co_curr=value;}
			get{return _co_curr;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CO_PERIOD_FROM", TypeCode.DateTime)]
		public DateTime? CO_PERIOD_FROM
		{
			set{ _co_period_from=value;}
			get{return _co_period_from;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("CO_PERIOD_TO", TypeCode.DateTime)]
		public DateTime? CO_PERIOD_TO
		{
			set{ _co_period_to=value;}
			get{return _co_period_to;}
		}
		#endregion Model

	}
}

