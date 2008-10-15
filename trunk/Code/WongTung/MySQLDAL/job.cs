using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类job。
	/// </summary>
	public class job:Ijob
	{
		public job()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string JOB_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from job");
			strSql.Append(" where JOB_CODE=@JOB_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@JOB_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = JOB_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.job model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into job(");
			strSql.Append("JOB_CO_CODE,JOB_CODE,JOB_NAME,JOB_CON,JOB_OPEN_BAL_HOUR,JOB_YTD_HOUR,JOB_OPEN_BAL_AMT,JOB_YTD_AMT,JOB_REC,JOB_OS_BAL,JOB_BUD_HOUR,JOB_CO_ORD,JOB_ADMIN,JOB_DESIGN,JOB_LEV1,JOB_LEV2,JOB_LEV3,JOB_CHARGE_OUT,JOB_DAILY,JOB_MON,JOB_PERIOD,JOB_PERIOD_VAL,JOB_AUTH,JOB_OFF_INCHG_AD,JOB_OFF_INCHG_DES,JOB_AUTH_1,JOB_AUTH_2,JOB_AUTH_3,JOB_AUTH_4,JOB_AUTH_5,JOB_INDEX,JOB_NAME_S,JOB_NAME_T)");
			strSql.Append(" values (");
			strSql.Append("@JOB_CO_CODE,@JOB_CODE,@JOB_NAME,@JOB_CON,@JOB_OPEN_BAL_HOUR,@JOB_YTD_HOUR,@JOB_OPEN_BAL_AMT,@JOB_YTD_AMT,@JOB_REC,@JOB_OS_BAL,@JOB_BUD_HOUR,@JOB_CO_ORD,@JOB_ADMIN,@JOB_DESIGN,@JOB_LEV1,@JOB_LEV2,@JOB_LEV3,@JOB_CHARGE_OUT,@JOB_DAILY,@JOB_MON,@JOB_PERIOD,@JOB_PERIOD_VAL,@JOB_AUTH,@JOB_OFF_INCHG_AD,@JOB_OFF_INCHG_DES,@JOB_AUTH_1,@JOB_AUTH_2,@JOB_AUTH_3,@JOB_AUTH_4,@JOB_AUTH_5,@JOB_INDEX,@JOB_NAME_S,@JOB_NAME_T)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@JOB_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@JOB_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@JOB_CON", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_OPEN_BAL_HOUR", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_YTD_HOUR", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_OPEN_BAL_AMT", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_YTD_AMT", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_REC", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_OS_BAL", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_BUD_HOUR", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_CO_ORD", MySqlDbType.Int32,11),
					new MySqlParameter("@JOB_ADMIN", MySqlDbType.Int32,1),
					new MySqlParameter("@JOB_DESIGN", MySqlDbType.Int32,1),
					new MySqlParameter("@JOB_LEV1", MySqlDbType.Int32,11),
					new MySqlParameter("@JOB_LEV2", MySqlDbType.Int32,1),
					new MySqlParameter("@JOB_LEV3", MySqlDbType.Int32,1),
					new MySqlParameter("@JOB_CHARGE_OUT", MySqlDbType.Int32,1),
					new MySqlParameter("@JOB_DAILY", MySqlDbType.Int32,1),
					new MySqlParameter("@JOB_MON", MySqlDbType.Int32,1),
					new MySqlParameter("@JOB_PERIOD", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_PERIOD_VAL", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_AUTH", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_OFF_INCHG_AD", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_OFF_INCHG_DES", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_AUTH_1", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_AUTH_2", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_AUTH_3", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_AUTH_4", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_AUTH_5", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_INDEX", MySqlDbType.Int32,3),
					new MySqlParameter("@JOB_NAME_S", MySqlDbType.Char,100),
					new MySqlParameter("@JOB_NAME_T", MySqlDbType.Char,100)};
			parameters[0].Value = model.JOB_CO_CODE;
			parameters[1].Value = model.JOB_CODE;
			parameters[2].Value = model.JOB_NAME;
			parameters[3].Value = model.JOB_CON;
			parameters[4].Value = model.JOB_OPEN_BAL_HOUR;
			parameters[5].Value = model.JOB_YTD_HOUR;
			parameters[6].Value = model.JOB_OPEN_BAL_AMT;
			parameters[7].Value = model.JOB_YTD_AMT;
			parameters[8].Value = model.JOB_REC;
			parameters[9].Value = model.JOB_OS_BAL;
			parameters[10].Value = model.JOB_BUD_HOUR;
			parameters[11].Value = model.JOB_CO_ORD;
			parameters[12].Value = model.JOB_ADMIN;
			parameters[13].Value = model.JOB_DESIGN;
			parameters[14].Value = model.JOB_LEV1;
			parameters[15].Value = model.JOB_LEV2;
			parameters[16].Value = model.JOB_LEV3;
			parameters[17].Value = model.JOB_CHARGE_OUT;
			parameters[18].Value = model.JOB_DAILY;
			parameters[19].Value = model.JOB_MON;
			parameters[20].Value = model.JOB_PERIOD;
			parameters[21].Value = model.JOB_PERIOD_VAL;
			parameters[22].Value = model.JOB_AUTH;
			parameters[23].Value = model.JOB_OFF_INCHG_AD;
			parameters[24].Value = model.JOB_OFF_INCHG_DES;
			parameters[25].Value = model.JOB_AUTH_1;
			parameters[26].Value = model.JOB_AUTH_2;
			parameters[27].Value = model.JOB_AUTH_3;
			parameters[28].Value = model.JOB_AUTH_4;
			parameters[29].Value = model.JOB_AUTH_5;
			parameters[30].Value = model.JOB_INDEX;
			parameters[31].Value = model.JOB_NAME_S;
			parameters[32].Value = model.JOB_NAME_T;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.job model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update job set ");
			strSql.Append("JOB_CO_CODE=@JOB_CO_CODE,");
			strSql.Append("JOB_NAME=@JOB_NAME,");
			strSql.Append("JOB_CON=@JOB_CON,");
			strSql.Append("JOB_OPEN_BAL_HOUR=@JOB_OPEN_BAL_HOUR,");
			strSql.Append("JOB_YTD_HOUR=@JOB_YTD_HOUR,");
			strSql.Append("JOB_OPEN_BAL_AMT=@JOB_OPEN_BAL_AMT,");
			strSql.Append("JOB_YTD_AMT=@JOB_YTD_AMT,");
			strSql.Append("JOB_REC=@JOB_REC,");
			strSql.Append("JOB_OS_BAL=@JOB_OS_BAL,");
			strSql.Append("JOB_BUD_HOUR=@JOB_BUD_HOUR,");
			strSql.Append("JOB_CO_ORD=@JOB_CO_ORD,");
			strSql.Append("JOB_ADMIN=@JOB_ADMIN,");
			strSql.Append("JOB_DESIGN=@JOB_DESIGN,");
			strSql.Append("JOB_LEV1=@JOB_LEV1,");
			strSql.Append("JOB_LEV2=@JOB_LEV2,");
			strSql.Append("JOB_LEV3=@JOB_LEV3,");
			strSql.Append("JOB_CHARGE_OUT=@JOB_CHARGE_OUT,");
			strSql.Append("JOB_DAILY=@JOB_DAILY,");
			strSql.Append("JOB_MON=@JOB_MON,");
			strSql.Append("JOB_PERIOD=@JOB_PERIOD,");
			strSql.Append("JOB_PERIOD_VAL=@JOB_PERIOD_VAL,");
			strSql.Append("JOB_AUTH=@JOB_AUTH,");
			strSql.Append("JOB_OFF_INCHG_AD=@JOB_OFF_INCHG_AD,");
			strSql.Append("JOB_OFF_INCHG_DES=@JOB_OFF_INCHG_DES,");
			strSql.Append("JOB_AUTH_1=@JOB_AUTH_1,");
			strSql.Append("JOB_AUTH_2=@JOB_AUTH_2,");
			strSql.Append("JOB_AUTH_3=@JOB_AUTH_3,");
			strSql.Append("JOB_AUTH_4=@JOB_AUTH_4,");
			strSql.Append("JOB_AUTH_5=@JOB_AUTH_5,");
			strSql.Append("JOB_INDEX=@JOB_INDEX,");
			strSql.Append("JOB_NAME_S=@JOB_NAME_S,");
			strSql.Append("JOB_NAME_T=@JOB_NAME_T");
			strSql.Append(" where JOB_CODE=@JOB_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@JOB_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@JOB_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@JOB_CON", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_OPEN_BAL_HOUR", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_YTD_HOUR", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_OPEN_BAL_AMT", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_YTD_AMT", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_REC", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_OS_BAL", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_BUD_HOUR", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_CO_ORD", MySqlDbType.Int32,11),
					new MySqlParameter("@JOB_ADMIN", MySqlDbType.Int32,1),
					new MySqlParameter("@JOB_DESIGN", MySqlDbType.Int32,1),
					new MySqlParameter("@JOB_LEV1", MySqlDbType.Int32,11),
					new MySqlParameter("@JOB_LEV2", MySqlDbType.Int32,1),
					new MySqlParameter("@JOB_LEV3", MySqlDbType.Int32,1),
					new MySqlParameter("@JOB_CHARGE_OUT", MySqlDbType.Int32,1),
					new MySqlParameter("@JOB_DAILY", MySqlDbType.Int32,1),
					new MySqlParameter("@JOB_MON", MySqlDbType.Int32,1),
					new MySqlParameter("@JOB_PERIOD", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_PERIOD_VAL", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_AUTH", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_OFF_INCHG_AD", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_OFF_INCHG_DES", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_AUTH_1", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_AUTH_2", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_AUTH_3", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_AUTH_4", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_AUTH_5", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_INDEX", MySqlDbType.Int32,3),
					new MySqlParameter("@JOB_NAME_S", MySqlDbType.Char,100),
					new MySqlParameter("@JOB_NAME_T", MySqlDbType.Char,100)};
			parameters[0].Value = model.JOB_CO_CODE;
			parameters[1].Value = model.JOB_CODE;
			parameters[2].Value = model.JOB_NAME;
			parameters[3].Value = model.JOB_CON;
			parameters[4].Value = model.JOB_OPEN_BAL_HOUR;
			parameters[5].Value = model.JOB_YTD_HOUR;
			parameters[6].Value = model.JOB_OPEN_BAL_AMT;
			parameters[7].Value = model.JOB_YTD_AMT;
			parameters[8].Value = model.JOB_REC;
			parameters[9].Value = model.JOB_OS_BAL;
			parameters[10].Value = model.JOB_BUD_HOUR;
			parameters[11].Value = model.JOB_CO_ORD;
			parameters[12].Value = model.JOB_ADMIN;
			parameters[13].Value = model.JOB_DESIGN;
			parameters[14].Value = model.JOB_LEV1;
			parameters[15].Value = model.JOB_LEV2;
			parameters[16].Value = model.JOB_LEV3;
			parameters[17].Value = model.JOB_CHARGE_OUT;
			parameters[18].Value = model.JOB_DAILY;
			parameters[19].Value = model.JOB_MON;
			parameters[20].Value = model.JOB_PERIOD;
			parameters[21].Value = model.JOB_PERIOD_VAL;
			parameters[22].Value = model.JOB_AUTH;
			parameters[23].Value = model.JOB_OFF_INCHG_AD;
			parameters[24].Value = model.JOB_OFF_INCHG_DES;
			parameters[25].Value = model.JOB_AUTH_1;
			parameters[26].Value = model.JOB_AUTH_2;
			parameters[27].Value = model.JOB_AUTH_3;
			parameters[28].Value = model.JOB_AUTH_4;
			parameters[29].Value = model.JOB_AUTH_5;
			parameters[30].Value = model.JOB_INDEX;
			parameters[31].Value = model.JOB_NAME_S;
			parameters[32].Value = model.JOB_NAME_T;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string JOB_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete job ");
			strSql.Append(" where JOB_CODE=@JOB_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@JOB_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = JOB_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.job GetModel(string JOB_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select JOB_CO_CODE,JOB_CODE,JOB_NAME,JOB_CON,JOB_OPEN_BAL_HOUR,JOB_YTD_HOUR,JOB_OPEN_BAL_AMT,JOB_YTD_AMT,JOB_REC,JOB_OS_BAL,JOB_BUD_HOUR,JOB_CO_ORD,JOB_ADMIN,JOB_DESIGN,JOB_LEV1,JOB_LEV2,JOB_LEV3,JOB_CHARGE_OUT,JOB_DAILY,JOB_MON,JOB_PERIOD,JOB_PERIOD_VAL,JOB_AUTH,JOB_OFF_INCHG_AD,JOB_OFF_INCHG_DES,JOB_AUTH_1,JOB_AUTH_2,JOB_AUTH_3,JOB_AUTH_4,JOB_AUTH_5,JOB_INDEX,JOB_NAME_S,JOB_NAME_T from job ");
			strSql.Append(" where JOB_CODE=@JOB_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@JOB_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = JOB_CODE;

			WongTung.Model.job model=new WongTung.Model.job();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.JOB_CO_CODE=ds.Tables[0].Rows[0]["JOB_CO_CODE"].ToString();
				model.JOB_CODE=ds.Tables[0].Rows[0]["JOB_CODE"].ToString();
				model.JOB_NAME=ds.Tables[0].Rows[0]["JOB_NAME"].ToString();
				if(ds.Tables[0].Rows[0]["JOB_CON"].ToString()!="")
				{
					model.JOB_CON=decimal.Parse(ds.Tables[0].Rows[0]["JOB_CON"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_OPEN_BAL_HOUR"].ToString()!="")
				{
					model.JOB_OPEN_BAL_HOUR=decimal.Parse(ds.Tables[0].Rows[0]["JOB_OPEN_BAL_HOUR"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_YTD_HOUR"].ToString()!="")
				{
					model.JOB_YTD_HOUR=decimal.Parse(ds.Tables[0].Rows[0]["JOB_YTD_HOUR"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_OPEN_BAL_AMT"].ToString()!="")
				{
					model.JOB_OPEN_BAL_AMT=decimal.Parse(ds.Tables[0].Rows[0]["JOB_OPEN_BAL_AMT"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_YTD_AMT"].ToString()!="")
				{
					model.JOB_YTD_AMT=decimal.Parse(ds.Tables[0].Rows[0]["JOB_YTD_AMT"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_REC"].ToString()!="")
				{
					model.JOB_REC=decimal.Parse(ds.Tables[0].Rows[0]["JOB_REC"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_OS_BAL"].ToString()!="")
				{
					model.JOB_OS_BAL=decimal.Parse(ds.Tables[0].Rows[0]["JOB_OS_BAL"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_BUD_HOUR"].ToString()!="")
				{
					model.JOB_BUD_HOUR=decimal.Parse(ds.Tables[0].Rows[0]["JOB_BUD_HOUR"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_CO_ORD"].ToString()!="")
				{
					model.JOB_CO_ORD=int.Parse(ds.Tables[0].Rows[0]["JOB_CO_ORD"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_ADMIN"].ToString()!="")
				{
					model.JOB_ADMIN=int.Parse(ds.Tables[0].Rows[0]["JOB_ADMIN"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_DESIGN"].ToString()!="")
				{
					model.JOB_DESIGN=int.Parse(ds.Tables[0].Rows[0]["JOB_DESIGN"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_LEV1"].ToString()!="")
				{
					model.JOB_LEV1=int.Parse(ds.Tables[0].Rows[0]["JOB_LEV1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_LEV2"].ToString()!="")
				{
					model.JOB_LEV2=int.Parse(ds.Tables[0].Rows[0]["JOB_LEV2"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_LEV3"].ToString()!="")
				{
					model.JOB_LEV3=int.Parse(ds.Tables[0].Rows[0]["JOB_LEV3"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_CHARGE_OUT"].ToString()!="")
				{
					model.JOB_CHARGE_OUT=int.Parse(ds.Tables[0].Rows[0]["JOB_CHARGE_OUT"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_DAILY"].ToString()!="")
				{
					model.JOB_DAILY=int.Parse(ds.Tables[0].Rows[0]["JOB_DAILY"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_MON"].ToString()!="")
				{
					model.JOB_MON=int.Parse(ds.Tables[0].Rows[0]["JOB_MON"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_PERIOD"].ToString()!="")
				{
					model.JOB_PERIOD=decimal.Parse(ds.Tables[0].Rows[0]["JOB_PERIOD"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_PERIOD_VAL"].ToString()!="")
				{
					model.JOB_PERIOD_VAL=decimal.Parse(ds.Tables[0].Rows[0]["JOB_PERIOD_VAL"].ToString());
				}
				model.JOB_AUTH=ds.Tables[0].Rows[0]["JOB_AUTH"].ToString();
				model.JOB_OFF_INCHG_AD=ds.Tables[0].Rows[0]["JOB_OFF_INCHG_AD"].ToString();
				model.JOB_OFF_INCHG_DES=ds.Tables[0].Rows[0]["JOB_OFF_INCHG_DES"].ToString();
				model.JOB_AUTH_1=ds.Tables[0].Rows[0]["JOB_AUTH_1"].ToString();
				model.JOB_AUTH_2=ds.Tables[0].Rows[0]["JOB_AUTH_2"].ToString();
				model.JOB_AUTH_3=ds.Tables[0].Rows[0]["JOB_AUTH_3"].ToString();
				model.JOB_AUTH_4=ds.Tables[0].Rows[0]["JOB_AUTH_4"].ToString();
				model.JOB_AUTH_5=ds.Tables[0].Rows[0]["JOB_AUTH_5"].ToString();
				if(ds.Tables[0].Rows[0]["JOB_INDEX"].ToString()!="")
				{
					model.JOB_INDEX=int.Parse(ds.Tables[0].Rows[0]["JOB_INDEX"].ToString());
				}
				model.JOB_NAME_S=ds.Tables[0].Rows[0]["JOB_NAME_S"].ToString();
				model.JOB_NAME_T=ds.Tables[0].Rows[0]["JOB_NAME_T"].ToString();
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
			strSql.Append("select JOB_CO_CODE,JOB_CODE,JOB_NAME,JOB_CON,JOB_OPEN_BAL_HOUR,JOB_YTD_HOUR,JOB_OPEN_BAL_AMT,JOB_YTD_AMT,JOB_REC,JOB_OS_BAL,JOB_BUD_HOUR,JOB_CO_ORD,JOB_ADMIN,JOB_DESIGN,JOB_LEV1,JOB_LEV2,JOB_LEV3,JOB_CHARGE_OUT,JOB_DAILY,JOB_MON,JOB_PERIOD,JOB_PERIOD_VAL,JOB_AUTH,JOB_OFF_INCHG_AD,JOB_OFF_INCHG_DES,JOB_AUTH_1,JOB_AUTH_2,JOB_AUTH_3,JOB_AUTH_4,JOB_AUTH_5,JOB_INDEX,JOB_NAME_S,JOB_NAME_T ");
			strSql.Append(" FROM job ");
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
			parameters[0].Value = "job";
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

