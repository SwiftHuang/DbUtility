using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WongTung.Common
{
    public class xException : Exception
    {
        private string _message = string.Empty;
        public xException(string message)
        {
            _message = message;
        }
        public override string Message
        {
            get { return _message; }
        }
    }
}
