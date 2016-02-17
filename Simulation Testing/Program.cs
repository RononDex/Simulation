using Simulation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation_Core_testing.Engines;
using Simulation_Core_testing.Math;
using Simulation_Core_testing.Objects;

namespace Simulation_Core_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Listeners.Add(new ConsoleTraceListener());

            var system = new SimulationSystem();

            // Add a thread and a simulation engine to the simulation framework
            system.AddSimulationThread(new SimulationThread(new SimulationEngine[] { new GravityEngine() }.ToList()));

            // Add a new object to the group
            var sun = new Star();
            sun.Position = new Vector3D(0,0,0);
            sun.Velocity = new Vector3D(0,0,0);
            var earth = new Planet();

            system.World.Objects.Add(sun);
            system.World.Objects.Add(earth);

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
