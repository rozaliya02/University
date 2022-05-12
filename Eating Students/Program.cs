using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eating_Students
{
    class Program
    {
        const int COUNT = 5;
        static Semaphore[] forks;

        static void Student(object o)
        {
            var n = (int)o;
            var r = new Random();

            while(true)
            {
                Console.WriteLine($"Student {n} start thinking.");
                Thread.Sleep(r.Next(200, 300));
                Console.WriteLine($"Student {n} stop thinking");

                forks[n].WaitOne();
                forks[(n + 1) % COUNT].WaitOne();

                Console.WriteLine($"Student {n} start eating.");
                Thread.Sleep(r.Next(200, 300));
                Console.WriteLine($"Student {n} stop eating.");

                forks[n].Release();
                forks[(n + 1) % COUNT].Release();
            }
        }
        static void Main(string[] args)
        {

            forks = Enumerable.Range(0, COUNT).Select(s => new Semaphore(1, 1)).ToArray();

            new Thread(Student).Start(0);
            new Thread(Student).Start(1);
            new Thread(Student).Start(2);
            new Thread(Student).Start(3);
            new Thread(Student).Start(4);

            Console.ReadLine();
        }
    }
}
