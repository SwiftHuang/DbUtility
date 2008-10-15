using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类update_time。
	/// </summary>
	public class update_time:Iupdate_time
	{
		public update_time()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UT_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from update_time");
			strSql.Append(" where UT_CODE=@UT_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UT_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = UT_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.update_time model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into update_time(");
			strSql.Append("UT_CODE,UT_DATE,UT_TIME,UT_FRE,UT_UPDATE_USER,UT_UPDATE_DT,UT_INF)");
			strSql.Append(" values (");
			strSql.Append("@UT_CODE,@UT_DATE,@UT_TIME,@UT_FRE,@UT_UPDATE_USER,@UT_UPDATE_DT,@UT_INF)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UT_CODE", MySqlDbType.Char,15),
					new MySqlParameter("@UT_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@UT_TIME", MySqlDbType.Char,5),
					new MySqlParameter("@UT_FRE", MySqlDbType.Int32,3),
					new MySqlParameter("@UT_UPDATE_USER", MySqlDbType.Char,20),
					new MySqlParameter("@UT_UPDATE_DT", MySqlDbType.DateTime),
					new MySqlParameter("@UT_INF", MySqlDbType.Char,100)};
			parameters[0].Value = model.UT_CODE;
			parameters[1].Value = model.UT_DATE;
			parameters[2].Value = model.UT_TIME;
			parameters[3].Value = model.UT_FRE;
			parameters[4].Value = model.UT_UPDATE_USER;
			parameters[5].Value = model.UT_UPDATE_DT;
			parameters[6].Value = model.UT_INF;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.update_time model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update update_time set ");
			strSql.Append("UT_DATE=@UT_DATE,");
			strSql.Append("UT_TIME=@UT_TIME,");
			strSql.Append("UT_FRE=@UT_FRE,");
			strSql.Append("UT_UPDATE_USER=@UT_UPDATE_USER,");
			strSql.Append("UT_UPDATE_DT=@UT_UPDATE_DT,");
			strSql.Append("UT_INF=@UT_INF");
			strSql.Append(" where UT_CODE=@UT_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UT_CODE", MySqlDbType.Char,15),
					new MySqlParameter("@UT_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@UT_TIME", MySqlDbType.Char,5),
					new MySqlParameter("@UT_FRE", MySqlDbType.Int32,3),
					new MySqlParameter("@UT_UPDATE_USER", MySqlDbType.Char,20),
					new MySqlParameter("@UT_UPDATE_DT", MySqlDbType.DateTime),
					new MySqlParameter("@UT_INF", MySqlDbType.Char,100)};
			parameters[0].Value = model.UT_CODE;
			parameters[1].Value = model.UT_DATE;
			parameters[2].Value = model.UT_TIME;
			parameters[3].Value = model.UT_FRE;
			parameters[4].Value = model.UT_UPDATE_USER;
			parameters[5].Value = model.UT_UPDATE_DT;
			parameters[6].Value = model.UT_INF;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string UT_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete update_time ");
			strSql.Append(" where UT_CODE=@UT_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UT_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = UT_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.update_time GetModel(string UT_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UT_CODE,UT_DATE,UT_TIME,UT_FRE,UT_UPDATE_USER,UT_UPDATE_DT,UT_INF from update_time ");
			strSql.Append(" where UT_CODE=@UT_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UT_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = UT_CODE;

			WongTung.Model.update_time model=new WongTung.Model.update_time();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.UT_CODE=ds.Tables[0].Rows[0]["UT_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["UT_DATE"].ToString()!="")
				{
					model.UT_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["UT_DATE"].ToString());
				}
				model.UT_TIME=ds.Tables[0].Rows[0]["UT_TIME"].ToString();
				if(ds.Tables[0].Rows[0]["UT_FRE"].ToString()!="")
				{
					model.UT_FRE=int.Parse(ds.Tables[0].Rows[0]["UT_FRE"].ToString());
				}
				model.UT_UPDATE_USER=ds.Tables[0].Rows[0]["UT_UPDATE_USER"].ToString();
				if(ds.Tables[0].Rows[0]["UT_UPDATE_DT"].ToString()!="")
				{
					model.UT_UPDATE_DT=DateTime.Parse(ds.Tables[0].Rows[0]["UT_UPDATE_DT"].ToString());
				}
				model.UT_INF=ds.Tables[0].Rows[0]["UT_INF"].ToString();
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
			strSql.Append("select UT_CODE,UT_DATE,UT_TIME,UT_FRE,UT_UPDATE_USER,UT_UPDATE_DT,UT_INF ");
			strSql.Append(" FROM update_time ");
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
			parameters[0].Value = "update_time";
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

