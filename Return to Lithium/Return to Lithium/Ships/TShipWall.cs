using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Return_to_Lithium.Ships;

namespace Return_to_Lithium.Ships
{
    class TShipWall
    {
        public int ID;
        public ObjectOrientation Orientation;
        public int Length;          //Width if horizontal, Height if vertical. (in # of tiles)
        public bool Door;

        public List<TWallSegment> Segments;

    }
}
