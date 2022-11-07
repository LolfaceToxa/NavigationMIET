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
            graph.Add(a, b);

            foreach (var link in graph.GetLinksOf(a))
            {
                Console.WriteLine(link.A.Name);
                Console.WriteLine(link.B.Name);
            }
        }
    }
}
