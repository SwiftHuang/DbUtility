using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类department。
	/// </summary>
	public class department:Idepartment
	{
		public department()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DEPT_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from department");
			strSql.Append(" where DEPT_CODE=@DEPT_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@DEPT_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = DEPT_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into department(");
			strSql.Append("DEPT_CO_CODE,DEPT_CODE,DEPT_NAME)");
			strSql.Append(" values (");
			strSql.Append("@DEPT_CO_CODE,@DEPT_CODE,@DEPT_NAME)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@DEPT_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@DEPT_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@DEPT_NAME", MySqlDbType.Char,100)};
			parameters[0].Value = model.DEPT_CO_CODE;
			parameters[1].Value = model.DEPT_CODE;
			parameters[2].Value = model.DEPT_NAME;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.department model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update department set ");
			strSql.Append("DEPT_CO_CODE=@DEPT_CO_CODE,");
			strSql.Append("DEPT_NAME=@DEPT_NAME");
			strSql.Append(" where DEPT_CODE=@DEPT_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@DEPT_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@DEPT_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@DEPT_NAME", MySqlDbType.Char,100)};
			parameters[0].Value = model.DEPT_CO_CODE;
			parameters[1].Value = model.DEPT_CODE;
			parameters[2].Value = model.DEPT_NAME;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string DEPT_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete department ");
			strSql.Append(" where DEPT_CODE=@DEPT_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@DEPT_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = DEPT_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.department GetModel(string DEPT_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DEPT_CO_CODE,DEPT_CODE,DEPT_NAME from department ");
			strSql.Append(" where DEPT_CODE=@DEPT_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@DEPT_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = DEPT_CODE;

			WongTung.Model.department model=new WongTung.Model.department();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.DEPT_CO_CODE=ds.Tables[0].Rows[0]["DEPT_CO_CODE"].ToString();
				model.DEPT_CODE=ds.Tables[0].Rows[0]["DEPT_CODE"].ToString();
				model.DEPT_NAME=ds.Tables[0].Rows[0]["DEPT_NAME"].ToString();
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
			strSql.Append("select DEPT_CO_CODE,DEPT_CODE,DEPT_NAME ");
			strSql.Append(" FROM department ");
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
			parameters[0].Value = "department";
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

