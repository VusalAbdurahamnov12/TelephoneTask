using System;
using System.Collections.Generic;
using System.Text;
using Telephone.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace Telephone.Models
{
    class MyTelephone : IContact
    {
        List<Person> MyContact = new List<Person>();
        public void Add(Person person)
        {
            MyContact.Add(person);
        }

        public void Call(Person person)
        {
            
            Console.WriteLine("Calling");
            Thread.Sleep(10000);
            Console.WriteLine("Takes call");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Task decreaseBalance = new Task(() =>  DecreaseBalance(person));
            Task waitingKey = new Task(() => WaitingKey());

            
            waitingKey.Start();
            decreaseBalance.Start();
            Task.WhenAny(waitingKey, decreaseBalance).Wait();

            watch.Stop();
            var elapsedS = Math.Round(watch.Elapsed.TotalSeconds, 0);

            TimeSpan time = TimeSpan.FromSeconds(elapsedS);
            string str = time.ToString(@"hh\:mm\:ss");
            Console.WriteLine(person.Balance);
            Console.WriteLine($"Total talking time :{str}");
        }
        static void  WaitingKey()
        {
            while (Console.ReadKey().Key != ConsoleKey.Enter) Console.Clear();
            
            return;
        }
        static void DecreaseBalance(Person p)//threading ile acamq
        {
            while (true)
            {
                Thread.Sleep(10000);
                p.Balance -= 0.03;
                if (p.Balance < 0.03) return;
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
