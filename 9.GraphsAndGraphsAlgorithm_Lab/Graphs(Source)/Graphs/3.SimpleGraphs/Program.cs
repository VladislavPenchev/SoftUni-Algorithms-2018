namespace _3.SimpleGraphs
{
    using System.Collections.Generic;
    using System;
    public class Program
    {
        static bool[] visited;
        static List<int>[] graphs;

        public static void Main()
        {
            graphs = new List<int>[]
            {
                new List<int> {3, 6},               //0
                new List<int> {2, 3, 4, 5, 6},      //1
                new List<int> {1, 4, 5},            //2
                new List<int> {0, 1, 5},            //3
                new List<int> {1, 2, 6},            //4
                new List<int> {1, 2, 3},            //5
                new List<int> {0, 1, 4}             //6
                
            };

            visited = new bool [graphs.Length];

            for (int i = 0; i < graphs.Length; i++)
            {
                //DFS(i);
                BFS(i);
            }

        }

        public static void BFS(int node)
        {
            if (visited[node])
            {
                return;
            }
                
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(node);
            visited[node] = true;

            while(queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                Console.WriteLine(currentNode);

                foreach (var child in graphs[currentNode])
                {
                    if (!visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }

        }

        public static void DFS(int node)
        {
            if (!visited[node])
            {
                visited[node] = true;

                foreach (var child in graphs[node])
                {
                    DFS(child);
                }

                Console.WriteLine($"{node} ");
            }
        }
    }
}
