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

        #region Get Entity
        public T GetEntity()
        {
            return GetEntity(null);
        }
        public T GetEntity(FilterParams filterParam)
        {
            return GetEntity(null, filterParam, null);
        }
        public T GetEntity(DisplayFields displayFields, FilterParams filterParam)
        {
            return GetEntity(displayFields, filterParam, null);
        }
        public T GetEntity(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            SqlEntity tmpSqlEty = new SqlEntity(GenSelectSql.SelectSql(string.Format(SqlFormat, CommandText), displayFields, filterParam, sortParams, 1), GenSelectSql.GenParameter(filterParam));
            _SqlEntity = tmpSqlEty;
            return GetEntity(tmpSqlEty.CommandText, tmpSqlEty.Parameters);
        }
        public T GetEntity(string sql, List<SqlParameter> parameters)
        {
            SqlDataReader reader = DbHelper.ExecuteReader(ConnectionString, sql, parameters);
            try
            {
                if (reader.HasRows)
                    return GenerateEntity<T, TS>.CreateSingleEntity(reader);
                else
                    return null;
            }
            catch
            { throw; }
            finally
            {
                if (!reader.IsClosed)
                    reader.Close();
            }
        }
        #endregion

        #region GetList
        public TS GetList()
        {
            return GetList(null, null, null, null);
        }
        public TS GetList(DisplayFields displayFields)
        {
            return GetList(displayFields, null, null, null);
        }
        public TS GetList(DisplayFields displayFields, FilterParams filterParam)
        {
            return GetList(displayFields, filterParam, null, null);
        }
        public TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams)
        {
            return GetList(displayFields, filterParam, sortParams, null);
        }
        public TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            SqlEntity tmpSqlEty = new SqlEntity(GenSelectSql.SelectSql(string.Format(SqlFormat, CommandText), displayFields, filterParam, sortParams, maxCount, false), GenSelectSql.GenParameter(filterParam));
            _SqlEntity = tmpSqlEty;
            return GetList(tmpSqlEty.CommandText, tmpSqlEty.Parameters);
        }
        public TS GetList(string sql, List<SqlParameter> parameters)
        {
            return GetList(sql, parameters, -1);
        }
        public TS GetList(string sql, List<SqlParameter> parameters, int timeout)
        {
            SqlDataReader reader = DbHelper.ExecuteReader(ConnectionString, sql, parameters, timeout);
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
        #endregion
    }
}
