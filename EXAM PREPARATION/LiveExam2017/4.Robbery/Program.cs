namespace _4.Robbery
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Edge
    {
        public Edge(int to,int weight)
        {
            this.To = to;
            this.Weight = weight;
        }

        public int To { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{To}, {Weight}";
        }
    }

    class Program
    {
        static bool[] colors;
        static int[] distTo;
        static int[] stepsTo;
        static bool[] visited;

        static void Main()
        {
            string[] input = Console.ReadLine().Split().ToArray();
            
            colors = new bool[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                colors[i] = input[i][input[i].Length - 1] == 'w';

            }

            int energy = int.Parse(Console.ReadLine());
            int waitCost = int.Parse(Console.ReadLine());
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int edgeCount = int.Parse(Console.ReadLine());

            List<Edge>[] graph = new List<Edge>[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                graph[i] = new List<Edge>();
            }

            distTo = new int[graph.Length];
            for (int i = 0; i < distTo.Length; i++)
            {
                distTo[i] = -1;
            }
            stepsTo = new int[graph.Length];
            visited = new bool[graph.Length];

            for (int i = 0; i < edgeCount; i++)
            {
                int[] edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int from = edge[0];
                int to = edge[1];
                int weight = edge[2];
                graph[from].Add(new Edge(to, weight));
            }

            Dijkstra(graph, start, end, waitCost);

        }

        static void Dijkstra(List<Edge>[] graph, int start, int end, int waitCost)
        {
            distTo[start] = 0;

            while (true)
            {
                int vertex = GetCurrentVertex();

                if (vertex == -1)
                {
                    break;
                }
            }
        }

        static int GetCurrentVertex()
        {
            int index = -1;
            int lowestDistance = int.MaxValue;
            for (int i = 0; i < distTo.Length; i++)
            {
                if (!visited[i] && distTo[i] < lowestDistance)
                {
                    index = i;
                    lowestDistance = distTo[i];
                    
                }
            }

            return 0;
        }
    }
}
