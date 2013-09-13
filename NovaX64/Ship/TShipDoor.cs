using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReturnToLithium.Miscellaneous;

namespace ReturnToLithium.Ship
{
    enum DoorStatus {Closed, Open, Closing, Opening}

    class TShipDoor : IUpdatableObject
    {
        public int ID;
        public ObjectOrientation Orientation;
        public int X;
        public int Y;

        public double ActionProgress;

        public void Update(DateTime currentTime)
        {
            throw new NotImplementedException();
        }
    }
}
