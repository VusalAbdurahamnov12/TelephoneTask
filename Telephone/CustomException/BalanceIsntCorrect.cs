using System;
using System.Collections.Generic;
using System.Text;

namespace Telephone.CustomException
{
    internal class BalanceIsntCorrect : Exception
    {
        public BalanceIsntCorrect(string message):base(message)
        {

        }
    }
}
