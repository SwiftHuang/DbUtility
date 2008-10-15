using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类budgetot。
	/// </summary>
	public class budgetot:Ibudgetot
	{
		public budgetot()
		{}
		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.budgetot model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into budgetot(");
			strSql.Append("BG_CO_CODE,BG_JOB_CODE,BG_SER_CODE,BG_POS,BG_HOUR,BG_EXP_BUDGET)");
			strSql.Append(" values (");
			strSql.Append("@BG_CO_CODE,@BG_JOB_CODE,@BG_SER_CODE,@BG_POS,@BG_HOUR,@BG_EXP_BUDGET)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@BG_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@BG_JOB_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@BG_SER_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@BG_POS", MySqlDbType.Char,3),
					new MySqlParameter("@BG_HOUR", MySqlDbType.Decimal,18),
					new MySqlParameter("@BG_EXP_BUDGET", MySqlDbType.Decimal,18)};
			parameters[0].Value = model.BG_CO_CODE;
			parameters[1].Value = model.BG_JOB_CODE;
			parameters[2].Value = model.BG_SER_CODE;
			parameters[3].Value = model.BG_POS;
			parameters[4].Value = model.BG_HOUR;
			parameters[5].Value = model.BG_EXP_BUDGET;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.budgetot model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update budgetot set ");
			strSql.Append("BG_CO_CODE=@BG_CO_CODE,");
			strSql.Append("BG_JOB_CODE=@BG_JOB_CODE,");
			strSql.Append("BG_SER_CODE=@BG_SER_CODE,");
			strSql.Append("BG_POS=@BG_POS,");
			strSql.Append("BG_HOUR=@BG_HOUR,");
			strSql.Append("BG_EXP_BUDGET=@BG_EXP_BUDGET");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@BG_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@BG_JOB_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@BG_SER_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@BG_POS", MySqlDbType.Char,3),
					new MySqlParameter("@BG_HOUR", MySqlDbType.Decimal,18),
					new MySqlParameter("@BG_EXP_BUDGET", MySqlDbType.Decimal,18)};
			parameters[0].Value = model.BG_CO_CODE;
			parameters[1].Value = model.BG_JOB_CODE;
			parameters[2].Value = model.BG_SER_CODE;
			parameters[3].Value = model.BG_POS;
			parameters[4].Value = model.BG_HOUR;
			parameters[5].Value = model.BG_EXP_BUDGET;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete budgetot ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.budgetot GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select BG_CO_CODE,BG_JOB_CODE,BG_SER_CODE,BG_POS,BG_HOUR,BG_EXP_BUDGET from budgetot ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			WongTung.Model.budgetot model=new WongTung.Model.budgetot();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.BG_CO_CODE=ds.Tables[0].Rows[0]["BG_CO_CODE"].ToString();
				model.BG_JOB_CODE=ds.Tables[0].Rows[0]["BG_JOB_CODE"].ToString();
				model.BG_SER_CODE=ds.Tables[0].Rows[0]["BG_SER_CODE"].ToString();
				model.BG_POS=ds.Tables[0].Rows[0]["BG_POS"].ToString();
				if(ds.Tables[0].Rows[0]["BG_HOUR"].ToString()!="")
				{
					model.BG_HOUR=decimal.Parse(ds.Tables[0].Rows[0]["BG_HOUR"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BG_EXP_BUDGET"].ToString()!="")
				{
					model.BG_EXP_BUDGET=decimal.Parse(ds.Tables[0].Rows[0]["BG_EXP_BUDGET"].ToString());
				}
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
			strSql.Append("select BG_CO_CODE,BG_JOB_CODE,BG_SER_CODE,BG_POS,BG_HOUR,BG_EXP_BUDGET ");
			strSql.Append(" FROM budgetot ");
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
			parameters[0].Value = "budgetot";
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

