using System;
using System.Collections.Generic;
using System.Text;

namespace Telephone.CustomException
{
    internal class NumberIsntCorrectException : Exception
    {
        public NumberIsntCorrectException(string message):base(message)
        {

        }
    }
}
