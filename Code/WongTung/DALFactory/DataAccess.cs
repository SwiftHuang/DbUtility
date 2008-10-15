using System;
using System.Reflection;
using System.Configuration;
namespace WongTung.DALFactory
{
	/// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="Maticsoft.SQLServerDAL" />。
	/// </summary>
	public sealed class DataAccess
	{
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];        
		public DataAccess()
		{ }

        #region CreateObject 

		//不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath,string classNamespace)
		{		
			try
			{
				object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);	
				return objType;
			}
			catch//(System.Exception ex)
			{
				//string str=ex.Message;// 记录错误日志
				return null;
			}			
			
        }
		//使用缓存
		private static object CreateObject(string AssemblyPath,string classNamespace)
		{			
			object objType = DataCache.GetCache(classNamespace);
			if (objType == null)
			{
				try
				{
					objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);					
					DataCache.SetCache(classNamespace, objType);// 写入缓存
				}
				catch//(System.Exception ex)
				{
					//string str=ex.Message;// 记录错误日志
				}
			}
			return objType;
		}
        #endregion

        #region CreateSysManage
        public static WongTung.IDAL.ISysManage CreateSysManage()
		{
			//方式1			
			//return (WongTung.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");

			//方式2 			
			string classNamespace = AssemblyPath+".SysManage";	
			object objType=CreateObject(AssemblyPath,classNamespace);
            return (WongTung.IDAL.ISysManage)objType;		
		}
		#endregion
             
        
   
		/// <summary>
		/// 创建backdate数据层接口
		/// </summary>
		public static WongTung.IDAL.Ibackdate Createbackdate()
		{

			string ClassNamespace = AssemblyPath +".backdate";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Ibackdate)objType;
		}

		/// <summary>
		/// 创建backspecial数据层接口
		/// </summary>
		public static WongTung.IDAL.Ibackspecial Createbackspecial()
		{

			string ClassNamespace = AssemblyPath +".backspecial";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Ibackspecial)objType;
		}

		/// <summary>
		/// 创建bk_jobbud数据层接口
		/// </summary>
		public static WongTung.IDAL.Ibk_jobbud Createbk_jobbud()
		{

			string ClassNamespace = AssemblyPath +".bk_jobbud";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Ibk_jobbud)objType;
		}

		/// <summary>
		/// 创建budgetot数据层接口
		/// </summary>
		public static WongTung.IDAL.Ibudgetot Createbudgetot()
		{

			string ClassNamespace = AssemblyPath +".budgetot";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Ibudgetot)objType;
		}

		/// <summary>
		/// 创建changepw数据层接口
		/// </summary>
		public static WongTung.IDAL.Ichangepw Createchangepw()
		{

			string ClassNamespace = AssemblyPath +".changepw";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Ichangepw)objType;
		}

		/// <summary>
		/// 创建company数据层接口
		/// </summary>
		public static WongTung.IDAL.Icompany Createcompany()
		{

			string ClassNamespace = AssemblyPath +".company";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Icompany)objType;
		}

		/// <summary>
		/// 创建dailyts数据层接口
		/// </summary>
		public static WongTung.IDAL.Idailyts Createdailyts()
		{

			string ClassNamespace = AssemblyPath +".dailyts";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Idailyts)objType;
		}

		/// <summary>
		/// 创建dailyts_hist数据层接口
		/// </summary>
		public static WongTung.IDAL.Idailyts_hist Createdailyts_hist()
		{

			string ClassNamespace = AssemblyPath +".dailyts_hist";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Idailyts_hist)objType;
		}

		/// <summary>
		/// 创建department数据层接口
		/// </summary>
		public static WongTung.IDAL.Idepartment Createdepartment()
		{

			string ClassNamespace = AssemblyPath +".department";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Idepartment)objType;
		}

		/// <summary>
		/// 创建emp_day_tem数据层接口
		/// </summary>
		public static WongTung.IDAL.Iemp_day_tem Createemp_day_tem()
		{

			string ClassNamespace = AssemblyPath +".emp_day_tem";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iemp_day_tem)objType;
		}

		/// <summary>
		/// 创建emp_job_tem数据层接口
		/// </summary>
		public static WongTung.IDAL.Iemp_job_tem Createemp_job_tem()
		{

			string ClassNamespace = AssemblyPath +".emp_job_tem";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iemp_job_tem)objType;
		}

		/// <summary>
		/// 创建employee数据层接口
		/// </summary>
		public static WongTung.IDAL.Iemployee Createemployee()
		{

			string ClassNamespace = AssemblyPath +".employee";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iemployee)objType;
		}

		/// <summary>
		/// 创建holiday数据层接口
		/// </summary>
		public static WongTung.IDAL.Iholiday Createholiday()
		{

			string ClassNamespace = AssemblyPath +".holiday";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iholiday)objType;
		}

		/// <summary>
		/// 创建holiday_date数据层接口
		/// </summary>
		public static WongTung.IDAL.Iholiday_date Createholiday_date()
		{

			string ClassNamespace = AssemblyPath +".holiday_date";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iholiday_date)objType;
		}

		/// <summary>
		/// 创建icpinq数据层接口
		/// </summary>
		public static WongTung.IDAL.Iicpinq Createicpinq()
		{

			string ClassNamespace = AssemblyPath +".icpinq";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iicpinq)objType;
		}

		/// <summary>
		/// 创建incomts数据层接口
		/// </summary>
		public static WongTung.IDAL.Iincomts Createincomts()
		{

			string ClassNamespace = AssemblyPath +".incomts";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iincomts)objType;
		}

		/// <summary>
		/// 创建incomts_hist数据层接口
		/// </summary>
		public static WongTung.IDAL.Iincomts_hist Createincomts_hist()
		{

			string ClassNamespace = AssemblyPath +".incomts_hist";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iincomts_hist)objType;
		}

		/// <summary>
		/// 创建job数据层接口
		/// </summary>
		public static WongTung.IDAL.Ijob Createjob()
		{

			string ClassNamespace = AssemblyPath +".job";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Ijob)objType;
		}

		/// <summary>
		/// 创建jobbud数据层接口
		/// </summary>
		public static WongTung.IDAL.Ijobbud Createjobbud()
		{

			string ClassNamespace = AssemblyPath +".jobbud";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Ijobbud)objType;
		}

		/// <summary>
		/// 创建leave_bak数据层接口
		/// </summary>
		public static WongTung.IDAL.Ileave_bak Createleave_bak()
		{

			string ClassNamespace = AssemblyPath +".leave_bak";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Ileave_bak)objType;
		}

		/// <summary>
		/// 创建nocontrol数据层接口
		/// </summary>
		public static WongTung.IDAL.Inocontrol Createnocontrol()
		{

			string ClassNamespace = AssemblyPath +".nocontrol";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Inocontrol)objType;
		}

		/// <summary>
		/// 创建non数据层接口
		/// </summary>
		public static WongTung.IDAL.Inon Createnon()
		{

			string ClassNamespace = AssemblyPath +".non";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Inon)objType;
		}

		/// <summary>
		/// 创建non_hist数据层接口
		/// </summary>
		public static WongTung.IDAL.Inon_hist Createnon_hist()
		{

			string ClassNamespace = AssemblyPath +".non_hist";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Inon_hist)objType;
		}

		/// <summary>
		/// 创建offices数据层接口
		/// </summary>
		public static WongTung.IDAL.Ioffices Createoffices()
		{

			string ClassNamespace = AssemblyPath +".offices";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Ioffices)objType;
		}

		/// <summary>
		/// 创建outstanding_temp数据层接口
		/// </summary>
		public static WongTung.IDAL.Ioutstanding_temp Createoutstanding_temp()
		{

			string ClassNamespace = AssemblyPath +".outstanding_temp";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Ioutstanding_temp)objType;
		}

		/// <summary>
		/// 创建pat_job_tem数据层接口
		/// </summary>
		public static WongTung.IDAL.Ipat_job_tem Createpat_job_tem()
		{

			string ClassNamespace = AssemblyPath +".pat_job_tem";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Ipat_job_tem)objType;
		}

		/// <summary>
		/// 创建plan_emp数据层接口
		/// </summary>
		public static WongTung.IDAL.Iplan_emp Createplan_emp()
		{

			string ClassNamespace = AssemblyPath +".plan_emp";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iplan_emp)objType;
		}

		/// <summary>
		/// 创建plan_pos数据层接口
		/// </summary>
		public static WongTung.IDAL.Iplan_pos Createplan_pos()
		{

			string ClassNamespace = AssemblyPath +".plan_pos";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iplan_pos)objType;
		}

		/// <summary>
		/// 创建position数据层接口
		/// </summary>
		public static WongTung.IDAL.Iposition Createposition()
		{

			string ClassNamespace = AssemblyPath +".position";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iposition)objType;
		}

		/// <summary>
		/// 创建prriod数据层接口
		/// </summary>
		public static WongTung.IDAL.Iprriod Createprriod()
		{

			string ClassNamespace = AssemblyPath +".prriod";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iprriod)objType;
		}

		/// <summary>
		/// 创建ptl_job_tem数据层接口
		/// </summary>
		public static WongTung.IDAL.Iptl_job_tem Createptl_job_tem()
		{

			string ClassNamespace = AssemblyPath +".ptl_job_tem";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iptl_job_tem)objType;
		}

		/// <summary>
		/// 创建servicetype数据层接口
		/// </summary>
		public static WongTung.IDAL.Iservicetype Createservicetype()
		{

			string ClassNamespace = AssemblyPath +".servicetype";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iservicetype)objType;
		}

		/// <summary>
		/// 创建spe_endorse数据层接口
		/// </summary>
		public static WongTung.IDAL.Ispe_endorse Createspe_endorse()
		{

			string ClassNamespace = AssemblyPath +".spe_endorse";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Ispe_endorse)objType;
		}

		/// <summary>
		/// 创建temp_all_app数据层接口
		/// </summary>
		public static WongTung.IDAL.Itemp_all_app Createtemp_all_app()
		{

			string ClassNamespace = AssemblyPath +".temp_all_app";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Itemp_all_app)objType;
		}

		/// <summary>
		/// 创建temp_day_inq数据层接口
		/// </summary>
		public static WongTung.IDAL.Itemp_day_inq Createtemp_day_inq()
		{

			string ClassNamespace = AssemblyPath +".temp_day_inq";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Itemp_day_inq)objType;
		}

		/// <summary>
		/// 创建update_time数据层接口
		/// </summary>
		public static WongTung.IDAL.Iupdate_time Createupdate_time()
		{

			string ClassNamespace = AssemblyPath +".update_time";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iupdate_time)objType;
		}

		/// <summary>
		/// 创建userinf数据层接口
		/// </summary>
		public static WongTung.IDAL.Iuserinf Createuserinf()
		{

			string ClassNamespace = AssemblyPath +".userinf";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iuserinf)objType;
		}

		/// <summary>
		/// 创建worknatrue数据层接口
		/// </summary>
		public static WongTung.IDAL.Iworknatrue Createworknatrue()
		{

			string ClassNamespace = AssemblyPath +".worknatrue";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iworknatrue)objType;
		}

		/// <summary>
		/// 创建workstage数据层接口
		/// </summary>
		public static WongTung.IDAL.Iworkstage Createworkstage()
		{

			string ClassNamespace = AssemblyPath +".workstage";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (WongTung.IDAL.Iworkstage)objType;
		}

}
}