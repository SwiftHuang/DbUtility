using System;
using System.Data;
namespace WongTung.IDAL
{
	/// <summary>
	/// 接口层Iposition 的摘要说明。
	/// </summary>
	public interface Iposition
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string POS_CODE);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(WongTung.Model.position model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(WongTung.Model.position model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(string POS_CODE);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		WongTung.Model.position GetModel(string POS_CODE);
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
