using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using WongTung.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace WongTung.MySQLDAL
{
	/// <summary>
	/// 数据访问类plan_pos。
	/// </summary>
	public class plan_pos:Iplan_pos
	{
		public plan_pos()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PLA_POS_CO,string PLA_POS_OFF,string PLA_POS_CODE)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from plan_pos");
			strSql.Append(" where PLA_POS_CO=@PLA_POS_CO and PLA_POS_OFF=@PLA_POS_OFF and PLA_POS_CODE=@PLA_POS_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PLA_POS_CO", MySqlDbType.Char,50),
					new MySqlParameter("@PLA_POS_OFF", MySqlDbType.Char,50),
					new MySqlParameter("@PLA_POS_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = PLA_POS_CO;
			parameters[1].Value = PLA_POS_OFF;
			parameters[2].Value = PLA_POS_CODE;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(WongTung.Model.plan_pos model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into plan_pos(");
			strSql.Append("PLA_POS_CO,PLA_POS_OFF,PLA_POS_CODE,PLA_POS_NUM,PLA_POS_NOR,PLA_POS_OT1,PLA_POS_OT2,PLA_POS_OT3,PLA_POS_T1,PLA_POS_T2,PLA_POS_T3)");
			strSql.Append(" values (");
			strSql.Append("@PLA_POS_CO,@PLA_POS_OFF,@PLA_POS_CODE,@PLA_POS_NUM,@PLA_POS_NOR,@PLA_POS_OT1,@PLA_POS_OT2,@PLA_POS_OT3,@PLA_POS_T1,@PLA_POS_T2,@PLA_POS_T3)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PLA_POS_CO", MySqlDbType.Char,3),
					new MySqlParameter("@PLA_POS_OFF", MySqlDbType.Char,3),
					new MySqlParameter("@PLA_POS_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@PLA_POS_NUM", MySqlDbType.Int32,1),
					new MySqlParameter("@PLA_POS_NOR", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_POS_OT1", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_POS_OT2", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_POS_OT3", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_POS_T1", MySqlDbType.Decimal,2),
					new MySqlParameter("@PLA_POS_T2", MySqlDbType.Decimal,2),
					new MySqlParameter("@PLA_POS_T3", MySqlDbType.Decimal,2)};
			parameters[0].Value = model.PLA_POS_CO;
			parameters[1].Value = model.PLA_POS_OFF;
			parameters[2].Value = model.PLA_POS_CODE;
			parameters[3].Value = model.PLA_POS_NUM;
			parameters[4].Value = model.PLA_POS_NOR;
			parameters[5].Value = model.PLA_POS_OT1;
			parameters[6].Value = model.PLA_POS_OT2;
			parameters[7].Value = model.PLA_POS_OT3;
			parameters[8].Value = model.PLA_POS_T1;
			parameters[9].Value = model.PLA_POS_T2;
			parameters[10].Value = model.PLA_POS_T3;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(WongTung.Model.plan_pos model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update plan_pos set ");
			strSql.Append("PLA_POS_NUM=@PLA_POS_NUM,");
			strSql.Append("PLA_POS_NOR=@PLA_POS_NOR,");
			strSql.Append("PLA_POS_OT1=@PLA_POS_OT1,");
			strSql.Append("PLA_POS_OT2=@PLA_POS_OT2,");
			strSql.Append("PLA_POS_OT3=@PLA_POS_OT3,");
			strSql.Append("PLA_POS_T1=@PLA_POS_T1,");
			strSql.Append("PLA_POS_T2=@PLA_POS_T2,");
			strSql.Append("PLA_POS_T3=@PLA_POS_T3");
			strSql.Append(" where PLA_POS_CO=@PLA_POS_CO and PLA_POS_OFF=@PLA_POS_OFF and PLA_POS_CODE=@PLA_POS_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PLA_POS_CO", MySqlDbType.Char,3),
					new MySqlParameter("@PLA_POS_OFF", MySqlDbType.Char,3),
					new MySqlParameter("@PLA_POS_CODE", MySqlDbType.Char,3),
					new MySqlParameter("@PLA_POS_NUM", MySqlDbType.Int32,1),
					new MySqlParameter("@PLA_POS_NOR", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_POS_OT1", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_POS_OT2", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_POS_OT3", MySqlDbType.Decimal,18),
					new MySqlParameter("@PLA_POS_T1", MySqlDbType.Decimal,2),
					new MySqlParameter("@PLA_POS_T2", MySqlDbType.Decimal,2),
					new MySqlParameter("@PLA_POS_T3", MySqlDbType.Decimal,2)};
			parameters[0].Value = model.PLA_POS_CO;
			parameters[1].Value = model.PLA_POS_OFF;
			parameters[2].Value = model.PLA_POS_CODE;
			parameters[3].Value = model.PLA_POS_NUM;
			parameters[4].Value = model.PLA_POS_NOR;
			parameters[5].Value = model.PLA_POS_OT1;
			parameters[6].Value = model.PLA_POS_OT2;
			parameters[7].Value = model.PLA_POS_OT3;
			parameters[8].Value = model.PLA_POS_T1;
			parameters[9].Value = model.PLA_POS_T2;
			parameters[10].Value = model.PLA_POS_T3;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string PLA_POS_CO,string PLA_POS_OFF,string PLA_POS_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete plan_pos ");
			strSql.Append(" where PLA_POS_CO=@PLA_POS_CO and PLA_POS_OFF=@PLA_POS_OFF and PLA_POS_CODE=@PLA_POS_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PLA_POS_CO", MySqlDbType.Char,50),
					new MySqlParameter("@PLA_POS_OFF", MySqlDbType.Char,50),
					new MySqlParameter("@PLA_POS_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = PLA_POS_CO;
			parameters[1].Value = PLA_POS_OFF;
			parameters[2].Value = PLA_POS_CODE;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public WongTung.Model.plan_pos GetModel(string PLA_POS_CO,string PLA_POS_OFF,string PLA_POS_CODE)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PLA_POS_CO,PLA_POS_OFF,PLA_POS_CODE,PLA_POS_NUM,PLA_POS_NOR,PLA_POS_OT1,PLA_POS_OT2,PLA_POS_OT3,PLA_POS_T1,PLA_POS_T2,PLA_POS_T3 from plan_pos ");
			strSql.Append(" where PLA_POS_CO=@PLA_POS_CO and PLA_POS_OFF=@PLA_POS_OFF and PLA_POS_CODE=@PLA_POS_CODE ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PLA_POS_CO", MySqlDbType.Char,50),
					new MySqlParameter("@PLA_POS_OFF", MySqlDbType.Char,50),
					new MySqlParameter("@PLA_POS_CODE", MySqlDbType.Char,50)};
			parameters[0].Value = PLA_POS_CO;
			parameters[1].Value = PLA_POS_OFF;
			parameters[2].Value = PLA_POS_CODE;

			WongTung.Model.plan_pos model=new WongTung.Model.plan_pos();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.PLA_POS_CO=ds.Tables[0].Rows[0]["PLA_POS_CO"].ToString();
				model.PLA_POS_OFF=ds.Tables[0].Rows[0]["PLA_POS_OFF"].ToString();
				model.PLA_POS_CODE=ds.Tables[0].Rows[0]["PLA_POS_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["PLA_POS_NUM"].ToString()!="")
				{
					model.PLA_POS_NUM=int.Parse(ds.Tables[0].Rows[0]["PLA_POS_NUM"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PLA_POS_NOR"].ToString()!="")
				{
					model.PLA_POS_NOR=decimal.Parse(ds.Tables[0].Rows[0]["PLA_POS_NOR"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PLA_POS_OT1"].ToString()!="")
				{
					model.PLA_POS_OT1=decimal.Parse(ds.Tables[0].Rows[0]["PLA_POS_OT1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PLA_POS_OT2"].ToString()!="")
				{
					model.PLA_POS_OT2=decimal.Parse(ds.Tables[0].Rows[0]["PLA_POS_OT2"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PLA_POS_OT3"].ToString()!="")
				{
					model.PLA_POS_OT3=decimal.Parse(ds.Tables[0].Rows[0]["PLA_POS_OT3"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PLA_POS_T1"].ToString()!="")
				{
					model.PLA_POS_T1=decimal.Parse(ds.Tables[0].Rows[0]["PLA_POS_T1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PLA_POS_T2"].ToString()!="")
				{
					model.PLA_POS_T2=decimal.Parse(ds.Tables[0].Rows[0]["PLA_POS_T2"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PLA_POS_T3"].ToString()!="")
				{
					model.PLA_POS_T3=decimal.Parse(ds.Tables[0].Rows[0]["PLA_POS_T3"].ToString());
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
			strSql.Append("select PLA_POS_CO,PLA_POS_OFF,PLA_POS_CODE,PLA_POS_NUM,PLA_POS_NOR,PLA_POS_OT1,PLA_POS_OT2,PLA_POS_OT3,PLA_POS_T1,PLA_POS_T2,PLA_POS_T3 ");
			strSql.Append(" FROM plan_pos ");
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
			parameters[0].Value = "plan_pos";
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

