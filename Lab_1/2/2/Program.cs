using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        delegate bool FilterDelegate(int num, int k);

        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.Write("Enter value of k: ");
            int k = int.Parse(Console.ReadLine());

            // Виконуємо фільтрацію за допомогою методу Where класу Enumerable
            int[] filteredArray1 = FilterArrayWithWhere(array, k);
            Console.WriteLine("Filtered Array using Enumerable.Where:");
            PrintArray(filteredArray1);

            // Виконуємо власну реалізацію фільтрації
            int[] filteredArray2 = FilterArrayCustom(array, k);
            Console.WriteLine("Filtered Array using custom implementation:");
            PrintArray(filteredArray2);
            Console.ReadKey();
        }

        static bool IsMultiple(int num, int k)
        {
            return num % k == 0;
        }

        static int[] FilterArrayWithWhere(int[] array, int k)
        {
            FilterDelegate filterDelegate = IsMultiple;
            return Array.FindAll(array, num => filterDelegate(num, k));
        }

        static int[] FilterArrayCustom(int[] array, int k)
        {
            FilterDelegate filterDelegate = IsMultiple;
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (filterDelegate(array[i], k))
                {
                    count++;
                }
            }

            int[] result = new int[count];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (filterDelegate(array[i], k))
                {
                    result[index++] = array[i];
                }
            }

            return result;
        }

        static void PrintArray(int[] array)
        {
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
