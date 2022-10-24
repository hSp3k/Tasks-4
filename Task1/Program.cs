using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Source;

namespace Task1
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            User obj = new User("Дмитрий", "Гирко", DateTime.Parse("21.11.2003")  ,"hSpek");
            //obj.DateBirth = DateTime.Parse("21.11.4000");
            obj.ExtractingData("hSpek, Дмитрий, Био-Сарава-Лапласа, dmitriy_girko@mail.ru, 21.11.2003");
            Console.WriteLine(obj.ToString());
        }
    }
}
