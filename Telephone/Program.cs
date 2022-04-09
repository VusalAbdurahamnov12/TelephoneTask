using System;
using System.Threading;
using System.Threading.Tasks;
using Telephone.Models;
namespace Telephone
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Abbas", "+98231231321", 0.18);
            MyTelephone telephone = new MyTelephone();

            telephone.Call(p1);
        }
        
    }
}
