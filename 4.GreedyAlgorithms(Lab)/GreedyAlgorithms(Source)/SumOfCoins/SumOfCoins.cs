namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var result = new Dictionary<int, int>();

            coins = coins.OrderByDescending(c => c).ToList();

            var coinsIndex = 0;
            var currentSum = 0;

            while (currentSum < targetSum)
            {
                if (currentSum > targetSum)
                {
                    coinsIndex++;
                    continue;
                }

                var remainingSum = targetSum - currentSum;

                var coinsCount = remainingSum / coins[coinsIndex];
                

                result[coins[coinsIndex]] = coinsCount;

                currentSum += coins[coinsIndex] * coinsCount;


            }

            return result;
        }
    }
}