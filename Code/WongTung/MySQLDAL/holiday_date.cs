using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类holiday_date。
	/// </summary>
	public class holiday_date:Iholiday_date
	{
		public holiday_date()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string HO_CO_CODE,string HO_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from holiday_date");
			strSql.Append(" where HO_CO_CODE=@HO_CO_CODE and HO_CODE=@HO_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@HO_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@HO_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = HO_CO_CODE;
			parameters[1].Value = HO_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.holiday_date model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into holiday_date(");
			strSql.Append("HO_CO_CODE,HO_LOC,HO_CODE,HO_DATE_START,HO_DATE_END,HO_DESC)");
			strSql.Append(" values (");
			strSql.Append("@HO_CO_CODE,@HO_LOC,@HO_CODE,@HO_DATE_START,@HO_DATE_END,@HO_DESC)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@HO_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@HO_LOC", MySqlDbType.Char,2),
					new MySqlParameter("@HO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@HO_DATE_START", MySqlDbType.DateTime),
					new MySqlParameter("@HO_DATE_END", MySqlDbType.DateTime),
					new MySqlParameter("@HO_DESC", MySqlDbType.Char,30)};
			parameters[0].Value = model.HO_CO_CODE;
			parameters[1].Value = model.HO_LOC;
			parameters[2].Value = model.HO_CODE;
			parameters[3].Value = model.HO_DATE_START;
			parameters[4].Value = model.HO_DATE_END;
			parameters[5].Value = model.HO_DESC;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.holiday_date model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update holiday_date set ");
			strSql.Append("HO_LOC=@HO_LOC,");
			strSql.Append("HO_DATE_START=@HO_DATE_START,");
			strSql.Append("HO_DATE_END=@HO_DATE_END,");
			strSql.Append("HO_DESC=@HO_DESC");
			strSql.Append(" where HO_CO_CODE=@HO_CO_CODE and HO_CODE=@HO_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@HO_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@HO_LOC", MySqlDbType.Char,2),
					new MySqlParameter("@HO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@HO_DATE_START", MySqlDbType.DateTime),
					new MySqlParameter("@HO_DATE_END", MySqlDbType.DateTime),
					new MySqlParameter("@HO_DESC", MySqlDbType.Char,30)};
			parameters[0].Value = model.HO_CO_CODE;
			parameters[1].Value = model.HO_LOC;
			parameters[2].Value = model.HO_CODE;
			parameters[3].Value = model.HO_DATE_START;
			parameters[4].Value = model.HO_DATE_END;
			parameters[5].Value = model.HO_DESC;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string HO_CO_CODE,string HO_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete holiday_date ");
			strSql.Append(" where HO_CO_CODE=@HO_CO_CODE and HO_CODE=@HO_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@HO_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@HO_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = HO_CO_CODE;
			parameters[1].Value = HO_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.holiday_date GetModel(string HO_CO_CODE,string HO_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select HO_CO_CODE,HO_LOC,HO_CODE,HO_DATE_START,HO_DATE_END,HO_DESC from holiday_date ");
			strSql.Append(" where HO_CO_CODE=@HO_CO_CODE and HO_CODE=@HO_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@HO_CO_CODE", MySqlDbType.Char,50),
					new MySqlParameter("@HO_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = HO_CO_CODE;
			parameters[1].Value = HO_CODE;

			WongTung.Model.holiday_date model=new WongTung.Model.holiday_date();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.HO_CO_CODE=ds.Tables[0].Rows[0]["HO_CO_CODE"].ToString();
				model.HO_LOC=ds.Tables[0].Rows[0]["HO_LOC"].ToString();
				model.HO_CODE=ds.Tables[0].Rows[0]["HO_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["HO_DATE_START"].ToString()!="")
				{
					model.HO_DATE_START=DateTime.Parse(ds.Tables[0].Rows[0]["HO_DATE_START"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HO_DATE_END"].ToString()!="")
				{
					model.HO_DATE_END=DateTime.Parse(ds.Tables[0].Rows[0]["HO_DATE_END"].ToString());
				}
				model.HO_DESC=ds.Tables[0].Rows[0]["HO_DESC"].ToString();
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
			strSql.Append("select HO_CO_CODE,HO_LOC,HO_CODE,HO_DATE_START,HO_DATE_END,HO_DESC ");
			strSql.Append(" FROM holiday_date ");
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
			parameters[0].Value = "holiday_date";
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

