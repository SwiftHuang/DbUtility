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
	/// 业务逻辑类backspecial 的摘要说明。
	/// </summary>
	public class backspecial
	{
		private readonly Ibackspecial dal=DataAccess.Createbackspecial();
		public backspecial()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BS_CODE)
		{
			return dal.Exists(BS_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.backspecial model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.backspecial model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string BS_CODE)
		{
			
			dal.Delete(BS_CODE);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.backspecial GetModel(string BS_CODE)
		{
			
			return dal.GetModel(BS_CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.backspecial GetModelByCache(string BS_CODE)
		{
			
			string CacheKey = "backspecialModel-" + BS_CODE;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(BS_CODE);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.backspecial)objModel;
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
		public List<WongTung.Model.backspecial> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.backspecial> modelList = new List<WongTung.Model.backspecial>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.backspecial model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.backspecial();
					model.BS_CO_CODE=ds.Tables[0].Rows[n]["BS_CO_CODE"].ToString();
					model.BS_CODE=ds.Tables[0].Rows[n]["BS_CODE"].ToString();
					if(ds.Tables[0].Rows[n]["BS_DATE"].ToString()!="")
					{
						model.BS_DATE=DateTime.Parse(ds.Tables[0].Rows[n]["BS_DATE"].ToString());
					}
					if(ds.Tables[0].Rows[n]["BS_CURDATE"].ToString()!="")
					{
						model.BS_CURDATE=DateTime.Parse(ds.Tables[0].Rows[n]["BS_CURDATE"].ToString());
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

