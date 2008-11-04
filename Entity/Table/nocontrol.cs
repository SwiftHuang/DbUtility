using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类nocontrol 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class nocontrol : iTable
	{
		public nocontrol()
		{}
		public enum Fields
		{
			NO_CO_CODE,
			NO_CODE,
			NO_DESC,
			NO_STA_NO,
			NO_SEQ_NO,
		}

		public static string TableName
		{
			get { return "nocontrol"; }
		}

		#region Model
		private String _no_co_code;
		private String _no_code;
		private String _no_desc;
		private Decimal? _no_sta_no;
		private Decimal? _no_seq_no;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("NO_CO_CODE", TypeCode.String)]
		public String NO_CO_CODE
		{
			set{ _no_co_code=value;}
			get{return _no_co_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("NO_CODE", TypeCode.String)]
		public String NO_CODE
		{
			set{ _no_code=value;}
			get{return _no_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("NO_DESC", TypeCode.String)]
		public String NO_DESC
		{
			set{ _no_desc=value;}
			get{return _no_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("NO_STA_NO", TypeCode.Decimal)]
		public Decimal? NO_STA_NO
		{
			set{ _no_sta_no=value;}
			get{return _no_sta_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("NO_SEQ_NO", TypeCode.Decimal)]
		public Decimal? NO_SEQ_NO
		{
			set{ _no_seq_no=value;}
			get{return _no_seq_no;}
		}
		#endregion Model

	}
}

