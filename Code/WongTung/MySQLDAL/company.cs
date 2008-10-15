using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类company。
	/// </summary>
	public class company:Icompany
	{
		public company()
		{}
		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.company model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into company(");
			strSql.Append("CO_CODE,CO_SCR_NAME,CO_RPT_NAME,CO_LB_DATE,CO_LE_DATE,CO_CB_DATE,CO_CE_DATE,CO_CURR,CO_PERIOD_FROM,CO_PERIOD_TO)");
			strSql.Append(" values (");
			strSql.Append("@CO_CODE,@CO_SCR_NAME,@CO_RPT_NAME,@CO_LB_DATE,@CO_LE_DATE,@CO_CB_DATE,@CO_CE_DATE,@CO_CURR,@CO_PERIOD_FROM,@CO_PERIOD_TO)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@CO_SCR_NAME", MySqlDbType.Char,50),
					new MySqlParameter("@CO_RPT_NAME", MySqlDbType.Char,50),
					new MySqlParameter("@CO_LB_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@CO_LE_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@CO_CB_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@CO_CE_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@CO_CURR", MySqlDbType.Char,3),
					new MySqlParameter("@CO_PERIOD_FROM", MySqlDbType.DateTime),
					new MySqlParameter("@CO_PERIOD_TO", MySqlDbType.DateTime)};
			parameters[0].Value = model.CO_CODE;
			parameters[1].Value = model.CO_SCR_NAME;
			parameters[2].Value = model.CO_RPT_NAME;
			parameters[3].Value = model.CO_LB_DATE;
			parameters[4].Value = model.CO_LE_DATE;
			parameters[5].Value = model.CO_CB_DATE;
			parameters[6].Value = model.CO_CE_DATE;
			parameters[7].Value = model.CO_CURR;
			parameters[8].Value = model.CO_PERIOD_FROM;
			parameters[9].Value = model.CO_PERIOD_TO;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.company model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update company set ");
			strSql.Append("CO_CODE=@CO_CODE,");
			strSql.Append("CO_SCR_NAME=@CO_SCR_NAME,");
			strSql.Append("CO_RPT_NAME=@CO_RPT_NAME,");
			strSql.Append("CO_LB_DATE=@CO_LB_DATE,");
			strSql.Append("CO_LE_DATE=@CO_LE_DATE,");
			strSql.Append("CO_CB_DATE=@CO_CB_DATE,");
			strSql.Append("CO_CE_DATE=@CO_CE_DATE,");
			strSql.Append("CO_CURR=@CO_CURR,");
			strSql.Append("CO_PERIOD_FROM=@CO_PERIOD_FROM,");
			strSql.Append("CO_PERIOD_TO=@CO_PERIOD_TO");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@CO_SCR_NAME", MySqlDbType.Char,50),
					new MySqlParameter("@CO_RPT_NAME", MySqlDbType.Char,50),
					new MySqlParameter("@CO_LB_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@CO_LE_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@CO_CB_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@CO_CE_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@CO_CURR", MySqlDbType.Char,3),
					new MySqlParameter("@CO_PERIOD_FROM", MySqlDbType.DateTime),
					new MySqlParameter("@CO_PERIOD_TO", MySqlDbType.DateTime)};
			parameters[0].Value = model.CO_CODE;
			parameters[1].Value = model.CO_SCR_NAME;
			parameters[2].Value = model.CO_RPT_NAME;
			parameters[3].Value = model.CO_LB_DATE;
			parameters[4].Value = model.CO_LE_DATE;
			parameters[5].Value = model.CO_CB_DATE;
			parameters[6].Value = model.CO_CE_DATE;
			parameters[7].Value = model.CO_CURR;
			parameters[8].Value = model.CO_PERIOD_FROM;
			parameters[9].Value = model.CO_PERIOD_TO;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete company ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.company GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CO_CODE,CO_SCR_NAME,CO_RPT_NAME,CO_LB_DATE,CO_LE_DATE,CO_CB_DATE,CO_CE_DATE,CO_CURR,CO_PERIOD_FROM,CO_PERIOD_TO from company ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			WongTung.Model.company model=new WongTung.Model.company();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.CO_CODE=ds.Tables[0].Rows[0]["CO_CODE"].ToString();
				model.CO_SCR_NAME=ds.Tables[0].Rows[0]["CO_SCR_NAME"].ToString();
				model.CO_RPT_NAME=ds.Tables[0].Rows[0]["CO_RPT_NAME"].ToString();
				if(ds.Tables[0].Rows[0]["CO_LB_DATE"].ToString()!="")
				{
					model.CO_LB_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["CO_LB_DATE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CO_LE_DATE"].ToString()!="")
				{
					model.CO_LE_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["CO_LE_DATE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CO_CB_DATE"].ToString()!="")
				{
					model.CO_CB_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["CO_CB_DATE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CO_CE_DATE"].ToString()!="")
				{
					model.CO_CE_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["CO_CE_DATE"].ToString());
				}
				model.CO_CURR=ds.Tables[0].Rows[0]["CO_CURR"].ToString();
				if(ds.Tables[0].Rows[0]["CO_PERIOD_FROM"].ToString()!="")
				{
					model.CO_PERIOD_FROM=DateTime.Parse(ds.Tables[0].Rows[0]["CO_PERIOD_FROM"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CO_PERIOD_TO"].ToString()!="")
				{
					model.CO_PERIOD_TO=DateTime.Parse(ds.Tables[0].Rows[0]["CO_PERIOD_TO"].ToString());
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
			strSql.Append("select CO_CODE,CO_SCR_NAME,CO_RPT_NAME,CO_LB_DATE,CO_LE_DATE,CO_CB_DATE,CO_CE_DATE,CO_CURR,CO_PERIOD_FROM,CO_PERIOD_TO ");
			strSql.Append(" FROM company ");
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
			parameters[0].Value = "company";
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

