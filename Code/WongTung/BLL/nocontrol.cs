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
	/// 业务逻辑类nocontrol 的摘要说明。
	/// </summary>
	public class nocontrol
	{
		private readonly Inocontrol dal=DataAccess.Createnocontrol();
		public nocontrol()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.nocontrol model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.nocontrol model)
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
		public WongTung.Model.nocontrol GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.nocontrol GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "nocontrolModel-" ;
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
			return (WongTung.Model.nocontrol)objModel;
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
		public List<WongTung.Model.nocontrol> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.nocontrol> modelList = new List<WongTung.Model.nocontrol>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.nocontrol model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.nocontrol();
					model.NO_CO_CODE=ds.Tables[0].Rows[n]["NO_CO_CODE"].ToString();
					model.NO_CODE=ds.Tables[0].Rows[n]["NO_CODE"].ToString();
					model.NO_DESC=ds.Tables[0].Rows[n]["NO_DESC"].ToString();
					if(ds.Tables[0].Rows[n]["NO_STA_NO"].ToString()!="")
					{
						model.NO_STA_NO=decimal.Parse(ds.Tables[0].Rows[n]["NO_STA_NO"].ToString());
					}
					if(ds.Tables[0].Rows[n]["NO_SEQ_NO"].ToString()!="")
					{
						model.NO_SEQ_NO=decimal.Parse(ds.Tables[0].Rows[n]["NO_SEQ_NO"].ToString());
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

