using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类pat_job_tem。
	/// </summary>
	public class pat_job_tem:Ipat_job_tem
	{
		public pat_job_tem()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string AJ_CO_CODE,string AJ_EMP_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from pat_job_tem");
			strSql.Append(" where AJ_CO_CODE=@AJ_CO_CODE and AJ_EMP_CODE=@AJ_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@AJ_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@AJ_EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = AJ_CO_CODE;
			parameters[1].Value = AJ_EMP_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.pat_job_tem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into pat_job_tem(");
			strSql.Append("AJ_CO_CODE,AJ_EMP_CODE,AJ_LAST_DATE,AJ_LAST_NUM,AJ_JOB_1,AJ_JOB_2,AJ_JOB_3,AJ_JOB_4,AJ_JOB_5,AJ_JOB_6,AJ_JOB_7,AJ_JOB_8,AJ_JOB_9,AJ_JOB_10,AJ_JOB_11,AJ_JOB_12,AJ_JOB_13,AJ_JOB_14,AJ_JOB_15,AJ_JOB_16,AJ_JOB_17,AJ_JOB_18,AJ_JOB_19,AJ_JOB_20)");
			strSql.Append(" values (");
			strSql.Append("@AJ_CO_CODE,@AJ_EMP_CODE,@AJ_LAST_DATE,@AJ_LAST_NUM,@AJ_JOB_1,@AJ_JOB_2,@AJ_JOB_3,@AJ_JOB_4,@AJ_JOB_5,@AJ_JOB_6,@AJ_JOB_7,@AJ_JOB_8,@AJ_JOB_9,@AJ_JOB_10,@AJ_JOB_11,@AJ_JOB_12,@AJ_JOB_13,@AJ_JOB_14,@AJ_JOB_15,@AJ_JOB_16,@AJ_JOB_17,@AJ_JOB_18,@AJ_JOB_19,@AJ_JOB_20)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@AJ_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@AJ_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_LAST_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@AJ_LAST_NUM", MySqlDbType.Decimal,2),
					new MySqlParameter("@AJ_JOB_1", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_2", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_3", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_4", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_5", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_6", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_7", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_8", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_9", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_10", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_11", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_12", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_13", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_14", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_15", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_16", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_17", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_18", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_19", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_20", MySqlDbType.Char,6)};
			parameters[0].Value = model.AJ_CO_CODE;
			parameters[1].Value = model.AJ_EMP_CODE;
			parameters[2].Value = model.AJ_LAST_DATE;
			parameters[3].Value = model.AJ_LAST_NUM;
			parameters[4].Value = model.AJ_JOB_1;
			parameters[5].Value = model.AJ_JOB_2;
			parameters[6].Value = model.AJ_JOB_3;
			parameters[7].Value = model.AJ_JOB_4;
			parameters[8].Value = model.AJ_JOB_5;
			parameters[9].Value = model.AJ_JOB_6;
			parameters[10].Value = model.AJ_JOB_7;
			parameters[11].Value = model.AJ_JOB_8;
			parameters[12].Value = model.AJ_JOB_9;
			parameters[13].Value = model.AJ_JOB_10;
			parameters[14].Value = model.AJ_JOB_11;
			parameters[15].Value = model.AJ_JOB_12;
			parameters[16].Value = model.AJ_JOB_13;
			parameters[17].Value = model.AJ_JOB_14;
			parameters[18].Value = model.AJ_JOB_15;
			parameters[19].Value = model.AJ_JOB_16;
			parameters[20].Value = model.AJ_JOB_17;
			parameters[21].Value = model.AJ_JOB_18;
			parameters[22].Value = model.AJ_JOB_19;
			parameters[23].Value = model.AJ_JOB_20;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.pat_job_tem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update pat_job_tem set ");
			strSql.Append("AJ_LAST_DATE=@AJ_LAST_DATE,");
			strSql.Append("AJ_LAST_NUM=@AJ_LAST_NUM,");
			strSql.Append("AJ_JOB_1=@AJ_JOB_1,");
			strSql.Append("AJ_JOB_2=@AJ_JOB_2,");
			strSql.Append("AJ_JOB_3=@AJ_JOB_3,");
			strSql.Append("AJ_JOB_4=@AJ_JOB_4,");
			strSql.Append("AJ_JOB_5=@AJ_JOB_5,");
			strSql.Append("AJ_JOB_6=@AJ_JOB_6,");
			strSql.Append("AJ_JOB_7=@AJ_JOB_7,");
			strSql.Append("AJ_JOB_8=@AJ_JOB_8,");
			strSql.Append("AJ_JOB_9=@AJ_JOB_9,");
			strSql.Append("AJ_JOB_10=@AJ_JOB_10,");
			strSql.Append("AJ_JOB_11=@AJ_JOB_11,");
			strSql.Append("AJ_JOB_12=@AJ_JOB_12,");
			strSql.Append("AJ_JOB_13=@AJ_JOB_13,");
			strSql.Append("AJ_JOB_14=@AJ_JOB_14,");
			strSql.Append("AJ_JOB_15=@AJ_JOB_15,");
			strSql.Append("AJ_JOB_16=@AJ_JOB_16,");
			strSql.Append("AJ_JOB_17=@AJ_JOB_17,");
			strSql.Append("AJ_JOB_18=@AJ_JOB_18,");
			strSql.Append("AJ_JOB_19=@AJ_JOB_19,");
			strSql.Append("AJ_JOB_20=@AJ_JOB_20");
			strSql.Append(" where AJ_CO_CODE=@AJ_CO_CODE and AJ_EMP_CODE=@AJ_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@AJ_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@AJ_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_LAST_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@AJ_LAST_NUM", MySqlDbType.Decimal,2),
					new MySqlParameter("@AJ_JOB_1", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_2", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_3", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_4", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_5", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_6", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_7", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_8", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_9", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_10", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_11", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_12", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_13", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_14", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_15", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_16", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_17", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_18", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_19", MySqlDbType.Char,6),
					new MySqlParameter("@AJ_JOB_20", MySqlDbType.Char,6)};
			parameters[0].Value = model.AJ_CO_CODE;
			parameters[1].Value = model.AJ_EMP_CODE;
			parameters[2].Value = model.AJ_LAST_DATE;
			parameters[3].Value = model.AJ_LAST_NUM;
			parameters[4].Value = model.AJ_JOB_1;
			parameters[5].Value = model.AJ_JOB_2;
			parameters[6].Value = model.AJ_JOB_3;
			parameters[7].Value = model.AJ_JOB_4;
			parameters[8].Value = model.AJ_JOB_5;
			parameters[9].Value = model.AJ_JOB_6;
			parameters[10].Value = model.AJ_JOB_7;
			parameters[11].Value = model.AJ_JOB_8;
			parameters[12].Value = model.AJ_JOB_9;
			parameters[13].Value = model.AJ_JOB_10;
			parameters[14].Value = model.AJ_JOB_11;
			parameters[15].Value = model.AJ_JOB_12;
			parameters[16].Value = model.AJ_JOB_13;
			parameters[17].Value = model.AJ_JOB_14;
			parameters[18].Value = model.AJ_JOB_15;
			parameters[19].Value = model.AJ_JOB_16;
			parameters[20].Value = model.AJ_JOB_17;
			parameters[21].Value = model.AJ_JOB_18;
			parameters[22].Value = model.AJ_JOB_19;
			parameters[23].Value = model.AJ_JOB_20;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string AJ_CO_CODE,string AJ_EMP_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete pat_job_tem ");
			strSql.Append(" where AJ_CO_CODE=@AJ_CO_CODE and AJ_EMP_CODE=@AJ_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@AJ_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@AJ_EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = AJ_CO_CODE;
			parameters[1].Value = AJ_EMP_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.pat_job_tem GetModel(string AJ_CO_CODE,string AJ_EMP_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AJ_CO_CODE,AJ_EMP_CODE,AJ_LAST_DATE,AJ_LAST_NUM,AJ_JOB_1,AJ_JOB_2,AJ_JOB_3,AJ_JOB_4,AJ_JOB_5,AJ_JOB_6,AJ_JOB_7,AJ_JOB_8,AJ_JOB_9,AJ_JOB_10,AJ_JOB_11,AJ_JOB_12,AJ_JOB_13,AJ_JOB_14,AJ_JOB_15,AJ_JOB_16,AJ_JOB_17,AJ_JOB_18,AJ_JOB_19,AJ_JOB_20 from pat_job_tem ");
			strSql.Append(" where AJ_CO_CODE=@AJ_CO_CODE and AJ_EMP_CODE=@AJ_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@AJ_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@AJ_EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = AJ_CO_CODE;
			parameters[1].Value = AJ_EMP_CODE;

			WongTung.Model.pat_job_tem model=new WongTung.Model.pat_job_tem();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.AJ_CO_CODE=ds.Tables[0].Rows[0]["AJ_CO_CODE"].ToString();
				model.AJ_EMP_CODE=ds.Tables[0].Rows[0]["AJ_EMP_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["AJ_LAST_DATE"].ToString()!="")
				{
					model.AJ_LAST_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["AJ_LAST_DATE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AJ_LAST_NUM"].ToString()!="")
				{
					model.AJ_LAST_NUM=decimal.Parse(ds.Tables[0].Rows[0]["AJ_LAST_NUM"].ToString());
				}
				model.AJ_JOB_1=ds.Tables[0].Rows[0]["AJ_JOB_1"].ToString();
				model.AJ_JOB_2=ds.Tables[0].Rows[0]["AJ_JOB_2"].ToString();
				model.AJ_JOB_3=ds.Tables[0].Rows[0]["AJ_JOB_3"].ToString();
				model.AJ_JOB_4=ds.Tables[0].Rows[0]["AJ_JOB_4"].ToString();
				model.AJ_JOB_5=ds.Tables[0].Rows[0]["AJ_JOB_5"].ToString();
				model.AJ_JOB_6=ds.Tables[0].Rows[0]["AJ_JOB_6"].ToString();
				model.AJ_JOB_7=ds.Tables[0].Rows[0]["AJ_JOB_7"].ToString();
				model.AJ_JOB_8=ds.Tables[0].Rows[0]["AJ_JOB_8"].ToString();
				model.AJ_JOB_9=ds.Tables[0].Rows[0]["AJ_JOB_9"].ToString();
				model.AJ_JOB_10=ds.Tables[0].Rows[0]["AJ_JOB_10"].ToString();
				model.AJ_JOB_11=ds.Tables[0].Rows[0]["AJ_JOB_11"].ToString();
				model.AJ_JOB_12=ds.Tables[0].Rows[0]["AJ_JOB_12"].ToString();
				model.AJ_JOB_13=ds.Tables[0].Rows[0]["AJ_JOB_13"].ToString();
				model.AJ_JOB_14=ds.Tables[0].Rows[0]["AJ_JOB_14"].ToString();
				model.AJ_JOB_15=ds.Tables[0].Rows[0]["AJ_JOB_15"].ToString();
				model.AJ_JOB_16=ds.Tables[0].Rows[0]["AJ_JOB_16"].ToString();
				model.AJ_JOB_17=ds.Tables[0].Rows[0]["AJ_JOB_17"].ToString();
				model.AJ_JOB_18=ds.Tables[0].Rows[0]["AJ_JOB_18"].ToString();
				model.AJ_JOB_19=ds.Tables[0].Rows[0]["AJ_JOB_19"].ToString();
				model.AJ_JOB_20=ds.Tables[0].Rows[0]["AJ_JOB_20"].ToString();
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
			strSql.Append("select AJ_CO_CODE,AJ_EMP_CODE,AJ_LAST_DATE,AJ_LAST_NUM,AJ_JOB_1,AJ_JOB_2,AJ_JOB_3,AJ_JOB_4,AJ_JOB_5,AJ_JOB_6,AJ_JOB_7,AJ_JOB_8,AJ_JOB_9,AJ_JOB_10,AJ_JOB_11,AJ_JOB_12,AJ_JOB_13,AJ_JOB_14,AJ_JOB_15,AJ_JOB_16,AJ_JOB_17,AJ_JOB_18,AJ_JOB_19,AJ_JOB_20 ");
			strSql.Append(" FROM pat_job_tem ");
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
			parameters[0].Value = "pat_job_tem";
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

