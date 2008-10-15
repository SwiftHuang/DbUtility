using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类temp_day_inq。
	/// </summary>
	public class temp_day_inq:Itemp_day_inq
	{
		public temp_day_inq()
		{}
		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.temp_day_inq model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into temp_day_inq(");
			strSql.Append("TEM_CO_CODE,TEM_STAFF_CODE,TEM_WORK_DATE,TEM_LINE_NO,TEM_HOUR_TYPE,TEM_APP_CODE,TEM_SER_CODE,TEM_JOB_CODE,TEM_NOR_HOUR_0,TEM_NOR_HOUR_1,TEM_NOR_HOUR_2,TEM_NOR_HOUR_3,TEM_NOR_HOUR_4,TEM_NOR_HOUR_5,TEM_NOR_HOUR_6,TEM_TYPE,TEM_APP_FLAG)");
			strSql.Append(" values (");
			strSql.Append("@TEM_CO_CODE,@TEM_STAFF_CODE,@TEM_WORK_DATE,@TEM_LINE_NO,@TEM_HOUR_TYPE,@TEM_APP_CODE,@TEM_SER_CODE,@TEM_JOB_CODE,@TEM_NOR_HOUR_0,@TEM_NOR_HOUR_1,@TEM_NOR_HOUR_2,@TEM_NOR_HOUR_3,@TEM_NOR_HOUR_4,@TEM_NOR_HOUR_5,@TEM_NOR_HOUR_6,@TEM_TYPE,@TEM_APP_FLAG)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@TEM_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@TEM_STAFF_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@TEM_WORK_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@TEM_LINE_NO", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_HOUR_TYPE", MySqlDbType.Char,1),
					new MySqlParameter("@TEM_APP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@TEM_SER_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@TEM_JOB_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@TEM_NOR_HOUR_0", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_NOR_HOUR_1", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_NOR_HOUR_2", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_NOR_HOUR_3", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_NOR_HOUR_4", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_NOR_HOUR_5", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_NOR_HOUR_6", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_TYPE", MySqlDbType.Char,1),
					new MySqlParameter("@TEM_APP_FLAG", MySqlDbType.Char,1)};
			parameters[0].Value = model.TEM_CO_CODE;
			parameters[1].Value = model.TEM_STAFF_CODE;
			parameters[2].Value = model.TEM_WORK_DATE;
			parameters[3].Value = model.TEM_LINE_NO;
			parameters[4].Value = model.TEM_HOUR_TYPE;
			parameters[5].Value = model.TEM_APP_CODE;
			parameters[6].Value = model.TEM_SER_CODE;
			parameters[7].Value = model.TEM_JOB_CODE;
			parameters[8].Value = model.TEM_NOR_HOUR_0;
			parameters[9].Value = model.TEM_NOR_HOUR_1;
			parameters[10].Value = model.TEM_NOR_HOUR_2;
			parameters[11].Value = model.TEM_NOR_HOUR_3;
			parameters[12].Value = model.TEM_NOR_HOUR_4;
			parameters[13].Value = model.TEM_NOR_HOUR_5;
			parameters[14].Value = model.TEM_NOR_HOUR_6;
			parameters[15].Value = model.TEM_TYPE;
			parameters[16].Value = model.TEM_APP_FLAG;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.temp_day_inq model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update temp_day_inq set ");
			strSql.Append("TEM_CO_CODE=@TEM_CO_CODE,");
			strSql.Append("TEM_STAFF_CODE=@TEM_STAFF_CODE,");
			strSql.Append("TEM_WORK_DATE=@TEM_WORK_DATE,");
			strSql.Append("TEM_LINE_NO=@TEM_LINE_NO,");
			strSql.Append("TEM_HOUR_TYPE=@TEM_HOUR_TYPE,");
			strSql.Append("TEM_APP_CODE=@TEM_APP_CODE,");
			strSql.Append("TEM_SER_CODE=@TEM_SER_CODE,");
			strSql.Append("TEM_JOB_CODE=@TEM_JOB_CODE,");
			strSql.Append("TEM_NOR_HOUR_0=@TEM_NOR_HOUR_0,");
			strSql.Append("TEM_NOR_HOUR_1=@TEM_NOR_HOUR_1,");
			strSql.Append("TEM_NOR_HOUR_2=@TEM_NOR_HOUR_2,");
			strSql.Append("TEM_NOR_HOUR_3=@TEM_NOR_HOUR_3,");
			strSql.Append("TEM_NOR_HOUR_4=@TEM_NOR_HOUR_4,");
			strSql.Append("TEM_NOR_HOUR_5=@TEM_NOR_HOUR_5,");
			strSql.Append("TEM_NOR_HOUR_6=@TEM_NOR_HOUR_6,");
			strSql.Append("TEM_TYPE=@TEM_TYPE,");
			strSql.Append("TEM_APP_FLAG=@TEM_APP_FLAG");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@TEM_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@TEM_STAFF_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@TEM_WORK_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@TEM_LINE_NO", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_HOUR_TYPE", MySqlDbType.Char,1),
					new MySqlParameter("@TEM_APP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@TEM_SER_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@TEM_JOB_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@TEM_NOR_HOUR_0", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_NOR_HOUR_1", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_NOR_HOUR_2", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_NOR_HOUR_3", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_NOR_HOUR_4", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_NOR_HOUR_5", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_NOR_HOUR_6", MySqlDbType.Decimal,18),
					new MySqlParameter("@TEM_TYPE", MySqlDbType.Char,1),
					new MySqlParameter("@TEM_APP_FLAG", MySqlDbType.Char,1)};
			parameters[0].Value = model.TEM_CO_CODE;
			parameters[1].Value = model.TEM_STAFF_CODE;
			parameters[2].Value = model.TEM_WORK_DATE;
			parameters[3].Value = model.TEM_LINE_NO;
			parameters[4].Value = model.TEM_HOUR_TYPE;
			parameters[5].Value = model.TEM_APP_CODE;
			parameters[6].Value = model.TEM_SER_CODE;
			parameters[7].Value = model.TEM_JOB_CODE;
			parameters[8].Value = model.TEM_NOR_HOUR_0;
			parameters[9].Value = model.TEM_NOR_HOUR_1;
			parameters[10].Value = model.TEM_NOR_HOUR_2;
			parameters[11].Value = model.TEM_NOR_HOUR_3;
			parameters[12].Value = model.TEM_NOR_HOUR_4;
			parameters[13].Value = model.TEM_NOR_HOUR_5;
			parameters[14].Value = model.TEM_NOR_HOUR_6;
			parameters[15].Value = model.TEM_TYPE;
			parameters[16].Value = model.TEM_APP_FLAG;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete temp_day_inq ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.temp_day_inq GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TEM_CO_CODE,TEM_STAFF_CODE,TEM_WORK_DATE,TEM_LINE_NO,TEM_HOUR_TYPE,TEM_APP_CODE,TEM_SER_CODE,TEM_JOB_CODE,TEM_NOR_HOUR_0,TEM_NOR_HOUR_1,TEM_NOR_HOUR_2,TEM_NOR_HOUR_3,TEM_NOR_HOUR_4,TEM_NOR_HOUR_5,TEM_NOR_HOUR_6,TEM_TYPE,TEM_APP_FLAG from temp_day_inq ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			WongTung.Model.temp_day_inq model=new WongTung.Model.temp_day_inq();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.TEM_CO_CODE=ds.Tables[0].Rows[0]["TEM_CO_CODE"].ToString();
				model.TEM_STAFF_CODE=ds.Tables[0].Rows[0]["TEM_STAFF_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["TEM_WORK_DATE"].ToString()!="")
				{
					model.TEM_WORK_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["TEM_WORK_DATE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TEM_LINE_NO"].ToString()!="")
				{
					model.TEM_LINE_NO=decimal.Parse(ds.Tables[0].Rows[0]["TEM_LINE_NO"].ToString());
				}
				model.TEM_HOUR_TYPE=ds.Tables[0].Rows[0]["TEM_HOUR_TYPE"].ToString();
				model.TEM_APP_CODE=ds.Tables[0].Rows[0]["TEM_APP_CODE"].ToString();
				model.TEM_SER_CODE=ds.Tables[0].Rows[0]["TEM_SER_CODE"].ToString();
				model.TEM_JOB_CODE=ds.Tables[0].Rows[0]["TEM_JOB_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["TEM_NOR_HOUR_0"].ToString()!="")
				{
					model.TEM_NOR_HOUR_0=decimal.Parse(ds.Tables[0].Rows[0]["TEM_NOR_HOUR_0"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TEM_NOR_HOUR_1"].ToString()!="")
				{
					model.TEM_NOR_HOUR_1=decimal.Parse(ds.Tables[0].Rows[0]["TEM_NOR_HOUR_1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TEM_NOR_HOUR_2"].ToString()!="")
				{
					model.TEM_NOR_HOUR_2=decimal.Parse(ds.Tables[0].Rows[0]["TEM_NOR_HOUR_2"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TEM_NOR_HOUR_3"].ToString()!="")
				{
					model.TEM_NOR_HOUR_3=decimal.Parse(ds.Tables[0].Rows[0]["TEM_NOR_HOUR_3"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TEM_NOR_HOUR_4"].ToString()!="")
				{
					model.TEM_NOR_HOUR_4=decimal.Parse(ds.Tables[0].Rows[0]["TEM_NOR_HOUR_4"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TEM_NOR_HOUR_5"].ToString()!="")
				{
					model.TEM_NOR_HOUR_5=decimal.Parse(ds.Tables[0].Rows[0]["TEM_NOR_HOUR_5"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TEM_NOR_HOUR_6"].ToString()!="")
				{
					model.TEM_NOR_HOUR_6=decimal.Parse(ds.Tables[0].Rows[0]["TEM_NOR_HOUR_6"].ToString());
				}
				model.TEM_TYPE=ds.Tables[0].Rows[0]["TEM_TYPE"].ToString();
				model.TEM_APP_FLAG=ds.Tables[0].Rows[0]["TEM_APP_FLAG"].ToString();
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
			strSql.Append("select TEM_CO_CODE,TEM_STAFF_CODE,TEM_WORK_DATE,TEM_LINE_NO,TEM_HOUR_TYPE,TEM_APP_CODE,TEM_SER_CODE,TEM_JOB_CODE,TEM_NOR_HOUR_0,TEM_NOR_HOUR_1,TEM_NOR_HOUR_2,TEM_NOR_HOUR_3,TEM_NOR_HOUR_4,TEM_NOR_HOUR_5,TEM_NOR_HOUR_6,TEM_TYPE,TEM_APP_FLAG ");
			strSql.Append(" FROM temp_day_inq ");
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
			parameters[0].Value = "temp_day_inq";
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

