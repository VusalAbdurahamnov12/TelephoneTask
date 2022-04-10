using System;
using System.Collections.Generic;
using System.Text;
using Telephone.Interface;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Telephone.Models
{
    class MyTelephone : IContact
    {
        List<Person> MyContact = new List<Person>();

        
        public MyTelephone(Person Myperson)
        {

        }
        public void Add(Person person)
        {
            MyContact.Add(person);
        }

        public void Call(Person Myperson,Person person)
        {
            double decrease = 0 ;
            Console.WriteLine($"My person {Myperson.Provider}");
            Console.WriteLine($"person {person.Provider}");
            if (Myperson.Provider == "Azercell") decrease = AzercellDecrease(person);
            else if(Myperson.Provider =="Bakcell")decrease = BakcellDecrease(person);
            else if(Myperson.Provider =="Nar")decrease = NarDecrease(person);            
            else if(Myperson.Provider =="Bakcell")decrease = NaxTelDecrease(person);            
            if (Myperson.Balance >= decrease)
            {
                Console.WriteLine(decrease);
                Console.WriteLine("Calling");
                Thread.Sleep(10000);
                Console.WriteLine("Takes call");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Task decreaseBalance = new Task(() => DecreaseBalance(Myperson,decrease));
                Task waitingKey = new Task(() => WaitingKey());


                waitingKey.Start();
                decreaseBalance.Start();
                Task.WhenAny(waitingKey, decreaseBalance).Wait();

                watch.Stop();
                var elapsedS = Math.Round(watch.Elapsed.TotalSeconds, 0);

                TimeSpan time = TimeSpan.FromSeconds(elapsedS);
                string str = time.ToString(@"hh\:mm\:ss");
                Console.WriteLine(Myperson.Balance);
                Console.WriteLine($"Total talking time :{str}");
                Myperson.HowMuchTalk = str;
            }
            else Console.WriteLine("You dont have enough balance");
        }
        static void WaitingKey()
        {
            while (Console.ReadKey().Key != ConsoleKey.Enter) Console.Clear();

            return;
        }
        static void DecreaseBalance(Person p,double tariff)//threading ile acamq
        {
            while (true)
            {
                Thread.Sleep(5000);
                p.Balance -= tariff;
                Console.WriteLine(p.Balance);
                if (p.Balance < tariff) 
                {
                    Console.WriteLine("Your balance is 0 now please increase your balance");
                    return; 
                }
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
Number-{item.Number}
How much you talk with him/her -{item.HowMuchTalk}");
            }
        }
        public Person SearchbyName(string name)
        {
            foreach (var item in MyContact)
            {
                if (item.FullName == name)
                {
                    return item;
                }
            }
            return null;
        }
        public double AzercellDecrease(Person person)
        {
            if (person.Provider == "Azercell") return 0.03;
            else if (person.Provider == "Bakcell") return 0.04;
            else if (person.Provider == "Nar") return 0.05;
            else if (person.Provider == "NaxTel") return 0.02;
            return 0.03;
        }
        public double BakcellDecrease(Person person)
        {
            if (person.Provider == "Azercell") return 0.04;
            else if (person.Provider == "Bakcell") return 0.03;
            else if (person.Provider == "Nar") return 0.05;
            else if (person.Provider == "NaxTel") return 0.02;
            return 0.03;
        }
        public double NarDecrease(Person person)
        {
            if (person.Provider == "Azercell") return 0.05;
            else if (person.Provider == "Bakcell") return 0.05;
            else if (person.Provider == "Nar") return 0.03;
            else if (person.Provider == "NaxTel") return 0.02;
            return 0.03;
        }
        public double NaxTelDecrease(Person person)
        {
            if (person.Provider == "Azercell") return 0.02;
            else if (person.Provider == "Bakcell") return 0.02;
            else if (person.Provider == "Nar") return 0.02;
            else if (person.Provider == "NaxTel") return 0.02;
            return 0.03;
        }
        public void IncreaseBalance(Person person)
        {
            person.Balance++;
            Console.WriteLine("Added balance");
        }
       
        public void ProviderSetter(Person person)
        {
            Regex Azercellreg = new Regex(@"^(\+994|0?)(50|51|10?)");
            Regex Bakcellreg = new Regex(@"^(\+994|0?)(55|90?)");
            Regex Narreg = new Regex(@"^(\+994|0?)(70|77?)");
            Regex NaxTelreg = new Regex(@"^(\+994|0?)(60?)");

            if (Azercellreg.IsMatch(person.Number)==true) person.Provider = "Azercell";
            else if (NaxTelreg.IsMatch(person.Number)==true) person.Provider = "NaxTel";
            else if(Narreg.IsMatch(person.Number)==true) person.Provider = "Nar";
            else if (Bakcellreg.IsMatch(person.Number) == true) person.Provider = "Bakcell";


        }
    }
}
