using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类ptl_job_tem。
	/// </summary>
	public class ptl_job_tem:Iptl_job_tem
	{
		public ptl_job_tem()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string TJ_CO_CODE,string TJ_EMP_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ptl_job_tem");
			strSql.Append(" where TJ_CO_CODE=@TJ_CO_CODE and TJ_EMP_CODE=@TJ_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@TJ_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@TJ_EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = TJ_CO_CODE;
			parameters[1].Value = TJ_EMP_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.ptl_job_tem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ptl_job_tem(");
			strSql.Append("TJ_CO_CODE,TJ_EMP_CODE,TJ_LAST_DATE,TJ_LAST_NUM,TJ_JOB_1,TJ_JOB_2,TJ_JOB_3,TJ_JOB_4,TJ_JOB_5,TJ_JOB_6,TJ_JOB_7,TJ_JOB_8,TJ_JOB_9,TJ_JOB_10,TJ_JOB_11,TJ_JOB_12,TJ_JOB_13,TJ_JOB_14,TJ_JOB_15,TJ_JOB_16,TJ_JOB_17,TJ_JOB_18,TJ_JOB_19,TJ_JOB_20)");
			strSql.Append(" values (");
			strSql.Append("@TJ_CO_CODE,@TJ_EMP_CODE,@TJ_LAST_DATE,@TJ_LAST_NUM,@TJ_JOB_1,@TJ_JOB_2,@TJ_JOB_3,@TJ_JOB_4,@TJ_JOB_5,@TJ_JOB_6,@TJ_JOB_7,@TJ_JOB_8,@TJ_JOB_9,@TJ_JOB_10,@TJ_JOB_11,@TJ_JOB_12,@TJ_JOB_13,@TJ_JOB_14,@TJ_JOB_15,@TJ_JOB_16,@TJ_JOB_17,@TJ_JOB_18,@TJ_JOB_19,@TJ_JOB_20)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@TJ_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@TJ_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_LAST_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@TJ_LAST_NUM", MySqlDbType.Decimal,2),
					new MySqlParameter("@TJ_JOB_1", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_2", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_3", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_4", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_5", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_6", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_7", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_8", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_9", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_10", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_11", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_12", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_13", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_14", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_15", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_16", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_17", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_18", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_19", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_20", MySqlDbType.Char,6)};
			parameters[0].Value = model.TJ_CO_CODE;
			parameters[1].Value = model.TJ_EMP_CODE;
			parameters[2].Value = model.TJ_LAST_DATE;
			parameters[3].Value = model.TJ_LAST_NUM;
			parameters[4].Value = model.TJ_JOB_1;
			parameters[5].Value = model.TJ_JOB_2;
			parameters[6].Value = model.TJ_JOB_3;
			parameters[7].Value = model.TJ_JOB_4;
			parameters[8].Value = model.TJ_JOB_5;
			parameters[9].Value = model.TJ_JOB_6;
			parameters[10].Value = model.TJ_JOB_7;
			parameters[11].Value = model.TJ_JOB_8;
			parameters[12].Value = model.TJ_JOB_9;
			parameters[13].Value = model.TJ_JOB_10;
			parameters[14].Value = model.TJ_JOB_11;
			parameters[15].Value = model.TJ_JOB_12;
			parameters[16].Value = model.TJ_JOB_13;
			parameters[17].Value = model.TJ_JOB_14;
			parameters[18].Value = model.TJ_JOB_15;
			parameters[19].Value = model.TJ_JOB_16;
			parameters[20].Value = model.TJ_JOB_17;
			parameters[21].Value = model.TJ_JOB_18;
			parameters[22].Value = model.TJ_JOB_19;
			parameters[23].Value = model.TJ_JOB_20;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.ptl_job_tem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ptl_job_tem set ");
			strSql.Append("TJ_LAST_DATE=@TJ_LAST_DATE,");
			strSql.Append("TJ_LAST_NUM=@TJ_LAST_NUM,");
			strSql.Append("TJ_JOB_1=@TJ_JOB_1,");
			strSql.Append("TJ_JOB_2=@TJ_JOB_2,");
			strSql.Append("TJ_JOB_3=@TJ_JOB_3,");
			strSql.Append("TJ_JOB_4=@TJ_JOB_4,");
			strSql.Append("TJ_JOB_5=@TJ_JOB_5,");
			strSql.Append("TJ_JOB_6=@TJ_JOB_6,");
			strSql.Append("TJ_JOB_7=@TJ_JOB_7,");
			strSql.Append("TJ_JOB_8=@TJ_JOB_8,");
			strSql.Append("TJ_JOB_9=@TJ_JOB_9,");
			strSql.Append("TJ_JOB_10=@TJ_JOB_10,");
			strSql.Append("TJ_JOB_11=@TJ_JOB_11,");
			strSql.Append("TJ_JOB_12=@TJ_JOB_12,");
			strSql.Append("TJ_JOB_13=@TJ_JOB_13,");
			strSql.Append("TJ_JOB_14=@TJ_JOB_14,");
			strSql.Append("TJ_JOB_15=@TJ_JOB_15,");
			strSql.Append("TJ_JOB_16=@TJ_JOB_16,");
			strSql.Append("TJ_JOB_17=@TJ_JOB_17,");
			strSql.Append("TJ_JOB_18=@TJ_JOB_18,");
			strSql.Append("TJ_JOB_19=@TJ_JOB_19,");
			strSql.Append("TJ_JOB_20=@TJ_JOB_20");
			strSql.Append(" where TJ_CO_CODE=@TJ_CO_CODE and TJ_EMP_CODE=@TJ_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@TJ_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@TJ_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_LAST_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@TJ_LAST_NUM", MySqlDbType.Decimal,2),
					new MySqlParameter("@TJ_JOB_1", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_2", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_3", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_4", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_5", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_6", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_7", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_8", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_9", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_10", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_11", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_12", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_13", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_14", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_15", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_16", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_17", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_18", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_19", MySqlDbType.Char,6),
					new MySqlParameter("@TJ_JOB_20", MySqlDbType.Char,6)};
			parameters[0].Value = model.TJ_CO_CODE;
			parameters[1].Value = model.TJ_EMP_CODE;
			parameters[2].Value = model.TJ_LAST_DATE;
			parameters[3].Value = model.TJ_LAST_NUM;
			parameters[4].Value = model.TJ_JOB_1;
			parameters[5].Value = model.TJ_JOB_2;
			parameters[6].Value = model.TJ_JOB_3;
			parameters[7].Value = model.TJ_JOB_4;
			parameters[8].Value = model.TJ_JOB_5;
			parameters[9].Value = model.TJ_JOB_6;
			parameters[10].Value = model.TJ_JOB_7;
			parameters[11].Value = model.TJ_JOB_8;
			parameters[12].Value = model.TJ_JOB_9;
			parameters[13].Value = model.TJ_JOB_10;
			parameters[14].Value = model.TJ_JOB_11;
			parameters[15].Value = model.TJ_JOB_12;
			parameters[16].Value = model.TJ_JOB_13;
			parameters[17].Value = model.TJ_JOB_14;
			parameters[18].Value = model.TJ_JOB_15;
			parameters[19].Value = model.TJ_JOB_16;
			parameters[20].Value = model.TJ_JOB_17;
			parameters[21].Value = model.TJ_JOB_18;
			parameters[22].Value = model.TJ_JOB_19;
			parameters[23].Value = model.TJ_JOB_20;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string TJ_CO_CODE,string TJ_EMP_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete ptl_job_tem ");
			strSql.Append(" where TJ_CO_CODE=@TJ_CO_CODE and TJ_EMP_CODE=@TJ_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@TJ_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@TJ_EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = TJ_CO_CODE;
			parameters[1].Value = TJ_EMP_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.ptl_job_tem GetModel(string TJ_CO_CODE,string TJ_EMP_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TJ_CO_CODE,TJ_EMP_CODE,TJ_LAST_DATE,TJ_LAST_NUM,TJ_JOB_1,TJ_JOB_2,TJ_JOB_3,TJ_JOB_4,TJ_JOB_5,TJ_JOB_6,TJ_JOB_7,TJ_JOB_8,TJ_JOB_9,TJ_JOB_10,TJ_JOB_11,TJ_JOB_12,TJ_JOB_13,TJ_JOB_14,TJ_JOB_15,TJ_JOB_16,TJ_JOB_17,TJ_JOB_18,TJ_JOB_19,TJ_JOB_20 from ptl_job_tem ");
			strSql.Append(" where TJ_CO_CODE=@TJ_CO_CODE and TJ_EMP_CODE=@TJ_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@TJ_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@TJ_EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = TJ_CO_CODE;
			parameters[1].Value = TJ_EMP_CODE;

			WongTung.Model.ptl_job_tem model=new WongTung.Model.ptl_job_tem();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.TJ_CO_CODE=ds.Tables[0].Rows[0]["TJ_CO_CODE"].ToString();
				model.TJ_EMP_CODE=ds.Tables[0].Rows[0]["TJ_EMP_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["TJ_LAST_DATE"].ToString()!="")
				{
					model.TJ_LAST_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["TJ_LAST_DATE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TJ_LAST_NUM"].ToString()!="")
				{
					model.TJ_LAST_NUM=decimal.Parse(ds.Tables[0].Rows[0]["TJ_LAST_NUM"].ToString());
				}
				model.TJ_JOB_1=ds.Tables[0].Rows[0]["TJ_JOB_1"].ToString();
				model.TJ_JOB_2=ds.Tables[0].Rows[0]["TJ_JOB_2"].ToString();
				model.TJ_JOB_3=ds.Tables[0].Rows[0]["TJ_JOB_3"].ToString();
				model.TJ_JOB_4=ds.Tables[0].Rows[0]["TJ_JOB_4"].ToString();
				model.TJ_JOB_5=ds.Tables[0].Rows[0]["TJ_JOB_5"].ToString();
				model.TJ_JOB_6=ds.Tables[0].Rows[0]["TJ_JOB_6"].ToString();
				model.TJ_JOB_7=ds.Tables[0].Rows[0]["TJ_JOB_7"].ToString();
				model.TJ_JOB_8=ds.Tables[0].Rows[0]["TJ_JOB_8"].ToString();
				model.TJ_JOB_9=ds.Tables[0].Rows[0]["TJ_JOB_9"].ToString();
				model.TJ_JOB_10=ds.Tables[0].Rows[0]["TJ_JOB_10"].ToString();
				model.TJ_JOB_11=ds.Tables[0].Rows[0]["TJ_JOB_11"].ToString();
				model.TJ_JOB_12=ds.Tables[0].Rows[0]["TJ_JOB_12"].ToString();
				model.TJ_JOB_13=ds.Tables[0].Rows[0]["TJ_JOB_13"].ToString();
				model.TJ_JOB_14=ds.Tables[0].Rows[0]["TJ_JOB_14"].ToString();
				model.TJ_JOB_15=ds.Tables[0].Rows[0]["TJ_JOB_15"].ToString();
				model.TJ_JOB_16=ds.Tables[0].Rows[0]["TJ_JOB_16"].ToString();
				model.TJ_JOB_17=ds.Tables[0].Rows[0]["TJ_JOB_17"].ToString();
				model.TJ_JOB_18=ds.Tables[0].Rows[0]["TJ_JOB_18"].ToString();
				model.TJ_JOB_19=ds.Tables[0].Rows[0]["TJ_JOB_19"].ToString();
				model.TJ_JOB_20=ds.Tables[0].Rows[0]["TJ_JOB_20"].ToString();
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
			strSql.Append("select TJ_CO_CODE,TJ_EMP_CODE,TJ_LAST_DATE,TJ_LAST_NUM,TJ_JOB_1,TJ_JOB_2,TJ_JOB_3,TJ_JOB_4,TJ_JOB_5,TJ_JOB_6,TJ_JOB_7,TJ_JOB_8,TJ_JOB_9,TJ_JOB_10,TJ_JOB_11,TJ_JOB_12,TJ_JOB_13,TJ_JOB_14,TJ_JOB_15,TJ_JOB_16,TJ_JOB_17,TJ_JOB_18,TJ_JOB_19,TJ_JOB_20 ");
			strSql.Append(" FROM ptl_job_tem ");
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
			parameters[0].Value = "ptl_job_tem";
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

