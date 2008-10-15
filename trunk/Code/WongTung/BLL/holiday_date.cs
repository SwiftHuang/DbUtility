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
	/// 业务逻辑类holiday_date 的摘要说明。
	/// </summary>
	public class holiday_date
	{
		private readonly Iholiday_date dal=DataAccess.Createholiday_date();
		public holiday_date()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string HO_CO_CODE,string HO_CODE)
		{
			return dal.Exists(HO_CO_CODE,HO_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.holiday_date model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.holiday_date model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string HO_CO_CODE,string HO_CODE)
		{
			
			dal.Delete(HO_CO_CODE,HO_CODE);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.holiday_date GetModel(string HO_CO_CODE,string HO_CODE)
		{
			
			return dal.GetModel(HO_CO_CODE,HO_CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.holiday_date GetModelByCache(string HO_CO_CODE,string HO_CODE)
		{
			
			string CacheKey = "holiday_dateModel-" + HO_CO_CODE+HO_CODE;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(HO_CO_CODE,HO_CODE);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.holiday_date)objModel;
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
		public List<WongTung.Model.holiday_date> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.holiday_date> modelList = new List<WongTung.Model.holiday_date>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.holiday_date model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.holiday_date();
					model.HO_CO_CODE=ds.Tables[0].Rows[n]["HO_CO_CODE"].ToString();
					model.HO_LOC=ds.Tables[0].Rows[n]["HO_LOC"].ToString();
					model.HO_CODE=ds.Tables[0].Rows[n]["HO_CODE"].ToString();
					if(ds.Tables[0].Rows[n]["HO_DATE_START"].ToString()!="")
					{
						model.HO_DATE_START=DateTime.Parse(ds.Tables[0].Rows[n]["HO_DATE_START"].ToString());
					}
					if(ds.Tables[0].Rows[n]["HO_DATE_END"].ToString()!="")
					{
						model.HO_DATE_END=DateTime.Parse(ds.Tables[0].Rows[n]["HO_DATE_END"].ToString());
					}
					model.HO_DESC=ds.Tables[0].Rows[n]["HO_DESC"].ToString();
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

