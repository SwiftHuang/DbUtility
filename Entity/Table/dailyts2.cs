using System;
using DataMapping;

namespace WongTung.Entity.Table
{
    /// <summary>
    /// 实体类dailyts 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class dailyts2
    {
        public dailyts2()
        { }
        #region Model
        private string _dt_co_code;
        private string _dt_staff_code;
        private DateTime _dt_work_date;
        private decimal _dt_line_no;
        private string _dt_app_code;
        private string _dt_job_code;
        private string _dt_ser_code;
        private decimal? _dt_nor_hour;
        private decimal? _dt_over_hour;
        private string _dt_type;
        private string _dt_period;
        private string _dt_submit;
        private string _dt_update;
        private string _dt_ramno;
        private DateTime _dt_update_date;
        /// <summary>
        /// 
        /// </summary>
        [Mapping("DT_CO_CODE", "")]
        public string DT_CO_CODE
        {
            set { _dt_co_code = value; }
            get { return _dt_co_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Mapping("DT_STAFF_CODE", "")]
        public string DT_STAFF_CODE
        {
            set { _dt_staff_code = value; }
            get { return _dt_staff_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Mapping("DT_WORK_DATE", "")]
        public DateTime DT_WORK_DATE
        {
            set { _dt_work_date = value; }
            get { return _dt_work_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Mapping("DT_LINE_NO", "")]
        public decimal DT_LINE_NO
        {
            set { _dt_line_no = value; }
            get { return _dt_line_no; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Mapping("DT_APP_CODE", "")]
        public string DT_APP_CODE
        {
            set { _dt_app_code = value; }
            get { return _dt_app_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Mapping("DT_JOB_CODE", "")]
        public string DT_JOB_CODE
        {
            set { _dt_job_code = value; }
            get { return _dt_job_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Mapping("DT_SER_CODE", "")]
        public string DT_SER_CODE
        {
            set { _dt_ser_code = value; }
            get { return _dt_ser_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Mapping("DT_NOR_HOUR", "")]
        public decimal? DT_NOR_HOUR
        {
            set { _dt_nor_hour = value; }
            get { return _dt_nor_hour; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Mapping("DT_OVER_HOUR", "")]
        public decimal? DT_OVER_HOUR
        {
            set { _dt_over_hour = value; }
            get { return _dt_over_hour; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Mapping("DT_TYPE", "")]
        public string DT_TYPE
        {
            set { _dt_type = value; }
            get { return _dt_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Mapping("DT_PERIOD", "")]
        public string DT_PERIOD
        {
            set { _dt_period = value; }
            get { return _dt_period; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Mapping("DT_SUBMIT", "")]
        public string DT_SUBMIT
        {
            set { _dt_submit = value; }
            get { return _dt_submit; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Mapping("DT_UPDATE", "")]
        public string DT_UPDATE
        {
            set { _dt_update = value; }
            get { return _dt_update; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Mapping("DT_RAMNO", "")]
        public string DT_RAMNO
        {
            set { _dt_ramno = value; }
            get { return _dt_ramno; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Mapping("DT_UPDATE_DATE", "")]
        public DateTime DT_UPDATE_DATE
        {
            set { _dt_update_date = value; }
            get { return _dt_update_date; }
        }
        #endregion Model

    }
}

