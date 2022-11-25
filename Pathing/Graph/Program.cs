using System;
using Pathing;

namespace GraphExe
{



    class Program
    {
        static void Main(string[] args)
        {
            Graph<Node> graph = new();
            Node o = new("O");
            Node a = new("A");
            Node b = new("B");
            Node c = new("C");
            Node d = new("D");
            graph.Add(o, b, 2);
            graph.Add(a, b, 2);
            graph.Add(a, c, 10);
            graph.Add(c, d, 3);
            graph.Add(b, c, 4);

            var path = Dijkstra<Node>.FindPath(graph, a, d);
            foreach (var node in path)
            {
                Console.WriteLine(node.Name);
            }
        }

    }
}
