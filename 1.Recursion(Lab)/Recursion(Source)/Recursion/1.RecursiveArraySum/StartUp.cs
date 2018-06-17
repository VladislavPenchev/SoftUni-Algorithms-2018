using System;
using System.Linq;

namespace _1.RecursiveArraySum
{
    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = Sum(arr,0);
            Console.WriteLine(sum);
        }

        private static int Sum(int[] array, int index)
        {
            if (array.Length == index)
            {
                return 0;
            }
            

            var recursion =  array[index] + Sum(array,index + 1);

            return recursion;
        }
    }
}
