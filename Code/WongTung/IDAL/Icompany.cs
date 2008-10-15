using System;
using System.Data;
namespace WongTung.IDAL
{
	/// <summary>
	/// 接口层Icompany 的摘要说明。
	/// </summary>
	public interface Icompany
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(WongTung.Model.company model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(WongTung.Model.company model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete();
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		WongTung.Model.company GetModel();
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
