using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    /// <summary>
    /// Holds properties in a string objcet dictionary
    /// </summary>
    public class PropertyBag : IEnumerable<KeyValuePair<string, object>>
    {
        /// <summary>
        /// All readonly properites use this prefix
        /// </summary>
        public const string READONLY_PREFIX = "@";

        #region Static Functions

        /// <summary>
        /// Gets the the readonly key name for a given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetReadOnlyKey(string key)
        {
            return string.Format("{0}{1}", READONLY_PREFIX, key);
        }

        #endregion

        #region Fields

        private Dictionary<string, object> properties;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the value of the defined property
        /// </summary>
        /// <param name="key">key of the property</param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                return properties.ContainsKey(key) ? properties[key] : null;
            }
            set
            {
                // Add the property to the dictionary if not present
                if (!properties.ContainsKey(key))
                    properties.Add(key, value);
                else
                {
                    // Throw an exception, if a readonly property is beeing set
                    if (key.StartsWith(READONLY_PREFIX))
                        throw new InvalidOperationException(string.Format("Tried to change the readonly property {0}", key));

                    properties[key] = value;
                }
            }
        }

        #endregion

        public PropertyBag()
        {
            properties = new Dictionary<string, object>();
        }        

        #region IEnumerable Members

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return properties.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return properties.GetEnumerator();
        }

        #endregion
    }
}
