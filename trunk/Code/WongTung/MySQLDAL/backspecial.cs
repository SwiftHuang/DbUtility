using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类backspecial。
	/// </summary>
	public class backspecial:Ibackspecial
	{
		public backspecial()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BS_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from backspecial");
			strSql.Append(" where BS_CODE=@BS_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@BS_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = BS_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.backspecial model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into backspecial(");
			strSql.Append("BS_CO_CODE,BS_CODE,BS_DATE,BS_CURDATE)");
			strSql.Append(" values (");
			strSql.Append("@BS_CO_CODE,@BS_CODE,@BS_DATE,@BS_CURDATE)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@BS_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@BS_CODE", MySqlDbType.Char,4),
					new MySqlParameter("@BS_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@BS_CURDATE", MySqlDbType.DateTime)};
			parameters[0].Value = model.BS_CO_CODE;
			parameters[1].Value = model.BS_CODE;
			parameters[2].Value = model.BS_DATE;
			parameters[3].Value = model.BS_CURDATE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.backspecial model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update backspecial set ");
			strSql.Append("BS_CO_CODE=@BS_CO_CODE,");
			strSql.Append("BS_DATE=@BS_DATE,");
			strSql.Append("BS_CURDATE=@BS_CURDATE");
			strSql.Append(" where BS_CODE=@BS_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@BS_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@BS_CODE", MySqlDbType.Char,4),
					new MySqlParameter("@BS_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@BS_CURDATE", MySqlDbType.DateTime)};
			parameters[0].Value = model.BS_CO_CODE;
			parameters[1].Value = model.BS_CODE;
			parameters[2].Value = model.BS_DATE;
			parameters[3].Value = model.BS_CURDATE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string BS_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete backspecial ");
			strSql.Append(" where BS_CODE=@BS_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@BS_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = BS_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.backspecial GetModel(string BS_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select BS_CO_CODE,BS_CODE,BS_DATE,BS_CURDATE from backspecial ");
			strSql.Append(" where BS_CODE=@BS_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@BS_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = BS_CODE;

			WongTung.Model.backspecial model=new WongTung.Model.backspecial();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.BS_CO_CODE=ds.Tables[0].Rows[0]["BS_CO_CODE"].ToString();
				model.BS_CODE=ds.Tables[0].Rows[0]["BS_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["BS_DATE"].ToString()!="")
				{
					model.BS_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["BS_DATE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BS_CURDATE"].ToString()!="")
				{
					model.BS_CURDATE=DateTime.Parse(ds.Tables[0].Rows[0]["BS_CURDATE"].ToString());
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
			strSql.Append("select BS_CO_CODE,BS_CODE,BS_DATE,BS_CURDATE ");
			strSql.Append(" FROM backspecial ");
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
			parameters[0].Value = "backspecial";
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

