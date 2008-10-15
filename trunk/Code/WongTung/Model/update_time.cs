using System;
namespace WongTung.Model
{
	/// <summary>
	/// 实体类update_time 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class update_time
	{
		public update_time()
		{}
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
		public string UT_CODE
		{
			set{ _ut_code=value;}
			get{return _ut_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime UT_DATE
		{
			set{ _ut_date=value;}
			get{return _ut_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UT_TIME
		{
			set{ _ut_time=value;}
			get{return _ut_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UT_FRE
		{
			set{ _ut_fre=value;}
			get{return _ut_fre;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UT_UPDATE_USER
		{
			set{ _ut_update_user=value;}
			get{return _ut_update_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime UT_UPDATE_DT
		{
			set{ _ut_update_dt=value;}
			get{return _ut_update_dt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UT_INF
		{
			set{ _ut_inf=value;}
			get{return _ut_inf;}
		}
		#endregion Model

	}
}

