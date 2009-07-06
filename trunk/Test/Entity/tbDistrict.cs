using System;
using System.Collections.Generic;
using System.Data;
using hwj.DBUtility;
using hwj.DBUtility.Entity;
using hwj.DBUtility.TableMapping;

namespace Test.Entity.Table
{
    /// <summary>
    /// 实体类tbDistrict 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class tbDistrict : BaseTable
    {
        public static string DBTableName = "tbDistrict";
        public tbDistrict()
            : base("tbDistrict")
        {

        }
        public enum Fields
        {
            /// <summary>
            ///区编号
            /// </summary>
            Code,
            /// <summary>
            ///区名
            /// </summary>
            Name,
            /// <summary>
            ///地区名称首个拼音
            /// </summary>
            PinYin,
            /// <summary>
            ///
            /// </summary>
            CreateOn,
            /// <summary>
            ///
            /// </summary>
            CreateBy,
            /// <summary>
            ///
            /// </summary>
            UpdateOn,
            /// <summary>
            ///
            /// </summary>
            UpdateBy,
        }

        #region Model
        private String _code;
        private String _name;
        private String _pinyin;
        private DateTime _createon;
        private String _createby;
        private DateTime _updateon;
        private String _updateby;
        /// <summary>
        /// 区编号[PK/Un-Null/char(4)]
        /// </summary>
        [FieldMapping("Code", DbType.String)]
        public String Code
        {
            set { AddAssigned("Code"); _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 区名[Un-Null/nvarchar(10)]
        /// </summary>
        [FieldMapping("Name", DbType.String)]
        public String Name
        {
            set { AddAssigned("Name"); _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 地区名称首个拼音[Allow Null/nchar(10)]
        /// </summary>
        [FieldMapping("PinYin", DbType.String)]
        public String PinYin
        {
            set { AddAssigned("PinYin"); _pinyin = value; }
            get { return _pinyin; }
        }
        /// <summary>
        /// [Allow Null/datetime(8)]
        /// </summary>
        [FieldMapping("CreateOn", DbType.DateTime)]
        public DateTime CreateOn
        {
            set { AddAssigned("CreateOn"); _createon = value; }
            get { return _createon; }
        }
        /// <summary>
        /// [Allow Null/char(10)]
        /// </summary>
        [FieldMapping("CreateBy", DbType.String)]
        public String CreateBy
        {
            set { AddAssigned("CreateBy"); _createby = value; }
            get { return _createby; }
        }
        /// <summary>
        /// [Allow Null/datetime(8)]
        /// </summary>
        [FieldMapping("UpdateOn", DbType.DateTime)]
        public DateTime UpdateOn
        {
            set { AddAssigned("UpdateOn"); _updateon = value; }
            get { return _updateon; }
        }
        /// <summary>
        /// [Allow Null/char(10)]
        /// </summary>
        [FieldMapping("UpdateBy", DbType.String)]
        public String UpdateBy
        {
            set { AddAssigned("UpdateBy"); _updateby = value; }
            get { return _updateby; }
        }
        #endregion Model

    }
    public class tbDistricts : BaseList<tbDistrict, tbDistricts> { }
    public class tbDistrictPage : PageResult<tbDistrict> { }
}

