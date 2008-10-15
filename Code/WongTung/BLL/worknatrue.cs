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
	/// 业务逻辑类worknatrue 的摘要说明。
	/// </summary>
	public class worknatrue
	{
		private readonly Iworknatrue dal=DataAccess.Createworknatrue();
		public worknatrue()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string WN_CODE)
		{
			return dal.Exists(WN_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.worknatrue model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.worknatrue model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string WN_CODE)
		{
			
			dal.Delete(WN_CODE);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.worknatrue GetModel(string WN_CODE)
		{
			
			return dal.GetModel(WN_CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.worknatrue GetModelByCache(string WN_CODE)
		{
			
			string CacheKey = "worknatrueModel-" + WN_CODE;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(WN_CODE);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.worknatrue)objModel;
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
		public List<WongTung.Model.worknatrue> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.worknatrue> modelList = new List<WongTung.Model.worknatrue>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.worknatrue model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.worknatrue();
					model.WN_CO_CODE=ds.Tables[0].Rows[n]["WN_CO_CODE"].ToString();
					model.WN_CODE=ds.Tables[0].Rows[n]["WN_CODE"].ToString();
					model.WN_DESC=ds.Tables[0].Rows[n]["WN_DESC"].ToString();
					model.WN_DESC_T=ds.Tables[0].Rows[n]["WN_DESC_T"].ToString();
					model.WN_DESC_S=ds.Tables[0].Rows[n]["WN_DESC_S"].ToString();
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

