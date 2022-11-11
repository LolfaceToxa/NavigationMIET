using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pathing;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace GraphTest
{
    [TestClass]
    public class DijkstraTests
    {

        static bool CompareLists<T>(List<T> l1, List<T> l2)
        {
            if (l1.Count != l2.Count) return false;
            for (int i = 0; i < l1.Count; i++)
            {
                if (!l1[i].Equals(l2[i])) return false;
            }
            return true;
        }


        Graph<Node> _graph;

        public DijkstraTests()
        {
            _graph = new();
        }

        public void AddChain(Node start, int len)
        {
            Node prev = start;
            Node cur;
            for (int i = 0; i < len; i++)
            {
                cur = new Node();
                if (prev is null)
                {
                    _graph.Add(cur);
                }
                else
                {
                    _graph.Add(prev, cur);
                }
                prev = cur;
            }
        }


        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(10)]
        [DataRow(100)]
        [DataRow(1000)]
        [DataRow(10000)]
        public void Chain(int len)
        {
            List<Node> realPath = new(len);
            Node prev = null;
            Node cur = null;
            for (int i = 0; i < len; i++)
            {
                cur = new Node();
                if (prev is null)
                {
                    _graph.Add(cur);
                }
                else
                {
                    _graph.Add(prev, cur);
                }
                realPath.Add(cur);
                prev = cur;
            }
            var path = Dijkstra<Node>.FindPath(_graph, realPath[0], realPath[realPath.Count - 1]);
            Assert.IsTrue(CompareLists(path, realPath));

        }



        [DataTestMethod]
        [DataRow(1, 10)]
        [DataRow(2, 10)]
        [DataRow(10, 10)]
        [DataRow(100, 10)]
        [DataRow(1000, 10)]

        [DataRow(1, 10, 10)]
        [DataRow(2, 10, 10)]
        [DataRow(10, 10, 10)]
        [DataRow(100, 10, 10)]
        public void Branches(int len, int branchLen, int branchCount = 1)
        {
            List<Node> realPath = new(len);
            Node prev = null;
            Node cur;
            for (int i = 0; i < len; i++)
            {
                cur = new Node();
                if (prev is null)
                {
                    _graph.Add(cur);
                }
                else
                {
                    _graph.Add(prev, cur);
                }
                for (int j = 0; j < branchCount; j++)
                {
                    AddChain(cur, branchLen);
                }
                realPath.Add(cur);
                prev = cur;
            }
            var path = Dijkstra<Node>.FindPath(_graph, realPath[0], realPath[realPath.Count - 1]);
            Assert.IsTrue(CompareLists(path, realPath));
        }


        public void AddLoop(Node start, int len)
        {
            Node prev = start;
            Node cur;
            for (int i = 0; i < len; i++)
            {
                cur = new Node();
                if (prev is null)
                {
                    _graph.Add(cur);
                }
                else
                {
                    _graph.Add(prev, cur);
                }
                prev = cur;
            }
            _graph.Add(prev, start);
        }



        [DataTestMethod]
        [DataRow(1, 10)]
        [DataRow(2, 10)]
        [DataRow(10, 10)]
        [DataRow(100, 10)]
        [DataRow(1000, 10)]
        public void Loops(int len, int loopLen)
        {
            List<Node> realPath = new(len);
            Node prev = null;
            Node cur;
            for (int i = 0; i < len; i++)
            {
                cur = new Node();
                if (prev is null)
                {
                    _graph.Add(cur);
                }
                else
                {
                    _graph.Add(prev, cur);
                }
                AddLoop(cur, loopLen);
                realPath.Add(cur);
                prev = cur;
            }
            var path = Dijkstra<Node>.FindPath(_graph, realPath[0], realPath[realPath.Count - 1]);
            Assert.IsTrue(CompareLists(path, realPath));
        }

    }
}
