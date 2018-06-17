using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Greatest_Strategy
{
    class Program
    {
        static int areaCount;
        static HashSet<int>[] graph;
        static bool[] visited;

        static void Main(string[] args)
        {
            int[] inputs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int areas = inputs[0];
            areaCount = areas;
            int edgeCount = inputs[1];
            int start = inputs[2];
            graph = new HashSet<int>[areas + 1];
            for (int i = 1; i < graph.Length; i++)
            {
                graph[i] = new HashSet<int>();
            }
            List<Edge> edges = new List<Edge>();
            for (int i = 0; i < edgeCount; i++)
            {
                string[] edgeInputs = Console.ReadLine().Split(' ');
                int first = int.Parse(edgeInputs[0]);
                int second = int.Parse(edgeInputs[1]);
                graph[first].Add(second);
                graph[second].Add(first);
                edges.Add(new Edge(first, second));
            }
            List<Edge> edgesToRemove = new List<Edge>();
            foreach (var edge in edges)
            {
                int parentCount = CountConnected(edge.Parent, edge.Child);
                int childCount = CountConnected(edge.Child, edge.Parent);
                if (parentCount % 2 == 0 && childCount % 2 == 0)
                {
                    edgesToRemove.Add(edge);
                }
            }
            foreach (var edge in edgesToRemove)
            {
                graph[edge.Parent].Remove(edge.Child);
                graph[edge.Child].Remove(edge.Parent);
            }
            int maxValue = 0;
            visited = new bool[areaCount + 1];
            for (int i = 1; i < graph.Length; i++)
            {
                if (!visited[i])
                {
                    int value = BFS(i);
                    if (value > maxValue)
                    {
                        maxValue = value;
                    }
                }
            }
            Console.WriteLine(maxValue);
        }

        private static int BFS(int node)
        {
            bool[] visited = new bool[areaCount + 1];
            visited[node] = true;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(node);
            int value = 0;
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                value += current;
                foreach (var child in graph[current])
                {
                    if (!visited[child])
                    {
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }
            return value;
        }

        private static int CountConnected(int node, int parent)
        {
            bool[] visited = new bool[areaCount + 1];
            visited[parent] = true;
            visited[node] = true;
            int counter = 1;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                foreach (var child in graph[current])
                {
                    if (!visited[child])
                    {
                        visited[child] = true;
                        queue.Enqueue(child);
                        counter++;
                    }
                }
            }
            return counter;
        }
    }

    class Edge
    {
        public int Parent { get; set; }
        public int Child { get; set; }

        public Edge(int parent, int child)
        {
            Parent = parent;
            Child = child;
        }
    }
}
