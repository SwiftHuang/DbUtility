using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类bk_jobbud。
	/// </summary>
	public class bk_jobbud:Ibk_jobbud
	{
		public bk_jobbud()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string JOB_CO_CODE,string JOB_CODE,string JOB_SER,string JOB_STAFF)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from bk_jobbud");
			strSql.Append(" where JOB_CO_CODE=@JOB_CO_CODE and JOB_CODE=@JOB_CODE and JOB_SER=@JOB_SER and JOB_STAFF=@JOB_STAFF ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@JOB_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@JOB_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@JOB_SER", MySqlDbType.Char,50),
					new MySqlParameter("@JOB_STAFF", MySqlDbType.Char,50)};
			parameters[0].Value = JOB_CO_CODE;
			parameters[1].Value = JOB_CODE;
			parameters[2].Value = JOB_SER;
			parameters[3].Value = JOB_STAFF;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.bk_jobbud model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into bk_jobbud(");
			strSql.Append("JOB_CO_CODE,JOB_CODE,JOB_SER,JOB_POS,JOB_STAFF,JOB_BUD,JOB_NOR,JOB_NOR_EXP,JOB_OT,JOB_OT_EXP)");
			strSql.Append(" values (");
			strSql.Append("@JOB_CO_CODE,@JOB_CODE,@JOB_SER,@JOB_POS,@JOB_STAFF,@JOB_BUD,@JOB_NOR,@JOB_NOR_EXP,@JOB_OT,@JOB_OT_EXP)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@JOB_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@JOB_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_SER", MySqlDbType.Char,3),
					new MySqlParameter("@JOB_POS", MySqlDbType.Char,3),
					new MySqlParameter("@JOB_STAFF", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_BUD", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_NOR", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_NOR_EXP", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_OT", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_OT_EXP", MySqlDbType.Decimal,18)};
			parameters[0].Value = model.JOB_CO_CODE;
			parameters[1].Value = model.JOB_CODE;
			parameters[2].Value = model.JOB_SER;
			parameters[3].Value = model.JOB_POS;
			parameters[4].Value = model.JOB_STAFF;
			parameters[5].Value = model.JOB_BUD;
			parameters[6].Value = model.JOB_NOR;
			parameters[7].Value = model.JOB_NOR_EXP;
			parameters[8].Value = model.JOB_OT;
			parameters[9].Value = model.JOB_OT_EXP;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.bk_jobbud model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update bk_jobbud set ");
			strSql.Append("JOB_POS=@JOB_POS,");
			strSql.Append("JOB_BUD=@JOB_BUD,");
			strSql.Append("JOB_NOR=@JOB_NOR,");
			strSql.Append("JOB_NOR_EXP=@JOB_NOR_EXP,");
			strSql.Append("JOB_OT=@JOB_OT,");
			strSql.Append("JOB_OT_EXP=@JOB_OT_EXP");
			strSql.Append(" where JOB_CO_CODE=@JOB_CO_CODE and JOB_CODE=@JOB_CODE and JOB_SER=@JOB_SER and JOB_STAFF=@JOB_STAFF ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@JOB_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@JOB_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_SER", MySqlDbType.Char,3),
					new MySqlParameter("@JOB_POS", MySqlDbType.Char,3),
					new MySqlParameter("@JOB_STAFF", MySqlDbType.Char,6),
					new MySqlParameter("@JOB_BUD", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_NOR", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_NOR_EXP", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_OT", MySqlDbType.Decimal,18),
					new MySqlParameter("@JOB_OT_EXP", MySqlDbType.Decimal,18)};
			parameters[0].Value = model.JOB_CO_CODE;
			parameters[1].Value = model.JOB_CODE;
			parameters[2].Value = model.JOB_SER;
			parameters[3].Value = model.JOB_POS;
			parameters[4].Value = model.JOB_STAFF;
			parameters[5].Value = model.JOB_BUD;
			parameters[6].Value = model.JOB_NOR;
			parameters[7].Value = model.JOB_NOR_EXP;
			parameters[8].Value = model.JOB_OT;
			parameters[9].Value = model.JOB_OT_EXP;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string JOB_CO_CODE,string JOB_CODE,string JOB_SER,string JOB_STAFF)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete bk_jobbud ");
			strSql.Append(" where JOB_CO_CODE=@JOB_CO_CODE and JOB_CODE=@JOB_CODE and JOB_SER=@JOB_SER and JOB_STAFF=@JOB_STAFF ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@JOB_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@JOB_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@JOB_SER", MySqlDbType.Char,50),
					new MySqlParameter("@JOB_STAFF", MySqlDbType.Char,50)};
			parameters[0].Value = JOB_CO_CODE;
			parameters[1].Value = JOB_CODE;
			parameters[2].Value = JOB_SER;
			parameters[3].Value = JOB_STAFF;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.bk_jobbud GetModel(string JOB_CO_CODE,string JOB_CODE,string JOB_SER,string JOB_STAFF)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select JOB_CO_CODE,JOB_CODE,JOB_SER,JOB_POS,JOB_STAFF,JOB_BUD,JOB_NOR,JOB_NOR_EXP,JOB_OT,JOB_OT_EXP from bk_jobbud ");
			strSql.Append(" where JOB_CO_CODE=@JOB_CO_CODE and JOB_CODE=@JOB_CODE and JOB_SER=@JOB_SER and JOB_STAFF=@JOB_STAFF ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@JOB_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@JOB_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@JOB_SER", MySqlDbType.Char,50),
					new MySqlParameter("@JOB_STAFF", MySqlDbType.Char,50)};
			parameters[0].Value = JOB_CO_CODE;
			parameters[1].Value = JOB_CODE;
			parameters[2].Value = JOB_SER;
			parameters[3].Value = JOB_STAFF;

			WongTung.Model.bk_jobbud model=new WongTung.Model.bk_jobbud();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.JOB_CO_CODE=ds.Tables[0].Rows[0]["JOB_CO_CODE"].ToString();
				model.JOB_CODE=ds.Tables[0].Rows[0]["JOB_CODE"].ToString();
				model.JOB_SER=ds.Tables[0].Rows[0]["JOB_SER"].ToString();
				model.JOB_POS=ds.Tables[0].Rows[0]["JOB_POS"].ToString();
				model.JOB_STAFF=ds.Tables[0].Rows[0]["JOB_STAFF"].ToString();
				if(ds.Tables[0].Rows[0]["JOB_BUD"].ToString()!="")
				{
					model.JOB_BUD=decimal.Parse(ds.Tables[0].Rows[0]["JOB_BUD"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_NOR"].ToString()!="")
				{
					model.JOB_NOR=decimal.Parse(ds.Tables[0].Rows[0]["JOB_NOR"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_NOR_EXP"].ToString()!="")
				{
					model.JOB_NOR_EXP=decimal.Parse(ds.Tables[0].Rows[0]["JOB_NOR_EXP"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_OT"].ToString()!="")
				{
					model.JOB_OT=decimal.Parse(ds.Tables[0].Rows[0]["JOB_OT"].ToString());
				}
				if(ds.Tables[0].Rows[0]["JOB_OT_EXP"].ToString()!="")
				{
					model.JOB_OT_EXP=decimal.Parse(ds.Tables[0].Rows[0]["JOB_OT_EXP"].ToString());
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
			strSql.Append("select JOB_CO_CODE,JOB_CODE,JOB_SER,JOB_POS,JOB_STAFF,JOB_BUD,JOB_NOR,JOB_NOR_EXP,JOB_OT,JOB_OT_EXP ");
			strSql.Append(" FROM bk_jobbud ");
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
			parameters[0].Value = "bk_jobbud";
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

