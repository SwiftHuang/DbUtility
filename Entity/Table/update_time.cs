using System;
using WongTung.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
	/// <summary>
	/// 实体类update_time 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class update_time
	{
		public update_time()
		{}
		public enum Fields{UT_CODE,
UT_DATE,
UT_TIME,
UT_FRE,
UT_UPDATE_USER,
UT_UPDATE_DT,
UT_INF,
}
		#region Model
		private string _ut_code;
		private DateTime _ut_date;
		private string _ut_time;
		private int _ut_fre;
		private string _ut_update_user;
		private DateTime _ut_update_dt;
		private string _ut_inf;
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("UT_CODE", TypeCode.String)]
		public string UT_CODE
		{
			set{ _ut_code=value;}
			get{return _ut_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("UT_DATE", TypeCode.DateTime)]
		public DateTime UT_DATE
		{
			set{ _ut_date=value;}
			get{return _ut_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("UT_TIME", TypeCode.String)]
		public string UT_TIME
		{
			set{ _ut_time=value;}
			get{return _ut_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("UT_FRE", TypeCode.Int)]
		public int UT_FRE
		{
			set{ _ut_fre=value;}
			get{return _ut_fre;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("UT_UPDATE_USER", TypeCode.String)]
		public string UT_UPDATE_USER
		{
			set{ _ut_update_user=value;}
			get{return _ut_update_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("UT_UPDATE_DT", TypeCode.DateTime)]
		public DateTime UT_UPDATE_DT
		{
			set{ _ut_update_dt=value;}
			get{return _ut_update_dt;}
		}
		/// <summary>
		/// 
		/// </summary>
		[FieldMapping("UT_INF", TypeCode.String)]
		public string UT_INF
		{
			set{ _ut_inf=value;}
			get{return _ut_inf;}
		}
		#endregion Model

	}
}

