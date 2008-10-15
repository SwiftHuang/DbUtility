using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类worknatrue。
	/// </summary>
	public class worknatrue:Iworknatrue
	{
		public worknatrue()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string WN_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from worknatrue");
			strSql.Append(" where WN_CODE=@WN_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@WN_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = WN_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.worknatrue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into worknatrue(");
			strSql.Append("WN_CO_CODE,WN_CODE,WN_DESC,WN_DESC_T,WN_DESC_S)");
			strSql.Append(" values (");
			strSql.Append("@WN_CO_CODE,@WN_CODE,@WN_DESC,@WN_DESC_T,@WN_DESC_S)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@WN_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@WN_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@WN_DESC", MySqlDbType.Char,100),
					new MySqlParameter("@WN_DESC_T", MySqlDbType.Char,100),
					new MySqlParameter("@WN_DESC_S", MySqlDbType.Char,100)};
			parameters[0].Value = model.WN_CO_CODE;
			parameters[1].Value = model.WN_CODE;
			parameters[2].Value = model.WN_DESC;
			parameters[3].Value = model.WN_DESC_T;
			parameters[4].Value = model.WN_DESC_S;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.worknatrue model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update worknatrue set ");
			strSql.Append("WN_CO_CODE=@WN_CO_CODE,");
			strSql.Append("WN_DESC=@WN_DESC,");
			strSql.Append("WN_DESC_T=@WN_DESC_T,");
			strSql.Append("WN_DESC_S=@WN_DESC_S");
			strSql.Append(" where WN_CODE=@WN_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@WN_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@WN_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@WN_DESC", MySqlDbType.Char,100),
					new MySqlParameter("@WN_DESC_T", MySqlDbType.Char,100),
					new MySqlParameter("@WN_DESC_S", MySqlDbType.Char,100)};
			parameters[0].Value = model.WN_CO_CODE;
			parameters[1].Value = model.WN_CODE;
			parameters[2].Value = model.WN_DESC;
			parameters[3].Value = model.WN_DESC_T;
			parameters[4].Value = model.WN_DESC_S;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string WN_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete worknatrue ");
			strSql.Append(" where WN_CODE=@WN_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@WN_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = WN_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.worknatrue GetModel(string WN_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select WN_CO_CODE,WN_CODE,WN_DESC,WN_DESC_T,WN_DESC_S from worknatrue ");
			strSql.Append(" where WN_CODE=@WN_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@WN_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = WN_CODE;

			WongTung.Model.worknatrue model=new WongTung.Model.worknatrue();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.WN_CO_CODE=ds.Tables[0].Rows[0]["WN_CO_CODE"].ToString();
				model.WN_CODE=ds.Tables[0].Rows[0]["WN_CODE"].ToString();
				model.WN_DESC=ds.Tables[0].Rows[0]["WN_DESC"].ToString();
				model.WN_DESC_T=ds.Tables[0].Rows[0]["WN_DESC_T"].ToString();
				model.WN_DESC_S=ds.Tables[0].Rows[0]["WN_DESC_S"].ToString();
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
			strSql.Append("select WN_CO_CODE,WN_CODE,WN_DESC,WN_DESC_T,WN_DESC_S ");
			strSql.Append(" FROM worknatrue ");
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
			parameters[0].Value = "worknatrue";
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

