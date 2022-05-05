using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{

    class Program
    {
        static void bubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for(int j = 0; j < n - i - 1; j++)
                    if(arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }

        static void selectionSort(int[] arr)
        {
            int n = arr.Length;
            for(int i = n - 1; i > 0; i--)
            {
                int maxIdx = i;
                for (int j = i - 1; j >= 0; j--)
                    if (arr[j] > arr[maxIdx])
                        maxIdx = j;

                int temp = arr[maxIdx];
                arr[maxIdx] = arr[i];
                arr[i] = temp;
            }
        }
        static void insertionSort(int[] arr)
        {
            int n = arr.Length;
            for(int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                while(j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        static void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        static bool nextPermutation(int[] vals)
        {
            int i = vals.Length - 1;
            while (i > 0 && vals[i - 1] >= vals[i])
                i--;
            if (i <= 0)
                return false;

            int j = vals.Length - 1;
            while (vals[i - 1] >= vals[j])
                j--;

            Swap(ref vals[i - 1], ref vals[j]);

            j = vals.Length - 1;

            while(i < j)
            {
                Swap(ref vals[i], ref vals[j]);
                i++;
                j--;
            }

            return true;

        }
        static void Main(string[] args)
        {
            Random r = new Random();

            var arr = new int[10000];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = r.Next(100);
            var arr1 = arr
            .ToArray();

            var arr2 = arr
            .ToArray();

            var arr3 = arr
            .ToArray();


            var t1 = DateTime.Now;

            insertionSort(arr1);

            var t2 = DateTime.Now;

            selectionSort(arr2);

            var t3 = DateTime.Now;

            bubbleSort(arr3);

            var t4 = DateTime.Now;

            Console.WriteLine($"InsertionSort: {(t2 - t1).Milliseconds}");
            Console.WriteLine($"SelectionSort: {(t3 - t2).Milliseconds}");
            Console.WriteLine($"BubbleSort: {(t4 - t3).Milliseconds}");

            Console.ReadLine();
        }
    }
}
