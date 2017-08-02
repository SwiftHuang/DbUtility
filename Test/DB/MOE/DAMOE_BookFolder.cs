using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using hwj.DBUtility;
using hwj.DBUtility.Interface;
using hwj.DBUtility.MSSQL;
using Westminster.MOE.Entity.MOEDB.Table;
using hwj.DBUtility.MSSQL.Interface;

namespace Westminster.MOE.DataAccess.MOEDB.Table
{
    /// <summary>
    /// DataAccess [Table:MOE_BookFolder]
    /// </summary>
    public partial class DAMOE_BookFolder : DALDependency<tbMOE_BookFolder, tbMOE_BookFolders>
    {
        public DAMOE_BookFolder(IMSSQLConnection conn)
            : base(conn)
        { }

        public bool Exists(string bfref)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbMOE_BookFolder.Fields.BFRef, bfref, Enums.Relation.Equal, Enums.Expression.AND);
            return base.RecordCount(fp) > 0;
        }

        public bool Add(tbMOE_BookFolder entity)
        {
            return base.Add(entity);
        }

        public bool Update(tbMOE_BookFolder updateEntity, string bfref)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbMOE_BookFolder.Fields.BFRef, bfref, Enums.Relation.Equal, Enums.Expression.AND);
            return base.Update(updateEntity, fp);
        }

        public bool Delete(string bfref)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbMOE_BookFolder.Fields.BFRef, bfref, Enums.Relation.Equal, Enums.Expression.AND);
            return base.Delete(fp);
        }

        public tbMOE_BookFolder GetEntity(string bfref)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbMOE_BookFolder.Fields.BFRef, bfref, Enums.Relation.Equal, Enums.Expression.AND);
            return base.GetEntity(fp);
        }

        public tbMOE_BookFolders GetList(string bfref)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbMOE_BookFolder.Fields.BFRef, bfref, Enums.Relation.Equal, Enums.Expression.AND);
            return base.GetList(null, fp);
        }

        public tbMOE_BookFolderPage GetPage(int pageIndex, int pageSize)
        {
            int RecordCount;
            tbMOE_BookFolderPage page = new tbMOE_BookFolderPage();
            DisplayFields pk = new DisplayFields();
            pk.Add(tbMOE_BookFolder.Fields.BFRef);
            page.PageSize = pageSize;
            page.Result = base.GetPage(null, null, null, pk, pageIndex, page.PageSize, out RecordCount);
            page.RecordCount = RecordCount;
            return page;
        }

    }
}

