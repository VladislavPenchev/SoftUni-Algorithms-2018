using System;

namespace _4.Variations
{
    class Program
    {
        static int[] elements;
        static int[] variations;
        static bool[] uses;

        static void Variation(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ",variations));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!uses[i])
                    {
                        uses[i] = true;
                        variations[index] = elements[i];
                        Variation(index + 1);
                        uses[i] = false;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            elements = new int[] { 1, 2, 3, 4 };
            variations = new int[2];
            uses = new bool[elements.Length];

            Variation(0);
        }
    }
}
