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
	/// 业务逻辑类spe_endorse 的摘要说明。
	/// </summary>
	public class spe_endorse
	{
		private readonly Ispe_endorse dal=DataAccess.Createspe_endorse();
		public spe_endorse()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SPE_CODE)
		{
			return dal.Exists(SPE_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.spe_endorse model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.spe_endorse model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string SPE_CODE)
		{
			
			dal.Delete(SPE_CODE);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.spe_endorse GetModel(string SPE_CODE)
		{
			
			return dal.GetModel(SPE_CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.spe_endorse GetModelByCache(string SPE_CODE)
		{
			
			string CacheKey = "spe_endorseModel-" + SPE_CODE;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SPE_CODE);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.spe_endorse)objModel;
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
		public List<WongTung.Model.spe_endorse> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.spe_endorse> modelList = new List<WongTung.Model.spe_endorse>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.spe_endorse model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.spe_endorse();
					model.SPE_CODE=ds.Tables[0].Rows[n]["SPE_CODE"].ToString();
					model.SPE_CRE_EMP=ds.Tables[0].Rows[n]["SPE_CRE_EMP"].ToString();
					if(ds.Tables[0].Rows[n]["SPE_CRE_DATE"].ToString()!="")
					{
						model.SPE_CRE_DATE=DateTime.Parse(ds.Tables[0].Rows[n]["SPE_CRE_DATE"].ToString());
					}
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

