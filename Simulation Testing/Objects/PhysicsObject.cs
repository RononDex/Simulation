using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation;
using Simulation_Core_testing.Math;

namespace Simulation_Core_testing.Objects
{
    public class PhysicsObject : SimulationObject
    {
        public double Mass
        {
            get { return Convert.ToSingle(this["Mass"]); }
            set { this["Mass"] = value; }
        }

        public Vector3D Position {
            get { return (Vector3D)this["Position"]; }
            set { this["Position"] = value; }
        }

        public Vector3D Velocity
        {
            get { return (Vector3D)this["Velocity"]; }
            set { this["Velocity"] = value; }
        }
    }
}
