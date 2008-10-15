using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类offices。
	/// </summary>
	public class offices:Ioffices
	{
		public offices()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string OFF_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from offices");
			strSql.Append(" where OFF_CODE=@OFF_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@OFF_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = OFF_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.offices model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into offices(");
			strSql.Append("OFF_CO_CODE,OFF_CODE,OFF_NAME,OFF_ENDORSE)");
			strSql.Append(" values (");
			strSql.Append("@OFF_CO_CODE,@OFF_CODE,@OFF_NAME,@OFF_ENDORSE)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@OFF_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@OFF_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@OFF_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@OFF_ENDORSE", MySqlDbType.Char,6)};
			parameters[0].Value = model.OFF_CO_CODE;
			parameters[1].Value = model.OFF_CODE;
			parameters[2].Value = model.OFF_NAME;
			parameters[3].Value = model.OFF_ENDORSE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.offices model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update offices set ");
			strSql.Append("OFF_CO_CODE=@OFF_CO_CODE,");
			strSql.Append("OFF_NAME=@OFF_NAME,");
			strSql.Append("OFF_ENDORSE=@OFF_ENDORSE");
			strSql.Append(" where OFF_CODE=@OFF_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@OFF_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@OFF_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@OFF_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@OFF_ENDORSE", MySqlDbType.Char,6)};
			parameters[0].Value = model.OFF_CO_CODE;
			parameters[1].Value = model.OFF_CODE;
			parameters[2].Value = model.OFF_NAME;
			parameters[3].Value = model.OFF_ENDORSE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string OFF_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete offices ");
			strSql.Append(" where OFF_CODE=@OFF_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@OFF_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = OFF_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.offices GetModel(string OFF_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select OFF_CO_CODE,OFF_CODE,OFF_NAME,OFF_ENDORSE from offices ");
			strSql.Append(" where OFF_CODE=@OFF_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@OFF_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = OFF_CODE;

			WongTung.Model.offices model=new WongTung.Model.offices();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.OFF_CO_CODE=ds.Tables[0].Rows[0]["OFF_CO_CODE"].ToString();
				model.OFF_CODE=ds.Tables[0].Rows[0]["OFF_CODE"].ToString();
				model.OFF_NAME=ds.Tables[0].Rows[0]["OFF_NAME"].ToString();
				model.OFF_ENDORSE=ds.Tables[0].Rows[0]["OFF_ENDORSE"].ToString();
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
			strSql.Append("select OFF_CO_CODE,OFF_CODE,OFF_NAME,OFF_ENDORSE ");
			strSql.Append(" FROM offices ");
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
			parameters[0].Value = "offices";
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

