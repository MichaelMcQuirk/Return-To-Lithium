using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Return_to_Lithium.Economics;
using Return_to_Lithium.Ships;
using Return_to_Lithium.Miscellaneous;

namespace Return_to_Lithium.Planetary
{
    class TPlanetoid : IUpdatableObject
    {
        public string Name;
        public int ID;
        public TSolarSystem SolarSystem;

        private int X;
        private int Y;

        public PlanetoidalClass Class;
        public PlanetoidalType Type;
        public int Category;             //size: 1->10 (small -> massive).

        public TMarket Market;
        public TResourceCollecton Resources;

        
        public int Population;
        public double birthRate;
        public double deathRate;
        public double immegrationRate;   //(not %)
        public double emmegrationRate;   //(not %)
        public double technologicalProgress;//used to determine ability to extract certain resources
        
        public List<TShip> DockedShips;
        public List<TPlanetoid> Moons;


        public void Update(DateTime currentTime)
        {
            throw new NotImplementedException();
        }
    }
}
