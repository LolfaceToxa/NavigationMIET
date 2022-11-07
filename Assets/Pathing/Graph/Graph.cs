using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assets.Pathing
{
    class Graph<TNode> where TNode : Node
    {
        public class Link
        {
            public TNode A { get; }
            public TNode B { get; }
            public double Length { get; }
            public Link(TNode a, TNode b, double length)
            {
                A = a;
                B = b;
                Length = length;
            }

            public Link(TNode a, TNode b) : this(a, b, 1)
            {
            }

            public bool HasNode(TNode node)
            {
                return node == A || node == B;
            }
        }

        private class LinkEnumerator : IEnumerator
        {

            List<Link> _links;
            TNode _node;

            int position = -1;

            public LinkEnumerator(List<Link> links, TNode node)
            {
                _links = links;
                _node = node;
            }

            public object Current
            {
                get
                {
                    try
                    {
                        return _links[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }


            public bool MoveNext()
            {
                while (true)
                {
                    position++;
                    if (position < _links.Count)
                    {
                        if (_links[position].HasNode(_node))
                            return true;
                    }
                    else
                        return false;
                }
            }

            public void Reset()
            {
                position = -1;
            }
        }

        HashSet<TNode> _nodes;
        List<Link> _links;

        public Graph()
        {
            _nodes = new();
            _links = new();
        }


        public void Add(TNode node)
        {
            _nodes.Add(node);
        }

        public void Add(TNode a, TNode b)
        {
            if (!_nodes.Contains(a))
            {
                Add(a);
            }
            if (!_nodes.Contains(b))
            {
                Add(b);
            }

            _links.Add(new Link(a, b));
        }

        public IEnumerator GetLinksOf(TNode node)
        {
            return new LinkEnumerator(_links, node);
        }




    }
}
