using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类spe_endorse。
	/// </summary>
	public class spe_endorse:Ispe_endorse
	{
		public spe_endorse()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SPE_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from spe_endorse");
			strSql.Append(" where SPE_CODE=@SPE_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@SPE_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = SPE_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.spe_endorse model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into spe_endorse(");
			strSql.Append("SPE_CODE,SPE_CRE_EMP,SPE_CRE_DATE)");
			strSql.Append(" values (");
			strSql.Append("@SPE_CODE,@SPE_CRE_EMP,@SPE_CRE_DATE)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@SPE_CODE", MySqlDbType.Char,1),
					new MySqlParameter("@SPE_CRE_EMP", MySqlDbType.Char,6),
					new MySqlParameter("@SPE_CRE_DATE", MySqlDbType.DateTime)};
			parameters[0].Value = model.SPE_CODE;
			parameters[1].Value = model.SPE_CRE_EMP;
			parameters[2].Value = model.SPE_CRE_DATE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.spe_endorse model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update spe_endorse set ");
			strSql.Append("SPE_CRE_EMP=@SPE_CRE_EMP,");
			strSql.Append("SPE_CRE_DATE=@SPE_CRE_DATE");
			strSql.Append(" where SPE_CODE=@SPE_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@SPE_CODE", MySqlDbType.Char,1),
					new MySqlParameter("@SPE_CRE_EMP", MySqlDbType.Char,6),
					new MySqlParameter("@SPE_CRE_DATE", MySqlDbType.DateTime)};
			parameters[0].Value = model.SPE_CODE;
			parameters[1].Value = model.SPE_CRE_EMP;
			parameters[2].Value = model.SPE_CRE_DATE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string SPE_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete spe_endorse ");
			strSql.Append(" where SPE_CODE=@SPE_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@SPE_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = SPE_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.spe_endorse GetModel(string SPE_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SPE_CODE,SPE_CRE_EMP,SPE_CRE_DATE from spe_endorse ");
			strSql.Append(" where SPE_CODE=@SPE_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@SPE_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = SPE_CODE;

			WongTung.Model.spe_endorse model=new WongTung.Model.spe_endorse();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.SPE_CODE=ds.Tables[0].Rows[0]["SPE_CODE"].ToString();
				model.SPE_CRE_EMP=ds.Tables[0].Rows[0]["SPE_CRE_EMP"].ToString();
				if(ds.Tables[0].Rows[0]["SPE_CRE_DATE"].ToString()!="")
				{
					model.SPE_CRE_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["SPE_CRE_DATE"].ToString());
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
			strSql.Append("select SPE_CODE,SPE_CRE_EMP,SPE_CRE_DATE ");
			strSql.Append(" FROM spe_endorse ");
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
			parameters[0].Value = "spe_endorse";
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

