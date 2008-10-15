using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类non_hist。
	/// </summary>
	public class non_hist:Inon_hist
	{
		public non_hist()
		{}
		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.non_hist model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into non_hist(");
			strSql.Append("CO_CODE,STAFF_CODE,DATE,TYPE,ANNUAL,SICK,ADMIN,OT_PAY)");
			strSql.Append(" values (");
			strSql.Append("@CO_CODE,@STAFF_CODE,@DATE,@TYPE,@ANNUAL,@SICK,@ADMIN,@OT_PAY)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@STAFF_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@DATE", MySqlDbType.DateTime),
					new MySqlParameter("@TYPE", MySqlDbType.Char,1),
					new MySqlParameter("@ANNUAL", MySqlDbType.Decimal,18),
					new MySqlParameter("@SICK", MySqlDbType.Decimal,18),
					new MySqlParameter("@ADMIN", MySqlDbType.Decimal,18),
					new MySqlParameter("@OT_PAY", MySqlDbType.Decimal,18)};
			parameters[0].Value = model.CO_CODE;
			parameters[1].Value = model.STAFF_CODE;
			parameters[2].Value = model.DATE;
			parameters[3].Value = model.TYPE;
			parameters[4].Value = model.ANNUAL;
			parameters[5].Value = model.SICK;
			parameters[6].Value = model.ADMIN;
			parameters[7].Value = model.OT_PAY;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.non_hist model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update non_hist set ");
			strSql.Append("CO_CODE=@CO_CODE,");
			strSql.Append("STAFF_CODE=@STAFF_CODE,");
			strSql.Append("DATE=@DATE,");
			strSql.Append("TYPE=@TYPE,");
			strSql.Append("ANNUAL=@ANNUAL,");
			strSql.Append("SICK=@SICK,");
			strSql.Append("ADMIN=@ADMIN,");
			strSql.Append("OT_PAY=@OT_PAY");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@STAFF_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@DATE", MySqlDbType.DateTime),
					new MySqlParameter("@TYPE", MySqlDbType.Char,1),
					new MySqlParameter("@ANNUAL", MySqlDbType.Decimal,18),
					new MySqlParameter("@SICK", MySqlDbType.Decimal,18),
					new MySqlParameter("@ADMIN", MySqlDbType.Decimal,18),
					new MySqlParameter("@OT_PAY", MySqlDbType.Decimal,18)};
			parameters[0].Value = model.CO_CODE;
			parameters[1].Value = model.STAFF_CODE;
			parameters[2].Value = model.DATE;
			parameters[3].Value = model.TYPE;
			parameters[4].Value = model.ANNUAL;
			parameters[5].Value = model.SICK;
			parameters[6].Value = model.ADMIN;
			parameters[7].Value = model.OT_PAY;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete non_hist ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.non_hist GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CO_CODE,STAFF_CODE,DATE,TYPE,ANNUAL,SICK,ADMIN,OT_PAY from non_hist ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			WongTung.Model.non_hist model=new WongTung.Model.non_hist();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.CO_CODE=ds.Tables[0].Rows[0]["CO_CODE"].ToString();
				model.STAFF_CODE=ds.Tables[0].Rows[0]["STAFF_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["DATE"].ToString()!="")
				{
					model.DATE=DateTime.Parse(ds.Tables[0].Rows[0]["DATE"].ToString());
				}
				model.TYPE=ds.Tables[0].Rows[0]["TYPE"].ToString();
				if(ds.Tables[0].Rows[0]["ANNUAL"].ToString()!="")
				{
					model.ANNUAL=decimal.Parse(ds.Tables[0].Rows[0]["ANNUAL"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SICK"].ToString()!="")
				{
					model.SICK=decimal.Parse(ds.Tables[0].Rows[0]["SICK"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ADMIN"].ToString()!="")
				{
					model.ADMIN=decimal.Parse(ds.Tables[0].Rows[0]["ADMIN"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OT_PAY"].ToString()!="")
				{
					model.OT_PAY=decimal.Parse(ds.Tables[0].Rows[0]["OT_PAY"].ToString());
				}
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
			strSql.Append("select CO_CODE,STAFF_CODE,DATE,TYPE,ANNUAL,SICK,ADMIN,OT_PAY ");
			strSql.Append(" FROM non_hist ");
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
			parameters[0].Value = "non_hist";
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

