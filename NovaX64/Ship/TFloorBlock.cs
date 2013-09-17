using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReturnToLithium.Crew;

namespace ReturnToLithium.Ship
{
    class TFloorBlock
    {
        //The ship is subdivided into many little squares, only one crew/member is usually allowed per square.
        public int X;
        public int Y;
        public const int Width = 60;
        public const int Height = 60;

        public List<TShipObject> Objects;       //the position property of each of these objects is relative to this block.
        public List<TPerson> Occupants;

 
    }
}
