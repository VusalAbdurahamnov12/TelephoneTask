using Telephone.Models;
namespace Telephone
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Abbas", "+994905140715", 0.18,true);
            Person p2 = new Person("Vusal", "+994771828921", 0.20, true);
            Person p3 = new Person("Jhon", "+994511828921", 0.30, true);
            Person p4 = new Person("Vusal", "+994101828921", 0.40, false);
            MyTelephone telephone = new MyTelephone(p1);
            telephone.Add(p2);
            telephone.Add(p3);
            telephone.Add(p4);
            telephone.ProviderSetter(p1);
            telephone.ProviderSetter(p2);
            telephone.ProviderSetter(p3);
            telephone.ProviderSetter(p4);
            telephone.Call( p3);
        }
        
    }
}
