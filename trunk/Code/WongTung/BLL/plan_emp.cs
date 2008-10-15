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
	/// 业务逻辑类plan_emp 的摘要说明。
	/// </summary>
	public class plan_emp
	{
		private readonly Iplan_emp dal=DataAccess.Createplan_emp();
		public plan_emp()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PLA_EMP_CO,string PLA_EMP_OFF,string PLA_EMP_POS,string PLA_EMP_CODE)
		{
			return dal.Exists(PLA_EMP_CO,PLA_EMP_OFF,PLA_EMP_POS,PLA_EMP_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.plan_emp model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.plan_emp model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string PLA_EMP_CO,string PLA_EMP_OFF,string PLA_EMP_POS,string PLA_EMP_CODE)
		{
			
			dal.Delete(PLA_EMP_CO,PLA_EMP_OFF,PLA_EMP_POS,PLA_EMP_CODE);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.plan_emp GetModel(string PLA_EMP_CO,string PLA_EMP_OFF,string PLA_EMP_POS,string PLA_EMP_CODE)
		{
			
			return dal.GetModel(PLA_EMP_CO,PLA_EMP_OFF,PLA_EMP_POS,PLA_EMP_CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.plan_emp GetModelByCache(string PLA_EMP_CO,string PLA_EMP_OFF,string PLA_EMP_POS,string PLA_EMP_CODE)
		{
			
			string CacheKey = "plan_empModel-" + PLA_EMP_CO+PLA_EMP_OFF+PLA_EMP_POS+PLA_EMP_CODE;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PLA_EMP_CO,PLA_EMP_OFF,PLA_EMP_POS,PLA_EMP_CODE);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.plan_emp)objModel;
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
		public List<WongTung.Model.plan_emp> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.plan_emp> modelList = new List<WongTung.Model.plan_emp>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.plan_emp model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.plan_emp();
					model.PLA_EMP_CO=ds.Tables[0].Rows[n]["PLA_EMP_CO"].ToString();
					model.PLA_EMP_OFF=ds.Tables[0].Rows[n]["PLA_EMP_OFF"].ToString();
					model.PLA_EMP_POS=ds.Tables[0].Rows[n]["PLA_EMP_POS"].ToString();
					model.PLA_EMP_CODE=ds.Tables[0].Rows[n]["PLA_EMP_CODE"].ToString();
					if(ds.Tables[0].Rows[n]["PLA_EMP_NUM"].ToString()!="")
					{
						model.PLA_EMP_NUM=int.Parse(ds.Tables[0].Rows[n]["PLA_EMP_NUM"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PLA_EMP_NOR"].ToString()!="")
					{
						model.PLA_EMP_NOR=decimal.Parse(ds.Tables[0].Rows[n]["PLA_EMP_NOR"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PLA_EMP_OT1"].ToString()!="")
					{
						model.PLA_EMP_OT1=decimal.Parse(ds.Tables[0].Rows[n]["PLA_EMP_OT1"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PLA_EMP_OT2"].ToString()!="")
					{
						model.PLA_EMP_OT2=decimal.Parse(ds.Tables[0].Rows[n]["PLA_EMP_OT2"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PLA_EMP_OT3"].ToString()!="")
					{
						model.PLA_EMP_OT3=decimal.Parse(ds.Tables[0].Rows[n]["PLA_EMP_OT3"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PLA_EMP_T1"].ToString()!="")
					{
						model.PLA_EMP_T1=decimal.Parse(ds.Tables[0].Rows[n]["PLA_EMP_T1"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PLA_EMP_T2"].ToString()!="")
					{
						model.PLA_EMP_T2=decimal.Parse(ds.Tables[0].Rows[n]["PLA_EMP_T2"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PLA_EMP_T3"].ToString()!="")
					{
						model.PLA_EMP_T3=decimal.Parse(ds.Tables[0].Rows[n]["PLA_EMP_T3"].ToString());
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

