using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类userinf。
	/// </summary>
	public class userinf:Iuserinf
	{
		public userinf()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string USER_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from userinf");
			strSql.Append(" where USER_CODE=@USER_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@USER_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = USER_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.userinf model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into userinf(");
			strSql.Append("USER_CO_CODE,USER_CODE,USER_NAME,USER_EMP_CODE,USER_RAND,USER_CURDATE,USER_RAND_BACK,USER_ACTIVATE,USER_CHNAME)");
			strSql.Append(" values (");
			strSql.Append("@USER_CO_CODE,@USER_CODE,@USER_NAME,@USER_EMP_CODE,@USER_RAND,@USER_CURDATE,@USER_RAND_BACK,@USER_ACTIVATE,@USER_CHNAME)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@USER_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@USER_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@USER_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@USER_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@USER_RAND", MySqlDbType.Char,4),
					new MySqlParameter("@USER_CURDATE", MySqlDbType.DateTime),
					new MySqlParameter("@USER_RAND_BACK", MySqlDbType.Char,4),
					new MySqlParameter("@USER_ACTIVATE", MySqlDbType.Char,1),
					new MySqlParameter("@USER_CHNAME", MySqlDbType.Char,50)};
			parameters[0].Value = model.USER_CO_CODE;
			parameters[1].Value = model.USER_CODE;
			parameters[2].Value = model.USER_NAME;
			parameters[3].Value = model.USER_EMP_CODE;
			parameters[4].Value = model.USER_RAND;
			parameters[5].Value = model.USER_CURDATE;
			parameters[6].Value = model.USER_RAND_BACK;
			parameters[7].Value = model.USER_ACTIVATE;
			parameters[8].Value = model.USER_CHNAME;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.userinf model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update userinf set ");
			strSql.Append("USER_CO_CODE=@USER_CO_CODE,");
			strSql.Append("USER_NAME=@USER_NAME,");
			strSql.Append("USER_EMP_CODE=@USER_EMP_CODE,");
			strSql.Append("USER_RAND=@USER_RAND,");
			strSql.Append("USER_CURDATE=@USER_CURDATE,");
			strSql.Append("USER_RAND_BACK=@USER_RAND_BACK,");
			strSql.Append("USER_ACTIVATE=@USER_ACTIVATE,");
			strSql.Append("USER_CHNAME=@USER_CHNAME");
			strSql.Append(" where USER_CODE=@USER_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@USER_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@USER_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@USER_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@USER_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@USER_RAND", MySqlDbType.Char,4),
					new MySqlParameter("@USER_CURDATE", MySqlDbType.DateTime),
					new MySqlParameter("@USER_RAND_BACK", MySqlDbType.Char,4),
					new MySqlParameter("@USER_ACTIVATE", MySqlDbType.Char,1),
					new MySqlParameter("@USER_CHNAME", MySqlDbType.Char,50)};
			parameters[0].Value = model.USER_CO_CODE;
			parameters[1].Value = model.USER_CODE;
			parameters[2].Value = model.USER_NAME;
			parameters[3].Value = model.USER_EMP_CODE;
			parameters[4].Value = model.USER_RAND;
			parameters[5].Value = model.USER_CURDATE;
			parameters[6].Value = model.USER_RAND_BACK;
			parameters[7].Value = model.USER_ACTIVATE;
			parameters[8].Value = model.USER_CHNAME;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string USER_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete userinf ");
			strSql.Append(" where USER_CODE=@USER_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@USER_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = USER_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.userinf GetModel(string USER_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select USER_CO_CODE,USER_CODE,USER_NAME,USER_EMP_CODE,USER_RAND,USER_CURDATE,USER_RAND_BACK,USER_ACTIVATE,USER_CHNAME from userinf ");
			strSql.Append(" where USER_CODE=@USER_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@USER_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = USER_CODE;

			WongTung.Model.userinf model=new WongTung.Model.userinf();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.USER_CO_CODE=ds.Tables[0].Rows[0]["USER_CO_CODE"].ToString();
				model.USER_CODE=ds.Tables[0].Rows[0]["USER_CODE"].ToString();
				model.USER_NAME=ds.Tables[0].Rows[0]["USER_NAME"].ToString();
				model.USER_EMP_CODE=ds.Tables[0].Rows[0]["USER_EMP_CODE"].ToString();
				model.USER_RAND=ds.Tables[0].Rows[0]["USER_RAND"].ToString();
				if(ds.Tables[0].Rows[0]["USER_CURDATE"].ToString()!="")
				{
					model.USER_CURDATE=DateTime.Parse(ds.Tables[0].Rows[0]["USER_CURDATE"].ToString());
				}
				model.USER_RAND_BACK=ds.Tables[0].Rows[0]["USER_RAND_BACK"].ToString();
				model.USER_ACTIVATE=ds.Tables[0].Rows[0]["USER_ACTIVATE"].ToString();
				model.USER_CHNAME=ds.Tables[0].Rows[0]["USER_CHNAME"].ToString();
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
			strSql.Append("select USER_CO_CODE,USER_CODE,USER_NAME,USER_EMP_CODE,USER_RAND,USER_CURDATE,USER_RAND_BACK,USER_ACTIVATE,USER_CHNAME ");
			strSql.Append(" FROM userinf ");
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
			parameters[0].Value = "userinf";
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

