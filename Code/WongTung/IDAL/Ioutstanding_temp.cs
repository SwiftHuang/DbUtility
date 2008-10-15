using System;
using System.Data;
namespace WongTung.IDAL
{
	/// <summary>
	/// 接口层Ioutstanding_temp 的摘要说明。
	/// </summary>
	public interface Ioutstanding_temp
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(decimal NUM);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(WongTung.Model.outstanding_temp model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(WongTung.Model.outstanding_temp model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(decimal NUM);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		WongTung.Model.outstanding_temp GetModel(decimal NUM);
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
