using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类icpinq。
	/// </summary>
	public class icpinq:Iicpinq
	{
		public icpinq()
		{}
		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.icpinq model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into icpinq(");
			strSql.Append("ICP_CO_CODE,ICP_OFFICE_CODE,ICP_OFFICE_NAME,ICP_EMP_CODE,ICP_EMP_NAME)");
			strSql.Append(" values (");
			strSql.Append("@ICP_CO_CODE,@ICP_OFFICE_CODE,@ICP_OFFICE_NAME,@ICP_EMP_CODE,@ICP_EMP_NAME)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ICP_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@ICP_OFFICE_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@ICP_OFFICE_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@ICP_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@ICP_EMP_NAME", MySqlDbType.Char,100)};
			parameters[0].Value = model.ICP_CO_CODE;
			parameters[1].Value = model.ICP_OFFICE_CODE;
			parameters[2].Value = model.ICP_OFFICE_NAME;
			parameters[3].Value = model.ICP_EMP_CODE;
			parameters[4].Value = model.ICP_EMP_NAME;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.icpinq model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update icpinq set ");
			strSql.Append("ICP_CO_CODE=@ICP_CO_CODE,");
			strSql.Append("ICP_OFFICE_CODE=@ICP_OFFICE_CODE,");
			strSql.Append("ICP_OFFICE_NAME=@ICP_OFFICE_NAME,");
			strSql.Append("ICP_EMP_CODE=@ICP_EMP_CODE,");
			strSql.Append("ICP_EMP_NAME=@ICP_EMP_NAME");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ICP_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@ICP_OFFICE_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@ICP_OFFICE_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@ICP_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@ICP_EMP_NAME", MySqlDbType.Char,100)};
			parameters[0].Value = model.ICP_CO_CODE;
			parameters[1].Value = model.ICP_OFFICE_CODE;
			parameters[2].Value = model.ICP_OFFICE_NAME;
			parameters[3].Value = model.ICP_EMP_CODE;
			parameters[4].Value = model.ICP_EMP_NAME;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete icpinq ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.icpinq GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ICP_CO_CODE,ICP_OFFICE_CODE,ICP_OFFICE_NAME,ICP_EMP_CODE,ICP_EMP_NAME from icpinq ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			WongTung.Model.icpinq model=new WongTung.Model.icpinq();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.ICP_CO_CODE=ds.Tables[0].Rows[0]["ICP_CO_CODE"].ToString();
				model.ICP_OFFICE_CODE=ds.Tables[0].Rows[0]["ICP_OFFICE_CODE"].ToString();
				model.ICP_OFFICE_NAME=ds.Tables[0].Rows[0]["ICP_OFFICE_NAME"].ToString();
				model.ICP_EMP_CODE=ds.Tables[0].Rows[0]["ICP_EMP_CODE"].ToString();
				model.ICP_EMP_NAME=ds.Tables[0].Rows[0]["ICP_EMP_NAME"].ToString();
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
			strSql.Append("select ICP_CO_CODE,ICP_OFFICE_CODE,ICP_OFFICE_NAME,ICP_EMP_CODE,ICP_EMP_NAME ");
			strSql.Append(" FROM icpinq ");
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
			parameters[0].Value = "icpinq";
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

