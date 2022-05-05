using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machines_and_exercises
{
    class Program
    {
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

            while (i < j)
            {
                Swap(ref vals[i], ref vals[j]);
                i++;
                j--;
            }

            return true;

        }
        static void Main(string[] args)
        {
            int[,] table = new int[,]
            {
                {8, 2, 9, 7},
                {9, 4, 3, 7},
                {5, 8, 1, 8},
                {7, 6, 9, 4}
            };

            var solution = new int[table.GetLength(0)];

            for (int i = 0; i < solution.Length; i++)
                solution[i] = i;
            var bestTime = int.MaxValue;
            var bestsolution = solution.ToArray();
            do
            {
                var solutionTime = 0;
                for (int i = 0; i < solution.Length; i++)
                    solutionTime += table[i, solution[i]];
                if(solutionTime < bestTime)
                {
                    bestTime = solutionTime;
                    bestsolution = solution.ToArray();
                }

            }

            while (nextPermutation(solution));

            for(int j = 0; j < bestsolution.Length; j++)
                Console.WriteLine($"{(char)('A' + j)} : {bestsolution[j + 1]}");

            Console.WriteLine($"={bestTime}");

            Console.ReadLine();


        }
    }
}
