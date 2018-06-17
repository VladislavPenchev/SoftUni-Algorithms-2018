using System;

namespace GeneraterMethod
{
    public class Program
    {
        public static void Generater(int index, int[] arr)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    arr[index] = i;
                    Generater(index + 1, arr);
                }
            }
        }

        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int[] arr = new int[number];
            Generater(0,arr);
        }
    }
}
