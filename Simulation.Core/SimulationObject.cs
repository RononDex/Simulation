using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    /// <summary>
    /// A single simulated object
    /// </summary>
    public class SimulationObject
    {
        #region Fields

        private PropertyBag propertyBag;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of the given property
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get { return propertyBag[key]; }
            set { propertyBag[key] = value; }
        }

        /// <summary>
        /// Gets the property bag
        /// </summary>
        public PropertyBag Properties
        {
            get { return this.propertyBag; }
        }

        #endregion

        public SimulationObject()
        {
            propertyBag = new PropertyBag();

            // Create & set the unique GUID for this object
            this[BuiltInProperties.ID] = Guid.NewGuid();

            // Write some debug information
            Debug.WriteLine("New simulation object of type {0} with id {1} created!", this.GetType(), this[BuiltInProperties.ID]);
        }


    }
}
