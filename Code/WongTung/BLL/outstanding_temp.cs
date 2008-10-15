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
	/// 业务逻辑类outstanding_temp 的摘要说明。
	/// </summary>
	public class outstanding_temp
	{
		private readonly Ioutstanding_temp dal=DataAccess.Createoutstanding_temp();
		public outstanding_temp()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal NUM)
		{
			return dal.Exists(NUM);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.outstanding_temp model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.outstanding_temp model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(decimal NUM)
		{
			
			dal.Delete(NUM);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.outstanding_temp GetModel(decimal NUM)
		{
			
			return dal.GetModel(NUM);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public WongTung.Model.outstanding_temp GetModelByCache(decimal NUM)
		{
			
			string CacheKey = "outstanding_tempModel-" + NUM;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(NUM);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (WongTung.Model.outstanding_temp)objModel;
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
		public List<WongTung.Model.outstanding_temp> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<WongTung.Model.outstanding_temp> modelList = new List<WongTung.Model.outstanding_temp>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				WongTung.Model.outstanding_temp model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new WongTung.Model.outstanding_temp();
					if(ds.Tables[0].Rows[n]["NUM"].ToString()!="")
					{
						model.NUM=decimal.Parse(ds.Tables[0].Rows[n]["NUM"].ToString());
					}
					model.OUT_OFF_CODE=ds.Tables[0].Rows[n]["OUT_OFF_CODE"].ToString();
					model.OUT_OFF_NAME=ds.Tables[0].Rows[n]["OUT_OFF_NAME"].ToString();
					model.OUT_EMP_CODE=ds.Tables[0].Rows[n]["OUT_EMP_CODE"].ToString();
					model.OUT_EMP_NAME=ds.Tables[0].Rows[n]["OUT_EMP_NAME"].ToString();
					if(ds.Tables[0].Rows[n]["OUT_DAY"].ToString()!="")
					{
						model.OUT_DAY=DateTime.Parse(ds.Tables[0].Rows[n]["OUT_DAY"].ToString());
					}
					if(ds.Tables[0].Rows[n]["OUT_POS_CLASS"].ToString()!="")
					{
						model.OUT_POS_CLASS=decimal.Parse(ds.Tables[0].Rows[n]["OUT_POS_CLASS"].ToString());
					}
					model.OUT_POS_CODE=ds.Tables[0].Rows[n]["OUT_POS_CODE"].ToString();
					if(ds.Tables[0].Rows[n]["OUT_UPDATE_DATE"].ToString()!="")
					{
						model.OUT_UPDATE_DATE=DateTime.Parse(ds.Tables[0].Rows[n]["OUT_UPDATE_DATE"].ToString());
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

