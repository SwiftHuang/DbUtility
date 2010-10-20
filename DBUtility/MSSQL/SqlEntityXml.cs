using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace hwj.DBUtility.MSSQL
{
    [Serializable]
    public class SqlEntityXml
    {
        #region Property
        public string CmdTxt { get; set; }
        public List<ParamXml> Params { get; set; }
        #endregion

        public SqlEntityXml()
        {

        }

        public SqlEntityXml(SqlEntity sqlEntity)
        {
            if (sqlEntity != null)
            {
                this.CmdTxt = sqlEntity.CommandText;

                if (sqlEntity.Parameters != null)
                {
                    this.Params = new List<ParamXml>();
                    foreach (SqlParameter p in sqlEntity.Parameters)
                    {
                        this.Params.Add(new ParamXml(p));
                    }
                }
            }
        }

        public SqlEntityXml(string cmdTxt, List<SqlParameter> cmdParms)
        {
            this.CmdTxt = cmdTxt;
            if (cmdParms != null)
            {
                this.Params = new List<ParamXml>();
                foreach (SqlParameter p in cmdParms)
                {
                    this.Params.Add(new ParamXml(p));
                }
            }
        }

        public string ToXml()
        {
            XmlSerializer xs = new XmlSerializer(this.GetType());
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            xs.Serialize(stream, this);
            return System.Text.Encoding.UTF8.GetString(stream.ToArray());
        }

    }


    [Serializable]
    public class ParamXml
    {
        #region Property
        public string Name { get; set; }
        public int Size { get; set; }
        public object Value { get; set; }
        public SqlDbType DbType { get; set; }
        #endregion

        public ParamXml()
        {

        }

        public ParamXml(SqlParameter sqlParameter)
        {
            this.Name = sqlParameter.ParameterName;
            this.Size = sqlParameter.Size;
            if (sqlParameter.Value.GetType() == typeof(System.DBNull))
                this.Value = "[DBNull]";
            else
                this.Value = sqlParameter.Value;
            this.DbType = sqlParameter.SqlDbType;
        }
    }
}
