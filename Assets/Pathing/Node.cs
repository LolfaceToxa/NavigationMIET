using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Pathing
{
    class Node
    {
        public Vector3 Position { get; set; }

        public Node()
        {

        }

        public Node(Vector3 pos)
        {
            this.Position = pos;
        }

        public Node(Node other)
        {
            this.Position = other.Position;
        }




    }
}
