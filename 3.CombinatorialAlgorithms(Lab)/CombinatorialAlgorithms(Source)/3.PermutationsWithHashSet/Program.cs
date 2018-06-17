using System;
using System.Collections.Generic;

namespace _3.PermutationsWithHashSet
{
    class Program
    {
        static int[] elements;

        static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                HashSet<int> swapped = new HashSet<int>();  
                Permute(index + 1);

                for (int i = 0; i < elements.Length; i++)
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                    swapped.Add(elements[i]);
                }
            }
        }

        static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }

        static void Main(string[] args)
        {
            elements = new[] { 1, 2, 3 };

            Permute(0);
        }
    }
}
