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
	/// 业务逻辑类budgetot 的摘要说明。
	/// </summary>
	public class budgetot
	{
		private readonly Ibudgetot dal=DataAccess.Createbudgetot();
		public budgetot()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.budgetot model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.budgetot model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.budgetot GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.budgetot GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "budgetotModel-" ;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.budgetot)objModel;
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
		public List<WongTung.Model.budgetot> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.budgetot> modelList = new List<WongTung.Model.budgetot>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.budgetot model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.budgetot();
					model.BG_CO_CODE=ds.Tables[0].Rows[n]["BG_CO_CODE"].ToString();
					model.BG_JOB_CODE=ds.Tables[0].Rows[n]["BG_JOB_CODE"].ToString();
					model.BG_SER_CODE=ds.Tables[0].Rows[n]["BG_SER_CODE"].ToString();
					model.BG_POS=ds.Tables[0].Rows[n]["BG_POS"].ToString();
					if(ds.Tables[0].Rows[n]["BG_HOUR"].ToString()!="")
					{
						model.BG_HOUR=decimal.Parse(ds.Tables[0].Rows[n]["BG_HOUR"].ToString());
					}
					if(ds.Tables[0].Rows[n]["BG_EXP_BUDGET"].ToString()!="")
					{
						model.BG_EXP_BUDGET=decimal.Parse(ds.Tables[0].Rows[n]["BG_EXP_BUDGET"].ToString());
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

