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


        class Edge
        {
            public int u;
            public int v;
            public int w;
            public Edge previous;
            public int f;

            public static Edge Make(string str)
            {
                var lines = str.Split(' ');
                return new Edge
                {
                    u = int.Parse(lines[0]),
                    v = int.Parse(lines[1]),
                    w = int.Parse(lines[2])
                };
            }

            public static Edge Start(int start)
            {
                return new Edge { u = start, v = start, w = 0 };
            }
        }

        static Dictionary<int, Dictionary<int, float>> info = new Dictionary<int, Dictionary<int, float>>();

        static Dictionary<int, HashSet<Edge>> dict = new Dictionary<int, HashSet<Edge>>();

        static string[] lines;

        static void Main(string[] args)
        {
            lines = Console.ReadLine().Split(' ');
            var nodes = int.Parse(lines[0]);
            var edges = int.Parse(lines[1]);
            var queries = int.Parse(lines[2]);
            var start = int.Parse(lines[3]);

            for (int i = 0; i < nodes; i++)
            {
                info[i] = new Dictionary<int, float>();
            }

            for (int i = 0; i < edges; i++)
            {
                AddEdge(Console.ReadLine().Split(' '));
                //var e = Edge.Make(Console.ReadLine());
                //AddEdge(e);
            }

            for (int i = 0; i < queries; i++)
            {
                var end = int.Parse(Console.ReadLine());
                if (start == end)
                {
                    Console.WriteLine(0);
                    continue;
                }
                var visited = new HashSet<int>();
                var openList = new SortedSet<Edge>(new EdgeComparer());
                openList.Add(Edge.Start(start));
                while (openList.Count > 0)
                {
                    var current = openList.First();
                    visited.Add(current.u);
                    openList.Remove(current);
                    foreach (var e in dict[current.u])
                    {
                        if (e.v == end)
                        {

                            break;
                        }
                        if (!visited.Contains(e.u))
                            openList.Add(e);
                    }
                }

            }
        }



        class EdgeComparer : IComparer<Edge>
        {
            public int Compare(Edge x, Edge y)
            {
                return x.w.CompareTo(y.w);
            }
        }

        static void AddEdge(string[] str)
        {
            info[int.Parse(str[0])].Add(int.Parse(str[1]), int.Parse(str[2]));
        }

        static void AddEdge(Edge e)
        {
            if (dict.ContainsKey(e.u))
                dict[e.u].Add(e);
            else
                dict[e.u] = new HashSet<Edge> { e };

            //if (dict.ContainsKey(e.v))
            //    dict[e.v].Add(e);
            //else
            //    dict[e.v] = new HashSet<Edge> { e };
        }
    }
}
