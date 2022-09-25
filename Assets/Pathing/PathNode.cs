using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Pathing
{
    class PathNode : Node
    {
        Dictionary<Node, double> Connections { get; set; }

        public PathNode()
        {
            this.Connections = new Dictionary<Node, double>();
        }


    }
}
