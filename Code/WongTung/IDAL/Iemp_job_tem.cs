using System;
using System.Data;
namespace WongTung.IDAL
{
	/// <summary>
	/// 接口层Iemp_job_tem 的摘要说明。
	/// </summary>
	public interface Iemp_job_tem
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string EJ_CO_CODE,string EJ_EMP_CODE);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(WongTung.Model.emp_job_tem model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(WongTung.Model.emp_job_tem model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(string EJ_CO_CODE,string EJ_EMP_CODE);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		WongTung.Model.emp_job_tem GetModel(string EJ_CO_CODE,string EJ_EMP_CODE);
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
