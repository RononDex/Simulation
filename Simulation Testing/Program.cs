using Simulation;
using System;
using System.Linq;
using Simulation_Core_testing.Engines;
using Simulation_Core_testing.Math;
using Simulation_Core_testing.Objects;

namespace Simulation_Core_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = new SimulationSystem();

            // Add a thread and a simulation engine to the simulation framework
            system.AddSimulationThread(new SimulationThread(new SimulationEngine[] { new GravityEngine() }.ToList()));

            // Add a new object to the group
            var sun = new Star();
            sun.Position = new Vector3D(0,0,0);
            sun.Velocity = new Vector3D(0,0,0);
            sun.Mass = 1.998855e30;

            var venus = new Planet();
            venus.Mass = 4.869e24;
            venus.Position = new Vector3D(41e9, 0, 0);
            venus.Velocity = new Vector3D(0, -35020, 0);

            var earth = new Planet();
            earth.Mass = 5.9722e24;
            earth.Position = new Vector3D(0, 149.6e9, 0);
            earth.Velocity = new Vector3D(29780,0,0);

            var moon = new Planet();
            moon.Mass = 7.342e22;
            moon.Position = earth.Position + new Vector3D(0, 384399000, 0);
            moon.Velocity = earth.Velocity + new Vector3D(1020,0,0);
            
            var saturn = new Planet();
            saturn.Mass = 5.683e26;
            saturn.Position = new Vector3D(1433.5e9, 0, 0);
            saturn.Velocity = new Vector3D(0, -9960000, 0);
            

            system.World.Objects.Add(sun);
            system.World.Objects.Add(earth);
            system.World.Objects.Add(moon);
            system.World.Objects.Add(saturn);
            system.World.Objects.Add(venus);

            DateTime simulatedDate = DateTime.Now;

            Console.SetCursorPosition(0, 8);
            Console.WriteLine("Solar system simulation");

            // Simulates the update loop
            while (true)
            {
                var step = new TimeSpan(0, 30, 0);

                system.Update(step);

                simulatedDate += step;

                // Date
                Console.SetCursorPosition(0, 10);
                Console.Write("Simulated date: {0}", simulatedDate);

                // Sun
                Console.SetCursorPosition(0, 11);
                Console.Write("Sun:    Pos: {0},\tVel: {1}", sun.Position, sun.Velocity);

                // Venus
                Console.SetCursorPosition(0, 12);
                Console.Write("Venus:  Pos: {0},\tVel: {1}", venus.Position, venus.Velocity);

                // Earth
                Console.SetCursorPosition(0, 13);
                Console.Write("Earth:  Pos: {0},\tVel: {1}", earth.Position, earth.Velocity);

                // Moon
                Console.SetCursorPosition(0, 14);
                Console.Write("Moon:   Pos: {0}, \tVel: {1}", moon.Position, moon.Velocity);

                // Saturn
                Console.SetCursorPosition(0, 15);
                Console.Write("Saturn: Pos: {0},\tVel: {1}", saturn.Position, saturn.Velocity);

                // Wait for user to press enter to start the next loop
                //Console.ReadLine();
            }
        }
    }
}
