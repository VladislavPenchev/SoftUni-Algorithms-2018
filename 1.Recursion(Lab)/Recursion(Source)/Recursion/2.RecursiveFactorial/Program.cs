using System;

namespace _2.RecursiveFactorial
{
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            long result = Factorial(number);
            Console.WriteLine(result);

        }

        private static long Factorial(int num)
        {
            if (num == 0)
            {
                return 1;
            }

            var recursion = num * Factorial(--num);

            return recursion;
        }
    }
}
