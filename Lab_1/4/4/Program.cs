using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    // Створення масиву делегатів
                    var delArray = new Func<double, double>[3];

                    // Ініціалізація делегатів
                    delArray[0] = n => Math.Sqrt(Math.Abs(n));
                    delArray[1] = n => Math.Pow(n, 3);
                    delArray[2] = n => n + 3.5;                   
                    Console.WriteLine("Введіть умову в форматі: варіант (0-2) число");
                    var input = Console.ReadLine().Trim().Split();

                    // Виклик відповідного делегата із масиву delArray, залежно від введених користувачем даних
                    Console.WriteLine(delArray[int.Parse(input[0])](double.Parse(input[1])));
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
