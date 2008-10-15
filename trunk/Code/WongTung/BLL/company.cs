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
	/// 业务逻辑类company 的摘要说明。
	/// </summary>
	public class company
	{
		private readonly Icompany dal=DataAccess.Createcompany();
		public company()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.company model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.company model)
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
		public WongTung.Model.company GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.company GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "companyModel-" ;
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
			return (WongTung.Model.company)objModel;
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
		public List<WongTung.Model.company> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.company> modelList = new List<WongTung.Model.company>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.company model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.company();
					model.CO_CODE=ds.Tables[0].Rows[n]["CO_CODE"].ToString();
					model.CO_SCR_NAME=ds.Tables[0].Rows[n]["CO_SCR_NAME"].ToString();
					model.CO_RPT_NAME=ds.Tables[0].Rows[n]["CO_RPT_NAME"].ToString();
					if(ds.Tables[0].Rows[n]["CO_LB_DATE"].ToString()!="")
					{
						model.CO_LB_DATE=DateTime.Parse(ds.Tables[0].Rows[n]["CO_LB_DATE"].ToString());
					}
					if(ds.Tables[0].Rows[n]["CO_LE_DATE"].ToString()!="")
					{
						model.CO_LE_DATE=DateTime.Parse(ds.Tables[0].Rows[n]["CO_LE_DATE"].ToString());
					}
					if(ds.Tables[0].Rows[n]["CO_CB_DATE"].ToString()!="")
					{
						model.CO_CB_DATE=DateTime.Parse(ds.Tables[0].Rows[n]["CO_CB_DATE"].ToString());
					}
					if(ds.Tables[0].Rows[n]["CO_CE_DATE"].ToString()!="")
					{
						model.CO_CE_DATE=DateTime.Parse(ds.Tables[0].Rows[n]["CO_CE_DATE"].ToString());
					}
					model.CO_CURR=ds.Tables[0].Rows[n]["CO_CURR"].ToString();
					if(ds.Tables[0].Rows[n]["CO_PERIOD_FROM"].ToString()!="")
					{
						model.CO_PERIOD_FROM=DateTime.Parse(ds.Tables[0].Rows[n]["CO_PERIOD_FROM"].ToString());
					}
					if(ds.Tables[0].Rows[n]["CO_PERIOD_TO"].ToString()!="")
					{
						model.CO_PERIOD_TO=DateTime.Parse(ds.Tables[0].Rows[n]["CO_PERIOD_TO"].ToString());
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

