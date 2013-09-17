using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReturnToLithium.Miscellaneous;

namespace ReturnToLithium.Ship
{

    class TShipObject : IUpdatableObject
    {
        //All ShipObjects are restricted to being placed INSIDE the ship.
        //such objects might be: Computer, Plant, Weapon, Food, Water spill, etc

        Direction FacingDirection;
        RelativePosition Position;             //is it on the left side of the block, right side, at the top? etc

        bool Interactable = false;


        void IUpdatableObject.Update(DateTime currentTime)
        {
            throw new NotImplementedException();
        }
    }
}
