using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.Pathing;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace GraphTest
{
    [TestClass]
    public class UnitTest1
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

        public UnitTest1()
        {
            _graph = new();
        }

        public void AddChain(int len)
        {

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
    }
}
