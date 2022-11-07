using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Pathing
{
    class PathNode : Node
    {
        public string Name { get; }

        public PathNode(Vector3 vec, string name) : base(vec)
        {
            Name = name;
        }

        public PathNode(Vector3 vec) : this(vec, string.Empty)
        {
        }


    }
}
