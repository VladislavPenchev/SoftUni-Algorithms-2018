namespace _3.LongestIncreasingSubsquence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };
            int[] solutions = new int[numbers.Length];

            int maxSolution = 0;

            for (int current = 0; current < numbers.Length; current++)
            {
                int solution = 1;
                int currentNumber = numbers[current];

                for (int solIndex = 0; solIndex < current; solIndex++)
                {
                    int previousNumber = numbers[solIndex];
                    int previousSolution = solutions[solIndex];

                    if (currentNumber > previousNumber
                        && solution <= previousSolution)
                    {
                        solution = previousSolution + 1;
                    }
                }

                solutions[current] = solution;

                if (solution > maxSolution)
                {
                    maxSolution = solution;
                }
            }

            System.Console.WriteLine(maxSolution);
        }
    }
}
