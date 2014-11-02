using Simulation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_Core_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Listeners.Add(new ConsoleTraceListener());

            var system = new SimulationSystem();

            // Add a thread and a simulation engine to the simulation framework
            system.AddSimulationThread(new SimulationThread(new SimulationEngine[] {new TestSimulationEngine() }.ToList()));

            // Add a new simulation group
            system.World.Objects.Add(new SimulationGroup());

            // Add a new object to the group
            ((SimulationGroup)system.World.Objects[0]).Objects.Add(new SimulationObject());
            system.World.Objects.Add(new SimulationObject());

            DateTime loopStart = DateTime.Now;
            DateTime loopEnd = DateTime.Now;

            // Simulates the update loop
            while (true)
            {
                loopStart = DateTime.Now;
                system.Update(loopStart - loopEnd);
                loopEnd = DateTime.Now;

                // Wait for user to press enter to start the next loop
                //Console.ReadLine();
            }
        }
    }
}
