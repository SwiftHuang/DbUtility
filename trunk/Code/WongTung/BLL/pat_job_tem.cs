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
	/// 业务逻辑类pat_job_tem 的摘要说明。
	/// </summary>
	public class pat_job_tem
	{
		private readonly Ipat_job_tem dal=DataAccess.Createpat_job_tem();
		public pat_job_tem()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string AJ_CO_CODE,string AJ_EMP_CODE)
		{
			return dal.Exists(AJ_CO_CODE,AJ_EMP_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.pat_job_tem model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.pat_job_tem model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string AJ_CO_CODE,string AJ_EMP_CODE)
		{
			
			dal.Delete(AJ_CO_CODE,AJ_EMP_CODE);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.pat_job_tem GetModel(string AJ_CO_CODE,string AJ_EMP_CODE)
		{
			
			return dal.GetModel(AJ_CO_CODE,AJ_EMP_CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.pat_job_tem GetModelByCache(string AJ_CO_CODE,string AJ_EMP_CODE)
		{
			
			string CacheKey = "pat_job_temModel-" + AJ_CO_CODE+AJ_EMP_CODE;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AJ_CO_CODE,AJ_EMP_CODE);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.pat_job_tem)objModel;
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
		public List<WongTung.Model.pat_job_tem> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.pat_job_tem> modelList = new List<WongTung.Model.pat_job_tem>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.pat_job_tem model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.pat_job_tem();
					model.AJ_CO_CODE=ds.Tables[0].Rows[n]["AJ_CO_CODE"].ToString();
					model.AJ_EMP_CODE=ds.Tables[0].Rows[n]["AJ_EMP_CODE"].ToString();
					if(ds.Tables[0].Rows[n]["AJ_LAST_DATE"].ToString()!="")
					{
						model.AJ_LAST_DATE=DateTime.Parse(ds.Tables[0].Rows[n]["AJ_LAST_DATE"].ToString());
					}
					if(ds.Tables[0].Rows[n]["AJ_LAST_NUM"].ToString()!="")
					{
						model.AJ_LAST_NUM=decimal.Parse(ds.Tables[0].Rows[n]["AJ_LAST_NUM"].ToString());
					}
					model.AJ_JOB_1=ds.Tables[0].Rows[n]["AJ_JOB_1"].ToString();
					model.AJ_JOB_2=ds.Tables[0].Rows[n]["AJ_JOB_2"].ToString();
					model.AJ_JOB_3=ds.Tables[0].Rows[n]["AJ_JOB_3"].ToString();
					model.AJ_JOB_4=ds.Tables[0].Rows[n]["AJ_JOB_4"].ToString();
					model.AJ_JOB_5=ds.Tables[0].Rows[n]["AJ_JOB_5"].ToString();
					model.AJ_JOB_6=ds.Tables[0].Rows[n]["AJ_JOB_6"].ToString();
					model.AJ_JOB_7=ds.Tables[0].Rows[n]["AJ_JOB_7"].ToString();
					model.AJ_JOB_8=ds.Tables[0].Rows[n]["AJ_JOB_8"].ToString();
					model.AJ_JOB_9=ds.Tables[0].Rows[n]["AJ_JOB_9"].ToString();
					model.AJ_JOB_10=ds.Tables[0].Rows[n]["AJ_JOB_10"].ToString();
					model.AJ_JOB_11=ds.Tables[0].Rows[n]["AJ_JOB_11"].ToString();
					model.AJ_JOB_12=ds.Tables[0].Rows[n]["AJ_JOB_12"].ToString();
					model.AJ_JOB_13=ds.Tables[0].Rows[n]["AJ_JOB_13"].ToString();
					model.AJ_JOB_14=ds.Tables[0].Rows[n]["AJ_JOB_14"].ToString();
					model.AJ_JOB_15=ds.Tables[0].Rows[n]["AJ_JOB_15"].ToString();
					model.AJ_JOB_16=ds.Tables[0].Rows[n]["AJ_JOB_16"].ToString();
					model.AJ_JOB_17=ds.Tables[0].Rows[n]["AJ_JOB_17"].ToString();
					model.AJ_JOB_18=ds.Tables[0].Rows[n]["AJ_JOB_18"].ToString();
					model.AJ_JOB_19=ds.Tables[0].Rows[n]["AJ_JOB_19"].ToString();
					model.AJ_JOB_20=ds.Tables[0].Rows[n]["AJ_JOB_20"].ToString();
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

