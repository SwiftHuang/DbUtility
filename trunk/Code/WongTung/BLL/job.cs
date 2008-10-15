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
	/// 业务逻辑类job 的摘要说明。
	/// </summary>
	public class job
	{
		private readonly Ijob dal=DataAccess.Createjob();
		public job()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string JOB_CODE)
		{
			return dal.Exists(JOB_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.job model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.job model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string JOB_CODE)
		{
			
			dal.Delete(JOB_CODE);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.job GetModel(string JOB_CODE)
		{
			
			return dal.GetModel(JOB_CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.job GetModelByCache(string JOB_CODE)
		{
			
			string CacheKey = "jobModel-" + JOB_CODE;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(JOB_CODE);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.job)objModel;
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
		public List<WongTung.Model.job> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.job> modelList = new List<WongTung.Model.job>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.job model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.job();
					model.JOB_CO_CODE=ds.Tables[0].Rows[n]["JOB_CO_CODE"].ToString();
					model.JOB_CODE=ds.Tables[0].Rows[n]["JOB_CODE"].ToString();
					model.JOB_NAME=ds.Tables[0].Rows[n]["JOB_NAME"].ToString();
					if(ds.Tables[0].Rows[n]["JOB_CON"].ToString()!="")
					{
						model.JOB_CON=decimal.Parse(ds.Tables[0].Rows[n]["JOB_CON"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_OPEN_BAL_HOUR"].ToString()!="")
					{
						model.JOB_OPEN_BAL_HOUR=decimal.Parse(ds.Tables[0].Rows[n]["JOB_OPEN_BAL_HOUR"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_YTD_HOUR"].ToString()!="")
					{
						model.JOB_YTD_HOUR=decimal.Parse(ds.Tables[0].Rows[n]["JOB_YTD_HOUR"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_OPEN_BAL_AMT"].ToString()!="")
					{
						model.JOB_OPEN_BAL_AMT=decimal.Parse(ds.Tables[0].Rows[n]["JOB_OPEN_BAL_AMT"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_YTD_AMT"].ToString()!="")
					{
						model.JOB_YTD_AMT=decimal.Parse(ds.Tables[0].Rows[n]["JOB_YTD_AMT"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_REC"].ToString()!="")
					{
						model.JOB_REC=decimal.Parse(ds.Tables[0].Rows[n]["JOB_REC"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_OS_BAL"].ToString()!="")
					{
						model.JOB_OS_BAL=decimal.Parse(ds.Tables[0].Rows[n]["JOB_OS_BAL"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_BUD_HOUR"].ToString()!="")
					{
						model.JOB_BUD_HOUR=decimal.Parse(ds.Tables[0].Rows[n]["JOB_BUD_HOUR"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_CO_ORD"].ToString()!="")
					{
						model.JOB_CO_ORD=int.Parse(ds.Tables[0].Rows[n]["JOB_CO_ORD"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_ADMIN"].ToString()!="")
					{
						model.JOB_ADMIN=int.Parse(ds.Tables[0].Rows[n]["JOB_ADMIN"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_DESIGN"].ToString()!="")
					{
						model.JOB_DESIGN=int.Parse(ds.Tables[0].Rows[n]["JOB_DESIGN"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_LEV1"].ToString()!="")
					{
						model.JOB_LEV1=int.Parse(ds.Tables[0].Rows[n]["JOB_LEV1"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_LEV2"].ToString()!="")
					{
						model.JOB_LEV2=int.Parse(ds.Tables[0].Rows[n]["JOB_LEV2"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_LEV3"].ToString()!="")
					{
						model.JOB_LEV3=int.Parse(ds.Tables[0].Rows[n]["JOB_LEV3"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_CHARGE_OUT"].ToString()!="")
					{
						model.JOB_CHARGE_OUT=int.Parse(ds.Tables[0].Rows[n]["JOB_CHARGE_OUT"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_DAILY"].ToString()!="")
					{
						model.JOB_DAILY=int.Parse(ds.Tables[0].Rows[n]["JOB_DAILY"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_MON"].ToString()!="")
					{
						model.JOB_MON=int.Parse(ds.Tables[0].Rows[n]["JOB_MON"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_PERIOD"].ToString()!="")
					{
						model.JOB_PERIOD=decimal.Parse(ds.Tables[0].Rows[n]["JOB_PERIOD"].ToString());
					}
					if(ds.Tables[0].Rows[n]["JOB_PERIOD_VAL"].ToString()!="")
					{
						model.JOB_PERIOD_VAL=decimal.Parse(ds.Tables[0].Rows[n]["JOB_PERIOD_VAL"].ToString());
					}
					model.JOB_AUTH=ds.Tables[0].Rows[n]["JOB_AUTH"].ToString();
					model.JOB_OFF_INCHG_AD=ds.Tables[0].Rows[n]["JOB_OFF_INCHG_AD"].ToString();
					model.JOB_OFF_INCHG_DES=ds.Tables[0].Rows[n]["JOB_OFF_INCHG_DES"].ToString();
					model.JOB_AUTH_1=ds.Tables[0].Rows[n]["JOB_AUTH_1"].ToString();
					model.JOB_AUTH_2=ds.Tables[0].Rows[n]["JOB_AUTH_2"].ToString();
					model.JOB_AUTH_3=ds.Tables[0].Rows[n]["JOB_AUTH_3"].ToString();
					model.JOB_AUTH_4=ds.Tables[0].Rows[n]["JOB_AUTH_4"].ToString();
					model.JOB_AUTH_5=ds.Tables[0].Rows[n]["JOB_AUTH_5"].ToString();
					if(ds.Tables[0].Rows[n]["JOB_INDEX"].ToString()!="")
					{
						model.JOB_INDEX=int.Parse(ds.Tables[0].Rows[n]["JOB_INDEX"].ToString());
					}
					model.JOB_NAME_S=ds.Tables[0].Rows[n]["JOB_NAME_S"].ToString();
					model.JOB_NAME_T=ds.Tables[0].Rows[n]["JOB_NAME_T"].ToString();
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

