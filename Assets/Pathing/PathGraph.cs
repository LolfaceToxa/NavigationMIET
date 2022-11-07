using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Pathing
{
    class PathGraph
    {
        public class Link
        {
            public PathNode A { get; }
            public PathNode B { get; }
            public double Length { get; }
            public Link(PathNode a, PathNode b)
            {
                A = a;
                B = b;
                Length = Vector3.Distance(b.Position, a.Position);
            }

            public 

        }

        public class LinkEnum : IEnumerator
        {

            List<Link> _links;
            PathNode _node;

            int position = -1;

            public LinkEnum(List<Link> links, PathNode node)
            {
                _links = links;
                _node = node;
            }

            public Link Current
            {
                get
                {
                    try
                    {
                        return _links[position];
                    }
                    catch(IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }


            public bool MoveNext()
            {
                while()
                position++;

                return (position < _links.Count);
            }

            public void Reset()
            {
                position = -1;
            }
        }

        HashSet<PathNode> _nodes;
        List<Link> _links;

        public PathGraph()
        {

        }


        public void Add(PathNode node)
        {

        }

        public void Add(PathNode a, PathNode b)
        {
            if (!_nodes.Contains(a))
            {
                Add(a);
            }
            if (!_nodes.Contains(b))
            {
                Add(b);
            }


        }




    }
}
