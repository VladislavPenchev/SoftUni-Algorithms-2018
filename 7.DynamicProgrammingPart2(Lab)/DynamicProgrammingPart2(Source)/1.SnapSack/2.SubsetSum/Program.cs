namespace _2.SubsetSum
{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    class Program
    {
        static Dictionary<int, int> CalSum(int[] numbers)
        {
            Dictionary<int,int> result = new Dictionary<int, int>();

            result.Add(0, 0);

            for (int index = 0; index < numbers.Length; index++)
            {
                var currentNumber = numbers[index];

                Dictionary<int, int> newSums = new Dictionary<int, int>();

                foreach (int key in result.Keys.ToList())
                {
                    int newSum = key + currentNumber;

                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum,currentNumber);
                    }
                }

            }

            return result;
        }


        static void Main(string[] args)
        {
            int[] arr = new int[] { 3, 5, 1, 4, 2 };

            Dictionary<int,int> sums = CalSum(arr);

            int targetSum = 9;

            if (sums.ContainsKey(targetSum))
            {
                while (targetSum != 0)
                {
                    var number = sums[targetSum];

                    Console.Write(number);

                    targetSum -= number;
                }
            }
        }
    }
}
