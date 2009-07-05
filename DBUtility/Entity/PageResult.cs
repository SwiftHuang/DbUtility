using System.Collections.Generic;

namespace hwj.DBUtility.Entity
{
    public class PageResult<T> where T : class, new()
    {
        public int RecordCount { get; set; }
        public List<T> Result { get; set; }
        public int PageSize { get; set; }
    }
}
