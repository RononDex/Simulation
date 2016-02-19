using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    /// <summary>
    /// A collection of simulation objects
    /// </summary>
    public class SimulationObjectCollection : List<SimulationObject>
    {
        /// <summary>
        /// Finds a simulation obect by its unique id
        /// </summary>
        /// <param name="id">The id of the object to find</param>
        /// <param name="recursive">Set this parameter to true, if the search needs to be done recursive.</param>
        /// <returns></returns>
        public SimulationObject FindById(Guid id, bool recursive = false)
        {
            return FindByFieldValue(BuiltInProperties.ID, id, recursive).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentType"></param>
        /// <param name="recusrive"></param>
        /// <param name="includeGroups"></param>
        /// <returns></returns>
        public List<SimulationObject> FinyByContentType(string contentType, bool recusrive, bool includeGroups = false)
        {
            return FindByFieldValue(BuiltInProperties.ContentType, contentType, recusrive, includeGroups);
        }

        /// <summary>
        /// Finds the simulationobjects of the given contentType.
        /// </summary>
        /// <param name="field">Name of the field to filter for</param>
        /// <param name="fieldValue">The field value to search for</param>
        /// <param name="recursive">If true, searches recusrive through all the groups</param>
        /// <param name="includeGroups">true if you want to include groups in the search results</param>
        /// <returns></returns>
        public List<SimulationObject> FindByFieldValue(string field, object fieldValue, bool recursive, bool includeGroups = false)
        {
            var result = new List<SimulationObject>();

            FindByFieldValueTypeRecursive(result, this, field, fieldValue, includeGroups, recursive);

            return result;
        }

        /// <summary>
        /// Finds all objects of the given fieldvalue recursivly inside a given simulation group
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="group"></param>
        /// <param name="fieldValue"></param>
        /// <param name="includeGroups"></param>
        private void FindByFieldValueTypeRecursive(ICollection<SimulationObject> objects, IEnumerable<SimulationObject> group, string field, object fieldValue, bool includeGroups, bool recusrive)
        {
            foreach (SimulationObject simulationObject in group)
            {
                if (Convert.ToString(simulationObject[field]).Equals(fieldValue))
                {
                    if (!includeGroups && simulationObject is SimulationGroup)
                        continue;

                    objects.Add(simulationObject);
                }
                if (recusrive && simulationObject is SimulationGroup)
                {
                    var newGroup = (SimulationGroup) simulationObject;
                    FindByFieldValueTypeRecursive(objects, newGroup.Objects, field, fieldValue, includeGroups, recusrive);
                }
            }
        }

        /// <summary>
        /// Finds allobjects of a given type
        /// </summary>
        /// <param name="type">The type to search for</param>
        /// <param name="recusrive">True to search recusrivly through groups and its members</param>
        /// <returns></returns>
        public List<type> FindByType<type>(bool recusrive) where type: SimulationObject
        {
            var result = new List<type>();

            FindByTypeTypeRecursive(result, this, recusrive);

            return result;
        }

        /// <summary>
        /// Finds all objects of the given type in a given group
        /// </summary>
        /// <param name="objects"></param>
        /// <param name="group"></param>
        /// <param name="fieldValue"></param>
        /// <param name="includeGroups"></param>
        private void FindByTypeTypeRecursive<type>(ICollection<type> objects, IEnumerable<SimulationObject> group, bool recusrive) where type : SimulationObject
        {
            foreach (SimulationObject simulationObject in group)
            {
                if (simulationObject is type)
                {
                    objects.Add((type)simulationObject);
                }
                if (recusrive && simulationObject is SimulationGroup)
                {
                    var newGroup = (SimulationGroup)simulationObject;
                    FindByTypeTypeRecursive<type>(objects, newGroup.Objects, recusrive);
                }
            }
        }
    }
}
