using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace hwj.MarkTableObject.Entity
{
    public class SPParamColumnInfo
    {
        public string IsResult { get; set; }
        public string ParameterName { get; set; }
        public string DataType { get; set; }
        public string ParameterMode { get; set; }

        public SPParamColumnInfo()
        {

        }

    }
    public class SPParamColumnInfos : List<SPParamColumnInfo>
    {
    }
}
