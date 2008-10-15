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
	/// 业务逻辑类holiday 的摘要说明。
	/// </summary>
	public class holiday
	{
		private readonly Iholiday dal=DataAccess.Createholiday();
		public holiday()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.holiday model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.holiday model)
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
		public WongTung.Model.holiday GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.holiday GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "holidayModel-" ;
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
			return (WongTung.Model.holiday)objModel;
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
		public List<WongTung.Model.holiday> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.holiday> modelList = new List<WongTung.Model.holiday>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.holiday model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.holiday();
					model.HD_CO_CODE=ds.Tables[0].Rows[n]["HD_CO_CODE"].ToString();
					model.HD_EMP_CODE=ds.Tables[0].Rows[n]["HD_EMP_CODE"].ToString();
					if(ds.Tables[0].Rows[n]["HD_LINE_NO"].ToString()!="")
					{
						model.HD_LINE_NO=decimal.Parse(ds.Tables[0].Rows[n]["HD_LINE_NO"].ToString());
					}
					if(ds.Tables[0].Rows[n]["HD_DATE"].ToString()!="")
					{
						model.HD_DATE=DateTime.Parse(ds.Tables[0].Rows[n]["HD_DATE"].ToString());
					}
					model.HD_LEVE_CODE=ds.Tables[0].Rows[n]["HD_LEVE_CODE"].ToString();
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

