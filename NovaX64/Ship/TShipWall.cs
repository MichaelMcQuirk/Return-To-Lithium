using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReturnToLithium.Ship
{
   

    class TShipWall
    {
        public int ID;
        public ObjectOrientation Orientation;
        public int Length;          //Width if horizontal, Height if vertical.
        public bool Door;

        public int Health;          //0..100 (if not 100, then gas will be escaping)

    }
}
