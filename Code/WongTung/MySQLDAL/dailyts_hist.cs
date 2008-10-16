using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//������������
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// ���ݷ�����dailyts_hist��
	/// </summary>
	public class dailyts_hist:Idailyts_hist
	{
		public dailyts_hist()
		{}
		#region  ��Ա����



		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(WongTung.Model.dailyts_hist model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dailyts_hist(");
			strSql.Append("DT_CO_CODE,DT_STAFF_CODE,DT_WORK_DATE,DT_LINE_NO,DT_APP_CODE,DT_JOB_CODE,DT_SER_CODE,DT_NOR_HOUR,DT_OVER_HOUR,DT_TYPE,DT_PERIOD,DT_SUBMIT)");
			strSql.Append(" values (");
			strSql.Append("@DT_CO_CODE,@DT_STAFF_CODE,@DT_WORK_DATE,@DT_LINE_NO,@DT_APP_CODE,@DT_JOB_CODE,@DT_SER_CODE,@DT_NOR_HOUR,@DT_OVER_HOUR,@DT_TYPE,@DT_PERIOD,@DT_SUBMIT)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@DT_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@DT_STAFF_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@DT_WORK_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@DT_LINE_NO", MySqlDbType.Decimal,18),
					new MySqlParameter("@DT_APP_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@DT_JOB_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@DT_SER_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@DT_NOR_HOUR", MySqlDbType.Decimal,18),
					new MySqlParameter("@DT_OVER_HOUR", MySqlDbType.Decimal,18),
					new MySqlParameter("@DT_TYPE", MySqlDbType.Char,1),
					new MySqlParameter("@DT_PERIOD", MySqlDbType.Char,16),
					new MySqlParameter("@DT_SUBMIT", MySqlDbType.Char,1)};
			parameters[0].Value = model.DT_CO_CODE;
			parameters[1].Value = model.DT_STAFF_CODE;
			parameters[2].Value = model.DT_WORK_DATE;
			parameters[3].Value = model.DT_LINE_NO;
			parameters[4].Value = model.DT_APP_CODE;
			parameters[5].Value = model.DT_JOB_CODE;
			parameters[6].Value = model.DT_SER_CODE;
			parameters[7].Value = model.DT_NOR_HOUR;
			parameters[8].Value = model.DT_OVER_HOUR;
			parameters[9].Value = model.DT_TYPE;
			parameters[10].Value = model.DT_PERIOD;
			parameters[11].Value = model.DT_SUBMIT;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(WongTung.Model.dailyts_hist model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dailyts_hist set ");
			strSql.Append("DT_CO_CODE=@DT_CO_CODE,");
			strSql.Append("DT_STAFF_CODE=@DT_STAFF_CODE,");
			strSql.Append("DT_WORK_DATE=@DT_WORK_DATE,");
			strSql.Append("DT_LINE_NO=@DT_LINE_NO,");
			strSql.Append("DT_APP_CODE=@DT_APP_CODE,");
			strSql.Append("DT_JOB_CODE=@DT_JOB_CODE,");
			strSql.Append("DT_SER_CODE=@DT_SER_CODE,");
			strSql.Append("DT_NOR_HOUR=@DT_NOR_HOUR,");
			strSql.Append("DT_OVER_HOUR=@DT_OVER_HOUR,");
			strSql.Append("DT_TYPE=@DT_TYPE,");
			strSql.Append("DT_PERIOD=@DT_PERIOD,");
			strSql.Append("DT_SUBMIT=@DT_SUBMIT");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@DT_CO_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@DT_STAFF_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@DT_WORK_DATE", MySqlDbType.DateTime),
					new MySqlParameter("@DT_LINE_NO", MySqlDbType.Decimal,18),
					new MySqlParameter("@DT_APP_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@DT_JOB_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@DT_SER_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@DT_NOR_HOUR", MySqlDbType.Decimal,18),
					new MySqlParameter("@DT_OVER_HOUR", MySqlDbType.Decimal,18),
					new MySqlParameter("@DT_TYPE", MySqlDbType.Char,1),
					new MySqlParameter("@DT_PERIOD", MySqlDbType.Char,16),
					new MySqlParameter("@DT_SUBMIT", MySqlDbType.Char,1)};
			parameters[0].Value = model.DT_CO_CODE;
			parameters[1].Value = model.DT_STAFF_CODE;
			parameters[2].Value = model.DT_WORK_DATE;
			parameters[3].Value = model.DT_LINE_NO;
			parameters[4].Value = model.DT_APP_CODE;
			parameters[5].Value = model.DT_JOB_CODE;
			parameters[6].Value = model.DT_SER_CODE;
			parameters[7].Value = model.DT_NOR_HOUR;
			parameters[8].Value = model.DT_OVER_HOUR;
			parameters[9].Value = model.DT_TYPE;
			parameters[10].Value = model.DT_PERIOD;
			parameters[11].Value = model.DT_SUBMIT;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete()
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete dailyts_hist ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public WongTung.Model.dailyts_hist GetModel()
		{
			//�ñ���������Ϣ�����Զ�������/�����ֶ�
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DT_CO_CODE,DT_STAFF_CODE,DT_WORK_DATE,DT_LINE_NO,DT_APP_CODE,DT_JOB_CODE,DT_SER_CODE,DT_NOR_HOUR,DT_OVER_HOUR,DT_TYPE,DT_PERIOD,DT_SUBMIT from dailyts_hist ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
};

			WongTung.Model.dailyts_hist model=new WongTung.Model.dailyts_hist();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.DT_CO_CODE=ds.Tables[0].Rows[0]["DT_CO_CODE"].ToString();
				model.DT_STAFF_CODE=ds.Tables[0].Rows[0]["DT_STAFF_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["DT_WORK_DATE"].ToString()!="")
				{
					model.DT_WORK_DATE=DateTime.Parse(ds.Tables[0].Rows[0]["DT_WORK_DATE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_LINE_NO"].ToString()!="")
				{
					model.DT_LINE_NO=decimal.Parse(ds.Tables[0].Rows[0]["DT_LINE_NO"].ToString());
				}
				model.DT_APP_CODE=ds.Tables[0].Rows[0]["DT_APP_CODE"].ToString();
				model.DT_JOB_CODE=ds.Tables[0].Rows[0]["DT_JOB_CODE"].ToString();
				model.DT_SER_CODE=ds.Tables[0].Rows[0]["DT_SER_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["DT_NOR_HOUR"].ToString()!="")
				{
					model.DT_NOR_HOUR=decimal.Parse(ds.Tables[0].Rows[0]["DT_NOR_HOUR"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DT_OVER_HOUR"].ToString()!="")
				{
					model.DT_OVER_HOUR=decimal.Parse(ds.Tables[0].Rows[0]["DT_OVER_HOUR"].ToString());
				}
				model.DT_TYPE=ds.Tables[0].Rows[0]["DT_TYPE"].ToString();
				model.DT_PERIOD=ds.Tables[0].Rows[0]["DT_PERIOD"].ToString();
				model.DT_SUBMIT=ds.Tables[0].Rows[0]["DT_SUBMIT"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DT_CO_CODE,DT_STAFF_CODE,DT_WORK_DATE,DT_LINE_NO,DT_APP_CODE,DT_JOB_CODE,DT_SER_CODE,DT_NOR_HOUR,DT_OVER_HOUR,DT_TYPE,DT_PERIOD,DT_SUBMIT ");
			strSql.Append(" FROM dailyts_hist ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "dailyts_hist";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����
	}
}
