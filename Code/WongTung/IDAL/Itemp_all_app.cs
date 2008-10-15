using System;
using System.Data;
namespace WongTung.IDAL
{
	/// <summary>
	/// 接口层Itemp_all_app 的摘要说明。
	/// </summary>
	public interface Itemp_all_app
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(WongTung.Model.temp_all_app model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(WongTung.Model.temp_all_app model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete();
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		WongTung.Model.temp_all_app GetModel();
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
