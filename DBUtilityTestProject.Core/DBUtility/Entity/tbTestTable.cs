using System;
using System.Data;
using hwj.DBUtility;
using hwj.DBUtility.Core;
using hwj.DBUtility.Core.Entity;
using hwj.DBUtility.Core.TableMapping;

namespace TestProject.Core.DBUtility.Entity
{
    /// <summary>
    /// Table:TestTable
    /// </summary>
    [Serializable]
    public class tbTestTable : BaseTable<tbTestTable>
    {
        public tbTestTable()
            : base(DBTableName)
        { }
        public const string DBTableName = "TestTable";


        public enum Fields
        {
            /// <summary>
            ///
            /// </summary>
            Id,
            /// <summary>
            ///
            /// </summary>
            Boolean,
            /// <summary>
            ///
            /// </summary>
            Amt_Numeric,
            /// <summary>
            ///
            /// </summary>
            Amt_Decimal,
            /// <summary>
            ///
            /// </summary>
            Amt_Float,
            /// <summary>
            ///
            /// </summary>
            Amt_Int,
            /// <summary>
            ///
            /// </summary>
            Desc_EN,
            /// <summary>
            ///
            /// </summary>
            Desc_CN,
            /// <summary>
            ///
            /// </summary>
            Key_EN,
            /// <summary>
            ///
            /// </summary>
            Key_CN,
            /// <summary>
            ///
            /// </summary>
            Remark_CN,
            /// <summary>
            ///
            /// </summary>
            Remark_EN,
            /// <summary>
            ///
            /// </summary>
            XML_Data,
            /// <summary>
            ///
            /// </summary>
            CreateOn,
        }

        #region Model
        private Int32 _id;
        private Boolean _boolean;
        private Decimal _amt_numeric;
        private Decimal _amt_decimal;
        private Double _amt_float;
        private Int32 _amt_int;
        private String _desc_en;
        private String _desc_cn;
        private String _key_en;
        private String _key_cn;
        private String _remark_cn;
        private String _remark_en;
        private String _xml_data;
        private DateTime _createon;
        /// <summary>
        /// [PK/Un-Null/int(10)]
        /// </summary>
        [FieldMapping("Id", DbType.Int32, 10, Enums.DataHandle.UnInsert, Enums.DataHandle.UnUpdate)]
        public Int32 Id
        {
            set { AddAssigned("Id"); _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// [Allow Null/bit(1)]
        /// </summary>
        [FieldMapping("Boolean", DbType.Boolean, 1)]
        public Boolean Boolean
        {
            set { AddAssigned("Boolean"); _boolean = value; }
            get { return _boolean; }
        }
        /// <summary>
        /// [Allow Null/decimal(5,2)]
        /// </summary>
        [FieldMapping("Amt_Numeric", DbType.Decimal, 3)]
        public Decimal Amt_Numeric
        {
            set { AddAssigned("Amt_Numeric"); _amt_numeric = value; }
            get { return _amt_numeric; }
        }
        /// <summary>
        /// [Allow Null/decimal(5,2)]
        /// </summary>
        [FieldMapping("Amt_Decimal", DbType.Decimal, 3)]
        public Decimal Amt_Decimal
        {
            set { AddAssigned("Amt_Decimal"); _amt_decimal = value; }
            get { return _amt_decimal; }
        }
        /// <summary>
        /// [Allow Null/float(15)]
        /// </summary>
        [FieldMapping("Amt_Float", DbType.Double, 15)]
        public Double Amt_Float
        {
            set { AddAssigned("Amt_Float"); _amt_float = value; }
            get { return _amt_float; }
        }
        /// <summary>
        /// [Allow Null/int(10)]
        /// </summary>
        [FieldMapping("Amt_Int", DbType.Int32, 10)]
        public Int32 Amt_Int
        {
            set { AddAssigned("Amt_Int"); _amt_int = value; }
            get { return _amt_int; }
        }
        /// <summary>
        /// [Allow Null/varchar(20)]
        /// </summary>
        [FieldMapping("Desc_EN", DbType.AnsiString, 20)]
        public String Desc_EN
        {
            set { AddAssigned("Desc_EN"); _desc_en = value; }
            get { return _desc_en; }
        }
        /// <summary>
        /// [Allow Null/nvarchar(20)]
        /// </summary>
        [FieldMapping("Desc_CN", DbType.String, 20)]
        public String Desc_CN
        {
            set { AddAssigned("Desc_CN"); _desc_cn = value; }
            get { return _desc_cn; }
        }
        /// <summary>
        /// [Allow Null/char(10)]
        /// </summary>
        [FieldMapping("Key_EN", DbType.AnsiStringFixedLength, 10)]
        public String Key_EN
        {
            set { AddAssigned("Key_EN"); _key_en = value; }
            get { return _key_en; }
        }
        /// <summary>
        /// [Allow Null/nchar(10)]
        /// </summary>
        [FieldMapping("Key_CN", DbType.StringFixedLength, 10)]
        public String Key_CN
        {
            set { AddAssigned("Key_CN"); _key_cn = value; }
            get { return _key_cn; }
        }
        /// <summary>
        /// [Allow Null/ntext(1073741823)]
        /// </summary>
        [FieldMapping("Remark_CN", DbType.String, 1073741823)]
        public String Remark_CN
        {
            set { AddAssigned("Remark_CN"); _remark_cn = value; }
            get { return _remark_cn; }
        }
        /// <summary>
        /// [Allow Null/text(2147483647)]
        /// </summary>
        [FieldMapping("Remark_EN", DbType.String, 2147483647)]
        public String Remark_EN
        {
            set { AddAssigned("Remark_EN"); _remark_en = value; }
            get { return _remark_en; }
        }
        /// <summary>
        /// [Allow Null/xml(2147483647)]
        /// </summary>
        [FieldMapping("XML_Data", DbType.String, 2147483647)]
        public String XML_Data
        {
            set { AddAssigned("XML_Data"); _xml_data = value; }
            get { return _xml_data; }
        }
        /// <summary>
        /// [Allow Null/datetime(8)]
        /// </summary>
        [FieldMapping("CreateOn", DbType.DateTime, 8)]
        public DateTime CreateOn
        {
            set { AddAssigned("CreateOn"); _createon = value; }
            get { return _createon; }
        }
        #endregion Model

    }
    [Serializable]
    public class tbTestTables : BaseList<tbTestTable, tbTestTables> { }
    public class tbTestTablePage : PageResult<tbTestTable, tbTestTables> { }
}

