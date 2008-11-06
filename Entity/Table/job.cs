using System;
using hwj.DBUtility.TableMapping;
namespace WongTung.Entity.Table
{
    /// <summary>
    /// 实体类job 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class job : iTable
    {
        public job()
        { }
        public enum Fields
        {
            JOB_CO_CODE,
            JOB_CODE,
            JOB_NAME,
            JOB_CON,
            JOB_OPEN_BAL_HOUR,
            JOB_YTD_HOUR,
            JOB_OPEN_BAL_AMT,
            JOB_YTD_AMT,
            JOB_REC,
            JOB_OS_BAL,
            JOB_BUD_HOUR,
            JOB_CO_ORD,
            JOB_ADMIN,
            JOB_DESIGN,
            JOB_LEV1,
            JOB_LEV2,
            JOB_LEV3,
            JOB_CHARGE_OUT,
            JOB_DAILY,
            JOB_MON,
            JOB_PERIOD,
            JOB_PERIOD_VAL,
            JOB_AUTH,
            JOB_OFF_INCHG_AD,
            JOB_OFF_INCHG_DES,
            JOB_AUTH_1,
            JOB_AUTH_2,
            JOB_AUTH_3,
            JOB_AUTH_4,
            JOB_AUTH_5,
            JOB_INDEX,
            JOB_NAME_S,
            JOB_NAME_T,
        }

        public static string TableName
        {
            get { return "job"; }
        }

        #region Model
        private String _job_co_code;
        private String _job_code;
        private String _job_name;
        private Decimal? _job_con;
        private Decimal? _job_open_bal_hour;
        private Decimal? _job_ytd_hour;
        private Decimal? _job_open_bal_amt;
        private Decimal? _job_ytd_amt;
        private Decimal? _job_rec;
        private Decimal? _job_os_bal;
        private Decimal? _job_bud_hour;
        private Int32 _job_co_ord;
        private Int16 _job_admin;
        private Int16 _job_design;
        private Int32 _job_lev1;
        private Int16 _job_lev2;
        private Int16 _job_lev3;
        private Int16 _job_charge_out;
        private Int16 _job_daily;
        private Int16 _job_mon;
        private Decimal? _job_period;
        private Decimal? _job_period_val;
        private String _job_auth;
        private String _job_off_inchg_ad;
        private String _job_off_inchg_des;
        private String _job_auth_1;
        private String _job_auth_2;
        private String _job_auth_3;
        private String _job_auth_4;
        private String _job_auth_5;
        private Int32 _job_index;
        private String _job_name_s;
        private String _job_name_t;
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_CO_CODE", TypeCode.String)]
        public String JOB_CO_CODE
        {
            set { _job_co_code = value; }
            get { return _job_co_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_CODE", TypeCode.String)]
        public String JOB_CODE
        {
            set { _job_code = value; }
            get { return _job_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_NAME", TypeCode.String)]
        public String JOB_NAME
        {
            set { _job_name = value; }
            get { return _job_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_CON", TypeCode.Decimal)]
        public Decimal? JOB_CON
        {
            set { _job_con = value; }
            get { return _job_con; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_OPEN_BAL_HOUR", TypeCode.Decimal)]
        public Decimal? JOB_OPEN_BAL_HOUR
        {
            set { _job_open_bal_hour = value; }
            get { return _job_open_bal_hour; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_YTD_HOUR", TypeCode.Decimal)]
        public Decimal? JOB_YTD_HOUR
        {
            set { _job_ytd_hour = value; }
            get { return _job_ytd_hour; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_OPEN_BAL_AMT", TypeCode.Decimal)]
        public Decimal? JOB_OPEN_BAL_AMT
        {
            set { _job_open_bal_amt = value; }
            get { return _job_open_bal_amt; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_YTD_AMT", TypeCode.Decimal)]
        public Decimal? JOB_YTD_AMT
        {
            set { _job_ytd_amt = value; }
            get { return _job_ytd_amt; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_REC", TypeCode.Decimal)]
        public Decimal? JOB_REC
        {
            set { _job_rec = value; }
            get { return _job_rec; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_OS_BAL", TypeCode.Decimal)]
        public Decimal? JOB_OS_BAL
        {
            set { _job_os_bal = value; }
            get { return _job_os_bal; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_BUD_HOUR", TypeCode.Decimal)]
        public Decimal? JOB_BUD_HOUR
        {
            set { _job_bud_hour = value; }
            get { return _job_bud_hour; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_CO_ORD", TypeCode.Int32)]
        public Int32 JOB_CO_ORD
        {
            set { _job_co_ord = value; }
            get { return _job_co_ord; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_ADMIN", TypeCode.Int16)]
        public Int16 JOB_ADMIN
        {
            set { _job_admin = value; }
            get { return _job_admin; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_DESIGN", TypeCode.Int16)]
        public Int16 JOB_DESIGN
        {
            set { _job_design = value; }
            get { return _job_design; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_LEV1", TypeCode.Int32)]
        public Int32 JOB_LEV1
        {
            set { _job_lev1 = value; }
            get { return _job_lev1; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_LEV2", TypeCode.Int16)]
        public Int16 JOB_LEV2
        {
            set { _job_lev2 = value; }
            get { return _job_lev2; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_LEV3", TypeCode.Int16)]
        public Int16 JOB_LEV3
        {
            set { _job_lev3 = value; }
            get { return _job_lev3; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_CHARGE_OUT", TypeCode.Int16)]
        public Int16 JOB_CHARGE_OUT
        {
            set { _job_charge_out = value; }
            get { return _job_charge_out; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_DAILY", TypeCode.Int16)]
        public Int16 JOB_DAILY
        {
            set { _job_daily = value; }
            get { return _job_daily; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_MON", TypeCode.Int16)]
        public Int16 JOB_MON
        {
            set { _job_mon = value; }
            get { return _job_mon; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_PERIOD", TypeCode.Decimal)]
        public Decimal? JOB_PERIOD
        {
            set { _job_period = value; }
            get { return _job_period; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_PERIOD_VAL", TypeCode.Decimal)]
        public Decimal? JOB_PERIOD_VAL
        {
            set { _job_period_val = value; }
            get { return _job_period_val; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_AUTH", TypeCode.String)]
        public String JOB_AUTH
        {
            set { _job_auth = value; }
            get { return _job_auth; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_OFF_INCHG_AD", TypeCode.String)]
        public String JOB_OFF_INCHG_AD
        {
            set { _job_off_inchg_ad = value; }
            get { return _job_off_inchg_ad; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_OFF_INCHG_DES", TypeCode.String)]
        public String JOB_OFF_INCHG_DES
        {
            set { _job_off_inchg_des = value; }
            get { return _job_off_inchg_des; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_AUTH_1", TypeCode.String)]
        public String JOB_AUTH_1
        {
            set { _job_auth_1 = value; }
            get { return _job_auth_1; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_AUTH_2", TypeCode.String)]
        public String JOB_AUTH_2
        {
            set { _job_auth_2 = value; }
            get { return _job_auth_2; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_AUTH_3", TypeCode.String)]
        public String JOB_AUTH_3
        {
            set { _job_auth_3 = value; }
            get { return _job_auth_3; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_AUTH_4", TypeCode.String)]
        public String JOB_AUTH_4
        {
            set { _job_auth_4 = value; }
            get { return _job_auth_4; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_AUTH_5", TypeCode.String)]
        public String JOB_AUTH_5
        {
            set { _job_auth_5 = value; }
            get { return _job_auth_5; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_INDEX", TypeCode.Int32)]
        public Int32 JOB_INDEX
        {
            set { _job_index = value; }
            get { return _job_index; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_NAME_S", TypeCode.String)]
        public String JOB_NAME_S
        {
            set { _job_name_s = value; }
            get { return _job_name_s; }
        }
        /// <summary>
        /// 
        /// </summary>
        [FieldMapping("JOB_NAME_T", TypeCode.String)]
        public String JOB_NAME_T
        {
            set { _job_name_t = value; }
            get { return _job_name_t; }
        }
        #endregion Model

    }
}

