using System;
using System.Collections.Generic;
using System.Text;
using Telephone.Interface;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Telephone.CustomException;
using Telephone.Extensions;
namespace Telephone.Models
{
    class MyTelephone : IContact
    {
        List<Person> MyContact = new List<Person>();
        public Person MyPerson { get; set; }
        public MyTelephone(Person myperson)
        {
            MyPerson = myperson;
        }
        public void Add(Person person)
        {
            MyContact.Add(person);
        }

        public void Call(Person person)
        {
            double decrease = FindProviderDecrease(MyPerson, person) ;          
            if (MyPerson.Balance >= decrease )
            {
                if (person.IsAviable == true)
                {
                    Console.WriteLine("Calling");
                    Thread.Sleep(10000);
                    Console.WriteLine("Takes call");
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    Task decreaseBalance = new Task(() => DecreaseBalance(MyPerson, decrease));
                    Task exitKey = new Task(() => ExitKey());

                    exitKey.Start();
                    decreaseBalance.Start();
                    Task.WhenAny(exitKey, decreaseBalance).Wait();
                    watch.Stop();
                    var elapsedS = Math.Round(watch.Elapsed.TotalSeconds, 0);

                    TimeSpan time = TimeSpan.FromSeconds(elapsedS);
                    string str = time.ToString(@"hh\:mm\:ss");
                    Console.WriteLine(MyPerson.Balance);
                    Console.WriteLine($"Total talking time :{str}");
                    person.HowMuchTalk = str;
                }
                else Console.WriteLine("This person busy now please call later");
            }
            else Console.WriteLine("You dont have enough balance");
        }
        static void ExitKey()
        {
            while (Console.ReadKey().Key != ConsoleKey.Q) Console.Clear();

            return;
        }
        static void DecreaseBalance(Person p,double tariff)//threading ile acamq
        {
            while (true)
            {
                Thread.Sleep(5000);
                p.Balance -= tariff;
                if (p.Balance < tariff) 
                {
                    Console.WriteLine("Your balance is 0 now please increase your balance");
                    return; 
                }
            }
        }
        public bool CheckIsAviable(Person person)
        {
            if (person.IsAviable == true) return true;
            throw new IsntAviableException("This person busy now please call later");
        }
        public void CallByNumber(int number)
        {
            double decrease = FindProviderDecrease(MyPerson, person);
            if (MyPerson.Balance >= decrease)
            {
                if (person.IsAviable == true)
                {
                    Console.WriteLine("Calling");
                    Thread.Sleep(10000);
                    Console.WriteLine("Takes call");
                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    Task decreaseBalance = new Task(() => DecreaseBalance(MyPerson, decrease));
                    Task exitKey = new Task(() => ExitKey());

                    exitKey.Start();
                    decreaseBalance.Start();
                    Task.WhenAny(exitKey, decreaseBalance).Wait();
                    watch.Stop();
                    var elapsedS = Math.Round(watch.Elapsed.TotalSeconds, 0);

                    TimeSpan time = TimeSpan.FromSeconds(elapsedS);
                    string str = time.ToString(@"hh\:mm\:ss");
                    Console.WriteLine(MyPerson.Balance);
                    Console.WriteLine($"Total talking time :{str}");
                    person.HowMuchTalk = str;
                }
                else Console.WriteLine("This person busy now please call later");
            }
            else Console.WriteLine("You dont have enough balance");
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
            name = name.UpperFirstLetter();
            foreach (var item in MyContact)
            {
                if (item.FullName == name)
                {
                    return item;
                }
            }
            return null;
        }
        public Person SearchbyNumber(string number)
        {
            number = number.UpperFirstLetter();
            foreach (var item in MyContact)
            {
                if (item.FullName == number)
                {
                    return item;
                }
            }
            return null;
        }
        public double FindProviderDecrease(Person myperson , Person person)
        {
            double decrease = 0;
            if (myperson.Provider == "Azercell") decrease = AzercellDecrease(person);
            else if (myperson.Provider == "Bakcell") decrease = BakcellDecrease(person);
            else if (myperson.Provider == "Nar") decrease = NarDecrease(person);
            else if (myperson.Provider == "Bakcell") decrease = NaxTelDecrease(person);
            return decrease;
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
        public void IncreaseBalance(string code)
        {
            if(code=="*101*1") MyPerson.Balance+=1;
            if(code=="*101*3") MyPerson.Balance+=3;
            if(code=="*101*5") MyPerson.Balance+=5;
            Console.WriteLine("Ussd code running ");
            Thread.Sleep(3000);
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
        public string ProviderFinder(string number)
        {
            Regex Azercellreg = new Regex(@"^(\+994|0?)(50|51|10?)");
            Regex Bakcellreg = new Regex(@"^(\+994|0?)(55|90?)");
            Regex Narreg = new Regex(@"^(\+994|0?)(70|77?)");
            Regex NaxTelreg = new Regex(@"^(\+994|0?)(60?)");

            if (Azercellreg.IsMatch(number) == true) return "Azercell";
            else if (NaxTelreg.IsMatch(number) == true) return"NaxTel";
            else if (Narreg.IsMatch(number) == true) return = "Nar";
            else if (Bakcellreg.IsMatch(number) == true) return = "Bakcell";


        }
    }
}
