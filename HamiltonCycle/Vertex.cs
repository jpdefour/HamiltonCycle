using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonPath
{
    public class Vertex : IEquatable<Vertex>
    {
        public bool IsStartingVertex { get; set; } = false;
        public bool isFinalVertex { get; set; } = false;

        public int Number { get; set; }

        public bool Equals(Vertex other)
        {
            return other.Number == Number;
        }
    }
}
