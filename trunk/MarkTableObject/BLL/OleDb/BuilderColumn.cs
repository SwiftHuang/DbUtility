using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using hwj.CommonLibrary.Object;
using hwj.MarkTableObject.Entity;

namespace hwj.MarkTableObject.BLL.OleDb
{
    public class BuilderColumn
    {

        public static ColumnInfos GetColumnInfoForTable(EntityInfo entity)
        {
            ColumnInfos list = new ColumnInfos();

            using (OleDbConnection connection = new OleDbConnection(entity.ConnectionString))
            {
                OleDbCommand command = new OleDbCommand(string.Format("SELECT * FROM {0}", entity.TableName), connection);

                connection.Open();
                DataTable tb1 = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, entity.TableName });
                DataView dv = tb1.DefaultView;

                OleDbDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo);
                DataTable tb = reader.GetSchemaTable();
                foreach (DataRow r in tb.Rows)
                {
                    ColumnInfo c = BLL.Common.GetColumnInfo(r);
                    c.DataTypeName = BLL.Common.GetStringValue(r["DataType"]).Replace("System.", "");

                    dv.RowFilter = string.Format("COLUMN_NAME='{0}'", c.ColumnName);
                    if (dv.Count > 0)
                    {
                        if (dv[0]["COLUMN_DEFAULT"] != null)
                            c.DefaultValue = dv[0]["COLUMN_DEFAULT"].ToString();
                        if (dv[0]["DESCRIPTION"] != null)
                            c.Description = dv[0]["DESCRIPTION"].ToString();
                    }

                    list.Add(c);
                }
                reader.Close();
            }
            return list;
        }

    }
}
