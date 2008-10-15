using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类workstage。
	/// </summary>
	public class workstage:Iworkstage
	{
		public workstage()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string WT_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from workstage");
			strSql.Append(" where WT_CODE=@WT_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@WT_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = WT_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.workstage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into workstage(");
			strSql.Append("WT_CO_CODE,WT_CODE,WT_DESC,WT_DESC_T,WT_DESC_S)");
			strSql.Append(" values (");
			strSql.Append("@WT_CO_CODE,@WT_CODE,@WT_DESC,@WT_DESC_T,@WT_DESC_S)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@WT_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@WT_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@WT_DESC", MySqlDbType.Char,100),
					new MySqlParameter("@WT_DESC_T", MySqlDbType.Char,100),
					new MySqlParameter("@WT_DESC_S", MySqlDbType.Char,100)};
			parameters[0].Value = model.WT_CO_CODE;
			parameters[1].Value = model.WT_CODE;
			parameters[2].Value = model.WT_DESC;
			parameters[3].Value = model.WT_DESC_T;
			parameters[4].Value = model.WT_DESC_S;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.workstage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update workstage set ");
			strSql.Append("WT_CO_CODE=@WT_CO_CODE,");
			strSql.Append("WT_DESC=@WT_DESC,");
			strSql.Append("WT_DESC_T=@WT_DESC_T,");
			strSql.Append("WT_DESC_S=@WT_DESC_S");
			strSql.Append(" where WT_CODE=@WT_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@WT_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@WT_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@WT_DESC", MySqlDbType.Char,100),
					new MySqlParameter("@WT_DESC_T", MySqlDbType.Char,100),
					new MySqlParameter("@WT_DESC_S", MySqlDbType.Char,100)};
			parameters[0].Value = model.WT_CO_CODE;
			parameters[1].Value = model.WT_CODE;
			parameters[2].Value = model.WT_DESC;
			parameters[3].Value = model.WT_DESC_T;
			parameters[4].Value = model.WT_DESC_S;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string WT_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete workstage ");
			strSql.Append(" where WT_CODE=@WT_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@WT_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = WT_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.workstage GetModel(string WT_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select WT_CO_CODE,WT_CODE,WT_DESC,WT_DESC_T,WT_DESC_S from workstage ");
			strSql.Append(" where WT_CODE=@WT_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@WT_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = WT_CODE;

			WongTung.Model.workstage model=new WongTung.Model.workstage();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.WT_CO_CODE=ds.Tables[0].Rows[0]["WT_CO_CODE"].ToString();
				model.WT_CODE=ds.Tables[0].Rows[0]["WT_CODE"].ToString();
				model.WT_DESC=ds.Tables[0].Rows[0]["WT_DESC"].ToString();
				model.WT_DESC_T=ds.Tables[0].Rows[0]["WT_DESC_T"].ToString();
				model.WT_DESC_S=ds.Tables[0].Rows[0]["WT_DESC_S"].ToString();
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
			strSql.Append("select WT_CO_CODE,WT_CODE,WT_DESC,WT_DESC_T,WT_DESC_S ");
			strSql.Append(" FROM workstage ");
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
			parameters[0].Value = "workstage";
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

