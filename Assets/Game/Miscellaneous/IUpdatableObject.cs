using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Return_to_Lithium.Miscellaneous
{
    interface IUpdatableObject
    {
        void Update(DateTime currentTime);
        /*Irregularly called. Called when:
    * - The object is in view of a user and might be active and thus needs to perform some action. Would thus be called at a regular interval.
    * - The object just came into view/range of the user and thus needs to be updated.
    */

    }
}
