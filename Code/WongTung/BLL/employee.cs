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
	/// 业务逻辑类employee 的摘要说明。
	/// </summary>
	public class employee
	{
		private readonly Iemployee dal=DataAccess.Createemployee();
		public employee()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string EMP_CODE)
		{
			return dal.Exists(EMP_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.employee model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.employee model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string EMP_CODE)
		{
			
			dal.Delete(EMP_CODE);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.employee GetModel(string EMP_CODE)
		{
			
			return dal.GetModel(EMP_CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.employee GetModelByCache(string EMP_CODE)
		{
			
			string CacheKey = "employeeModel-" + EMP_CODE;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(EMP_CODE);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.employee)objModel;
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
		public List<WongTung.Model.employee> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.employee> modelList = new List<WongTung.Model.employee>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.employee model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.employee();
					model.EMP_CO_CODE=ds.Tables[0].Rows[n]["EMP_CO_CODE"].ToString();
					model.EMP_CODE=ds.Tables[0].Rows[n]["EMP_CODE"].ToString();
					model.EMP_NAME=ds.Tables[0].Rows[n]["EMP_NAME"].ToString();
					model.EMP_POS_CODE=ds.Tables[0].Rows[n]["EMP_POS_CODE"].ToString();
					model.EMP_DEP_CODE=ds.Tables[0].Rows[n]["EMP_DEP_CODE"].ToString();
					model.EMP_INITIAL=ds.Tables[0].Rows[n]["EMP_INITIAL"].ToString();
					model.EMP_OFFICE=ds.Tables[0].Rows[n]["EMP_OFFICE"].ToString();
					model.EMP_CHNAME=ds.Tables[0].Rows[n]["EMP_CHNAME"].ToString();
					model.EMP_SPE=ds.Tables[0].Rows[n]["EMP_SPE"].ToString();
					if(ds.Tables[0].Rows[n]["EMP_CRE_DATE"].ToString()!="")
					{
						model.EMP_CRE_DATE=DateTime.Parse(ds.Tables[0].Rows[n]["EMP_CRE_DATE"].ToString());
					}
					model.EMP_DEL=ds.Tables[0].Rows[n]["EMP_DEL"].ToString();
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

