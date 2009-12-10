using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility.MSSQL
{
    public class BaseSqlDAL<T, TS> : BaseDataAccess<T>
        where T : BaseSqlTable<T>, new()
        where TS : List<T>, new()
    {
        protected static GenerateSelectSql<T> GenSelectSql = new GenerateSelectSql<T>();
        private const string SqlFormat = "({0}) AS TEMPHWJ";

        #region Property
        public string CommandText { get; set; }
        #endregion

        public BaseSqlDAL(string ConnectionString)
            : base(ConnectionString)
        {

        }

        public TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            _SqlEntity = new SqlEntity(GenSelectSql.SelectSql(string.Format(SqlFormat, CommandText), displayFields, filterParam, sortParams, maxCount, false), GenSelectSql.GenParameter(filterParam));
            return GetList(SqlEntity.CommandText, SqlEntity.Parameters);
        }
        public TS GetList(string sql, List<SqlParameter> parameters)
        {
            SqlDataReader reader = DbHelper.ExecuteReader(ConnectionString, sql, parameters);
            try
            {
                if (reader.HasRows)
                    return GenerateEntity<T, TS>.CreateListEntity(reader);
                else
                    return new TS();
            }
            catch
            { throw; }
            finally
            {
                if (!reader.IsClosed)
                    reader.Close();
            }
        }

    }
}
