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
	/// 业务逻辑类backdate 的摘要说明。
	/// </summary>
	public class backdate
	{
		private readonly Ibackdate dal=DataAccess.Createbackdate();
		public backdate()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.backdate model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.backdate model)
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
		public WongTung.Model.backdate GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.backdate GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "backdateModel-" ;
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
			return (WongTung.Model.backdate)objModel;
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
		public List<WongTung.Model.backdate> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.backdate> modelList = new List<WongTung.Model.backdate>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.backdate model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.backdate();
					model.BK_CO_CODE=ds.Tables[0].Rows[n]["BK_CO_CODE"].ToString();
					model.BK_USER=ds.Tables[0].Rows[n]["BK_USER"].ToString();
					model.BK_RAN_NO=ds.Tables[0].Rows[n]["BK_RAN_NO"].ToString();
					model.BK_EMP=ds.Tables[0].Rows[n]["BK_EMP"].ToString();
					if(ds.Tables[0].Rows[n]["BK_RAN_DATE"].ToString()!="")
					{
						model.BK_RAN_DATE=DateTime.Parse(ds.Tables[0].Rows[n]["BK_RAN_DATE"].ToString());
					}
					if(ds.Tables[0].Rows[n]["BK_CRE_DATE"].ToString()!="")
					{
						model.BK_CRE_DATE=DateTime.Parse(ds.Tables[0].Rows[n]["BK_CRE_DATE"].ToString());
					}
					model.BK_STATUS=ds.Tables[0].Rows[n]["BK_STATUS"].ToString();
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

