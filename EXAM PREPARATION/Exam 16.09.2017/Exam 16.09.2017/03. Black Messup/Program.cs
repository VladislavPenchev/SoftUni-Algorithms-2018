using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Black_Messup
{
    class Program
    {
        private static bool[] visited;
        private static List<int>[] graph;
        private static Dictionary<int, Atom> atoms;
        private static Dictionary<string, int> nodes;

        static void Main(string[] args)
        {
            int nodeCount = int.Parse(Console.ReadLine());
            int edgeCount = int.Parse(Console.ReadLine());
            int counter = 0;
            nodes = new Dictionary<string, int>();
            atoms = new Dictionary<int, Atom>();
            for (int i = 0; i < nodeCount; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                string name = inputs[0];
                int weight = int.Parse(inputs[1]);
                int decay = int.Parse(inputs[2]);
                nodes.Add(name, counter);
                atoms.Add(counter, new Atom(weight, decay));
                counter++;
            }
            graph = new List<int>[nodeCount];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }
            for (int i = 0; i < edgeCount; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int first = nodes[inputs[0]];
                int second = nodes[inputs[1]];
                graph[first].Add(second);
                graph[second].Add(first);
            }
            List<List<int>> connectedComponents = new List<List<int>>();
            visited = new bool[nodeCount];
            for (int i = 0; i < nodeCount; i++)
            {
                if (!visited[i])
                {
                    List<int> connected = new List<int>();
                    BFS(i, connected);
                    connectedComponents.Add(connected);
                }
            }
            int maxValue = 0;
            foreach (var component in connectedComponents)
            {
                int value = CalculateValue(component);
                if (value > maxValue)
                {
                    maxValue = value;
                }
            }
            Console.WriteLine(maxValue);
        }

        private static int CalculateValue(List<int> component)
        {
            SortedDictionary<int, List<Atom>> atomsByDecay =
                new SortedDictionary<int, List<Atom>>(Comparer<int>.Create((x, y) => -x.CompareTo(y)));
            int value = 0;
            foreach (var atom in component.Select(x => atoms[x]))
            {
                if (!atomsByDecay.ContainsKey(atom.Decay))
                {
                    atomsByDecay.Add(atom.Decay, new List<Atom>());
                }
                atomsByDecay[atom.Decay].Add(atom);
            }
            while (atomsByDecay.Count > 0 && atomsByDecay.First().Value[0].Decay > 0)
            {
                List<Atom> atomsWithBiggestDecay = atomsByDecay.First().Value;
                int weigth = atomsWithBiggestDecay.Max(x => x.Weight);
                value += weigth;
                atomsByDecay.Remove(atomsByDecay.First().Key);
                foreach (var atom in atomsWithBiggestDecay)
                {
                    if (atom.Weight != weigth)
                    {
                        atom.Decay--;
                        if (!atomsByDecay.ContainsKey(atom.Decay))
                        {
                            atomsByDecay.Add(atom.Decay, new List<Atom>());
                        }
                        atomsByDecay[atom.Decay].Add(atom);
                    }
                }
            }
            return value;
        }

        private static void BFS(int start, List<int> connected)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                connected.Add(node);
                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }
        }
    }

    class Atom
    {
        public int Weight { get; set; }
        public int Decay { get; set; }

        public Atom(int weight, int decay)
        {
            Weight = weight;
            Decay = decay;
        }
    }
}
