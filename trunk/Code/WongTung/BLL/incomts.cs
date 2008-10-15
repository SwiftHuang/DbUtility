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
	/// 业务逻辑类incomts 的摘要说明。
	/// </summary>
	public class incomts
	{
		private readonly Iincomts dal=DataAccess.Createincomts();
		public incomts()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.incomts model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.incomts model)
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
		public WongTung.Model.incomts GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.incomts GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "incomtsModel-" ;
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
			return (WongTung.Model.incomts)objModel;
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
		public List<WongTung.Model.incomts> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.incomts> modelList = new List<WongTung.Model.incomts>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.incomts model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.incomts();
					model.IST_CO_CODE=ds.Tables[0].Rows[n]["IST_CO_CODE"].ToString();
					model.IST_OFFCIE_CODE=ds.Tables[0].Rows[n]["IST_OFFCIE_CODE"].ToString();
					if(ds.Tables[0].Rows[n]["IST_WORK_DATE"].ToString()!="")
					{
						model.IST_WORK_DATE=DateTime.Parse(ds.Tables[0].Rows[n]["IST_WORK_DATE"].ToString());
					}
					model.IST_USER_CODE=ds.Tables[0].Rows[n]["IST_USER_CODE"].ToString();
					model.IST_USER_NAME=ds.Tables[0].Rows[n]["IST_USER_NAME"].ToString();
					model.IST_INPUT_OK=ds.Tables[0].Rows[n]["IST_INPUT_OK"].ToString();
					model.IST_APP=ds.Tables[0].Rows[n]["IST_APP"].ToString();
					if(ds.Tables[0].Rows[n]["IST_NOR_HR"].ToString()!="")
					{
						model.IST_NOR_HR=decimal.Parse(ds.Tables[0].Rows[n]["IST_NOR_HR"].ToString());
					}
					if(ds.Tables[0].Rows[n]["IST_OT_HR"].ToString()!="")
					{
						model.IST_OT_HR=decimal.Parse(ds.Tables[0].Rows[n]["IST_OT_HR"].ToString());
					}
					model.IST_PERIOD=ds.Tables[0].Rows[n]["IST_PERIOD"].ToString();
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

