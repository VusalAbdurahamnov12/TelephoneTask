using System;
using System.Collections.Generic;
using System.Text;

namespace Telephone.Models
{
    class Person
    {
        public string FullName { get; set; }
        public string Number{ get; set; }
        public bool IsAviable { get; set; }
        public double Balance { get; set; }
        public enum Tarif
        {
            GencOl, Serbest, Sade
        }
        public Person(string fullName  ,string number, double balance) 
        {
            FullName = fullName;
            Balance = balance;
            Number = number;
        }


    }
}
