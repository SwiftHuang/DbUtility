using System;
using System.Collections.Generic;
using System.Data;
using hwj.DBUtility;
using hwj.DBUtility.Entity;
using hwj.DBUtility.TableMapping;

namespace Test.DB.Entity
{
    /// <summary>
    /// Table:Test_IMG
    /// </summary>
    [Serializable]
    public class tbTest_IMG : BaseTable<tbTest_IMG>
    {
        public tbTest_IMG()
            : base(DBTableName)
        { }
        public const string DBTableName = "Test_IMG";


        public enum Fields
        {
            /// <summary>
            ///
            /// </summary>
            Id,
            /// <summary>
            ///
            /// </summary>
            Img,
        }

        #region Model
        private Int32 _id;
        private Byte[] _img;
        /// <summary>
        /// [Un-Null/int(10)]
        /// </summary>
        [FieldMapping("Id", DbType.Int32, 10, Enums.DataHandle.UnInsert, Enums.DataHandle.UnUpdate)]
        public Int32 Id
        {
            set { AddAssigned("Id"); _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// [Un-Null/image(2147483647)]
        /// </summary>
        [FieldMapping("Img", DbType.Binary, 2147483647)]
        public Byte[] Img
        {
            set { AddAssigned("Img"); _img = value; }
            get { return _img; }
        }
        #endregion Model

    }
    [Serializable]
    public class tbTest_IMGs : BaseList<tbTest_IMG, tbTest_IMGs> { }
    public class tbTest_IMGPage : PageResult<tbTest_IMG, tbTest_IMGs> { }
}

