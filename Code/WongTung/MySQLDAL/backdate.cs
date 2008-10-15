using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类backdate。
	/// </summary>
	public class backdate:Ibackdate
	{
		public backdate()
		{}
		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.backdate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into backdate(");
			strSql.Append("BK_CO_CODE,BK_USER,BK_RAN_NO,BK_EMP,BK_RAN_DATE,BK_CRE_DATE,BK_STATUS)");
			strSql.Append(" values (");
			strSql.Append("@BK_CO_CODE,@BK_USER,@BK_RAN_NO,@BK_EMP,@BK_RAN_DATE,@BK_CRE_DATE,@BK_STATUS)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@BK_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@BK_USER", MySqlDbType.VarChar,6),
					new MySqlParameter("@BK_RAN_NO", MySqlDbType.VarChar,4),
					new MySqlParameter("@BK_EMP", MySqlDbType.VarChar,6),
					new MySqlParameter("@BK_RAN_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@BK_CRE_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@BK_STATUS", MySqlDbType.Char,1)};
			parameters[0].Value = model.BK_CO_CODE;
			parameters[1].Value = model.BK_USER;
			parameters[2].Value = model.BK_RAN_NO;
			parameters[3].Value = model.BK_EMP;
			parameters[4].Value = model.BK_RAN_DATE;
			parameters[5].Value = model.BK_CRE_DATE;
			parameters[6].Value = model.BK_STATUS;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.backdate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update backdate set ");
			strSql.Append("BK_CO_CODE=@BK_CO_CODE,");
			strSql.Append("BK_USER=@BK_USER,");
			strSql.Append("BK_RAN_NO=@BK_RAN_NO,");
			strSql.Append("BK_EMP=@BK_EMP,");
			strSql.Append("BK_RAN_DATE=@BK_RAN_DATE,");
			strSql.Append("BK_CRE_DATE=@BK_CRE_DATE,");
			strSql.Append("BK_STATUS=@BK_STATUS");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@BK_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@BK_USER", MySqlDbType.VarChar,6),
					new MySqlParameter("@BK_RAN_NO", MySqlDbType.VarChar,4),
					new MySqlParameter("@BK_EMP", MySqlDbType.VarChar,6),
					new MySqlParameter("@BK_RAN_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@BK_CRE_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@BK_STATUS", MySqlDbType.Char,1)};
			parameters[0].Value = model.BK_CO_CODE;
			parameters[1].Value = model.BK_USER;
			parameters[2].Value = model.BK_RAN_NO;
			parameters[3].Value = model.BK_EMP;
			parameters[4].Value = model.BK_RAN_DATE;
			parameters[5].Value = model.BK_CRE_DATE;
			parameters[6].Value = model.BK_STATUS;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete backdate ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.backdate GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select BK_CO_CODE,BK_USER,BK_RAN_NO,BK_EMP,BK_RAN_DATE,BK_CRE_DATE,BK_STATUS from backdate ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			WongTung.Model.backdate model=new WongTung.Model.backdate();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.BK_CO_CODE=ds.Tables[0].Rows[0]["BK_CO_CODE"].ToString();
				model.BK_USER=ds.Tables[0].Rows[0]["BK_USER"].ToString();
				model.BK_RAN_NO=ds.Tables[0].Rows[0]["BK_RAN_NO"].ToString();
				model.BK_EMP=ds.Tables[0].Rows[0]["BK_EMP"].ToString();
				if(ds.Tables[0].Rows[0]["BK_RAN_DATE"].ToString()!="")
				{
					model.BK_RAN_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["BK_RAN_DATE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BK_CRE_DATE"].ToString()!="")
				{
					model.BK_CRE_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["BK_CRE_DATE"].ToString());
				}
				model.BK_STATUS=ds.Tables[0].Rows[0]["BK_STATUS"].ToString();
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
			strSql.Append("select BK_CO_CODE,BK_USER,BK_RAN_NO,BK_EMP,BK_RAN_DATE,BK_CRE_DATE,BK_STATUS ");
			strSql.Append(" FROM backdate ");
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
			parameters[0].Value = "backdate";
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

