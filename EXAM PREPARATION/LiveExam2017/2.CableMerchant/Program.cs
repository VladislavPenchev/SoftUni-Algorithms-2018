namespace _2.CableMerchant
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        static Dictionary<int, List<int>> parents = new Dictionary<int, List<int>>();

        static void Main(string[] args)
        {
            int sticks = int.Parse(Console.ReadLine());
            int edgesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgesCount; i++)
            {
                graph[i] = new List<int>();
                parents[i] = new List<int>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                int[] edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int from = edge[0];
                int to = edge[1];

                graph[from].Add(to);
                graph[to].Add(from);

            }

            while (true)
            {
                var node = parents
                    .Where(n => parents[n.Key].Count == 0)
                    .OrderByDescending(x => x.Key)
                    .FirstOrDefault();

                if (node.Value == null)
                {
                    break;
                }
            }

        }
    }
}
