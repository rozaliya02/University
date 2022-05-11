using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Baker_and_Client
{
    class Program
    {

        const int CAPACITY = 5;
        static Queue<object> rack = new Queue<object>(CAPACITY);

        static Semaphore semaphoreFreeSpace = new Semaphore(CAPACITY, CAPACITY);
        static Semaphore semanphoreBread = new Semaphore(0, CAPACITY);

       
        static void Baker()
        {
            var r = new Random();

            while(true)
            {
                semaphoreFreeSpace.WaitOne();

                lock (rack)
                {
                    
                        Thread.Sleep(r.Next(300, 400));

                        Console.WriteLine($"Baker: making bread { rack.Count + 1}");
                        rack.Enqueue(null);

                        semanphoreBread.Release();
                    
                }
                
            }

        }

        static void Client(object o)
        {
            var n = (int)o;

            var r = new Random();

            while(true)
            {
                Thread.Sleep(r.Next(200, 300));

                lock(rack)
                {
                    
                        Console.WriteLine($"Client {n}: buying bread {rack.Count}");

                        rack.Dequeue();
                        semaphoreFreeSpace.Release();
                    
                }
            }
        }
        static void Main(string[] args)
        {
            new Thread(Baker).Start();

            new Thread(Client).Start(1);
            new Thread(Client).Start(2);
            new Thread(Client).Start(3);

            Console.ReadLine();


        }
    }
}
