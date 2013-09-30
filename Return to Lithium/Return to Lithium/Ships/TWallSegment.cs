using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Return_to_Lithium.Ships
{
    class TWallSegment
    {
        public int X;
        public int Y;
        private TShipWall parent;
        
        public int Health;          //0..100 (if not 100, then gas will be escaping)
    }
}
