using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WongTung.Common
{
    /// <summary>
    /// 非法数据异常
    /// </summary>
    public class InvalidDataException : ApplicationException
    {
        /// <summary>
        /// 构造非法数据异常
        /// </summary>
        public InvalidDataException()
            : base()
        {
        }
        /// <summary>
        /// 构造非法数据异常
        /// </summary>
        /// <param name="message">异常信息</param>
        public InvalidDataException(string message)
            : base(message)
        {
        }
    }
}
