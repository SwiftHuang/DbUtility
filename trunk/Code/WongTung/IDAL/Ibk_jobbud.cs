using System;
using System.Data;
namespace WongTung.IDAL
{
	/// <summary>
	/// 接口层Ibk_jobbud 的摘要说明。
	/// </summary>
	public interface Ibk_jobbud
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string JOB_CO_CODE,string JOB_CODE,string JOB_SER,string JOB_STAFF);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(WongTung.Model.bk_jobbud model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(WongTung.Model.bk_jobbud model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(string JOB_CO_CODE,string JOB_CODE,string JOB_SER,string JOB_STAFF);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		WongTung.Model.bk_jobbud GetModel(string JOB_CO_CODE,string JOB_CODE,string JOB_SER,string JOB_STAFF);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
//		DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
	}
}
