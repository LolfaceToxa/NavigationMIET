using System;
using Assets.Pathing;

namespace GraphExe
{



    class Program
    {
        static void Main(string[] args)
        {
            Graph<Node> graph = new();
            Node a = new("A");
            Node b = new("B");
            Node c = new("C");
            graph.Add(a, b);
            graph.Add(a, c);
            graph.Add(b, c);

            foreach (var link in graph.GetLinksOf(a))
            {
                Console.WriteLine(link.Other(a).Name);
            }
        }

    }
}
