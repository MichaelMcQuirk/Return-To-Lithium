using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReturnToLithium.Planetary
{
    class TResourceCollecton
    {
        public List<TResource> Resources;


        public TResource Get(string name)
        {
            foreach (TResource R in Resources)
                if (R.Name.ToLower().Equals(name.ToLower())) return R;

            throw new Exception("ERROR: (Resource Collection) No such resource, " + name + " , exits!");
        }
    }
}
