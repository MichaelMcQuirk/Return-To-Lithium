using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Return_to_Lithium.Miscellaneous;

namespace Return_to_Lithium.Ships
{
    enum DoorStatus {Closed, Open, Closing, Opening}

    class TShipDoor : IUpdatableObject
    {
        public int ID;
        public ObjectOrientation Orientation;
        public int X;
        public int Y;

        public TFloorTile adjacentBlock1;      //used for path finding.
        public TFloorTile adjacentBlock2;

        public double ActionProgress;

        public void Update(DateTime currentTime)
        {
            throw new NotImplementedException();
        }
    }
}
