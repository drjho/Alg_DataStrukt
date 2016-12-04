using System;
using System.Collections.Generic;
using System.Linq;

namespace SSSP_NNW
{
    class Program
    {
        class Node
        {
            public int u;
            public float f;

            public Node(int u)
            {
                this.u = u;
            }
        }

        class EqualComparer : IEqualityComparer<Node>
        {
            public bool Equals(Node x, Node y)
            {
                return x.u.Equals(y.u);
            }

            public int GetHashCode(Node n)
            {
                return n.u.GetHashCode();
            }
        }

        class Comparer : IComparer<Node>
        {
            public int Compare(Node x, Node y)
            {
                return x.f.CompareTo(y.f);
            }
        }

        static Dictionary<int, Dictionary<int, float>> graph;

        static string[] lines;

        static void Main(string[] args)
        {
            try
            {


                while (true)
                {
                    lines = Console.ReadLine().Split(' ');
                    var numN = int.Parse(lines[0]);
                    var numE = int.Parse(lines[1]);
                    var numQ = int.Parse(lines[2]);
                    var start = int.Parse(lines[3]);

                    if (numN == 0 && numE == 0 && numQ == 0 && start == 0)
                        return;

                    graph = new Dictionary<int, Dictionary<int, float>>();
                    for (int i = 0; i < numN; i++)
                    {
                        graph[i] = new Dictionary<int, float>();
                    }

                    for (int i = 0; i < numE; i++)
                    {
                        AddEdge(Console.ReadLine().Split(' '));
                    }

                    for (int i = 0; i < numQ; i++)
                    {
                        var goal = int.Parse(Console.ReadLine());
                        if (start == goal)
                        {
                            Console.WriteLine(0);
                            continue;
                        }

                        var visited = new Dictionary<int, Node>();
                        var candidates = new SortedDictionary<Node, float>(new Comparer());
                        candidates[new Node(start)] = 0;
                        bool found = false;
                        while (candidates.Count > 0)
                        {
                            var current = candidates.First();
                            if (current.Key.u == goal)
                            {
                                Console.WriteLine(current.Key.f);
                                found = true;
                                break;
                            }
                            candidates.Remove(current.Key);

                            foreach (var e in graph[current.Key.u])
                            {
                                var n = new Node(e.Key);

                                n.f = current.Key.f + e.Value;

                                if (candidates.ContainsKey(n) && candidates[n] < n.f)
                                    continue;
                                if (visited.ContainsKey(n.u) && visited[n.u].f < n.f)
                                    continue;
                                candidates[n] = n.f;

                            }
                            visited[current.Key.u] = current.Key;
                        }
                        if (!found)
                            Console.WriteLine("Impossible");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        static float GetWeight(int u, int v)
        {
            return graph[u][v];
        }


        static void AddEdge(string[] str)
        {
            graph[int.Parse(str[0])].Add(int.Parse(str[1]), int.Parse(str[2]));
        }

    }
}
