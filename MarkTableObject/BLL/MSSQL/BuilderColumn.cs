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
                if (entity.Module == DBModule.SQL || entity.Module == DBModule.SP)
                    command = new SqlCommand(entity.CommandText, connection);
                else
                    command = new SqlCommand(string.Format("SELECT Top 1 * FROM {0}", entity.TableName), connection);

                connection.Open();
                DataTable tb1 = connection.GetSchema("Columns", new string[] { null, null, entity.TableName });
                DataView dv = tb1.DefaultView;

                SqlDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo);
                DataTable tb = reader.GetSchemaTable();
                int index = 0;
                foreach (DataRow r in tb.Rows)
                {
                    if (index >= reader.VisibleFieldCount)
                        break;
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
                    index++;
                }
                reader.Close();
            }
            return list;
        }
        public static SPParamColumnInfos GetColumnInfoForSPParam(EntityInfo entity)
        {
            SPParamColumnInfos list = new SPParamColumnInfos();
            using (SqlConnection connection = new SqlConnection(entity.ConnectionString))
            {
                connection.Open();
                DataTable tb = connection.GetSchema("ProcedureParameters", new string[] { null, null, entity.SPName });
                foreach (DataRow r in tb.Rows)
                {
                    SPParamColumnInfo c = BLL.Common.GetSPParamColumnInfo(r);
                    list.Add(c);
                }
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
