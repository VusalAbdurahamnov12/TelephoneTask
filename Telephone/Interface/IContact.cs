using System;
using System.Collections.Generic;
using System.Text;
using Telephone.Models;
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
        public void Call(Person Myperson, Person person);
        public void CallByNumber(int number);
    }
}
