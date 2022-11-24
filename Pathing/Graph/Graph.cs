using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pathing
{
    public class Graph<TNode> where TNode : INode
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
                return node.Equals(A) || node.Equals(B);
            }

            public TNode Other(TNode node)
            {
                if (node.Equals(A)) return B;
                if (node.Equals(B)) return A;
                throw new Exception("Link doesnt have given node!");
            }
        }

        private class LinkEnumerator : IEnumerator<Link>
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

            Link IEnumerator<Link>.Current => (Link)Current;

            public void Dispose()
            {
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

        private class LinkEnumerable : IEnumerable<Link>
        {
            List<Link> _links;
            TNode _node;
            public LinkEnumerable(List<Link> links, TNode node)
            {
                _links = links;
                _node = node;
            }

            public IEnumerator<Link> GetEnumerator() => new LinkEnumerator(_links, _node);

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }


        public HashSet<TNode> Nodes { get; }
        public List<Link> Links { get; }

        public Graph()
        {
            Nodes = new();
            Links = new();
        }


        public void Add(TNode node)
        {
            Nodes.Add(node);
        }

        public void Add(TNode a, TNode b) => Add(a, b, 1);
        public void Add(TNode a, TNode b, double dist)
        {
            if (!Nodes.Contains(a))
            {
                Add(a);
            }
            if (!Nodes.Contains(b))
            {
                Add(b);
            }

            Links.Add(new Link(a, b, dist));
        }

        public IEnumerable<Link> GetLinksOf(TNode node)
        {
            return new LinkEnumerable(Links, node);
        }




    }
}
