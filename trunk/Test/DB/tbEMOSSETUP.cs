using System;
using System.Collections.Generic;
using System.Data;
using hwj.DBUtility;
using hwj.DBUtility.Entity;
using hwj.DBUtility.TableMapping;

namespace Test.DB
{
    /// <summary>
    /// Table:EMOSSETUP
    /// </summary>
    [Serializable]
    public class tbEMOSSETUP : BaseTable<tbEMOSSETUP>
    {
        public tbEMOSSETUP()
            : base(DBTableName)
        { }
        public const string DBTableName = "EMOSSETUP";


        public enum Fields
        {
            /// <summary>
            ///
            /// </summary>
            ID,
            /// <summary>
            ///
            /// </summary>
            VALUE,
            /// <summary>
            ///
            /// </summary>
            CompanyCode,
            /// <summary>
            ///
            /// </summary>
            BranchCode,
        }

        #region Model
        private String _id;
        private String _value;
        private String _companycode;
        private String _branchcode;
        /// <summary>
        /// [PK/Un-Null/nvarchar(10)]
        /// </summary>
        [FieldMapping("ID", DbType.String, 10)]
        public String ID
        {
            set { AddAssigned("ID"); _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// [Allow Null/nvarchar(100)]
        /// </summary>
        [FieldMapping("VALUE", DbType.String, 100)]
        public String VALUE
        {
            set { AddAssigned("VALUE"); _value = value; }
            get { return _value; }
        }
        /// <summary>
        /// [PK/Un-Null/varchar(2)/Default:('WM')]
        /// </summary>
        [FieldMapping("CompanyCode", DbType.AnsiString, 2)]
        public String CompanyCode
        {
            set { AddAssigned("CompanyCode"); _companycode = value; }
            get { return _companycode; }
        }
        /// <summary>
        /// [PK/Un-Null/varchar(2)/Default:('H')]
        /// </summary>
        [FieldMapping("BranchCode", DbType.AnsiString, 2)]
        public String BranchCode
        {
            set { AddAssigned("BranchCode"); _branchcode = value; }
            get { return _branchcode; }
        }
        #endregion Model

    }
    [Serializable]
    public class tbEMOSSETUPs : BaseList<tbEMOSSETUP, tbEMOSSETUPs> { }
    public class tbEMOSSETUPPage : PageResult<tbEMOSSETUP, tbEMOSSETUPs> { }
}

