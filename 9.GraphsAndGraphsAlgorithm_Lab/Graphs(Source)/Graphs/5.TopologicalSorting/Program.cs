namespace _5.TopologicalSorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static List<int>[] graph;

        static HashSet<int> GetNodesWithIncommingEdges()
        {
            var nodesWithIncommingEdges = new HashSet<int>();
            graph
                .SelectMany(s => s)
                .ToList()
                .ForEach(e => nodesWithIncommingEdges.Add(e));

            return nodesWithIncommingEdges;
        }

        public static void Main(string[] args)
        {
            graph = new List<int>[]
            {
                new List<int> {1, 2},
                new List<int> {3 , 4},
                new List<int> {5 },
                new List<int> {2, 5},
                new List<int> {3 },
                new List<int> { }
            };

            List<int> result = new List<int>();
            HashSet<int> nodes = new HashSet<int>();

            HashSet<int> nodeWithIncomingEdges = GetNodesWithIncommingEdges();
            
            for (int i = 0; i < graph.Length; i++)
            {
                if (!nodeWithIncomingEdges.Contains(i))
                {
                    nodes.Add(i);
                }
            }

            while (nodes.Count != 0)
            {
                var currentNode = nodes.First();
                nodes.Remove(currentNode);

                result.Add(currentNode);

                var children = graph[currentNode].ToList();
                graph[currentNode] = new List<int>();

                var leftNodesWithIncommingEdges = GetNodesWithIncommingEdges();

                foreach (var child in children)
                {
                    if (!leftNodesWithIncommingEdges.Contains(child))
                    {
                        nodes.Add(child);
                    }
                }
            }

            if()
        }
    }
}
