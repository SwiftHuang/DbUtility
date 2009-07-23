using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility.MSSQL
{
    public class BaseSqlDAL<T, TS>
        where T : BaseSqlTable<T>, new()
        where TS : List<T>, new()
    {
        protected static GenerateSelectSql<T> GenSql = new GenerateSelectSql<T>();
        private const string SqlFormat = "({0}) AS TEMPHWJ";
        #region Property
        public string CommandText { get; set; }
        protected SqlEntity _SqlEntity = null;
        public SqlEntity SqlEntity
        {
            get { return _SqlEntity; }
        }
        #endregion

        public TS GetList(DisplayFields displayFields, FilterParams filterParam, SortParams sortParams, int? maxCount)
        {
            _SqlEntity = new SqlEntity(GenSql.SelectSql(string.Format(SqlFormat, CommandText), displayFields, filterParam, sortParams, maxCount, false), GenSql.GenParameter(filterParam));
            return GetList(SqlEntity.CommandText, SqlEntity.Parameters);
        }
        public TS GetList(string sql, List<SqlParameter> parameters)
        {
            SqlDataReader reader = DbHelper.ExecuteReader(sql, parameters);
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
