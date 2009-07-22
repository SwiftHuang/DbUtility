using System.Collections.Generic;
using hwj.DBUtility.TableMapping;

namespace hwj.DBUtility.Entity
{
    public class PageResult<T, TS>
        where T : BaseTable<T>, new()
        where TS : List<T>, new()
    {
        /// <summary>
        /// 记录总数
        /// </summary>
        public int RecordCount { get; set; }
        /// <summary>
        /// 当前页结果集
        /// </summary>
        public TS Result { get; set; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize { get; set; }
    }
}
