using System;
using System.Linq;

namespace _5.GenerationCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int border = int.Parse(Console.ReadLine());
            int[] vector = new int[border];


            GenCombs(arr,vector,0,border);
        }

        private static void GenCombs(int[] set ,int[] vector,int index,  int border)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ",vector));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenCombs(set, vector, index + 1, i + 1);
                }
            }
        }
    }
}
