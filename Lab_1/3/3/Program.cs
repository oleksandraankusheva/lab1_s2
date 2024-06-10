using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        public delegate double SeriesTerm(int n);

        public static double CalculateSum(SeriesTerm term, double precision)
        {
            double sum = 0.0;
            double currentTerm = 0.0;
            int n = 0;

            do
            {
                currentTerm = term(n);
                sum += currentTerm;
                n++;
            } while (Math.Abs(currentTerm) > precision);

            return sum;
        }

        public static double Series1Term(int n)
        {
            return 1.0 / Math.Pow(2, n);
        }

        public static double Series2Term(int n)
        {
            return 1.0 / Factorial(n + 1);
        }

        public static double Series3Term(int n)
        {
            return Math.Pow(-1, n) / Math.Pow(2, n);
        }

        public static double Factorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            else
                return n * Factorial(n - 1);
        }

        public static void Main()
        {
            double precision = 1e-6;

            Console.WriteLine("Series 1 Sum: " + CalculateSum(Series1Term, precision));
            Console.WriteLine("Series 2 Sum: " + CalculateSum(Series2Term, precision));
            Console.WriteLine("Series 3 Sum: " + CalculateSum(Series3Term, precision));

            Console.ReadKey();
        }
    }
}
