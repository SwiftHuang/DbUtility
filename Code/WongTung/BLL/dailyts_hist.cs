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
	/// 业务逻辑类dailyts_hist 的摘要说明。
	/// </summary>
	public class dailyts_hist
	{
		private readonly Idailyts_hist dal=DataAccess.Createdailyts_hist();
		public dailyts_hist()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.dailyts_hist model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.dailyts_hist model)
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
		public WongTung.Model.dailyts_hist GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.dailyts_hist GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "dailyts_histModel-" ;
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
			return (WongTung.Model.dailyts_hist)objModel;
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
		public List<WongTung.Model.dailyts_hist> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.dailyts_hist> modelList = new List<WongTung.Model.dailyts_hist>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.dailyts_hist model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.dailyts_hist();
					model.DT_CO_CODE=ds.Tables[0].Rows[n]["DT_CO_CODE"].ToString();
					model.DT_STAFF_CODE=ds.Tables[0].Rows[n]["DT_STAFF_CODE"].ToString();
					if(ds.Tables[0].Rows[n]["DT_WORK_DATE"].ToString()!="")
					{
						model.DT_WORK_DATE=DateTime.Parse(ds.Tables[0].Rows[n]["DT_WORK_DATE"].ToString());
					}
					if(ds.Tables[0].Rows[n]["DT_LINE_NO"].ToString()!="")
					{
						model.DT_LINE_NO=decimal.Parse(ds.Tables[0].Rows[n]["DT_LINE_NO"].ToString());
					}
					model.DT_APP_CODE=ds.Tables[0].Rows[n]["DT_APP_CODE"].ToString();
					model.DT_JOB_CODE=ds.Tables[0].Rows[n]["DT_JOB_CODE"].ToString();
					model.DT_SER_CODE=ds.Tables[0].Rows[n]["DT_SER_CODE"].ToString();
					if(ds.Tables[0].Rows[n]["DT_NOR_HOUR"].ToString()!="")
					{
						model.DT_NOR_HOUR=decimal.Parse(ds.Tables[0].Rows[n]["DT_NOR_HOUR"].ToString());
					}
					if(ds.Tables[0].Rows[n]["DT_OVER_HOUR"].ToString()!="")
					{
						model.DT_OVER_HOUR=decimal.Parse(ds.Tables[0].Rows[n]["DT_OVER_HOUR"].ToString());
					}
					model.DT_TYPE=ds.Tables[0].Rows[n]["DT_TYPE"].ToString();
					model.DT_PERIOD=ds.Tables[0].Rows[n]["DT_PERIOD"].ToString();
					model.DT_SUBMIT=ds.Tables[0].Rows[n]["DT_SUBMIT"].ToString();
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

