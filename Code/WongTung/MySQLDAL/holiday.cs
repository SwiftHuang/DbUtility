using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类holiday。
	/// </summary>
	public class holiday:Iholiday
	{
		public holiday()
		{}
		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.holiday model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into holiday(");
			strSql.Append("HD_CO_CODE,HD_EMP_CODE,HD_LINE_NO,HD_DATE,HD_LEVE_CODE)");
			strSql.Append(" values (");
			strSql.Append("@HD_CO_CODE,@HD_EMP_CODE,@HD_LINE_NO,@HD_DATE,@HD_LEVE_CODE)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@HD_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@HD_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@HD_LINE_NO", MySqlDbType.Decimal,18),
					new MySqlParameter("@HD_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@HD_LEVE_CODE", MySqlDbType.Char,3)};
			parameters[0].Value = model.HD_CO_CODE;
			parameters[1].Value = model.HD_EMP_CODE;
			parameters[2].Value = model.HD_LINE_NO;
			parameters[3].Value = model.HD_DATE;
			parameters[4].Value = model.HD_LEVE_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.holiday model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update holiday set ");
			strSql.Append("HD_CO_CODE=@HD_CO_CODE,");
			strSql.Append("HD_EMP_CODE=@HD_EMP_CODE,");
			strSql.Append("HD_LINE_NO=@HD_LINE_NO,");
			strSql.Append("HD_DATE=@HD_DATE,");
			strSql.Append("HD_LEVE_CODE=@HD_LEVE_CODE");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@HD_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@HD_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@HD_LINE_NO", MySqlDbType.Decimal,18),
					new MySqlParameter("@HD_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@HD_LEVE_CODE", MySqlDbType.Char,3)};
			parameters[0].Value = model.HD_CO_CODE;
			parameters[1].Value = model.HD_EMP_CODE;
			parameters[2].Value = model.HD_LINE_NO;
			parameters[3].Value = model.HD_DATE;
			parameters[4].Value = model.HD_LEVE_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete holiday ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.holiday GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select HD_CO_CODE,HD_EMP_CODE,HD_LINE_NO,HD_DATE,HD_LEVE_CODE from holiday ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			WongTung.Model.holiday model=new WongTung.Model.holiday();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.HD_CO_CODE=ds.Tables[0].Rows[0]["HD_CO_CODE"].ToString();
				model.HD_EMP_CODE=ds.Tables[0].Rows[0]["HD_EMP_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["HD_LINE_NO"].ToString()!="")
				{
					model.HD_LINE_NO=decimal.Parse(ds.Tables[0].Rows[0]["HD_LINE_NO"].ToString());
				}
				if(ds.Tables[0].Rows[0]["HD_DATE"].ToString()!="")
				{
					model.HD_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["HD_DATE"].ToString());
				}
				model.HD_LEVE_CODE=ds.Tables[0].Rows[0]["HD_LEVE_CODE"].ToString();
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
			strSql.Append("select HD_CO_CODE,HD_EMP_CODE,HD_LINE_NO,HD_DATE,HD_LEVE_CODE ");
			strSql.Append(" FROM holiday ");
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
			parameters[0].Value = "holiday";
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

