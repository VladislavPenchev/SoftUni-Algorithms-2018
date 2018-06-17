namespace _4.SimpleGraph_Part2
{
    using System.Collections.Generic;
    using System;

    public class Program
    {
        static bool[] visited;
        static List<int>[] graph;

        public static void DFS(int node)
        {
            if (!visited[node])
            {
                visited[node] = true;

                foreach (var child in graph[node])
                {
                    DFS(child);
                }

                Console.Write($"{node} ");
            }
        }

        public static void BFS(int node)
        {
            Queue<int> queue = new Queue<int>();

            if (visited[node])
            {
                return;
            }

            queue.Enqueue(node);          

            while (queue.Count != 0)
            {
                int currentNode = queue.Dequeue();

                Console.Write($"{currentNode} ");

                foreach (var child in graph[currentNode])
                {
                    if (!visited[child])
                    {
                        visited[child] = true;
                        queue.Enqueue(child);

                    }

                }
            }

            

        }

        public static void Main()
        {
            graph = new List<int>[] 
            {
                new List<int>{3, 6},
                new List<int>{2, 3, 4, 5, 6 },
                new List<int>{1, 4, 5},
                new List<int>{0, 1, 5 },
                new List<int>{1, 2, 6 },
                new List<int>{1, 2, 3 },
                new List<int>{0, 1, 4 },
                new List<int>{8},
                new List<int>{7}
            };

            visited = new bool[graph.Length];

            int componenedCount = 0;

            for (int i = 0; i < graph.Length; i++)
            {
                if (!visited[i])
                {
                    componenedCount++;
                    Console.Write($"connected componend{componenedCount}: ");
                    DFS(i);
                    Console.WriteLine();
                }

                //DFS(i);
                //BFS(i);
            }


        }
    }
}
