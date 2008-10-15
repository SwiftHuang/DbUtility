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
	/// 业务逻辑类update_time 的摘要说明。
	/// </summary>
	public class update_time
	{
		private readonly Iupdate_time dal=DataAccess.Createupdate_time();
		public update_time()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UT_CODE)
		{
			return dal.Exists(UT_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.update_time model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.update_time model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string UT_CODE)
		{
			
			dal.Delete(UT_CODE);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.update_time GetModel(string UT_CODE)
		{
			
			return dal.GetModel(UT_CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.update_time GetModelByCache(string UT_CODE)
		{
			
			string CacheKey = "update_timeModel-" + UT_CODE;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UT_CODE);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.update_time)objModel;
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
		public List<WongTung.Model.update_time> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.update_time> modelList = new List<WongTung.Model.update_time>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.update_time model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.update_time();
					model.UT_CODE=ds.Tables[0].Rows[n]["UT_CODE"].ToString();
					if(ds.Tables[0].Rows[n]["UT_DATE"].ToString()!="")
					{
						model.UT_DATE=DateTime.Parse(ds.Tables[0].Rows[n]["UT_DATE"].ToString());
					}
					model.UT_TIME=ds.Tables[0].Rows[n]["UT_TIME"].ToString();
					if(ds.Tables[0].Rows[n]["UT_FRE"].ToString()!="")
					{
						model.UT_FRE=int.Parse(ds.Tables[0].Rows[n]["UT_FRE"].ToString());
					}
					model.UT_UPDATE_USER=ds.Tables[0].Rows[n]["UT_UPDATE_USER"].ToString();
					if(ds.Tables[0].Rows[n]["UT_UPDATE_DT"].ToString()!="")
					{
						model.UT_UPDATE_DT=DateTime.Parse(ds.Tables[0].Rows[n]["UT_UPDATE_DT"].ToString());
					}
					model.UT_INF=ds.Tables[0].Rows[n]["UT_INF"].ToString();
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

