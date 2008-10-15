using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类emp_job_tem。
	/// </summary>
	public class emp_job_tem:Iemp_job_tem
	{
		public emp_job_tem()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string EJ_CO_CODE,string EJ_EMP_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from emp_job_tem");
			strSql.Append(" where EJ_CO_CODE=@EJ_CO_CODE and EJ_EMP_CODE=@EJ_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@EJ_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@EJ_EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = EJ_CO_CODE;
			parameters[1].Value = EJ_EMP_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.emp_job_tem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into emp_job_tem(");
			strSql.Append("EJ_CO_CODE,EJ_EMP_CODE,EJ_LAST_DATE,EJ_LAST_NUM,EJ_JOB_1,EJ_JOB_2,EJ_JOB_3,EJ_JOB_4,EJ_JOB_5,EJ_JOB_6,EJ_JOB_7,EJ_JOB_8,EJ_JOB_9,EJ_JOB_10,EJ_JOB_11,EJ_JOB_12,EJ_JOB_13,EJ_JOB_14,EJ_JOB_15,EJ_JOB_16,EJ_JOB_17,EJ_JOB_18,EJ_JOB_19,EJ_JOB_20)");
			strSql.Append(" values (");
			strSql.Append("@EJ_CO_CODE,@EJ_EMP_CODE,@EJ_LAST_DATE,@EJ_LAST_NUM,@EJ_JOB_1,@EJ_JOB_2,@EJ_JOB_3,@EJ_JOB_4,@EJ_JOB_5,@EJ_JOB_6,@EJ_JOB_7,@EJ_JOB_8,@EJ_JOB_9,@EJ_JOB_10,@EJ_JOB_11,@EJ_JOB_12,@EJ_JOB_13,@EJ_JOB_14,@EJ_JOB_15,@EJ_JOB_16,@EJ_JOB_17,@EJ_JOB_18,@EJ_JOB_19,@EJ_JOB_20)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@EJ_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@EJ_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_LAST_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@EJ_LAST_NUM", MySqlDbType.Decimal,2),
					new MySqlParameter("@EJ_JOB_1", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_2", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_3", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_4", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_5", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_6", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_7", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_8", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_9", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_10", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_11", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_12", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_13", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_14", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_15", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_16", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_17", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_18", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_19", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_20", MySqlDbType.Char,6)};
			parameters[0].Value = model.EJ_CO_CODE;
			parameters[1].Value = model.EJ_EMP_CODE;
			parameters[2].Value = model.EJ_LAST_DATE;
			parameters[3].Value = model.EJ_LAST_NUM;
			parameters[4].Value = model.EJ_JOB_1;
			parameters[5].Value = model.EJ_JOB_2;
			parameters[6].Value = model.EJ_JOB_3;
			parameters[7].Value = model.EJ_JOB_4;
			parameters[8].Value = model.EJ_JOB_5;
			parameters[9].Value = model.EJ_JOB_6;
			parameters[10].Value = model.EJ_JOB_7;
			parameters[11].Value = model.EJ_JOB_8;
			parameters[12].Value = model.EJ_JOB_9;
			parameters[13].Value = model.EJ_JOB_10;
			parameters[14].Value = model.EJ_JOB_11;
			parameters[15].Value = model.EJ_JOB_12;
			parameters[16].Value = model.EJ_JOB_13;
			parameters[17].Value = model.EJ_JOB_14;
			parameters[18].Value = model.EJ_JOB_15;
			parameters[19].Value = model.EJ_JOB_16;
			parameters[20].Value = model.EJ_JOB_17;
			parameters[21].Value = model.EJ_JOB_18;
			parameters[22].Value = model.EJ_JOB_19;
			parameters[23].Value = model.EJ_JOB_20;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.emp_job_tem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update emp_job_tem set ");
			strSql.Append("EJ_LAST_DATE=@EJ_LAST_DATE,");
			strSql.Append("EJ_LAST_NUM=@EJ_LAST_NUM,");
			strSql.Append("EJ_JOB_1=@EJ_JOB_1,");
			strSql.Append("EJ_JOB_2=@EJ_JOB_2,");
			strSql.Append("EJ_JOB_3=@EJ_JOB_3,");
			strSql.Append("EJ_JOB_4=@EJ_JOB_4,");
			strSql.Append("EJ_JOB_5=@EJ_JOB_5,");
			strSql.Append("EJ_JOB_6=@EJ_JOB_6,");
			strSql.Append("EJ_JOB_7=@EJ_JOB_7,");
			strSql.Append("EJ_JOB_8=@EJ_JOB_8,");
			strSql.Append("EJ_JOB_9=@EJ_JOB_9,");
			strSql.Append("EJ_JOB_10=@EJ_JOB_10,");
			strSql.Append("EJ_JOB_11=@EJ_JOB_11,");
			strSql.Append("EJ_JOB_12=@EJ_JOB_12,");
			strSql.Append("EJ_JOB_13=@EJ_JOB_13,");
			strSql.Append("EJ_JOB_14=@EJ_JOB_14,");
			strSql.Append("EJ_JOB_15=@EJ_JOB_15,");
			strSql.Append("EJ_JOB_16=@EJ_JOB_16,");
			strSql.Append("EJ_JOB_17=@EJ_JOB_17,");
			strSql.Append("EJ_JOB_18=@EJ_JOB_18,");
			strSql.Append("EJ_JOB_19=@EJ_JOB_19,");
			strSql.Append("EJ_JOB_20=@EJ_JOB_20");
			strSql.Append(" where EJ_CO_CODE=@EJ_CO_CODE and EJ_EMP_CODE=@EJ_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@EJ_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@EJ_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_LAST_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@EJ_LAST_NUM", MySqlDbType.Decimal,2),
					new MySqlParameter("@EJ_JOB_1", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_2", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_3", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_4", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_5", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_6", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_7", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_8", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_9", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_10", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_11", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_12", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_13", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_14", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_15", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_16", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_17", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_18", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_19", MySqlDbType.Char,6),
					new MySqlParameter("@EJ_JOB_20", MySqlDbType.Char,6)};
			parameters[0].Value = model.EJ_CO_CODE;
			parameters[1].Value = model.EJ_EMP_CODE;
			parameters[2].Value = model.EJ_LAST_DATE;
			parameters[3].Value = model.EJ_LAST_NUM;
			parameters[4].Value = model.EJ_JOB_1;
			parameters[5].Value = model.EJ_JOB_2;
			parameters[6].Value = model.EJ_JOB_3;
			parameters[7].Value = model.EJ_JOB_4;
			parameters[8].Value = model.EJ_JOB_5;
			parameters[9].Value = model.EJ_JOB_6;
			parameters[10].Value = model.EJ_JOB_7;
			parameters[11].Value = model.EJ_JOB_8;
			parameters[12].Value = model.EJ_JOB_9;
			parameters[13].Value = model.EJ_JOB_10;
			parameters[14].Value = model.EJ_JOB_11;
			parameters[15].Value = model.EJ_JOB_12;
			parameters[16].Value = model.EJ_JOB_13;
			parameters[17].Value = model.EJ_JOB_14;
			parameters[18].Value = model.EJ_JOB_15;
			parameters[19].Value = model.EJ_JOB_16;
			parameters[20].Value = model.EJ_JOB_17;
			parameters[21].Value = model.EJ_JOB_18;
			parameters[22].Value = model.EJ_JOB_19;
			parameters[23].Value = model.EJ_JOB_20;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string EJ_CO_CODE,string EJ_EMP_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete emp_job_tem ");
			strSql.Append(" where EJ_CO_CODE=@EJ_CO_CODE and EJ_EMP_CODE=@EJ_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@EJ_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@EJ_EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = EJ_CO_CODE;
			parameters[1].Value = EJ_EMP_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.emp_job_tem GetModel(string EJ_CO_CODE,string EJ_EMP_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select EJ_CO_CODE,EJ_EMP_CODE,EJ_LAST_DATE,EJ_LAST_NUM,EJ_JOB_1,EJ_JOB_2,EJ_JOB_3,EJ_JOB_4,EJ_JOB_5,EJ_JOB_6,EJ_JOB_7,EJ_JOB_8,EJ_JOB_9,EJ_JOB_10,EJ_JOB_11,EJ_JOB_12,EJ_JOB_13,EJ_JOB_14,EJ_JOB_15,EJ_JOB_16,EJ_JOB_17,EJ_JOB_18,EJ_JOB_19,EJ_JOB_20 from emp_job_tem ");
			strSql.Append(" where EJ_CO_CODE=@EJ_CO_CODE and EJ_EMP_CODE=@EJ_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@EJ_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@EJ_EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = EJ_CO_CODE;
			parameters[1].Value = EJ_EMP_CODE;

			WongTung.Model.emp_job_tem model=new WongTung.Model.emp_job_tem();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.EJ_CO_CODE=ds.Tables[0].Rows[0]["EJ_CO_CODE"].ToString();
				model.EJ_EMP_CODE=ds.Tables[0].Rows[0]["EJ_EMP_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["EJ_LAST_DATE"].ToString()!="")
				{
					model.EJ_LAST_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["EJ_LAST_DATE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EJ_LAST_NUM"].ToString()!="")
				{
					model.EJ_LAST_NUM=decimal.Parse(ds.Tables[0].Rows[0]["EJ_LAST_NUM"].ToString());
				}
				model.EJ_JOB_1=ds.Tables[0].Rows[0]["EJ_JOB_1"].ToString();
				model.EJ_JOB_2=ds.Tables[0].Rows[0]["EJ_JOB_2"].ToString();
				model.EJ_JOB_3=ds.Tables[0].Rows[0]["EJ_JOB_3"].ToString();
				model.EJ_JOB_4=ds.Tables[0].Rows[0]["EJ_JOB_4"].ToString();
				model.EJ_JOB_5=ds.Tables[0].Rows[0]["EJ_JOB_5"].ToString();
				model.EJ_JOB_6=ds.Tables[0].Rows[0]["EJ_JOB_6"].ToString();
				model.EJ_JOB_7=ds.Tables[0].Rows[0]["EJ_JOB_7"].ToString();
				model.EJ_JOB_8=ds.Tables[0].Rows[0]["EJ_JOB_8"].ToString();
				model.EJ_JOB_9=ds.Tables[0].Rows[0]["EJ_JOB_9"].ToString();
				model.EJ_JOB_10=ds.Tables[0].Rows[0]["EJ_JOB_10"].ToString();
				model.EJ_JOB_11=ds.Tables[0].Rows[0]["EJ_JOB_11"].ToString();
				model.EJ_JOB_12=ds.Tables[0].Rows[0]["EJ_JOB_12"].ToString();
				model.EJ_JOB_13=ds.Tables[0].Rows[0]["EJ_JOB_13"].ToString();
				model.EJ_JOB_14=ds.Tables[0].Rows[0]["EJ_JOB_14"].ToString();
				model.EJ_JOB_15=ds.Tables[0].Rows[0]["EJ_JOB_15"].ToString();
				model.EJ_JOB_16=ds.Tables[0].Rows[0]["EJ_JOB_16"].ToString();
				model.EJ_JOB_17=ds.Tables[0].Rows[0]["EJ_JOB_17"].ToString();
				model.EJ_JOB_18=ds.Tables[0].Rows[0]["EJ_JOB_18"].ToString();
				model.EJ_JOB_19=ds.Tables[0].Rows[0]["EJ_JOB_19"].ToString();
				model.EJ_JOB_20=ds.Tables[0].Rows[0]["EJ_JOB_20"].ToString();
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
			strSql.Append("select EJ_CO_CODE,EJ_EMP_CODE,EJ_LAST_DATE,EJ_LAST_NUM,EJ_JOB_1,EJ_JOB_2,EJ_JOB_3,EJ_JOB_4,EJ_JOB_5,EJ_JOB_6,EJ_JOB_7,EJ_JOB_8,EJ_JOB_9,EJ_JOB_10,EJ_JOB_11,EJ_JOB_12,EJ_JOB_13,EJ_JOB_14,EJ_JOB_15,EJ_JOB_16,EJ_JOB_17,EJ_JOB_18,EJ_JOB_19,EJ_JOB_20 ");
			strSql.Append(" FROM emp_job_tem ");
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
			parameters[0].Value = "emp_job_tem";
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

