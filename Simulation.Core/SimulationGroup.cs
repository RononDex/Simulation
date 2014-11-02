using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    /// <summary>
    /// A simulation object, which holds a collection of sub objects
    /// </summary>
    public class SimulationGroup : SimulationObject
    {
        public SimulationObjectCollection Objects { get; private set; }

        public SimulationGroup()
        {
            this.Objects = new SimulationObjectCollection();
        }
    }
}
