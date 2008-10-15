using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类outstanding_temp。
	/// </summary>
	public class outstanding_temp:Ioutstanding_temp
	{
		public outstanding_temp()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal NUM)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from outstanding_temp");
			strSql.Append(" where NUM=@NUM ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@NUM", MySqlDbType.Double)};
			parameters[0].Value = NUM;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.outstanding_temp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into outstanding_temp(");
			strSql.Append("NUM,OUT_OFF_CODE,OUT_OFF_NAME,OUT_EMP_CODE,OUT_EMP_NAME,OUT_DAY,OUT_POS_CLASS,OUT_POS_CODE,OUT_UPDATE_DATE)");
			strSql.Append(" values (");
			strSql.Append("@NUM,@OUT_OFF_CODE,@OUT_OFF_NAME,@OUT_EMP_CODE,@OUT_EMP_NAME,@OUT_DAY,@OUT_POS_CLASS,@OUT_POS_CODE,@OUT_UPDATE_DATE)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@NUM", MySqlDbType.Double,10),
					new MySqlParameter("@OUT_OFF_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@OUT_OFF_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@OUT_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@OUT_EMP_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@OUT_DAY", MySqlDbType.DateTime),
					new MySqlParameter("@OUT_POS_CLASS", MySqlDbType.Decimal,18),
					new MySqlParameter("@OUT_POS_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@OUT_UPDATE_DATE", MySqlDbType.DateTime)};
			parameters[0].Value = model.NUM;
			parameters[1].Value = model.OUT_OFF_CODE;
			parameters[2].Value = model.OUT_OFF_NAME;
			parameters[3].Value = model.OUT_EMP_CODE;
			parameters[4].Value = model.OUT_EMP_NAME;
			parameters[5].Value = model.OUT_DAY;
			parameters[6].Value = model.OUT_POS_CLASS;
			parameters[7].Value = model.OUT_POS_CODE;
			parameters[8].Value = model.OUT_UPDATE_DATE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.outstanding_temp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update outstanding_temp set ");
			strSql.Append("OUT_OFF_CODE=@OUT_OFF_CODE,");
			strSql.Append("OUT_OFF_NAME=@OUT_OFF_NAME,");
			strSql.Append("OUT_EMP_CODE=@OUT_EMP_CODE,");
			strSql.Append("OUT_EMP_NAME=@OUT_EMP_NAME,");
			strSql.Append("OUT_DAY=@OUT_DAY,");
			strSql.Append("OUT_POS_CLASS=@OUT_POS_CLASS,");
			strSql.Append("OUT_POS_CODE=@OUT_POS_CODE,");
			strSql.Append("OUT_UPDATE_DATE=@OUT_UPDATE_DATE");
			strSql.Append(" where NUM=@NUM ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@NUM", MySqlDbType.Double,10),
					new MySqlParameter("@OUT_OFF_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@OUT_OFF_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@OUT_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@OUT_EMP_NAME", MySqlDbType.Char,100),
					new MySqlParameter("@OUT_DAY", MySqlDbType.DateTime),
					new MySqlParameter("@OUT_POS_CLASS", MySqlDbType.Decimal,18),
					new MySqlParameter("@OUT_POS_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@OUT_UPDATE_DATE", MySqlDbType.DateTime)};
			parameters[0].Value = model.NUM;
			parameters[1].Value = model.OUT_OFF_CODE;
			parameters[2].Value = model.OUT_OFF_NAME;
			parameters[3].Value = model.OUT_EMP_CODE;
			parameters[4].Value = model.OUT_EMP_NAME;
			parameters[5].Value = model.OUT_DAY;
			parameters[6].Value = model.OUT_POS_CLASS;
			parameters[7].Value = model.OUT_POS_CODE;
			parameters[8].Value = model.OUT_UPDATE_DATE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(decimal NUM)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete outstanding_temp ");
			strSql.Append(" where NUM=@NUM ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@NUM", MySqlDbType.Double)};
			parameters[0].Value = NUM;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.outstanding_temp GetModel(decimal NUM)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select NUM,OUT_OFF_CODE,OUT_OFF_NAME,OUT_EMP_CODE,OUT_EMP_NAME,OUT_DAY,OUT_POS_CLASS,OUT_POS_CODE,OUT_UPDATE_DATE from outstanding_temp ");
			strSql.Append(" where NUM=@NUM ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@NUM", MySqlDbType.Double)};
			parameters[0].Value = NUM;

			WongTung.Model.outstanding_temp model=new WongTung.Model.outstanding_temp();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["NUM"].ToString()!="")
				{
					model.NUM=decimal.Parse(ds.Tables[0].Rows[0]["NUM"].ToString());
				}
				model.OUT_OFF_CODE=ds.Tables[0].Rows[0]["OUT_OFF_CODE"].ToString();
				model.OUT_OFF_NAME=ds.Tables[0].Rows[0]["OUT_OFF_NAME"].ToString();
				model.OUT_EMP_CODE=ds.Tables[0].Rows[0]["OUT_EMP_CODE"].ToString();
				model.OUT_EMP_NAME=ds.Tables[0].Rows[0]["OUT_EMP_NAME"].ToString();
				if(ds.Tables[0].Rows[0]["OUT_DAY"].ToString()!="")
				{
					model.OUT_DAY=DateTime.Parse(ds.Tables[0].Rows[0]["OUT_DAY"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OUT_POS_CLASS"].ToString()!="")
				{
					model.OUT_POS_CLASS=decimal.Parse(ds.Tables[0].Rows[0]["OUT_POS_CLASS"].ToString());
				}
				model.OUT_POS_CODE=ds.Tables[0].Rows[0]["OUT_POS_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["OUT_UPDATE_DATE"].ToString()!="")
				{
					model.OUT_UPDATE_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["OUT_UPDATE_DATE"].ToString());
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
			strSql.Append("select NUM,OUT_OFF_CODE,OUT_OFF_NAME,OUT_EMP_CODE,OUT_EMP_NAME,OUT_DAY,OUT_POS_CLASS,OUT_POS_CODE,OUT_UPDATE_DATE ");
			strSql.Append(" FROM outstanding_temp ");
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
			parameters[0].Value = "outstanding_temp";
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

