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
	/// 业务逻辑类plan_pos 的摘要说明。
	/// </summary>
	public class plan_pos
	{
		private readonly Iplan_pos dal=DataAccess.Createplan_pos();
		public plan_pos()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PLA_POS_CO,string PLA_POS_OFF,string PLA_POS_CODE)
		{
			return dal.Exists(PLA_POS_CO,PLA_POS_OFF,PLA_POS_CODE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.plan_pos model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.plan_pos model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string PLA_POS_CO,string PLA_POS_OFF,string PLA_POS_CODE)
		{
			
			dal.Delete(PLA_POS_CO,PLA_POS_OFF,PLA_POS_CODE);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.plan_pos GetModel(string PLA_POS_CO,string PLA_POS_OFF,string PLA_POS_CODE)
		{
			
			return dal.GetModel(PLA_POS_CO,PLA_POS_OFF,PLA_POS_CODE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.plan_pos GetModelByCache(string PLA_POS_CO,string PLA_POS_OFF,string PLA_POS_CODE)
		{
			
			string CacheKey = "plan_posModel-" + PLA_POS_CO+PLA_POS_OFF+PLA_POS_CODE;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PLA_POS_CO,PLA_POS_OFF,PLA_POS_CODE);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.plan_pos)objModel;
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
		public List<WongTung.Model.plan_pos> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.plan_pos> modelList = new List<WongTung.Model.plan_pos>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.plan_pos model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.plan_pos();
					model.PLA_POS_CO=ds.Tables[0].Rows[n]["PLA_POS_CO"].ToString();
					model.PLA_POS_OFF=ds.Tables[0].Rows[n]["PLA_POS_OFF"].ToString();
					model.PLA_POS_CODE=ds.Tables[0].Rows[n]["PLA_POS_CODE"].ToString();
					if(ds.Tables[0].Rows[n]["PLA_POS_NUM"].ToString()!="")
					{
						model.PLA_POS_NUM=int.Parse(ds.Tables[0].Rows[n]["PLA_POS_NUM"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PLA_POS_NOR"].ToString()!="")
					{
						model.PLA_POS_NOR=decimal.Parse(ds.Tables[0].Rows[n]["PLA_POS_NOR"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PLA_POS_OT1"].ToString()!="")
					{
						model.PLA_POS_OT1=decimal.Parse(ds.Tables[0].Rows[n]["PLA_POS_OT1"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PLA_POS_OT2"].ToString()!="")
					{
						model.PLA_POS_OT2=decimal.Parse(ds.Tables[0].Rows[n]["PLA_POS_OT2"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PLA_POS_OT3"].ToString()!="")
					{
						model.PLA_POS_OT3=decimal.Parse(ds.Tables[0].Rows[n]["PLA_POS_OT3"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PLA_POS_T1"].ToString()!="")
					{
						model.PLA_POS_T1=decimal.Parse(ds.Tables[0].Rows[n]["PLA_POS_T1"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PLA_POS_T2"].ToString()!="")
					{
						model.PLA_POS_T2=decimal.Parse(ds.Tables[0].Rows[n]["PLA_POS_T2"].ToString());
					}
					if(ds.Tables[0].Rows[n]["PLA_POS_T3"].ToString()!="")
					{
						model.PLA_POS_T3=decimal.Parse(ds.Tables[0].Rows[n]["PLA_POS_T3"].ToString());
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

