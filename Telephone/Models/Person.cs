using System;
using System.Collections.Generic;
using System.Text;

namespace Telephone.Interface
{
    class Person
    {
        public string FullName { get; set; }
        public string Number{ get; set; }
        public bool IsAviable { get; set; }
        public int Balance { get; set; }
        public enum Tarif
        {
            GencOl, Serbest, Sade
        }
        public Person(string FullName  ,int number,int balance , Tarif t) 
        {
            FullName = name;
            Balance = balance;
            Number = number;
        }


    }
}
