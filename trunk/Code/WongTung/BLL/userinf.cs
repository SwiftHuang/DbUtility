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
	/// 业务逻辑类userinf 的摘要说明。
	/// </summary>
	public class userinf
	{
		private readonly Iuserinf dal=DataAccess.Createuserinf();
		public userinf()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string USER_CODE)
		{
			return dal.Exists(USER_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.userinf model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.userinf model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string USER_CODE)
		{
			
			dal.Delete(USER_CODE);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.userinf GetModel(string USER_CODE)
		{
			
			return dal.GetModel(USER_CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.userinf GetModelByCache(string USER_CODE)
		{
			
			string CacheKey = "userinfModel-" + USER_CODE;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(USER_CODE);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.userinf)objModel;
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
		public List<WongTung.Model.userinf> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.userinf> modelList = new List<WongTung.Model.userinf>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.userinf model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.userinf();
					model.USER_CO_CODE=ds.Tables[0].Rows[n]["USER_CO_CODE"].ToString();
					model.USER_CODE=ds.Tables[0].Rows[n]["USER_CODE"].ToString();
					model.USER_NAME=ds.Tables[0].Rows[n]["USER_NAME"].ToString();
					model.USER_EMP_CODE=ds.Tables[0].Rows[n]["USER_EMP_CODE"].ToString();
					model.USER_RAND=ds.Tables[0].Rows[n]["USER_RAND"].ToString();
					if(ds.Tables[0].Rows[n]["USER_CURDATE"].ToString()!="")
					{
						model.USER_CURDATE=DateTime.Parse(ds.Tables[0].Rows[n]["USER_CURDATE"].ToString());
					}
					model.USER_RAND_BACK=ds.Tables[0].Rows[n]["USER_RAND_BACK"].ToString();
					model.USER_ACTIVATE=ds.Tables[0].Rows[n]["USER_ACTIVATE"].ToString();
					model.USER_CHNAME=ds.Tables[0].Rows[n]["USER_CHNAME"].ToString();
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

