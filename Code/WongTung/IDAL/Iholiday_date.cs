using System;
using System.Data;
namespace WongTung.IDAL
{
	/// <summary>
	/// 接口层Iholiday_date 的摘要说明。
	/// </summary>
	public interface Iholiday_date
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string HO_CO_CODE,string HO_CODE);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(WongTung.Model.holiday_date model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(WongTung.Model.holiday_date model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(string HO_CO_CODE,string HO_CODE);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		WongTung.Model.holiday_date GetModel(string HO_CO_CODE,string HO_CODE);
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
