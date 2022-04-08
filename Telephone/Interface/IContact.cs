using System;
using System.Collections.Generic;
using System.Text;

namespace Telephone.Interface
{
    interface IContact
    {
        /*
         Delete
Add 
CallHistory*/

        public void Add(Person person);
        public void Delete(Person person);
        public void Call(string name);
        public void CallByNumber(int number);
    }
}
