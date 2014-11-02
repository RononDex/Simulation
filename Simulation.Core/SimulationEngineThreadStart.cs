using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    /// <summary>
    /// Value object for a thread start
    /// </summary>
    public sealed class SimulationEngineThreadStart
    {
        /// <summary>
        /// The context of the simulation which is passed to the engines
        /// </summary>
        public SimulationContext Context
        {
            get;
            set;
        }

        /// <summary>
        /// The step size
        /// </summary>
        public TimeSpan Step { get; set; }
    }
}
