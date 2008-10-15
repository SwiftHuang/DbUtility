using System;
using System.Data;
namespace WongTung.IDAL
{
	/// <summary>
	/// 接口层Iincomts 的摘要说明。
	/// </summary>
	public interface Iincomts
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(WongTung.Model.incomts model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(WongTung.Model.incomts model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete();
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		WongTung.Model.incomts GetModel();
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
