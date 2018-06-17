namespace _1.ShootingRange
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int target = int.Parse(Console.ReadLine());

            bool[] marked = new bool[targets.Length];

            Gen(0, target,targets,marked);
            
        }

        static void Gen(int index, int target, int[] targets, bool[] marked)
        {
            int score = GetTargets(targets,marked);

            if (score == target)
            {
                Print(targets, marked);
            }

            HashSet<int> swapped = new HashSet<int>();

            for (int i = index; i < targets.Length; i++)
            {
                if (swapped.Contains(i))
                {
                    Swap(index, i,targets);
                    marked[i] = true;

                    Gen(index + 1,target,targets,marked);

                    Swap(index, i, targets);
                    marked[i] = false;

                    swapped.Add(targets[i]);
                }
            }

        }

        static void Swap(int index, int currentValue,int[] targets)
        {
            int temp = targets[index];
            targets[index] = targets[currentValue];
            targets[currentValue] = index;
        }

        static int GetTargets(int[] targets,bool[] marked)
        {
            // 1 2 3
            int score = 0;
            int multiplier = 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (marked[i])
                {
                    score += targets[i] * ++multiplier;
                }
            }

            return score;
        }

        static void Print(int[] targets, bool[] marked)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < targets.Length; i++)
            {
                if (marked[i])
                {
                    builder.Append(targets[i] + " ");
                }
            }

            Console.WriteLine(builder.ToString().Trim());
        }
    }
}
