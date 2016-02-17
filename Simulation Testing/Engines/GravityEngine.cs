using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation;
using Simulation_Core_testing.Objects;

namespace Simulation_Core_testing.Engines
{
    /// <summary>
    /// Simulates the effects of gravity on objects
    /// </summary>
    public class GravityEngine : SimulationEngine
    {
        public const double GRAVITATIONAL_CONSTANT = 6.67408e-11;

        public override void UpdateWorld(SimulationContext context, TimeSpan step)
        {
            var physicsObjects = context.World.Objects.FindByType<PhysicsObject>(true);

            foreach (var physObject in physicsObjects)
            {
                
            }
        }
    }
}
