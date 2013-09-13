using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReturnToLithium.Miscellaneous;
using ReturnToLithium.Crew;

namespace ReturnToLithium.Ship
{
    class TShipRoom : IUpdatableObject
    {
        public int ID;

        public int X;
        public int Y;
        public int Width;
        public int Height;

        public List<TShipRoom> AdjacentRooms;
        public List<TShipRoom> ConnectedRooms;
        public List<TShipDoor> Doors;               //Each connected room is matched to a single door.

        public List<TPerson> Occupants;

        public void Update(DateTime currentTime)
        {
            throw new NotImplementedException();
        }
    }
}
