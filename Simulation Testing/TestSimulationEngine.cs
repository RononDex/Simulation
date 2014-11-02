using Simulation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_Core_testing
{
    public class TestSimulationEngine : SimulationEngine
    {
        public override void UpdateWorld(SimulationContext context, TimeSpan step)
        {
            // Do some stuff to the simulation world
            
            Console.WriteLine("UpdatingWorld with step {0}", step);

            // Add a new object each loop
            context.World.Objects.Add(new SimulationObject());
        }
    }
}
