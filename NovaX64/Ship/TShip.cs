using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReturnToLithium.Miscellaneous;
using ReturnToLithium.Crew;

namespace ReturnToLithium.Ship
{
    class TShip : IUpdatableObject
    {

        public int ID;
        public string Name;

        public int Floors;
        public int Width;     //always a multiple of the width of a floor tile
        public int Height;    //always a multiple of the height of a floor tile



        public List<TShipRoom> Rooms;
        public List<List<TFloorBlock>> FloorTiles;
        public List<TPerson> Occupants;

        public void Update(DateTime currentTime)
        {
            throw new NotImplementedException();
        }







        /*
             ________________
            / |       |      \
           /                  \
          /_  | _  _  | _   _  \
         /                      \________
        |     |       |      |      |    \
        |                                 \
        |  _  | _  _  | _   _| _   _|      |
        |                                  /
        \     |       |      |     _|_____/
         \                        /
          \ _ | _  _  | _   _| _ /
           \                    /
            \_|_______|______|_/
         * 
         * Items/Rooms placed in ships will be snapped to a square grid that encompases the entire ship.
         * Each block is 1 unit by 1 unit
         * Only one friendly crew member is allowed to occupy the same block.
         */

    }
}
