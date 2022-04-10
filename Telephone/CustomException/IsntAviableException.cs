using System;
using System.Collections.Generic;
using System.Text;

namespace Telephone.CustomException
{
    internal class IsntAviableException : Exception
    {
        public IsntAviableException(string message) : base(message) 
        {

        }
    }
}
