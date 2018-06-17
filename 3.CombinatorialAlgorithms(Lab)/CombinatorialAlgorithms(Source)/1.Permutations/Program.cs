using System;

namespace _1.Permutations
{
    class Program
    {
        static int[] elements;
        static bool[] used;
        static int[] permutations;

        static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    var currentElement = elements[i];
                    if (!used[i])
                    {
                        used[i] = true;
                        permutations[index] = currentElement;
                        Permute(index + 1);
                        used[i] = false;
                    }
                }
            }
        }



        static void Main(string[] args)
        {
            elements = new[] { 1, 2, 3 };
            used = new bool[elements.Length];
            permutations = new int[elements.Length];

            Permute(0);

        }
    }
}
