using System;
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

        }

        List<PathNode> _nodes;
        List<Link> _links;

        public PathGraph()
        {

        }




    }
}
