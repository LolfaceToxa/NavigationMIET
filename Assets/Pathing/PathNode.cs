using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Pathing
{
    class PathNode : Node
    {
        Dictionary<double, Node> Connections { get; set; }

        public PathNode()
        {
            this.Connections = new Dictionary<double, Node>();
        }
        
        
    }
}
