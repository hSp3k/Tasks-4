using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Source;

namespace Task2
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            DynamicArray<int> obj1 = new DynamicArray<int>();
            DynamicArray<int> obj2 = new DynamicArray<int>();

            obj1.CapacityChanged += CapacityChanged;
            obj1.CapacityChanged += CapacityChanged;

            int[] array1 = { 1, 2, 3, 4, 10 };
            int[] array2 = { 10, 4, 3, 2, 1 };

            

            obj1.AddRange(array1);
            obj1.AddRange(array1);
            obj1.AddRange(array1);
            obj1.AddRange(array1);
            obj1.AddRange(array1); 
            obj1.AddRange(array1);
            obj1.AddRange(array1);


            foreach (var item in obj1)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            //Console.WriteLine(obj1 != obj2);
        }

        public static void CapacityChanged(object sender, CapacityEventArgs e)
        {
            Console.WriteLine($"{e.GetType()} : {e.OldCapacity} -> {e.NewCapacity}");
        }
    }
}
