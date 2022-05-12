using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlModul.DBControl.SQL.Exceptions
{
    class ConnectionStringIsEmptyException : Exception
    {
        const string message = "Connection String is Null or Empty!";
        public ConnectionStringIsEmptyException() : base(message) { }
    }
}
