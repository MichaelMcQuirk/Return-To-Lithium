using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Return_to_Lithium.Planetary;
using Return_to_Lithium.Miscellaneous;

namespace Return_to_Lithium.Economics
{
    class TMarket : IUpdatableObject
    {
        //Market: Each inhabited planetoid has it's own market. Markets can trade with markets from other planets.
        private TPlanetoid HostPlanetoid;
        private TSolarSystem HostSolarSystem;
        //miscellaneous 
        public int Credits;
        public double TaxRate;//divided by 24 for per hour tax. (Not %) eg: 3.6 represents 3.6 credits per person per day.
        public double InflationRate;

        public void Update(DateTime currentTime)
        {
            throw new NotImplementedException();
        }
    }
}
