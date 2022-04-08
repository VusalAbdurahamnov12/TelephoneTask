using System;
using System.Collections.Generic;
using System.Text;
using Telephone.Interface;
using System.Threading;
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
            bool isTalking = false;
            Person person = SearchbyName(name);
            if (person != null)
            {
                Console.WriteLine("Calling");
                Thread.Sleep(10000);
                DateTime startTimne = DateTime.UtcNow;
                int startingTime = startTimne.Millisecond;
                
            }
        }

        public void CallByNumber(int number)
        {   
             
        }

        public void Delete(Person person)
        {
            MyContact.Remove(person);
        }
        public void ShowAll() 
        {
            foreach (var item in MyContact)
            {
                Console.WriteLine($@"Name-{item.FullName}
Number-{item.Number}");
            }
        }
        public Person SearchbyName(string name)
        {
            foreach (var item in MyContact)
            {
                if(item.FullName == name)
                {
                    return item;
                }
            }
            return null;
        }

    }
}
