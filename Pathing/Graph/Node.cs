using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pathing
{
    public class Node
    {
        public string Name { get; }

        public Node(string name)
        {
            Name = name;
        }

        public Node() : this(string.Empty)
        {
        }


    }
}
