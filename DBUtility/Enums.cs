using System;

namespace hwj.DBUtility
{
    public class Enums
    {
        /// <summary>
        /// 字段关系(Field [Relation] Value)
        /// </summary>
        public enum Relation
        {
            /// <summary>
            /// 等于(=)
            /// </summary>
            Equal,
            /// <summary>
            /// 不等于(&lt;&gt;)
            /// </summary>
            Unequal,
            /// <summary>
            /// 大于(&gt;)
            /// </summary>
            Greater,
            /// <summary>
            /// 小于(&lt;)
            /// </summary>
            Less,
            /// <summary>
            /// 大于等于(&gt;=)
            /// </summary>
            GreaterThanOrEqual,
            /// <summary>
            /// 小于等于(&lt;=)
            /// </summary>
            LessThanOrEqual,
            /// <summary>
            /// 为空(is null)
            /// </summary>
            IsNull,
            /// <summary>
            /// 不为空(is not null)
            /// </summary>
            IsNotNull,
            /// <summary>
            /// 相似(like)
            /// </summary>
            Like,
            /// <summary>
            /// 包含(in)
            /// </summary>
            IN,
            /// <summary>
            /// 不包含(not in)
            /// </summary>
            NotIN,
        }
        public enum DatabaseType
        {
            None,
            MySql,
            MsSql
        }
        /// <summary>
        /// 逻辑运算符
        /// </summary>
        public enum Expression
        {
            None,
            /// <summary>
            /// 逗号
            /// </summary>
            Comma,
            /// <summary>
            /// 与
            /// </summary>
            AND,
            /// <summary>
            /// 或
            /// </summary>
            OR
        }
        /// <summary>
        /// 排序
        /// </summary>
        public enum OrderBy
        {
            /// <summary>
            /// 降序
            /// </summary>
            Descending,
            /// <summary>
            /// 升序
            /// </summary>
            Ascending,
            None
        }
        public enum DataHandle
        {
            /// <summary>
            /// 不插入该字段
            /// </summary>
            UnInsert,
            /// <summary>
            /// 不更新该字段
            /// </summary>
            UnUpdate,
            /// <summary>
            /// 该字段不允许为Null
            /// </summary>
            UnNull,
        }
        public enum EffentNextType
        {
            /// <summary>
            /// 对其他语句无任何影响 
            /// </summary>
            None,
            /// <summary>
            /// 当前语句必须为"select count(1) from .."格式，如果存在则继续执行，不存在回滚事务
            /// </summary>
            WhenHaveContine,
            /// <summary>
            /// 当前语句必须为"select count(1) from .."格式，如果不存在则继续执行，存在回滚事务
            /// </summary>
            WhenNoHaveContine,
            /// <summary>
            /// 当前语句影响到的行数必须大于0，否则回滚事务
            /// </summary>
            ExcuteEffectRows,
            /// <summary>
            /// 引发事件-当前语句必须为"select count(1) from .."格式，如果不存在则继续执行，存在回滚事务
            /// </summary>
            SolicitationEvent
        }
    }
    public static class EnumsExtensions
    {
        public static string ToSqlString(this Enums.Relation oper)
        {
            switch (oper)
            {
                case Enums.Relation.Equal:
                    return "=";
                case Enums.Relation.Unequal:
                    return "<>";
                case Enums.Relation.IsNull:
                    return " is null ";
                case Enums.Relation.IsNotNull:
                    return " is not null";
                case Enums.Relation.GreaterThanOrEqual:
                    return ">=";
                case Enums.Relation.Greater:
                    return ">";
                case Enums.Relation.Less:
                    return "<";
                case Enums.Relation.LessThanOrEqual:
                    return "<=";
                case Enums.Relation.Like:
                    return " LIKE ";
                case Enums.Relation.IN:
                    return " IN({0}) ";
                case Enums.Relation.NotIN:
                    return " NOT IN({0}) ";
                default:
                    throw new Exception("Enums.Operator error");
            }
            throw new Exception("Enums.Operator error");
        }
        public static string ToSqlString(this Enums.Expression exp)
        {
            switch (exp)
            {
                case Enums.Expression.AND:
                    return " AND ";
                case Enums.Expression.OR:
                    return " OR ";
                case Enums.Expression.Comma:
                    return ",";
                case Enums.Expression.None:
                    return "";
                default:
                    throw new Exception("Enums Expression error");
            }
            throw new Exception("Enums Expression error");
        }
        public static string ToSqlString(this Enums.OrderBy ord)
        {
            switch (ord)
            {
                case Enums.OrderBy.Descending:
                    return "desc";
                case Enums.OrderBy.Ascending:
                    return string.Empty;
                case Enums.OrderBy.None:
                    return string.Empty;
                default:
                    return string.Empty;
            }
        }
        public static bool Find(this Enums.DataHandle[] handles, Enums.DataHandle dataHandle)
        {
            if (handles == null || handles.Length == 0)
                return false;
            foreach (Enums.DataHandle dh in handles)
            {
                if (dh == dataHandle)
                    return true;
            }
            return false;
        }
    }
}
