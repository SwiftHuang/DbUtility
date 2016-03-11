using System;
using System.Collections.Generic;
using System.Data;
using hwj.DBUtility;
using hwj.DBUtility.Entity;
using hwj.DBUtility.TableMapping;

namespace Test.DB.Entity
{
    /// <summary>
    /// Table:Test_Table
    /// </summary>
    [Serializable]
    public class tbTest_Table : BaseTable<tbTest_Table>
    {
        public tbTest_Table()
            : base(DBTableName)
        { }
        public const string DBTableName = "Test_Table";


        public enum Fields
        {
            /// <summary>
            ///
            /// </summary>
            Test_ID,
        }

        #region Model
        private Int32 _test_id;
        /// <summary>
        /// [PK/Un-Null/int(4)]
        /// </summary>
        [FieldMapping("Test_ID", DbType.Int32, Enums.DataHandle.UnInsert, Enums.DataHandle.UnUpdate)]
        public Int32 Test_ID
        {
            set{ AddAssigned("Test_ID"); _test_id=value; }
            get{ return _test_id; }
        }
        #endregion Model

    }
    [Serializable]
    public class tbTest_Tables : BaseList<tbTest_Table, tbTest_Tables> { }
    public class tbTest_TablePage : PageResult<tbTest_Table, tbTest_Tables> { }
}

