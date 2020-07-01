namespace Simulation
{
    /// <summary>
    /// Used by simulation engines
    /// </summary>
    public class SimulationContext
    {
        public SimulationWorld World { get; private set; }

        /// <summary>
        /// Creates a new simulation context
        /// </summary>
        /// <param name="world">The world of the context</param>
        public SimulationContext(SimulationWorld world)
        {
            this.World = world;
        }
    }
}
