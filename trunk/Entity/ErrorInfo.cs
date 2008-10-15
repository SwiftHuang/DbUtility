using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WongTung.Entity
{
    public class ErrorInfo : BaseEntity<ErrorInfo>
    {
        public enum ErrorTypes
        {
            None,
            Login,
            DefaultException,
            Exception
        }

        #region Attribue
        public ErrorTypes ErrorType { get; set; }
        public Exception Exceptions { get; set; }
        public LoginInfo LoginInfos { get; set; }
        #endregion

    }

}
