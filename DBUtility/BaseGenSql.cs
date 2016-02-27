using hwj.DBUtility.TableMapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace hwj.DBUtility
{
    public abstract class BaseGenSql<T> where T : class, new()
    {
        protected const string _StringFormat = "'{0}'";
        protected const string _DecimalFormat = "{0}";
        protected static string _FieldFormat = string.Empty;
        protected static string _SqlParam = string.Empty;
        protected static string _SqlWhereParam = string.Empty;

        /// <summary>
        /// 获取数据库SQL
        /// </summary>
        protected string DatabaseGetDateSql = string.Empty;

        private static readonly int andL = Enums.ExpressionString(Enums.Expression.AND).Length;
        private static readonly int andR = Enums.ExpressionString(Enums.Expression.OR).Length;

        #region Protected Functions

        protected string GetCondition(SqlParam para, bool isFilter, bool isPage)
        {
            StringBuilder sbStr = new StringBuilder();
            if (!para.IsCustomText)
            {
                string __MsSqlParam = string.Empty;
                if (isFilter)
                {
                    __MsSqlParam = _SqlWhereParam;
                }
                else
                {
                    __MsSqlParam = _SqlParam;
                }

                sbStr.AppendFormat(_FieldFormat, para.FieldName).Append(Enums.RelationString(para.Operator));

                if (para.Operator == Enums.Relation.IsNotNull || para.Operator == Enums.Relation.IsNull)
                {
                    //sbStr.Append(para.Expression.ToSqlString());
                }
                else if (isPage)
                {
                    if (para.IsUnicode)
                    {
                        sbStr.Append("N");//.Append('\'');
                    }
                    sbStr.Append('\'');

                    if (IsDatabaseDate(para))
                    {
                        sbStr.Append(DatabaseGetDateSql);
                    }
                    else
                    {
                        if (para.Operator == Enums.Relation.Like || para.Operator == Enums.Relation.NotLike)
                        {
                            sbStr.Append(para.FieldValue.ToString().Replace("'", "''").Replace("[", "[[]"));
                        }
                        else
                        {
                            sbStr.Append(para.FieldValue.ToString().Replace("'", "''"));
                        }
                    }

                    sbStr.Append('\'');//.Append('\'');
                }
                else if (IsDatabaseDate(para))
                {
                    sbStr.Append(DatabaseGetDateSql);
                }
                else
                {
                    sbStr.AppendFormat(__MsSqlParam, !string.IsNullOrEmpty(para.ParamName) ? para.ParamName : para.FieldName);
                }
            }
            else
            {
                sbStr.Append(para.CustomText);
            }
            sbStr.Append(Enums.ExpressionString(para.Expression));
            return sbStr.ToString();
        }

        protected string GenFilterParamsSql(FilterParams listParam, bool isPage)
        {
            if (listParam != null && listParam.Count > 0)
            {
                string strWhere = "WHERE ";
                StringBuilder sbWhere = new StringBuilder();
                int index = 0;
                if (!isPage)
                    sbWhere.Append(strWhere);
                foreach (SqlParam para in listParam)
                {
                    if (!para.IsCustomText)
                    {
                        if (string.IsNullOrEmpty(para.FieldName))
                        {
                            if (para.FieldValue.ToString() == ")")
                            {
                                string tmp = TrimSql(sbWhere.ToString());
                                sbWhere = new StringBuilder();
                                sbWhere.Append(tmp).Append(para.FieldValue).Append(Enums.ExpressionString(para.Expression));
                            }
                            else
                            {
                                sbWhere.Append(para.FieldValue);
                            }
                        }

                        #region IN

                        else if (para.Operator == Enums.Relation.IN || para.Operator == Enums.Relation.NotIN
                            || para.Operator == Enums.Relation.IN_InsertSQL || para.Operator == Enums.Relation.NotIN_InsertSQL)
                        {
                            StringBuilder inSql = new StringBuilder();
                            string[] strList = GetSQL_IN_Value(para.FieldValue);
                            if (strList == null || strList.Length == 0)
                            {
                                sbWhere.Append(" 1=0 ").Append(Enums.ExpressionString(para.Expression));
                                continue;
                            }
                            if (!isPage)
                            {
                                if (para.Operator == Enums.Relation.IN || para.Operator == Enums.Relation.NotIN)
                                {
                                    foreach (string s in strList)
                                    {
                                        inSql.AppendFormat(_SqlParam, (para.ParamName != null ? para.ParamName : "T") + index).Append(',');
                                        index++;
                                    }
                                }
                                else
                                {
                                    string tmpFormat = _StringFormat;
                                    FieldMappingInfo f = FieldMappingInfo.GetFieldInfo(typeof(T), para.FieldName);
                                    if (f != null)
                                    {
                                        if (IsNumType(f.DataTypeCode))
                                        {
                                            tmpFormat = _DecimalFormat;
                                        }

                                        foreach (string s in strList)
                                        {
                                            inSql.AppendFormat(tmpFormat, s).Append(',');
                                        }
                                    }
                                }
                            }
                            else
                            {
                                FieldMappingInfo f = FieldMappingInfo.GetFieldInfo(typeof(T), para.FieldName);
                                if (f != null)
                                {
                                    if (IsNumType(f.DataTypeCode))
                                    {
                                        foreach (string s in strList)
                                        {
                                            inSql.AppendFormat(_DecimalFormat, s).Append(',');
                                        }
                                    }
                                    else
                                    {
                                        foreach (string s in strList)
                                        {
                                            inSql.Append('N').AppendFormat(_StringFormat, s).Append(',');
                                        }
                                    }
                                }
                            }

                            if (!string.IsNullOrEmpty(inSql.ToString()))
                            {
                                sbWhere.AppendFormat(_FieldFormat, para.FieldName).AppendFormat(Enums.RelationString(para.Operator), inSql.ToString().TrimEnd(',')).Append(Enums.ExpressionString(para.Expression));
                            }
                        }
                        else if (para.Operator == Enums.Relation.IN_SelectSQL || para.Operator == Enums.Relation.NotIN_SelectSQL)
                        {
                            if (!string.IsNullOrEmpty(para.FieldValue.ToString()))
                            {
                                sbWhere.AppendFormat(_FieldFormat, para.FieldName).AppendFormat(Enums.RelationString(para.Operator), para.FieldValue.ToString().TrimEnd(';')).Append(Enums.ExpressionString(para.Expression));
                            }
                        }

                        #endregion IN
                        else
                        {
                            sbWhere.Append(GetCondition(para, true, isPage));
                        }
                    }
                    else
                    {
                        sbWhere.Append(GetCondition(para, true, isPage));
                    }
                }
                //格式化最后的表达式，
                if (sbWhere.ToString() == strWhere)
                    return string.Empty;
                else
                    return TrimSql(sbWhere.ToString());
            }
            else
                return string.Empty;
        }

        protected string GenFilterParamsSql(FilterParams listParam)
        {
            return GenFilterParamsSql(listParam, false);
        }

        protected string GenGroupParamsSql(GroupParams param)
        {
            return GenDisplayFieldsSql(param, true);
        }

        protected string GenDisplayFieldsSql(DisplayFields fields)
        {
            return GenDisplayFieldsSql(fields, false);
        }

        protected string GenDisplayFieldsSql(List<Enum> fields, bool isPage)
        {
            if (fields != null && fields.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Enum s in fields)
                {
                    sb.AppendFormat(_FieldFormat, s.ToString()).Append(',');
                }
                return sb.ToString().TrimEnd(',');
            }
            if (!isPage)
                return "*";
            else
                return "";
        }

        protected string GenSortParamsSql(SortParams orders)
        {
            return GenSortParamsSql(orders, false);
        }

        protected string GenSortParamsSql(SortParams orders, bool isPage)
        {
            if (orders != null)
            {
                StringBuilder sb = new StringBuilder();
                if (!isPage)
                    sb.Append("ORDER BY ");
                foreach (SortParam o in orders)
                {
                    sb.AppendFormat(_FieldFormat + " {1},", o.FieldName, Enums.OrderByString(o.OrderBy));
                }
                return sb.ToString().TrimEnd(',');
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// 格式化最后的表达式
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        protected string TrimSql(string sql)
        {
            if (sql.Substring(sql.Length - andL, andL) == Enums.ExpressionString(Enums.Expression.AND))
                sql = sql.Substring(0, sql.Length - andL);
            if (sql.Substring(sql.Length - andR, andR) == Enums.ExpressionString(Enums.Expression.OR))
                sql = sql.Substring(0, sql.Length - andR);
            return sql.TrimEnd(',');
        }

        ///// <summary>
        ///// 检查非法字符
        ///// </summary>
        ///// <param name="str"></param>
        ///// <returns></returns>
        //protected string CheckSql(string str)
        //{
        //    string s = string.Empty;
        //    if (str == null)
        //    {
        //        s = string.Empty;
        //    }
        //    else
        //    {
        //        s = str.Replace("'", "").Replace("*", "").Replace("select", "")
        //               .Replace("where", "").Replace(";", "").Replace("drop", "").Replace("DROP", "").Replace("and", "").Replace("or", "").Replace("delete", "").Replace("asc", "").Replace("<", "").Replace(">", "").Replace("=", "").Replace(";", "").Replace("&", "").Replace("*", "");
        //    }
        //    return s;
        //}

        protected bool IsNumType(DbType typeCode)
        {
            return Common.IsNumType(typeCode);
        }

        protected bool IsDateType(DbType typeCode)
        {
            if (typeCode == DbType.DateTime)
                return true;
            else
                return false;
        }

        protected bool IsDatabaseDate(SqlParam param)
        {
            if (param.FieldValue is DateTime && Convert.ToDateTime(param.FieldValue) == SqlParam.DatabaseDate)
                return true;
            return false;
        }

        protected bool IsDatabaseDate(System.Data.DbType dbType, object value)
        {
            if (IsDateType(dbType) && Convert.ToDateTime(value) == SqlParam.DatabaseDate)
                return true;
            else
                return false;
        }

        protected string[] GetSQL_IN_Value(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            else if (obj.GetType().IsGenericType)
            {
                Type type = obj.GetType();
                List<string> sList = new List<string>();
                if (Array.IndexOf(type.GetInterfaces(), typeof(IEnumerable)) > -1)
                {
                    IEnumerable en = obj as IEnumerable;
                    foreach (object t in en)
                    {
                        sList.Add(Convert.ToString(t));
                    }
                }
                return sList.ToArray();
            }
            else if (obj is string)
            {
                return new string[] { obj.ToString() };
            }
            else
            {
                return (string[])obj;
            }
        }

        #endregion Protected Functions


    }
}