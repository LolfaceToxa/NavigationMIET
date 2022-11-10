using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Assets.Pathing
{



    public class Dijkstra<TNode> where TNode : Node
    {

        public const double ERROR = 1e-16;

        public static bool NearZero(double value) => Math.Abs(value) < ERROR;


        static private TNode FindNextMin(Dictionary<TNode, double> distances, Dictionary<TNode, bool> shortest, HashSet<TNode> nodes)
        {
            double min = double.MaxValue;
            TNode minNode = null;

            foreach (var node in nodes)
            {
                if (shortest[node] == false && distances[node] <= min)
                {
                    min = distances[node];
                    minNode = node;
                }
            }
            return minNode;
        }

        static public Dictionary<TNode, double> CalculateDistances(Graph<TNode> graph, TNode start)
        {

            var distances = new Dictionary<TNode, double>(graph.Nodes.Count);
            var isShortestPath = new Dictionary<TNode, bool>(graph.Nodes.Count);

            foreach (var node in graph.Nodes)
            {
                distances.Add(node, double.MaxValue);
                isShortestPath.Add(node, false);
            }

            distances[start] = 0.0;

            int size = graph.Nodes.Count;
            for (int i = 0; i < size - 1; i++)
            {
                var minNode = FindNextMin(distances, isShortestPath, graph.Nodes);
                isShortestPath[minNode] = true;


                var minNodeDist = distances[minNode];

                foreach (var link in graph.GetLinksOf(minNode))
                {
                    var otherNode = link.Other(minNode);
                    if (isShortestPath[otherNode] == false && minNodeDist != double.MaxValue && minNodeDist + link.Length < distances[otherNode])
                    {
                        distances[otherNode] = minNodeDist + link.Length;
                    }
                }

            }

            return distances;
        }

        public static Stack<TNode> ReversePath(Graph<TNode> graph, Dictionary<TNode, double> distances, TNode start, TNode end)
        {
            double distanceLeft = distances[end];

            bool foundNode;
            TNode curNode;
            Stack<TNode> path = new Stack<TNode>();
            path.Push(end);
            HashSet<TNode> ignore = new();
            while (!NearZero(distanceLeft))
            {
                curNode = path.Peek();
                foundNode = false;
                foreach (var link in graph.GetLinksOf(curNode))
                {
                    var otherNode = link.Other(curNode);

                    if (!ignore.Contains(otherNode) && NearZero(distanceLeft - distances[otherNode] - link.Length))
                    {
                        distanceLeft = distances[otherNode];
                        path.Push(otherNode);
                        foundNode = true;
                        break;
                    }
                }

                if (!foundNode)
                {
                    ignore.Add(path.Pop());
                    distanceLeft = distances[path.Peek()];
                }

            }
            Debug.Assert(path.Peek() == start);
            return path;
        }


        static public List<TNode> FindPath(Graph<TNode> graph, TNode start, TNode end)
        {
            var distances = CalculateDistances(graph, start);
            var path = ReversePath(graph, distances, start, end);
            return new List<TNode>(path);
        }
    }
}
