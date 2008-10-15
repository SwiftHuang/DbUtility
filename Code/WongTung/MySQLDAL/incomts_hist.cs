using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类incomts_hist。
	/// </summary>
	public class incomts_hist:Iincomts_hist
	{
		public incomts_hist()
		{}
		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.incomts_hist model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into incomts_hist(");
			strSql.Append("IST_CO_CODE,IST_OFFICE_CODE,IST_WORK_DATE,IST_USER_CODE,IST_USER_NAME,IST_INPUT_OK,IST_APP,IST_NOR_HR,IST_OT_HR,IST_PERIOD)");
			strSql.Append(" values (");
			strSql.Append("@IST_CO_CODE,@IST_OFFICE_CODE,@IST_WORK_DATE,@IST_USER_CODE,@IST_USER_NAME,@IST_INPUT_OK,@IST_APP,@IST_NOR_HR,@IST_OT_HR,@IST_PERIOD)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@IST_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@IST_OFFICE_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@IST_WORK_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@IST_USER_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@IST_USER_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@IST_INPUT_OK", MySqlDbType.Char,10),
					new MySqlParameter("@IST_APP", MySqlDbType.Char,10),
					new MySqlParameter("@IST_NOR_HR", MySqlDbType.Decimal,18),
					new MySqlParameter("@IST_OT_HR", MySqlDbType.Decimal,18),
					new MySqlParameter("@IST_PERIOD", MySqlDbType.Char,16)};
			parameters[0].Value = model.IST_CO_CODE;
			parameters[1].Value = model.IST_OFFICE_CODE;
			parameters[2].Value = model.IST_WORK_DATE;
			parameters[3].Value = model.IST_USER_CODE;
			parameters[4].Value = model.IST_USER_NAME;
			parameters[5].Value = model.IST_INPUT_OK;
			parameters[6].Value = model.IST_APP;
			parameters[7].Value = model.IST_NOR_HR;
			parameters[8].Value = model.IST_OT_HR;
			parameters[9].Value = model.IST_PERIOD;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.incomts_hist model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update incomts_hist set ");
			strSql.Append("IST_CO_CODE=@IST_CO_CODE,");
			strSql.Append("IST_OFFICE_CODE=@IST_OFFICE_CODE,");
			strSql.Append("IST_WORK_DATE=@IST_WORK_DATE,");
			strSql.Append("IST_USER_CODE=@IST_USER_CODE,");
			strSql.Append("IST_USER_NAME=@IST_USER_NAME,");
			strSql.Append("IST_INPUT_OK=@IST_INPUT_OK,");
			strSql.Append("IST_APP=@IST_APP,");
			strSql.Append("IST_NOR_HR=@IST_NOR_HR,");
			strSql.Append("IST_OT_HR=@IST_OT_HR,");
			strSql.Append("IST_PERIOD=@IST_PERIOD");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@IST_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@IST_OFFICE_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@IST_WORK_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@IST_USER_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@IST_USER_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@IST_INPUT_OK", MySqlDbType.Char,10),
					new MySqlParameter("@IST_APP", MySqlDbType.Char,10),
					new MySqlParameter("@IST_NOR_HR", MySqlDbType.Decimal,18),
					new MySqlParameter("@IST_OT_HR", MySqlDbType.Decimal,18),
					new MySqlParameter("@IST_PERIOD", MySqlDbType.Char,16)};
			parameters[0].Value = model.IST_CO_CODE;
			parameters[1].Value = model.IST_OFFICE_CODE;
			parameters[2].Value = model.IST_WORK_DATE;
			parameters[3].Value = model.IST_USER_CODE;
			parameters[4].Value = model.IST_USER_NAME;
			parameters[5].Value = model.IST_INPUT_OK;
			parameters[6].Value = model.IST_APP;
			parameters[7].Value = model.IST_NOR_HR;
			parameters[8].Value = model.IST_OT_HR;
			parameters[9].Value = model.IST_PERIOD;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete incomts_hist ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.incomts_hist GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select IST_CO_CODE,IST_OFFICE_CODE,IST_WORK_DATE,IST_USER_CODE,IST_USER_NAME,IST_INPUT_OK,IST_APP,IST_NOR_HR,IST_OT_HR,IST_PERIOD from incomts_hist ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			WongTung.Model.incomts_hist model=new WongTung.Model.incomts_hist();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.IST_CO_CODE=ds.Tables[0].Rows[0]["IST_CO_CODE"].ToString();
				model.IST_OFFICE_CODE=ds.Tables[0].Rows[0]["IST_OFFICE_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["IST_WORK_DATE"].ToString()!="")
				{
					model.IST_WORK_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["IST_WORK_DATE"].ToString());
				}
				model.IST_USER_CODE=ds.Tables[0].Rows[0]["IST_USER_CODE"].ToString();
				model.IST_USER_NAME=ds.Tables[0].Rows[0]["IST_USER_NAME"].ToString();
				model.IST_INPUT_OK=ds.Tables[0].Rows[0]["IST_INPUT_OK"].ToString();
				model.IST_APP=ds.Tables[0].Rows[0]["IST_APP"].ToString();
				if(ds.Tables[0].Rows[0]["IST_NOR_HR"].ToString()!="")
				{
					model.IST_NOR_HR=decimal.Parse(ds.Tables[0].Rows[0]["IST_NOR_HR"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IST_OT_HR"].ToString()!="")
				{
					model.IST_OT_HR=decimal.Parse(ds.Tables[0].Rows[0]["IST_OT_HR"].ToString());
				}
				model.IST_PERIOD=ds.Tables[0].Rows[0]["IST_PERIOD"].ToString();
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
			strSql.Append("select IST_CO_CODE,IST_OFFICE_CODE,IST_WORK_DATE,IST_USER_CODE,IST_USER_NAME,IST_INPUT_OK,IST_APP,IST_NOR_HR,IST_OT_HR,IST_PERIOD ");
			strSql.Append(" FROM incomts_hist ");
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
			parameters[0].Value = "incomts_hist";
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

