using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Telephone.CustomException;
namespace Telephone.Models
{
    class Person
    {
        private string _number;
        private string _fullName;
        private double _balance;
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (String.IsNullOrEmpty(value) == false && String.IsNullOrWhiteSpace(value) == false) _fullName = value;
                else throw new FullNameIsntCorrectException("Please type name correctly");
            }
        }
        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (NumberChecker(value) == true) _number = value;
                else throw new NumberIsntCorrectException("Please type number correctly");
            }
        }
        public bool IsAviable { get; set; }
        public double Balance
        {
            get 
            {
                return _balance;
            }
            set 
            {
                if (value >= 0) _balance = value;
                else throw new BalanceIsntCorrect("Balance cant be negative");
            }
        }
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
            return reg.IsMatch(number);
        }


        public override string ToString()
        {
            return $@"Full Name-{FullName}
Number-{Number}";
        }
    }
}
