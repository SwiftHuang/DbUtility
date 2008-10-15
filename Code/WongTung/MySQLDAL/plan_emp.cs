using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类plan_emp。
	/// </summary>
	public class plan_emp:Iplan_emp
	{
		public plan_emp()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PLA_EMP_CO,string PLA_EMP_OFF,string PLA_EMP_POS,string PLA_EMP_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from plan_emp");
			strSql.Append(" where PLA_EMP_CO=@PLA_EMP_CO and PLA_EMP_OFF=@PLA_EMP_OFF and PLA_EMP_POS=@PLA_EMP_POS and PLA_EMP_CODE=@PLA_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PLA_EMP_CO", MySqlDbType.Char,50),
					new MySqlParameter("@PLA_EMP_OFF", MySqlDbType.Char,50),
					new MySqlParameter("@PLA_EMP_POS", MySqlDbType.Char,50),
					new MySqlParameter("@PLA_EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = PLA_EMP_CO;
			parameters[1].Value = PLA_EMP_OFF;
			parameters[2].Value = PLA_EMP_POS;
			parameters[3].Value = PLA_EMP_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.plan_emp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into plan_emp(");
			strSql.Append("PLA_EMP_CO,PLA_EMP_OFF,PLA_EMP_POS,PLA_EMP_CODE,PLA_EMP_NUM,PLA_EMP_NOR,PLA_EMP_OT1,PLA_EMP_OT2,PLA_EMP_OT3,PLA_EMP_T1,PLA_EMP_T2,PLA_EMP_T3)");
			strSql.Append(" values (");
			strSql.Append("@PLA_EMP_CO,@PLA_EMP_OFF,@PLA_EMP_POS,@PLA_EMP_CODE,@PLA_EMP_NUM,@PLA_EMP_NOR,@PLA_EMP_OT1,@PLA_EMP_OT2,@PLA_EMP_OT3,@PLA_EMP_T1,@PLA_EMP_T2,@PLA_EMP_T3)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PLA_EMP_CO", MySqlDbType.Char,3),
					new MySqlParameter("@PLA_EMP_OFF", MySqlDbType.Char,3),
					new MySqlParameter("@PLA_EMP_POS", MySqlDbType.Char,3),
					new MySqlParameter("@PLA_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@PLA_EMP_NUM", MySqlDbType.Int32,1),
					new MySqlParameter("@PLA_EMP_NOR", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_EMP_OT1", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_EMP_OT2", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_EMP_OT3", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_EMP_T1", MySqlDbType.Decimal,2),
					new MySqlParameter("@PLA_EMP_T2", MySqlDbType.Decimal,2),
					new MySqlParameter("@PLA_EMP_T3", MySqlDbType.Decimal,2)};
			parameters[0].Value = model.PLA_EMP_CO;
			parameters[1].Value = model.PLA_EMP_OFF;
			parameters[2].Value = model.PLA_EMP_POS;
			parameters[3].Value = model.PLA_EMP_CODE;
			parameters[4].Value = model.PLA_EMP_NUM;
			parameters[5].Value = model.PLA_EMP_NOR;
			parameters[6].Value = model.PLA_EMP_OT1;
			parameters[7].Value = model.PLA_EMP_OT2;
			parameters[8].Value = model.PLA_EMP_OT3;
			parameters[9].Value = model.PLA_EMP_T1;
			parameters[10].Value = model.PLA_EMP_T2;
			parameters[11].Value = model.PLA_EMP_T3;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.plan_emp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update plan_emp set ");
			strSql.Append("PLA_EMP_NUM=@PLA_EMP_NUM,");
			strSql.Append("PLA_EMP_NOR=@PLA_EMP_NOR,");
			strSql.Append("PLA_EMP_OT1=@PLA_EMP_OT1,");
			strSql.Append("PLA_EMP_OT2=@PLA_EMP_OT2,");
			strSql.Append("PLA_EMP_OT3=@PLA_EMP_OT3,");
			strSql.Append("PLA_EMP_T1=@PLA_EMP_T1,");
			strSql.Append("PLA_EMP_T2=@PLA_EMP_T2,");
			strSql.Append("PLA_EMP_T3=@PLA_EMP_T3");
			strSql.Append(" where PLA_EMP_CO=@PLA_EMP_CO and PLA_EMP_OFF=@PLA_EMP_OFF and PLA_EMP_POS=@PLA_EMP_POS and PLA_EMP_CODE=@PLA_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PLA_EMP_CO", MySqlDbType.Char,3),
					new MySqlParameter("@PLA_EMP_OFF", MySqlDbType.Char,3),
					new MySqlParameter("@PLA_EMP_POS", MySqlDbType.Char,3),
					new MySqlParameter("@PLA_EMP_CODE", MySqlDbType.Char,6),
					new MySqlParameter("@PLA_EMP_NUM", MySqlDbType.Int32,1),
					new MySqlParameter("@PLA_EMP_NOR", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_EMP_OT1", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_EMP_OT2", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_EMP_OT3", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_EMP_T1", MySqlDbType.Decimal,2),
					new MySqlParameter("@PLA_EMP_T2", MySqlDbType.Decimal,2),
					new MySqlParameter("@PLA_EMP_T3", MySqlDbType.Decimal,2)};
			parameters[0].Value = model.PLA_EMP_CO;
			parameters[1].Value = model.PLA_EMP_OFF;
			parameters[2].Value = model.PLA_EMP_POS;
			parameters[3].Value = model.PLA_EMP_CODE;
			parameters[4].Value = model.PLA_EMP_NUM;
			parameters[5].Value = model.PLA_EMP_NOR;
			parameters[6].Value = model.PLA_EMP_OT1;
			parameters[7].Value = model.PLA_EMP_OT2;
			parameters[8].Value = model.PLA_EMP_OT3;
			parameters[9].Value = model.PLA_EMP_T1;
			parameters[10].Value = model.PLA_EMP_T2;
			parameters[11].Value = model.PLA_EMP_T3;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string PLA_EMP_CO,string PLA_EMP_OFF,string PLA_EMP_POS,string PLA_EMP_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete plan_emp ");
			strSql.Append(" where PLA_EMP_CO=@PLA_EMP_CO and PLA_EMP_OFF=@PLA_EMP_OFF and PLA_EMP_POS=@PLA_EMP_POS and PLA_EMP_CODE=@PLA_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PLA_EMP_CO", MySqlDbType.Char,50),
					new MySqlParameter("@PLA_EMP_OFF", MySqlDbType.Char,50),
					new MySqlParameter("@PLA_EMP_POS", MySqlDbType.Char,50),
					new MySqlParameter("@PLA_EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = PLA_EMP_CO;
			parameters[1].Value = PLA_EMP_OFF;
			parameters[2].Value = PLA_EMP_POS;
			parameters[3].Value = PLA_EMP_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.plan_emp GetModel(string PLA_EMP_CO,string PLA_EMP_OFF,string PLA_EMP_POS,string PLA_EMP_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PLA_EMP_CO,PLA_EMP_OFF,PLA_EMP_POS,PLA_EMP_CODE,PLA_EMP_NUM,PLA_EMP_NOR,PLA_EMP_OT1,PLA_EMP_OT2,PLA_EMP_OT3,PLA_EMP_T1,PLA_EMP_T2,PLA_EMP_T3 from plan_emp ");
			strSql.Append(" where PLA_EMP_CO=@PLA_EMP_CO and PLA_EMP_OFF=@PLA_EMP_OFF and PLA_EMP_POS=@PLA_EMP_POS and PLA_EMP_CODE=@PLA_EMP_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PLA_EMP_CO", MySqlDbType.Char,50),
					new MySqlParameter("@PLA_EMP_OFF", MySqlDbType.Char,50),
					new MySqlParameter("@PLA_EMP_POS", MySqlDbType.Char,50),
					new MySqlParameter("@PLA_EMP_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = PLA_EMP_CO;
			parameters[1].Value = PLA_EMP_OFF;
			parameters[2].Value = PLA_EMP_POS;
			parameters[3].Value = PLA_EMP_CODE;

			WongTung.Model.plan_emp model=new WongTung.Model.plan_emp();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.PLA_EMP_CO=ds.Tables[0].Rows[0]["PLA_EMP_CO"].ToString();
				model.PLA_EMP_OFF=ds.Tables[0].Rows[0]["PLA_EMP_OFF"].ToString();
				model.PLA_EMP_POS=ds.Tables[0].Rows[0]["PLA_EMP_POS"].ToString();
				model.PLA_EMP_CODE=ds.Tables[0].Rows[0]["PLA_EMP_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["PLA_EMP_NUM"].ToString()!="")
				{
					model.PLA_EMP_NUM=int.Parse(ds.Tables[0].Rows[0]["PLA_EMP_NUM"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PLA_EMP_NOR"].ToString()!="")
				{
					model.PLA_EMP_NOR=decimal.Parse(ds.Tables[0].Rows[0]["PLA_EMP_NOR"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PLA_EMP_OT1"].ToString()!="")
				{
					model.PLA_EMP_OT1=decimal.Parse(ds.Tables[0].Rows[0]["PLA_EMP_OT1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PLA_EMP_OT2"].ToString()!="")
				{
					model.PLA_EMP_OT2=decimal.Parse(ds.Tables[0].Rows[0]["PLA_EMP_OT2"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PLA_EMP_OT3"].ToString()!="")
				{
					model.PLA_EMP_OT3=decimal.Parse(ds.Tables[0].Rows[0]["PLA_EMP_OT3"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PLA_EMP_T1"].ToString()!="")
				{
					model.PLA_EMP_T1=decimal.Parse(ds.Tables[0].Rows[0]["PLA_EMP_T1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PLA_EMP_T2"].ToString()!="")
				{
					model.PLA_EMP_T2=decimal.Parse(ds.Tables[0].Rows[0]["PLA_EMP_T2"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PLA_EMP_T3"].ToString()!="")
				{
					model.PLA_EMP_T3=decimal.Parse(ds.Tables[0].Rows[0]["PLA_EMP_T3"].ToString());
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
			strSql.Append("select PLA_EMP_CO,PLA_EMP_OFF,PLA_EMP_POS,PLA_EMP_CODE,PLA_EMP_NUM,PLA_EMP_NOR,PLA_EMP_OT1,PLA_EMP_OT2,PLA_EMP_OT3,PLA_EMP_T1,PLA_EMP_T2,PLA_EMP_T3 ");
			strSql.Append(" FROM plan_emp ");
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
			parameters[0].Value = "plan_emp";
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

