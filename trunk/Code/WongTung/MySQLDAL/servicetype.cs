using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类servicetype。
	/// </summary>
	public class servicetype:Iservicetype
	{
		public servicetype()
		{}
		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.servicetype model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into servicetype(");
			strSql.Append("ST_CO_CODE,ST_JOB_CODE,ST_SER_CODE,ST_DESC,ST_DESC1,ST_DESC_T1,ST_DESC_S1,ST_DESC_T2,ST_DESC_S2)");
			strSql.Append(" values (");
			strSql.Append("@ST_CO_CODE,@ST_JOB_CODE,@ST_SER_CODE,@ST_DESC,@ST_DESC1,@ST_DESC_T1,@ST_DESC_S1,@ST_DESC_T2,@ST_DESC_S2)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ST_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@ST_JOB_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@ST_SER_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@ST_DESC", MySqlDbType.Char,100),
					new MySqlParameter("@ST_DESC1", MySqlDbType.Char,100),
					new MySqlParameter("@ST_DESC_T1", MySqlDbType.Char,100),
					new MySqlParameter("@ST_DESC_S1", MySqlDbType.Char,100),
					new MySqlParameter("@ST_DESC_T2", MySqlDbType.Char,100),
					new MySqlParameter("@ST_DESC_S2", MySqlDbType.Char,100)};
			parameters[0].Value = model.ST_CO_CODE;
			parameters[1].Value = model.ST_JOB_CODE;
			parameters[2].Value = model.ST_SER_CODE;
			parameters[3].Value = model.ST_DESC;
			parameters[4].Value = model.ST_DESC1;
			parameters[5].Value = model.ST_DESC_T1;
			parameters[6].Value = model.ST_DESC_S1;
			parameters[7].Value = model.ST_DESC_T2;
			parameters[8].Value = model.ST_DESC_S2;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.servicetype model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update servicetype set ");
			strSql.Append("ST_CO_CODE=@ST_CO_CODE,");
			strSql.Append("ST_JOB_CODE=@ST_JOB_CODE,");
			strSql.Append("ST_SER_CODE=@ST_SER_CODE,");
			strSql.Append("ST_DESC=@ST_DESC,");
			strSql.Append("ST_DESC1=@ST_DESC1,");
			strSql.Append("ST_DESC_T1=@ST_DESC_T1,");
			strSql.Append("ST_DESC_S1=@ST_DESC_S1,");
			strSql.Append("ST_DESC_T2=@ST_DESC_T2,");
			strSql.Append("ST_DESC_S2=@ST_DESC_S2");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ST_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@ST_JOB_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@ST_SER_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@ST_DESC", MySqlDbType.Char,100),
					new MySqlParameter("@ST_DESC1", MySqlDbType.Char,100),
					new MySqlParameter("@ST_DESC_T1", MySqlDbType.Char,100),
					new MySqlParameter("@ST_DESC_S1", MySqlDbType.Char,100),
					new MySqlParameter("@ST_DESC_T2", MySqlDbType.Char,100),
					new MySqlParameter("@ST_DESC_S2", MySqlDbType.Char,100)};
			parameters[0].Value = model.ST_CO_CODE;
			parameters[1].Value = model.ST_JOB_CODE;
			parameters[2].Value = model.ST_SER_CODE;
			parameters[3].Value = model.ST_DESC;
			parameters[4].Value = model.ST_DESC1;
			parameters[5].Value = model.ST_DESC_T1;
			parameters[6].Value = model.ST_DESC_S1;
			parameters[7].Value = model.ST_DESC_T2;
			parameters[8].Value = model.ST_DESC_S2;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete servicetype ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.servicetype GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ST_CO_CODE,ST_JOB_CODE,ST_SER_CODE,ST_DESC,ST_DESC1,ST_DESC_T1,ST_DESC_S1,ST_DESC_T2,ST_DESC_S2 from servicetype ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			WongTung.Model.servicetype model=new WongTung.Model.servicetype();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.ST_CO_CODE=ds.Tables[0].Rows[0]["ST_CO_CODE"].ToString();
				model.ST_JOB_CODE=ds.Tables[0].Rows[0]["ST_JOB_CODE"].ToString();
				model.ST_SER_CODE=ds.Tables[0].Rows[0]["ST_SER_CODE"].ToString();
				model.ST_DESC=ds.Tables[0].Rows[0]["ST_DESC"].ToString();
				model.ST_DESC1=ds.Tables[0].Rows[0]["ST_DESC1"].ToString();
				model.ST_DESC_T1=ds.Tables[0].Rows[0]["ST_DESC_T1"].ToString();
				model.ST_DESC_S1=ds.Tables[0].Rows[0]["ST_DESC_S1"].ToString();
				model.ST_DESC_T2=ds.Tables[0].Rows[0]["ST_DESC_T2"].ToString();
				model.ST_DESC_S2=ds.Tables[0].Rows[0]["ST_DESC_S2"].ToString();
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
			strSql.Append("select ST_CO_CODE,ST_JOB_CODE,ST_SER_CODE,ST_DESC,ST_DESC1,ST_DESC_T1,ST_DESC_S1,ST_DESC_T2,ST_DESC_S2 ");
			strSql.Append(" FROM servicetype ");
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
			parameters[0].Value = "servicetype";
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

