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
            Console.WindowWidth = 200;
            Console.BufferWidth = 200;
            Debug.Listeners.Add(new ConsoleTraceListener());

            var system = new SimulationSystem();

            // Add a thread and a simulation engine to the simulation framework
            system.AddSimulationThread(new SimulationThread(new SimulationEngine[] { new GravityEngine() }.ToList()));

            // Add a new object to the group
            var sun = new Star();
            sun.Position = new Vector3D(0,0,0);
            sun.Velocity = new Vector3D(0,0,0);
            sun.Mass = 1.998855e30;

            var earth = new Planet();
            earth.Mass = 5.9722e24;
            earth.Position = new Vector3D(0, 149.6e9, 0);
            earth.Velocity = new Vector3D(29780,0,0);

            system.World.Objects.Add(sun);
            system.World.Objects.Add(earth);

            DateTime loopStart = DateTime.Now;
            DateTime loopEnd = DateTime.Now;

            DateTime simulatedDate = DateTime.Now;

            // Simulates the update loop
            while (true)
            {
                var step = new TimeSpan(0, 10, 0);
                loopStart = DateTime.Now;

                system.Update(step);
                loopEnd = DateTime.Now;

                simulatedDate += step;
                Console.WriteLine("Pos: Earth: {0}\t Sun: {1} |{2}", earth.Position, sun.Position, simulatedDate);
                //Console.WriteLine("Vel: Earth: {0}\t Sun: {1}\tD: {3} |{2}", earth.Velocity, sun.Velocity, simulatedDate, (earth.Position - sun.Position).Length);

                // Wait for user to press enter to start the next loop
                //Console.ReadLine();
            }
        }
    }
}
