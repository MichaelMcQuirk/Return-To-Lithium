using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Return_to_Lithium.Miscellaneous;
using Return_to_Lithium.Crew;

namespace Return_to_Lithium.Ships
{
    class TShipRoom : IUpdatableObject
    {
        public int ID;

        public int X;
        public int Y;
        public int Width;   //always a multiple of the width of a floor tile
        public int Height;  //always a multiple of the height of a floor tile

        public double OxygenLevel = 100;

        public List<List<TFloorTile>> FloorTiles;   //2D array of floor tiles
        //public List<TShipRoom> AdjacentRooms;  Outdated due to adjacent floor tiles?
        public List<TShipRoom> ConnectedRooms;
        public List<TShipDoor> Doors;               //Each connected room is matched to a single door.

        public List<TPerson> Occupants;

        public void Update(DateTime currentTime)
        {
            throw new NotImplementedException();
        }

        public List<TFloorTile> GetListOfUnoccupiedTiles()
        {
            List<TFloorTile> availableTiles = new List<TFloorTile>();
            foreach (List<TFloorTile> column in FloorTiles)
                foreach (TFloorTile tile in column)
                    if (tile.Occupants.Count == 0) availableTiles.Add(tile);
            return availableTiles;
        }
    }
}
