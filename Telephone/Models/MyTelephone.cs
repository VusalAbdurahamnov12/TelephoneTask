using System;
using System.Collections.Generic;
using System.Text;
using Telephone.Interface;
namespace Telephone.Models
{
    class MyTelephone : IContact
    {
        List<Person> MyContact = new List<Person>();
        public void Add(Person person)
        {
            MyContact.Add(person);
        }

        public void Call(string name)
        {
             
        }

        public void CallByNumber(int number)
        {
             
        }

        public void Delete(Person person)
        {
            MyContact.Remove(person);
        }
    }
}
