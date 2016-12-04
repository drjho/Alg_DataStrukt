using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSP_NNW
{
    class Program
    {
        class Node
        {
            public int u;
            public Node previous;
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

            public int GetHashCode(Node obj)
            {
                return obj.u.GetHashCode();
            }
        }

        class Comparer : IComparer<Node>
        {
            public int Compare(Node x, Node y)
            {
                return x.f.CompareTo(y.f);
            }
        }

        static Node[] nodes;

        static Dictionary<int, Dictionary<int, float>> graph = new Dictionary<int, Dictionary<int, float>>();

        static string[] lines;

        static void Main(string[] args)
        {
            lines = Console.ReadLine().Split(' ');
            var numN = int.Parse(lines[0]);
            var numE = int.Parse(lines[1]);
            var numQ = int.Parse(lines[2]);
            var start = int.Parse(lines[3]);

            nodes = new Node[numN];
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
                //var visited = new Dictionary<Node, float>(new EqualComparer());
                var visited = new Dictionary<int, Node>();
                var candidates = new SortedDictionary<Node, float>(new Comparer());
                candidates.Add(new Node(start), 0);
                while (candidates.Count > 0)
                {
                    var current = candidates.First();
                    candidates.Remove(current.Key);
                    foreach (var e in graph[current.Key.u])
                    {
                        var n = new Node(e.Key) { previous = current.Key };
                        
                        if (e.Key == goal)
                        {
                            Console.WriteLine(GetPathSteps(n));
                            break;
                        }
                        n.f = current.Key.f + GetWeight(current.Key.u, n.u);

                        if (candidates.ContainsKey(n) && candidates[n] < n.f)
                            continue;
                        if (visited.ContainsKey(n.u) && visited[n.u].f < n.f)
                            continue;
                        candidates[n] = n.f;

                    }
                    //visited.Add(current.Key, current.Value);
                    visited[current.Key.u] = current.Key;
                }
            }
        }



        static int GetPathSteps(Node n)
        {
            int c = 0;
            while (n.previous != null)
            {
                c++;
                n = n.previous;
            }
            return c;
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
