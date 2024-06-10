using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _1
{
    internal class Timer
    {
        public void Execute(Action func, int t)
        {
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    func.Invoke();
                    Thread.Sleep(TimeSpan.FromSeconds(t));
                }
            });
            thread.Start();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();

            timer.Execute(() =>
            {
                Console.WriteLine("1 message!");
            }, 5);

            timer.Execute(() =>
            {
                Console.WriteLine("2 message!");
            }, 2);

            Console.ReadLine();
        }
    }
}
