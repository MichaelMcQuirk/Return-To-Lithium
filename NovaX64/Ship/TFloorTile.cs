/*NOTES:
 * - GetPathTo has not been tested yet... (TEST IT)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReturnToLithium.Crew;

namespace ReturnToLithium.Ship
{
    class TFloorTile
    {
        //The ship is subdivided into many little squares, only one crew/member is usually allowed per square.
        public int X;
        public int Y;
        public const int Width = 60;
        public const int Height = 60;

        public List<TPerson> Occupants;
        public List<TFloorTile> AdjacentTiles;

        public double Fire = 0;         //If the tile catches fire this becomes 100. Use fire extinguisher to reduce to 0.
        public double PreIgnition = 0;  //When a tile is on fire, it slowly sets it's neighboring tiles on fire. The PreIgnition counter determines when a tile finally catches fire.

        private TFloorTile  Search_Parent;
        private double      Search_Dist;

        public List<TFloorTile> GetPathTo(TFloorTile destination)   //returns an empty list if no path is available. if path is available, the current tile will always be included (and first).
        {
            List<TFloorTile> OpenList = new List<TFloorTile>();
            OpenList.Add(this);
            TFloorTile cur = this;

            while (cur != destination && OpenList.Count != 0)
            {
                cur = GetClosestTileToDest(OpenList, destination);
                OpenList.Remove(cur);

                foreach (TFloorTile adj in cur.AdjacentTiles)
                {    
                   if (OpenList.Contains(adj) == false)
                   {
                       adj.Search_Dist = GetLinearDist(adj, destination);
                       adj.Search_Parent = cur;
                       OpenList.Add(adj);
                   }
                }
            }

            if (cur != destination) //if there is no path      and the last tile to be checked was not the destination tile.
                return new List<TFloorTile>();

            List<TFloorTile> path = new List<TFloorTile>();
            path.Add(cur);
            while (cur.Search_Parent != null)
            {
                path.Insert(0, cur.Search_Parent);
                cur = cur.Search_Parent;
            }

            return path;

        }

        private double GetLinearDist(TFloorTile from, TFloorTile to)
        {
            return Math.Sqrt(Math.Pow(from.X - to.X, 2) + Math.Pow(from.Y - to.Y, 2));
        }

        private TFloorTile GetClosestTileToDest(List<TFloorTile> list, TFloorTile dest)
        {
            if (list.Count == 0) throw new Exception("Error: can't find a closest tile from an empty list!");
            TFloorTile closest = list[0];
            Double closestsDist = closest.Search_Dist;

            for (int i = 1; i < list.Count; i++)
            {
                TFloorTile cur = list[i];
                double curDist = cur.Search_Dist;
                if (curDist < closestsDist)
                {
                    closest = cur;
                    closestsDist = curDist;
                }
            }

            return closest;
        }
    }
}
