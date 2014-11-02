using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    /// <summary>
    /// An engine, which simulates things in the simulationworld and modifies its objects
    /// </summary>
    public abstract class SimulationEngine
    {
        public abstract void UpdateWorld(SimulationContext context, TimeSpan step);
    }
}
