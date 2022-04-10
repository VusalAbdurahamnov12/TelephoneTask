using Telephone.Models;
namespace Telephone
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Abbas", "+994905140715", 0.18,true);
            Person p2 = new Person("Vusal", "+994771828921", 0.20, true);
            MyTelephone telephone = new MyTelephone(p1);
            telephone.ProviderSetter(p1);
            telephone.ProviderSetter(p2);
            telephone.Call(p1, p2);
        }
        
    }
}
