using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类employee。
	/// </summary>
	public class employee:Iemployee
	{
		public employee()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string EMP_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from employee");
			strSql.Append(" where EMP_CODE=@EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = EMP_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.employee model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into employee(");
			strSql.Append("EMP_CO_CODE,EMP_CODE,EMP_NAME,EMP_POS_CODE,EMP_DEP_CODE,EMP_INITIAL,EMP_OFFICE,EMP_CHNAME,EMP_SPE,EMP_CRE_DATE,EMP_DEL)");
			strSql.Append(" values (");
			strSql.Append("@EMP_CO_CODE,@EMP_CODE,@EMP_NAME,@EMP_POS_CODE,@EMP_DEP_CODE,@EMP_INITIAL,@EMP_OFFICE,@EMP_CHNAME,@EMP_SPE,@EMP_CRE_DATE,@EMP_DEL)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@EMP_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@EMP_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@EMP_POS_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@EMP_DEP_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@EMP_INITIAL", MySqlDbType.Char,10),
					new MySqlParameter("@EMP_OFFICE", MySqlDbType.Char,3),
					new MySqlParameter("@EMP_CHNAME", MySqlDbType.Char,50),
					new MySqlParameter("@EMP_SPE", MySqlDbType.Char,1),
					new MySqlParameter("@EMP_CRE_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@EMP_DEL", MySqlDbType.Char,1)};
			parameters[0].Value = model.EMP_CO_CODE;
			parameters[1].Value = model.EMP_CODE;
			parameters[2].Value = model.EMP_NAME;
			parameters[3].Value = model.EMP_POS_CODE;
			parameters[4].Value = model.EMP_DEP_CODE;
			parameters[5].Value = model.EMP_INITIAL;
			parameters[6].Value = model.EMP_OFFICE;
			parameters[7].Value = model.EMP_CHNAME;
			parameters[8].Value = model.EMP_SPE;
			parameters[9].Value = model.EMP_CRE_DATE;
			parameters[10].Value = model.EMP_DEL;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.employee model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update employee set ");
			strSql.Append("EMP_CO_CODE=@EMP_CO_CODE,");
			strSql.Append("EMP_NAME=@EMP_NAME,");
			strSql.Append("EMP_POS_CODE=@EMP_POS_CODE,");
			strSql.Append("EMP_DEP_CODE=@EMP_DEP_CODE,");
			strSql.Append("EMP_INITIAL=@EMP_INITIAL,");
			strSql.Append("EMP_OFFICE=@EMP_OFFICE,");
			strSql.Append("EMP_CHNAME=@EMP_CHNAME,");
			strSql.Append("EMP_SPE=@EMP_SPE,");
			strSql.Append("EMP_CRE_DATE=@EMP_CRE_DATE,");
			strSql.Append("EMP_DEL=@EMP_DEL");
			strSql.Append(" where EMP_CODE=@EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@EMP_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@EMP_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@EMP_POS_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@EMP_DEP_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@EMP_INITIAL", MySqlDbType.Char,10),
					new MySqlParameter("@EMP_OFFICE", MySqlDbType.Char,3),
					new MySqlParameter("@EMP_CHNAME", MySqlDbType.Char,50),
					new MySqlParameter("@EMP_SPE", MySqlDbType.Char,1),
					new MySqlParameter("@EMP_CRE_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@EMP_DEL", MySqlDbType.Char,1)};
			parameters[0].Value = model.EMP_CO_CODE;
			parameters[1].Value = model.EMP_CODE;
			parameters[2].Value = model.EMP_NAME;
			parameters[3].Value = model.EMP_POS_CODE;
			parameters[4].Value = model.EMP_DEP_CODE;
			parameters[5].Value = model.EMP_INITIAL;
			parameters[6].Value = model.EMP_OFFICE;
			parameters[7].Value = model.EMP_CHNAME;
			parameters[8].Value = model.EMP_SPE;
			parameters[9].Value = model.EMP_CRE_DATE;
			parameters[10].Value = model.EMP_DEL;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string EMP_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete employee ");
			strSql.Append(" where EMP_CODE=@EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = EMP_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.employee GetModel(string EMP_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select EMP_CO_CODE,EMP_CODE,EMP_NAME,EMP_POS_CODE,EMP_DEP_CODE,EMP_INITIAL,EMP_OFFICE,EMP_CHNAME,EMP_SPE,EMP_CRE_DATE,EMP_DEL from employee ");
			strSql.Append(" where EMP_CODE=@EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = EMP_CODE;

			WongTung.Model.employee model=new WongTung.Model.employee();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.EMP_CO_CODE=ds.Tables[0].Rows[0]["EMP_CO_CODE"].ToString();
				model.EMP_CODE=ds.Tables[0].Rows[0]["EMP_CODE"].ToString();
				model.EMP_NAME=ds.Tables[0].Rows[0]["EMP_NAME"].ToString();
				model.EMP_POS_CODE=ds.Tables[0].Rows[0]["EMP_POS_CODE"].ToString();
				model.EMP_DEP_CODE=ds.Tables[0].Rows[0]["EMP_DEP_CODE"].ToString();
				model.EMP_INITIAL=ds.Tables[0].Rows[0]["EMP_INITIAL"].ToString();
				model.EMP_OFFICE=ds.Tables[0].Rows[0]["EMP_OFFICE"].ToString();
				model.EMP_CHNAME=ds.Tables[0].Rows[0]["EMP_CHNAME"].ToString();
				model.EMP_SPE=ds.Tables[0].Rows[0]["EMP_SPE"].ToString();
				if(ds.Tables[0].Rows[0]["EMP_CRE_DATE"].ToString()!="")
				{
					model.EMP_CRE_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["EMP_CRE_DATE"].ToString());
				}
				model.EMP_DEL=ds.Tables[0].Rows[0]["EMP_DEL"].ToString();
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
			strSql.Append("select EMP_CO_CODE,EMP_CODE,EMP_NAME,EMP_POS_CODE,EMP_DEP_CODE,EMP_INITIAL,EMP_OFFICE,EMP_CHNAME,EMP_SPE,EMP_CRE_DATE,EMP_DEL ");
			strSql.Append(" FROM employee ");
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
			parameters[0].Value = "employee";
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

