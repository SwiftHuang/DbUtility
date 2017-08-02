using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using hwj.DBUtility;
using hwj.DBUtility.MSSQL;
using hwj.DBUtility.Interface;
using hwj.DBUtility.MSSQL.Interface;

namespace Test.DB
{
    /// <summary>
    /// DataAccess [Table:EMOSSETUP]
    /// </summary>
    public partial class DAEMOSSETUP : DALDependency<tbEMOSSETUP, tbEMOSSETUPs>
    {
        public DAEMOSSETUP(string connectionString)
            : base(connectionString)
        {
            TableName = tbEMOSSETUP.DBTableName;
        }
        public DAEMOSSETUP(IMSSQLConnection conn)
            : base(conn)
        {

        }

        public bool Add(tbEMOSSETUP entity)
        {
            return base.Add(entity);
        }

        public bool Update(tbEMOSSETUP updateEntity, string id, string companyCode, string branchCode)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbEMOSSETUP.Fields.ID, id, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbEMOSSETUP.Fields.CompanyCode, companyCode, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbEMOSSETUP.Fields.BranchCode, branchCode, Enums.Relation.Equal, Enums.Expression.AND);
            return base.Update(updateEntity, fp);
        }

        public bool Delete(string id, string companyCode, string branchCode)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbEMOSSETUP.Fields.ID, id, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbEMOSSETUP.Fields.CompanyCode, companyCode, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbEMOSSETUP.Fields.BranchCode, branchCode, Enums.Relation.Equal, Enums.Expression.AND);
            return base.Delete(fp);
        }

        public tbEMOSSETUP GetEntity(string id, string companyCode, string branchCode)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbEMOSSETUP.Fields.ID, id, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbEMOSSETUP.Fields.CompanyCode, companyCode, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbEMOSSETUP.Fields.BranchCode, branchCode, Enums.Relation.Equal, Enums.Expression.AND);
            return base.GetEntity(fp);
        }

        public tbEMOSSETUPs GetList(string companyCode, List<string> IDList)
        {
            FilterParams fp = new FilterParams();
            //fp.AddParam(tbEMOSSETUP.Fields.ID, IDList, Enums.Relation.IN, Enums.Expression.AND);
            fp.AddParam(tbEMOSSETUP.Fields.ID, new List<string>(), Enums.Relation.IN, Enums.Expression.AND);
            //fp.AddParam(tbEMOSSETUP.Fields.ID, new List<string>() { "BKGREF", "BKGREF2" }, Enums.Relation.IN, Enums.Expression.OR);
            fp.AddParam(tbEMOSSETUP.Fields.CompanyCode, companyCode, Enums.Relation.Equal, Enums.Expression.AND);

            return base.GetList(null, fp);
        }
    }
}

