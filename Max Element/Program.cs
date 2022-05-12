using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Max_Element
{
    class Program
    {
        static int FindMax(int[] arr, int r, int l)
        {
            int max = arr[0];
            for (int i = l + 1; i < r; i++)
            {
                for (int k = 0; k < 1000; k++);

                if (arr[i] > max)
                    max = arr[i];

            }

            return max;           
        }

        static int FindMaxParallel(int[] arr, int threadsCount)
        {
            var threads = new Thread[threadsCount];
            var maxVals = new int[threadsCount];

            var part = arr.Length / threadsCount;

              for (int t = 0; t < threadsCount; t++)
              {
                threads[t] = new Thread((o) =>
                {
                    var _t = (int)o;

                    maxVals[_t] = FindMax(arr, _t * part, (_t + 1) * part);
                });

                threads[t].Start(t);
              } 
            
              for(int t = 0; t < threadsCount; t++)

                threads[t].Join();

            return FindMax(maxVals, 0, maxVals.Length);
        }
        static void Main(string[] args)
        {
            var r = new Random();
            var arr = Enumerable.Range(0, 1_000_000).Select(n => r.Next()).ToArray();

            var dt1 = DateTime.Now;
            var max = FindMax(arr, 0, arr.Length);
            var dt2 = DateTime.Now;

            Console.WriteLine($"Max: {max}, {(dt2 - dt1).Milliseconds}");

            var dt3 = DateTime.Now;
            max = FindMaxParallel(arr, 2);
            var dt4 = DateTime.Now;

            Console.WriteLine($"Max: {max}, {(dt4 - dt3).Milliseconds}");

            Console.ReadLine();
        }
    }
}
