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
	/// 业务逻辑类emp_day_tem 的摘要说明。
	/// </summary>
	public class emp_day_tem
	{
		private readonly Iemp_day_tem dal=DataAccess.Createemp_day_tem();
		public emp_day_tem()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ED_CO_CODE,string ED_EMP_CODE)
		{
			return dal.Exists(ED_CO_CODE,ED_EMP_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.emp_day_tem model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.emp_day_tem model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string ED_CO_CODE,string ED_EMP_CODE)
		{
			
			dal.Delete(ED_CO_CODE,ED_EMP_CODE);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.emp_day_tem GetModel(string ED_CO_CODE,string ED_EMP_CODE)
		{
			
			return dal.GetModel(ED_CO_CODE,ED_EMP_CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.emp_day_tem GetModelByCache(string ED_CO_CODE,string ED_EMP_CODE)
		{
			
			string CacheKey = "emp_day_temModel-" + ED_CO_CODE+ED_EMP_CODE;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ED_CO_CODE,ED_EMP_CODE);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.emp_day_tem)objModel;
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
		public List<WongTung.Model.emp_day_tem> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.emp_day_tem> modelList = new List<WongTung.Model.emp_day_tem>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.emp_day_tem model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.emp_day_tem();
					model.ED_CO_CODE=ds.Tables[0].Rows[n]["ED_CO_CODE"].ToString();
					model.ED_EMP_CODE=ds.Tables[0].Rows[n]["ED_EMP_CODE"].ToString();
					model.ED_JS_1=ds.Tables[0].Rows[n]["ED_JS_1"].ToString();
					model.ED_JS_2=ds.Tables[0].Rows[n]["ED_JS_2"].ToString();
					model.ED_JS_3=ds.Tables[0].Rows[n]["ED_JS_3"].ToString();
					model.ED_JS_4=ds.Tables[0].Rows[n]["ED_JS_4"].ToString();
					model.ED_JS_5=ds.Tables[0].Rows[n]["ED_JS_5"].ToString();
					model.ED_JS_6=ds.Tables[0].Rows[n]["ED_JS_6"].ToString();
					model.ED_JS_7=ds.Tables[0].Rows[n]["ED_JS_7"].ToString();
					model.ED_JS_8=ds.Tables[0].Rows[n]["ED_JS_8"].ToString();
					model.ED_JS_9=ds.Tables[0].Rows[n]["ED_JS_9"].ToString();
					model.ED_JS_10=ds.Tables[0].Rows[n]["ED_JS_10"].ToString();
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

