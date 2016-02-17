using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_Core_testing.Math
{
    /// <summary>
    /// A double precision 3D vector
    /// </summary>
    public class Vector3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3D()
        {
                
        }

        public Vector3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        #region Operators

        /// <summary>
        /// Adds the given two 3D vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X + v2.X, 
                                v1.Y + v2.Y, 
                                v1.Z + v2.Z);
        }

        /// <summary>
        /// Subtracts the given two 3D vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X - v2.X,
                                v1.Y - v2.Y,
                                v1.Z - v2.Z);
        }

        /// <summary>
        /// Scalar multiplication
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3D operator *(double x, Vector3D v)
        {
            return new Vector3D(x * v.X,
                                x * v.Y,
                                x * v.Z);
        }

        #endregion
    }
}
