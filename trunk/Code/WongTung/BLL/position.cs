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
	/// 业务逻辑类position 的摘要说明。
	/// </summary>
	public class position
	{
		private readonly Iposition dal=DataAccess.Createposition();
		public position()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string POS_CODE)
		{
			return dal.Exists(POS_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.position model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.position model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string POS_CODE)
		{
			
			dal.Delete(POS_CODE);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.position GetModel(string POS_CODE)
		{
			
			return dal.GetModel(POS_CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.position GetModelByCache(string POS_CODE)
		{
			
			string CacheKey = "positionModel-" + POS_CODE;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(POS_CODE);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.position)objModel;
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
		public List<WongTung.Model.position> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.position> modelList = new List<WongTung.Model.position>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.position model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.position();
					model.POS_CO_CODE=ds.Tables[0].Rows[n]["POS_CO_CODE"].ToString();
					model.POS_CODE=ds.Tables[0].Rows[n]["POS_CODE"].ToString();
					model.POS_DESC=ds.Tables[0].Rows[n]["POS_DESC"].ToString();
					if(ds.Tables[0].Rows[n]["POS_FEE_LEV1"].ToString()!="")
					{
						model.POS_FEE_LEV1=decimal.Parse(ds.Tables[0].Rows[n]["POS_FEE_LEV1"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POS_FEE_LEV2"].ToString()!="")
					{
						model.POS_FEE_LEV2=decimal.Parse(ds.Tables[0].Rows[n]["POS_FEE_LEV2"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POS_FEE_LEV3"].ToString()!="")
					{
						model.POS_FEE_LEV3=decimal.Parse(ds.Tables[0].Rows[n]["POS_FEE_LEV3"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POS_RATE_OUT"].ToString()!="")
					{
						model.POS_RATE_OUT=decimal.Parse(ds.Tables[0].Rows[n]["POS_RATE_OUT"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POS_RATE_DAILY"].ToString()!="")
					{
						model.POS_RATE_DAILY=decimal.Parse(ds.Tables[0].Rows[n]["POS_RATE_DAILY"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POS_RATE_MON"].ToString()!="")
					{
						model.POS_RATE_MON=decimal.Parse(ds.Tables[0].Rows[n]["POS_RATE_MON"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POS_RATE_OT"].ToString()!="")
					{
						model.POS_RATE_OT=decimal.Parse(ds.Tables[0].Rows[n]["POS_RATE_OT"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POS_MON_TOTAL"].ToString()!="")
					{
						model.POS_MON_TOTAL=decimal.Parse(ds.Tables[0].Rows[n]["POS_MON_TOTAL"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POS_MON_UTILIST"].ToString()!="")
					{
						model.POS_MON_UTILIST=decimal.Parse(ds.Tables[0].Rows[n]["POS_MON_UTILIST"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POS_MON_REV"].ToString()!="")
					{
						model.POS_MON_REV=decimal.Parse(ds.Tables[0].Rows[n]["POS_MON_REV"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POS_SAL_FROM"].ToString()!="")
					{
						model.POS_SAL_FROM=decimal.Parse(ds.Tables[0].Rows[n]["POS_SAL_FROM"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POS_SAL_TO"].ToString()!="")
					{
						model.POS_SAL_TO=decimal.Parse(ds.Tables[0].Rows[n]["POS_SAL_TO"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POS_DALIY_COST"].ToString()!="")
					{
						model.POS_DALIY_COST=decimal.Parse(ds.Tables[0].Rows[n]["POS_DALIY_COST"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POS_MON_COST"].ToString()!="")
					{
						model.POS_MON_COST=decimal.Parse(ds.Tables[0].Rows[n]["POS_MON_COST"].ToString());
					}
					if(ds.Tables[0].Rows[n]["POS_CLASS"].ToString()!="")
					{
						model.POS_CLASS=decimal.Parse(ds.Tables[0].Rows[n]["POS_CLASS"].ToString());
					}
					model.POS_PLAN=ds.Tables[0].Rows[n]["POS_PLAN"].ToString();
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

