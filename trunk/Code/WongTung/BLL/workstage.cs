using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using WongTung.Model;
using WongTung.DALFactory;
using WongTung.IDAL;
namespace WongTung.BLL
{
	/// <summary>
	/// 业务逻辑类workstage 的摘要说明。
	/// </summary>
	public class workstage
	{
		private readonly Iworkstage dal=DataAccess.Createworkstage();
		public workstage()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string WT_CODE)
		{
			return dal.Exists(WT_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.workstage model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.workstage model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string WT_CODE)
		{
			
			dal.Delete(WT_CODE);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.workstage GetModel(string WT_CODE)
		{
			
			return dal.GetModel(WT_CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.workstage GetModelByCache(string WT_CODE)
		{
			
			string CacheKey = "workstageModel-" + WT_CODE;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(WT_CODE);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.workstage)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<WongTung.Model.workstage> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.workstage> modelList = new List<WongTung.Model.workstage>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.workstage model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.workstage();
					model.WT_CO_CODE=ds.Tables[0].Rows[n]["WT_CO_CODE"].ToString();
					model.WT_CODE=ds.Tables[0].Rows[n]["WT_CODE"].ToString();
					model.WT_DESC=ds.Tables[0].Rows[n]["WT_DESC"].ToString();
					model.WT_DESC_T=ds.Tables[0].Rows[n]["WT_DESC_T"].ToString();
					model.WT_DESC_S=ds.Tables[0].Rows[n]["WT_DESC_S"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

