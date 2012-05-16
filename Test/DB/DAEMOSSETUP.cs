using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using hwj.DBUtility;
using hwj.DBUtility.MSSQL;

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

        public static bool Update(DbTransaction trans, tbEMOSSETUP updateEntity, string id, string companyCode, string branchCode)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbEMOSSETUP.Fields.ID, id, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbEMOSSETUP.Fields.CompanyCode, companyCode, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbEMOSSETUP.Fields.BranchCode, branchCode, Enums.Relation.Equal, Enums.Expression.AND);
            return DAEMOSSETUP.Update(trans, updateEntity, fp);
            //return  .Update(updateEntity, fp);
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

        public tbEMOSSETUP GetEntity(DbTransaction trans, string id, string companyCode, string branchCode)
        {
            FilterParams fp = new FilterParams();
            fp.AddParam(tbEMOSSETUP.Fields.ID, id, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbEMOSSETUP.Fields.CompanyCode, companyCode, Enums.Relation.Equal, Enums.Expression.AND);
            fp.AddParam(tbEMOSSETUP.Fields.BranchCode, branchCode, Enums.Relation.Equal, Enums.Expression.AND);

            return trans.GetEntity<tbEMOSSETUP>(DAEMOSSETUP.GetSQLEntity(fp));
        }
    }
}

