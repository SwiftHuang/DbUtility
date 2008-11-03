﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WongTung.DBUtility
{
    public class SqlParam
    {
        #region Property
        public string FieldName { get; set; }
        public object FieldValue { get; set; }
        public Enums.Operator Operator { get; set; }
        public Enums.Expression Expression { get; set; }
        #endregion

        public SqlParam(string fieldName, object fieldValue, Enums.Operator oper, Enums.Expression exp)
            : base()
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
            Operator = oper;
            Expression = exp;
        }

        public SqlParam(string fieldName, object fieldValue, Enums.Operator oper)
            : base()
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
            Operator = oper;
            Expression = Enums.Expression.None;
        }
    }
}