using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using hwj.CommonLibrary.Object;
using hwj.MarkTableObject.Entity;

namespace hwj.MarkTableObject.BLL.MSSQL
{
    public class BuilderColumn
    {
        public static ColumnInfos GetColumnInfoForTable(EntityInfo entity)
        {
            ColumnInfos list = new ColumnInfos();
            using (SqlConnection connection = new SqlConnection(entity.ConnectionString))
            {
                SqlCommand command = null;
                if (entity.Module == DBModule.SQL)
                    command = new SqlCommand(entity.CommandText, connection);
                else
                    command = new SqlCommand(string.Format("SELECT * FROM {0}", entity.TableName), connection);

                connection.Open();
                DataTable tb1 = connection.GetSchema("Columns", new string[] { null, null, entity.TableName });
                DataView dv = tb1.DefaultView;

                SqlDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo);
                DataTable tb = reader.GetSchemaTable();
                foreach (DataRow r in tb.Rows)
                {
                    ColumnInfo c = BLL.Common.GetColumnInfo(r);
                    c.DataTypeName = BLL.Common.GetStringValue(r["DataTypeName"]);

                    dv.RowFilter = string.Format("COLUMN_NAME='{0}'", c.ColumnName);
                    if (dv.Count > 0)
                    {
                        if (dv[0]["COLUMN_DEFAULT"] != null)
                            c.DefaultValue = dv[0]["COLUMN_DEFAULT"].ToString();
                        //if (dv[0]["DESCRIPTION"] != null)
                        //    c.Description = dv[0]["DESCRIPTION"].ToString();
                    }

                    list.Add(c);
                }
                reader.Close();
            }
            return list;
        }
        public static void GetTableList(string connectionString, out List<string> tableList, out List<string> viewList)
        {
            tableList = new List<string>();
            viewList = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable tb = connection.GetSchema("Tables");
                DataView dv = tb.DefaultView;
                dv.RowFilter = "TABLE_TYPE='BASE TABLE'";
                dv.Sort = "TABLE_NAME";
                foreach (DataRowView r in dv)
                {
                    tableList.Add(r["TABLE_NAME"].ToString());
                }

                dv.RowFilter = "TABLE_TYPE='VIEW'";
                dv.Sort = "TABLE_NAME";
                foreach (DataRowView r in dv)
                {
                    viewList.Add(r["TABLE_NAME"].ToString());
                }
            }
        }
    }
}
