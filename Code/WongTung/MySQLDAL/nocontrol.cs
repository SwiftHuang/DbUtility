using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类nocontrol。
	/// </summary>
	public class nocontrol:Inocontrol
	{
		public nocontrol()
		{}
		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.nocontrol model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into nocontrol(");
			strSql.Append("NO_CO_CODE,NO_CODE,NO_DESC,NO_STA_NO,NO_SEQ_NO)");
			strSql.Append(" values (");
			strSql.Append("@NO_CO_CODE,@NO_CODE,@NO_DESC,@NO_STA_NO,@NO_SEQ_NO)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@NO_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@NO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@NO_DESC", MySqlDbType.Char,100),
					new MySqlParameter("@NO_STA_NO", MySqlDbType.Decimal,18),
					new MySqlParameter("@NO_SEQ_NO", MySqlDbType.Decimal,18)};
			parameters[0].Value = model.NO_CO_CODE;
			parameters[1].Value = model.NO_CODE;
			parameters[2].Value = model.NO_DESC;
			parameters[3].Value = model.NO_STA_NO;
			parameters[4].Value = model.NO_SEQ_NO;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.nocontrol model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update nocontrol set ");
			strSql.Append("NO_CO_CODE=@NO_CO_CODE,");
			strSql.Append("NO_CODE=@NO_CODE,");
			strSql.Append("NO_DESC=@NO_DESC,");
			strSql.Append("NO_STA_NO=@NO_STA_NO,");
			strSql.Append("NO_SEQ_NO=@NO_SEQ_NO");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@NO_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@NO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@NO_DESC", MySqlDbType.Char,100),
					new MySqlParameter("@NO_STA_NO", MySqlDbType.Decimal,18),
					new MySqlParameter("@NO_SEQ_NO", MySqlDbType.Decimal,18)};
			parameters[0].Value = model.NO_CO_CODE;
			parameters[1].Value = model.NO_CODE;
			parameters[2].Value = model.NO_DESC;
			parameters[3].Value = model.NO_STA_NO;
			parameters[4].Value = model.NO_SEQ_NO;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete nocontrol ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.nocontrol GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select NO_CO_CODE,NO_CODE,NO_DESC,NO_STA_NO,NO_SEQ_NO from nocontrol ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			WongTung.Model.nocontrol model=new WongTung.Model.nocontrol();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.NO_CO_CODE=ds.Tables[0].Rows[0]["NO_CO_CODE"].ToString();
				model.NO_CODE=ds.Tables[0].Rows[0]["NO_CODE"].ToString();
				model.NO_DESC=ds.Tables[0].Rows[0]["NO_DESC"].ToString();
				if(ds.Tables[0].Rows[0]["NO_STA_NO"].ToString()!="")
				{
					model.NO_STA_NO=decimal.Parse(ds.Tables[0].Rows[0]["NO_STA_NO"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NO_SEQ_NO"].ToString()!="")
				{
					model.NO_SEQ_NO=decimal.Parse(ds.Tables[0].Rows[0]["NO_SEQ_NO"].ToString());
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
			strSql.Append("select NO_CO_CODE,NO_CODE,NO_DESC,NO_STA_NO,NO_SEQ_NO ");
			strSql.Append(" FROM nocontrol ");
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
			parameters[0].Value = "nocontrol";
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

