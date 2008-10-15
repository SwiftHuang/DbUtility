using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类changepw。
	/// </summary>
	public class changepw:Ichangepw
	{
		public changepw()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CP_USER_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from changepw");
			strSql.Append(" where CP_USER_CODE=@CP_USER_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@CP_USER_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = CP_USER_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.changepw model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into changepw(");
			strSql.Append("CP_CO_CODE,CP_USER_CODE,CP_NEW_PWD)");
			strSql.Append(" values (");
			strSql.Append("@CP_CO_CODE,@CP_USER_CODE,@CP_NEW_PWD)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@CP_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@CP_USER_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@CP_NEW_PWD", MySqlDbType.Char,15)};
			parameters[0].Value = model.CP_CO_CODE;
			parameters[1].Value = model.CP_USER_CODE;
			parameters[2].Value = model.CP_NEW_PWD;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.changepw model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update changepw set ");
			strSql.Append("CP_CO_CODE=@CP_CO_CODE,");
			strSql.Append("CP_NEW_PWD=@CP_NEW_PWD");
			strSql.Append(" where CP_USER_CODE=@CP_USER_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@CP_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@CP_USER_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@CP_NEW_PWD", MySqlDbType.Char,15)};
			parameters[0].Value = model.CP_CO_CODE;
			parameters[1].Value = model.CP_USER_CODE;
			parameters[2].Value = model.CP_NEW_PWD;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string CP_USER_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete changepw ");
			strSql.Append(" where CP_USER_CODE=@CP_USER_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@CP_USER_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = CP_USER_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.changepw GetModel(string CP_USER_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CP_CO_CODE,CP_USER_CODE,CP_NEW_PWD from changepw ");
			strSql.Append(" where CP_USER_CODE=@CP_USER_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@CP_USER_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = CP_USER_CODE;

			WongTung.Model.changepw model=new WongTung.Model.changepw();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.CP_CO_CODE=ds.Tables[0].Rows[0]["CP_CO_CODE"].ToString();
				model.CP_USER_CODE=ds.Tables[0].Rows[0]["CP_USER_CODE"].ToString();
				model.CP_NEW_PWD=ds.Tables[0].Rows[0]["CP_NEW_PWD"].ToString();
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
			strSql.Append("select CP_CO_CODE,CP_USER_CODE,CP_NEW_PWD ");
			strSql.Append(" FROM changepw ");
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
			parameters[0].Value = "changepw";
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

