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
	/// 业务逻辑类bk_jobbud 的摘要说明。
	/// </summary>
	public class bk_jobbud
	{
		private readonly Ibk_jobbud dal=DataAccess.Createbk_jobbud();
		public bk_jobbud()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string JOB_CO_CODE,string JOB_CODE,string JOB_SER,string JOB_STAFF)
		{
			return dal.Exists(JOB_CO_CODE,JOB_CODE,JOB_SER,JOB_STAFF);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.bk_jobbud model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.bk_jobbud model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string JOB_CO_CODE,string JOB_CODE,string JOB_SER,string JOB_STAFF)
		{
			
			dal.Delete(JOB_CO_CODE,JOB_CODE,JOB_SER,JOB_STAFF);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.bk_jobbud GetModel(string JOB_CO_CODE,string JOB_CODE,string JOB_SER,string JOB_STAFF)
		{
			
			return dal.GetModel(JOB_CO_CODE,JOB_CODE,JOB_SER,JOB_STAFF);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.bk_jobbud GetModelByCache(string JOB_CO_CODE,string JOB_CODE,string JOB_SER,string JOB_STAFF)
		{
			
			string CacheKey = "bk_jobbudModel-" + JOB_CO_CODE+JOB_CODE+JOB_SER+JOB_STAFF;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(JOB_CO_CODE,JOB_CODE,JOB_SER,JOB_STAFF);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.bk_jobbud)objModel;
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
		public List<WongTung.Model.bk_jobbud> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.bk_jobbud> modelList = new List<WongTung.Model.bk_jobbud>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.bk_jobbud model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.bk_jobbud();
					model.JOB_CO_CODE=ds.Tables[0].Rows[n]["JOB_CO_CODE"].ToString();
					model.JOB_CODE=ds.Tables[0].Rows[n]["JOB_CODE"].ToString();
					model.JOB_SER=ds.Tables[0].Rows[n]["JOB_SER"].ToString();
					model.JOB_POS=ds.Tables[0].Rows[n]["JOB_POS"].ToString();
					model.JOB_STAFF=ds.Tables[0].Rows[n]["JOB_STAFF"].ToString();
					if(ds.Tables[0].Rows[n]["JOB_BUD"].ToString()!="")
					{
						model.JOB_BUD=decimal.Parse(ds.Tables[0].Rows[n]["JOB_BUD"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_NOR"].ToString()!="")
					{
						model.JOB_NOR=decimal.Parse(ds.Tables[0].Rows[n]["JOB_NOR"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_NOR_EXP"].ToString()!="")
					{
						model.JOB_NOR_EXP=decimal.Parse(ds.Tables[0].Rows[n]["JOB_NOR_EXP"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_OT"].ToString()!="")
					{
						model.JOB_OT=decimal.Parse(ds.Tables[0].Rows[n]["JOB_OT"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_OT_EXP"].ToString()!="")
					{
						model.JOB_OT_EXP=decimal.Parse(ds.Tables[0].Rows[n]["JOB_OT_EXP"].ToString());
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

