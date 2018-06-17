using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Balls
{
    class Program
    {
        private static int[] elements;
        private static int totalBalls;
        private static int maxBalls;
        private static int[] results;
        private static List<string> printing;

        static void Main(string[] args)
        {
            int pockets = int.Parse(Console.ReadLine());
            totalBalls = int.Parse(Console.ReadLine());
            maxBalls = int.Parse(Console.ReadLine());
            results = new int[pockets];
            printing = new List<string>();
            PermuteRecursively(0, totalBalls);
            Console.WriteLine(String.Join(Environment.NewLine, printing));
        }
        private static void PermuteRecursively(int index, int remaining)
        {
            if (index == results.Length)
            {
                printing.Add(String.Join(", ", results));
                return;
            }
            for (int i = Math.Min(maxBalls, remaining); i >= Math.Max(1, remaining - (results.Length - index - 1) * maxBalls); i--)
            {

                results[index] = i;
                PermuteRecursively(index + 1, remaining - i);
            }
        }
    }
}
