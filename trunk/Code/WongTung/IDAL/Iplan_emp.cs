using System;
using System.Data;
namespace WongTung.IDAL
{
	/// <summary>
	/// 接口层Iplan_emp 的摘要说明。
	/// </summary>
	public interface Iplan_emp
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string PLA_EMP_CO,string PLA_EMP_OFF,string PLA_EMP_POS,string PLA_EMP_CODE);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(WongTung.Model.plan_emp model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(WongTung.Model.plan_emp model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(string PLA_EMP_CO,string PLA_EMP_OFF,string PLA_EMP_POS,string PLA_EMP_CODE);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		WongTung.Model.plan_emp GetModel(string PLA_EMP_CO,string PLA_EMP_OFF,string PLA_EMP_POS,string PLA_EMP_CODE);
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
