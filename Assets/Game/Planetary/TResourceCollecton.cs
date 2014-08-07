using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Return_to_Lithium.Planetary
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
