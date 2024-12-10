using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Exceptions
{
    public class InvalidTcException : Exception
    {
       public InvalidTcException(string message) : base(message)
        {

        }
    }
}
