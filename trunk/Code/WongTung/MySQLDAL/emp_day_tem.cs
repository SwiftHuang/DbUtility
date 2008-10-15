using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类emp_day_tem。
	/// </summary>
	public class emp_day_tem:Iemp_day_tem
	{
		public emp_day_tem()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ED_CO_CODE,string ED_EMP_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from emp_day_tem");
			strSql.Append(" where ED_CO_CODE=@ED_CO_CODE and ED_EMP_CODE=@ED_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ED_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@ED_EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = ED_CO_CODE;
			parameters[1].Value = ED_EMP_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.emp_day_tem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into emp_day_tem(");
			strSql.Append("ED_CO_CODE,ED_EMP_CODE,ED_JS_1,ED_JS_2,ED_JS_3,ED_JS_4,ED_JS_5,ED_JS_6,ED_JS_7,ED_JS_8,ED_JS_9,ED_JS_10)");
			strSql.Append(" values (");
			strSql.Append("@ED_CO_CODE,@ED_EMP_CODE,@ED_JS_1,@ED_JS_2,@ED_JS_3,@ED_JS_4,@ED_JS_5,@ED_JS_6,@ED_JS_7,@ED_JS_8,@ED_JS_9,@ED_JS_10)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ED_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@ED_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@ED_JS_1", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_2", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_3", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_4", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_5", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_6", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_7", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_8", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_9", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_10", MySqlDbType.Char,15)};
			parameters[0].Value = model.ED_CO_CODE;
			parameters[1].Value = model.ED_EMP_CODE;
			parameters[2].Value = model.ED_JS_1;
			parameters[3].Value = model.ED_JS_2;
			parameters[4].Value = model.ED_JS_3;
			parameters[5].Value = model.ED_JS_4;
			parameters[6].Value = model.ED_JS_5;
			parameters[7].Value = model.ED_JS_6;
			parameters[8].Value = model.ED_JS_7;
			parameters[9].Value = model.ED_JS_8;
			parameters[10].Value = model.ED_JS_9;
			parameters[11].Value = model.ED_JS_10;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.emp_day_tem model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update emp_day_tem set ");
			strSql.Append("ED_JS_1=@ED_JS_1,");
			strSql.Append("ED_JS_2=@ED_JS_2,");
			strSql.Append("ED_JS_3=@ED_JS_3,");
			strSql.Append("ED_JS_4=@ED_JS_4,");
			strSql.Append("ED_JS_5=@ED_JS_5,");
			strSql.Append("ED_JS_6=@ED_JS_6,");
			strSql.Append("ED_JS_7=@ED_JS_7,");
			strSql.Append("ED_JS_8=@ED_JS_8,");
			strSql.Append("ED_JS_9=@ED_JS_9,");
			strSql.Append("ED_JS_10=@ED_JS_10");
			strSql.Append(" where ED_CO_CODE=@ED_CO_CODE and ED_EMP_CODE=@ED_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ED_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@ED_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@ED_JS_1", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_2", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_3", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_4", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_5", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_6", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_7", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_8", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_9", MySqlDbType.Char,15),
					new MySqlParameter("@ED_JS_10", MySqlDbType.Char,15)};
			parameters[0].Value = model.ED_CO_CODE;
			parameters[1].Value = model.ED_EMP_CODE;
			parameters[2].Value = model.ED_JS_1;
			parameters[3].Value = model.ED_JS_2;
			parameters[4].Value = model.ED_JS_3;
			parameters[5].Value = model.ED_JS_4;
			parameters[6].Value = model.ED_JS_5;
			parameters[7].Value = model.ED_JS_6;
			parameters[8].Value = model.ED_JS_7;
			parameters[9].Value = model.ED_JS_8;
			parameters[10].Value = model.ED_JS_9;
			parameters[11].Value = model.ED_JS_10;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string ED_CO_CODE,string ED_EMP_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete emp_day_tem ");
			strSql.Append(" where ED_CO_CODE=@ED_CO_CODE and ED_EMP_CODE=@ED_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ED_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@ED_EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = ED_CO_CODE;
			parameters[1].Value = ED_EMP_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.emp_day_tem GetModel(string ED_CO_CODE,string ED_EMP_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ED_CO_CODE,ED_EMP_CODE,ED_JS_1,ED_JS_2,ED_JS_3,ED_JS_4,ED_JS_5,ED_JS_6,ED_JS_7,ED_JS_8,ED_JS_9,ED_JS_10 from emp_day_tem ");
			strSql.Append(" where ED_CO_CODE=@ED_CO_CODE and ED_EMP_CODE=@ED_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ED_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@ED_EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = ED_CO_CODE;
			parameters[1].Value = ED_EMP_CODE;

			WongTung.Model.emp_day_tem model=new WongTung.Model.emp_day_tem();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.ED_CO_CODE=ds.Tables[0].Rows[0]["ED_CO_CODE"].ToString();
				model.ED_EMP_CODE=ds.Tables[0].Rows[0]["ED_EMP_CODE"].ToString();
				model.ED_JS_1=ds.Tables[0].Rows[0]["ED_JS_1"].ToString();
				model.ED_JS_2=ds.Tables[0].Rows[0]["ED_JS_2"].ToString();
				model.ED_JS_3=ds.Tables[0].Rows[0]["ED_JS_3"].ToString();
				model.ED_JS_4=ds.Tables[0].Rows[0]["ED_JS_4"].ToString();
				model.ED_JS_5=ds.Tables[0].Rows[0]["ED_JS_5"].ToString();
				model.ED_JS_6=ds.Tables[0].Rows[0]["ED_JS_6"].ToString();
				model.ED_JS_7=ds.Tables[0].Rows[0]["ED_JS_7"].ToString();
				model.ED_JS_8=ds.Tables[0].Rows[0]["ED_JS_8"].ToString();
				model.ED_JS_9=ds.Tables[0].Rows[0]["ED_JS_9"].ToString();
				model.ED_JS_10=ds.Tables[0].Rows[0]["ED_JS_10"].ToString();
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
			strSql.Append("select ED_CO_CODE,ED_EMP_CODE,ED_JS_1,ED_JS_2,ED_JS_3,ED_JS_4,ED_JS_5,ED_JS_6,ED_JS_7,ED_JS_8,ED_JS_9,ED_JS_10 ");
			strSql.Append(" FROM emp_day_tem ");
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
			parameters[0].Value = "emp_day_tem";
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

