using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Telephone.Models
{
    class Person
    {
        private string _number;
        public string FullName { get; set; }
        public string Number
        {
            get
            {
                return _number;
            }
            set 
            {
                if (NumberChecker(value) == true) _number = value;
                else throw new Exception("sda");
            }
        }
        public bool IsAviable { get; set; }
        public double Balance { get; set; }
        public string HowMuchTalk { get; set; }
        //public  enum Provayder
        //{
        //    Nar, Azercell, Bakcell
        //}
        public string Provider { get; set; }
        public Person(string fullName, string number, double balance, bool isAviable)
        {
            FullName = fullName;
            Balance = balance;
            Number = number;
            IsAviable = isAviable;
        }

        public bool NumberChecker(string number)
        {
            Regex reg = new Regex(@"^([+994|0]+)([\-])?([(50|51|10|55|99|70|77|60)]+)([\-])?([2-9])([0-9]{2})+([\-])?([0-9]{2})+([\-])?([0-9]{2})$");
            //Regex reg = new Regex(@"^(\+994|0?)((50|51|10|55|99|70|77|60?)+)([\-])?([2-9])([0-9]{2})+([\-])?([0-9]{2})+([\-])?([0-9]{2})$");
            return reg.IsMatch(number);
        }

        public bool CheckName(string number)
        {
            return true;
        }

    }
}
