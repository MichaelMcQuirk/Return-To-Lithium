using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReturnToLithium.Miscellaneous;

namespace ReturnToLithium.Planetary
{
    class TSolarSystem : IUpdatableObject
    {
        public String Name;

        public double X;
        public double Y;
        public int Rings;

        public List<TPlanetoid> Planetoids;

        public void Update(DateTime currentTime)
        {
            throw new NotImplementedException();
        }
    }
}
