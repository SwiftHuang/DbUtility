using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类position。
	/// </summary>
	public class position:Iposition
	{
		public position()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string POS_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from position");
			strSql.Append(" where POS_CODE=@POS_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@POS_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = POS_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.position model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into position(");
			strSql.Append("POS_CO_CODE,POS_CODE,POS_DESC,POS_FEE_LEV1,POS_FEE_LEV2,POS_FEE_LEV3,POS_RATE_OUT,POS_RATE_DAILY,POS_RATE_MON,POS_RATE_OT,POS_MON_TOTAL,POS_MON_UTILIST,POS_MON_REV,POS_SAL_FROM,POS_SAL_TO,POS_DALIY_COST,POS_MON_COST,POS_CLASS,POS_PLAN)");
			strSql.Append(" values (");
			strSql.Append("@POS_CO_CODE,@POS_CODE,@POS_DESC,@POS_FEE_LEV1,@POS_FEE_LEV2,@POS_FEE_LEV3,@POS_RATE_OUT,@POS_RATE_DAILY,@POS_RATE_MON,@POS_RATE_OT,@POS_MON_TOTAL,@POS_MON_UTILIST,@POS_MON_REV,@POS_SAL_FROM,@POS_SAL_TO,@POS_DALIY_COST,@POS_MON_COST,@POS_CLASS,@POS_PLAN)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@POS_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@POS_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@POS_DESC", MySqlDbType.Char,100),
					new MySqlParameter("@POS_FEE_LEV1", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_FEE_LEV2", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_FEE_LEV3", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_RATE_OUT", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_RATE_DAILY", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_RATE_MON", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_RATE_OT", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_MON_TOTAL", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_MON_UTILIST", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_MON_REV", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_SAL_FROM", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_SAL_TO", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_DALIY_COST", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_MON_COST", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_CLASS", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_PLAN", MySqlDbType.Char,1)};
			parameters[0].Value = model.POS_CO_CODE;
			parameters[1].Value = model.POS_CODE;
			parameters[2].Value = model.POS_DESC;
			parameters[3].Value = model.POS_FEE_LEV1;
			parameters[4].Value = model.POS_FEE_LEV2;
			parameters[5].Value = model.POS_FEE_LEV3;
			parameters[6].Value = model.POS_RATE_OUT;
			parameters[7].Value = model.POS_RATE_DAILY;
			parameters[8].Value = model.POS_RATE_MON;
			parameters[9].Value = model.POS_RATE_OT;
			parameters[10].Value = model.POS_MON_TOTAL;
			parameters[11].Value = model.POS_MON_UTILIST;
			parameters[12].Value = model.POS_MON_REV;
			parameters[13].Value = model.POS_SAL_FROM;
			parameters[14].Value = model.POS_SAL_TO;
			parameters[15].Value = model.POS_DALIY_COST;
			parameters[16].Value = model.POS_MON_COST;
			parameters[17].Value = model.POS_CLASS;
			parameters[18].Value = model.POS_PLAN;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.position model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update position set ");
			strSql.Append("POS_CO_CODE=@POS_CO_CODE,");
			strSql.Append("POS_DESC=@POS_DESC,");
			strSql.Append("POS_FEE_LEV1=@POS_FEE_LEV1,");
			strSql.Append("POS_FEE_LEV2=@POS_FEE_LEV2,");
			strSql.Append("POS_FEE_LEV3=@POS_FEE_LEV3,");
			strSql.Append("POS_RATE_OUT=@POS_RATE_OUT,");
			strSql.Append("POS_RATE_DAILY=@POS_RATE_DAILY,");
			strSql.Append("POS_RATE_MON=@POS_RATE_MON,");
			strSql.Append("POS_RATE_OT=@POS_RATE_OT,");
			strSql.Append("POS_MON_TOTAL=@POS_MON_TOTAL,");
			strSql.Append("POS_MON_UTILIST=@POS_MON_UTILIST,");
			strSql.Append("POS_MON_REV=@POS_MON_REV,");
			strSql.Append("POS_SAL_FROM=@POS_SAL_FROM,");
			strSql.Append("POS_SAL_TO=@POS_SAL_TO,");
			strSql.Append("POS_DALIY_COST=@POS_DALIY_COST,");
			strSql.Append("POS_MON_COST=@POS_MON_COST,");
			strSql.Append("POS_CLASS=@POS_CLASS,");
			strSql.Append("POS_PLAN=@POS_PLAN");
			strSql.Append(" where POS_CODE=@POS_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@POS_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@POS_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@POS_DESC", MySqlDbType.Char,100),
					new MySqlParameter("@POS_FEE_LEV1", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_FEE_LEV2", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_FEE_LEV3", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_RATE_OUT", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_RATE_DAILY", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_RATE_MON", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_RATE_OT", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_MON_TOTAL", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_MON_UTILIST", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_MON_REV", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_SAL_FROM", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_SAL_TO", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_DALIY_COST", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_MON_COST", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_CLASS", MySqlDbType.Decimal,18),
					new MySqlParameter("@POS_PLAN", MySqlDbType.Char,1)};
			parameters[0].Value = model.POS_CO_CODE;
			parameters[1].Value = model.POS_CODE;
			parameters[2].Value = model.POS_DESC;
			parameters[3].Value = model.POS_FEE_LEV1;
			parameters[4].Value = model.POS_FEE_LEV2;
			parameters[5].Value = model.POS_FEE_LEV3;
			parameters[6].Value = model.POS_RATE_OUT;
			parameters[7].Value = model.POS_RATE_DAILY;
			parameters[8].Value = model.POS_RATE_MON;
			parameters[9].Value = model.POS_RATE_OT;
			parameters[10].Value = model.POS_MON_TOTAL;
			parameters[11].Value = model.POS_MON_UTILIST;
			parameters[12].Value = model.POS_MON_REV;
			parameters[13].Value = model.POS_SAL_FROM;
			parameters[14].Value = model.POS_SAL_TO;
			parameters[15].Value = model.POS_DALIY_COST;
			parameters[16].Value = model.POS_MON_COST;
			parameters[17].Value = model.POS_CLASS;
			parameters[18].Value = model.POS_PLAN;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string POS_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete position ");
			strSql.Append(" where POS_CODE=@POS_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@POS_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = POS_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.position GetModel(string POS_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select POS_CO_CODE,POS_CODE,POS_DESC,POS_FEE_LEV1,POS_FEE_LEV2,POS_FEE_LEV3,POS_RATE_OUT,POS_RATE_DAILY,POS_RATE_MON,POS_RATE_OT,POS_MON_TOTAL,POS_MON_UTILIST,POS_MON_REV,POS_SAL_FROM,POS_SAL_TO,POS_DALIY_COST,POS_MON_COST,POS_CLASS,POS_PLAN from position ");
			strSql.Append(" where POS_CODE=@POS_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@POS_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = POS_CODE;

			WongTung.Model.position model=new WongTung.Model.position();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.POS_CO_CODE=ds.Tables[0].Rows[0]["POS_CO_CODE"].ToString();
				model.POS_CODE=ds.Tables[0].Rows[0]["POS_CODE"].ToString();
				model.POS_DESC=ds.Tables[0].Rows[0]["POS_DESC"].ToString();
				if(ds.Tables[0].Rows[0]["POS_FEE_LEV1"].ToString()!="")
				{
					model.POS_FEE_LEV1=decimal.Parse(ds.Tables[0].Rows[0]["POS_FEE_LEV1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POS_FEE_LEV2"].ToString()!="")
				{
					model.POS_FEE_LEV2=decimal.Parse(ds.Tables[0].Rows[0]["POS_FEE_LEV2"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POS_FEE_LEV3"].ToString()!="")
				{
					model.POS_FEE_LEV3=decimal.Parse(ds.Tables[0].Rows[0]["POS_FEE_LEV3"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POS_RATE_OUT"].ToString()!="")
				{
					model.POS_RATE_OUT=decimal.Parse(ds.Tables[0].Rows[0]["POS_RATE_OUT"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POS_RATE_DAILY"].ToString()!="")
				{
					model.POS_RATE_DAILY=decimal.Parse(ds.Tables[0].Rows[0]["POS_RATE_DAILY"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POS_RATE_MON"].ToString()!="")
				{
					model.POS_RATE_MON=decimal.Parse(ds.Tables[0].Rows[0]["POS_RATE_MON"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POS_RATE_OT"].ToString()!="")
				{
					model.POS_RATE_OT=decimal.Parse(ds.Tables[0].Rows[0]["POS_RATE_OT"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POS_MON_TOTAL"].ToString()!="")
				{
					model.POS_MON_TOTAL=decimal.Parse(ds.Tables[0].Rows[0]["POS_MON_TOTAL"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POS_MON_UTILIST"].ToString()!="")
				{
					model.POS_MON_UTILIST=decimal.Parse(ds.Tables[0].Rows[0]["POS_MON_UTILIST"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POS_MON_REV"].ToString()!="")
				{
					model.POS_MON_REV=decimal.Parse(ds.Tables[0].Rows[0]["POS_MON_REV"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POS_SAL_FROM"].ToString()!="")
				{
					model.POS_SAL_FROM=decimal.Parse(ds.Tables[0].Rows[0]["POS_SAL_FROM"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POS_SAL_TO"].ToString()!="")
				{
					model.POS_SAL_TO=decimal.Parse(ds.Tables[0].Rows[0]["POS_SAL_TO"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POS_DALIY_COST"].ToString()!="")
				{
					model.POS_DALIY_COST=decimal.Parse(ds.Tables[0].Rows[0]["POS_DALIY_COST"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POS_MON_COST"].ToString()!="")
				{
					model.POS_MON_COST=decimal.Parse(ds.Tables[0].Rows[0]["POS_MON_COST"].ToString());
				}
				if(ds.Tables[0].Rows[0]["POS_CLASS"].ToString()!="")
				{
					model.POS_CLASS=decimal.Parse(ds.Tables[0].Rows[0]["POS_CLASS"].ToString());
				}
				model.POS_PLAN=ds.Tables[0].Rows[0]["POS_PLAN"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select POS_CO_CODE,POS_CODE,POS_DESC,POS_FEE_LEV1,POS_FEE_LEV2,POS_FEE_LEV3,POS_RATE_OUT,POS_RATE_DAILY,POS_RATE_MON,POS_RATE_OT,POS_MON_TOTAL,POS_MON_UTILIST,POS_MON_REV,POS_SAL_FROM,POS_SAL_TO,POS_DALIY_COST,POS_MON_COST,POS_CLASS,POS_PLAN ");
			strSql.Append(" FROM position ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "position";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

