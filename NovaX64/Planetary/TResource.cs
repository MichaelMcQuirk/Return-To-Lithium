using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReturnToLithium.Planetary
{
    class TResource
    {
        //Identification
        public string RID;
        public string Name;

        //Value
        public int Quality; //1->10?
        public double Quantity;    
        public double Price;
        public double GlobalPrice;//Benchmark Universal Price.

        //Miscellaneous (Demand, Supply, Production etc). All values are subject to regular change
        public double perHourProduction;
        public double perHourConsumption;
        public double preferedMinStorage;
        public double preferedMaxStorage;
        public double inflationRate; //per day?
        public double demand;//Increases the longer the perHourConsumtion rate is not met.

        //Planetoid Specific Data. Values rarely change (only cataclysmic event, over-extraction or addition of new resources into game).
        public double CrustComposition;
        public double MantleComposition;
        public double OuterCoreComposition;
        public double InnerCoreComposition;
        public double AtmosphericComposition;//Only used if we will be dealing with gasses.
    }
}
