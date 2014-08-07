using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Return_to_Lithium.Miscellaneous;
using Return_to_Lithium.Crew;

namespace Return_to_Lithium.Ships
{
    class TShip : IUpdatableObject
    {

        public int ID;
        public string Name;

        public int Floors;
        public int Width;     //always a multiple of the width of a floor tile
        public int Height;    //always a multiple of the height of a floor tile



        public List<TShipRoom> Rooms;
        public List<List<TFloorTile>> FloorTiles;
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
         * Items/Rooms placed in ships will be snapped to a square grid that encompasses the entire ship.
         * Each block is 1 unit by 1 unit
         * Only one friendly crew member is allowed to occupy the same block.
         */

    }
}
