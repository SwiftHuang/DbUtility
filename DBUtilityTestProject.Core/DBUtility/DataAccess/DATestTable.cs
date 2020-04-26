using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using hwj.DBUtility;
using hwj.DBUtility.Core.MSSQL.Interface;
using hwj.DBUtility.Core.MSSQL;
using TestProject.Core.DBUtility.Entity;
using hwj.DBUtility.Core;

namespace TestProject.Core.DBUtility.DataAccess
{
    /// <summary>
    /// DataAccess [Table:TestTable]
    /// </summary>
    public partial class DATestTable : DALDependency<tbTestTable, tbTestTables>
    {
        public DATestTable(IMSSQLConnection conn)
            : base(conn)
        { }

        public bool Exists(int id)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTestTable.Fields.Id, id, Enums.Relation.Equal, Enums.Expression.AND);
            return base.RecordCount(fp) > 0;
        }

        public bool Add(tbTestTable entity)
        {
            return base.Add(entity);
        }

        public bool Update(tbTestTable updateEntity, int id)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTestTable.Fields.Id, id, Enums.Relation.Equal, Enums.Expression.AND);
            return base.Update(updateEntity, fp);
        }

        public bool Delete(int id)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTestTable.Fields.Id, id, Enums.Relation.Equal, Enums.Expression.AND);
            return base.Delete(fp);
        }

        public tbTestTable GetEntity(int id)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTestTable.Fields.Id, id, Enums.Relation.Equal, Enums.Expression.AND);
            return base.GetEntity(fp);
        }

        public tbTestTables GetList(int id)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbTestTable.Fields.Id, id, Enums.Relation.Equal, Enums.Expression.AND);
            return base.GetList(null, fp);
        }

        public tbTestTablePage GetPage(int pageIndex, int pageSize)
        {
            int RecordCount;
            tbTestTablePage page = new tbTestTablePage();
            DisplayFields pk = new DisplayFields();
            pk.Add(tbTestTable.Fields.Id);
            page.PageSize = pageSize;
            page.Result = base.GetPage(null, null, null, pk, pageIndex, page.PageSize, out RecordCount);
            page.RecordCount = RecordCount;
            return page;
        }

    }
}

