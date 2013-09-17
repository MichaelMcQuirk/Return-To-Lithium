using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReturnToLithium.Miscellaneous;
using ReturnToLithium.Ship;

namespace ReturnToLithium.Crew
{
    enum PersonStatus {Working, Idle, Walking, Fixing, Fighting, Firefighting, Dead}
    enum Alleigence {Friendly, Ally, Neutral, Enemy}

    class TPerson : IUpdatableObject
    {
        private int Health;//default max is 100
        public int X;
        public int Y;
        public int Floor;
        public TShip CurrentShip; //if he has beamed onto an enemy ship, that ship will be the one stored here. (X and Y is relative to the current ship)
        //Thanks!

        //Walking
        private List<int> WaypointsX;//positions of each door the person walks to.
        private List<int> WaypointsY;

        public void Update(DateTime currentTime)
        {
            throw new NotImplementedException();
        }
    }
}
