using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulation
{
    /// <summary>
    /// The simulation system manages a simulation
    /// </summary>
    public class SimulationSystem
    {
        object objLock = new Object();

        /// <summary>
        /// Counts the completed threads
        /// </summary>
        protected int completedThreadsCount = 0;
        /// <summary>
        /// The amount of threads to be completed
        /// </summary>
        protected int threadsToCompleteCount = 0;

        /// <summary>
        /// The simulated world
        /// </summary>
        public SimulationWorld World { get; private set; }

        ///// <summary>
        ///// List of all simulation engines that do changes to this simulation system
        ///// </summary>
        //public List<SimulationEngine> SimulationEngines { get; private set; }

        /// <summary>
        /// Mapping, which Thread handels which engine(s)
        /// </summary>
        private List<SimulationThread> Threads
        {
            get;
            set;
        }

        /// <summary>
        /// Gets all simulation threads
        /// </summary>
        /// <returns></returns>
        public SimulationThread[] GetThreads()
        {
            return this.Threads.ToArray();
        }

        /// <summary>
        /// Adds a simulation thread to the simulationSystem
        /// </summary>
        /// <param name="thread"></param>
        public void AddSimulationThread(SimulationThread thread)
        {
            thread.ThreadCompleted += ThreadCompleted;
            this.Threads.Add(thread);
        }

        /// <summary>
        /// Initializes the simulation system  with default values
        /// </summary>
        public SimulationSystem()
        {
            this.Init(new SimulationWorld());
        }

        /// <summary>
        /// Initializes a simulation system
        /// </summary>
        /// <param name="world">A custom world object</param>
        public SimulationSystem(SimulationWorld world)
        {
            #region PRECONDITION

            if (world == null)
                throw new ArgumentNullException("The simulation world of a simulation system must not be NULL!");

            #endregion

            this.Init(world);
        }

        /// <summary>
        /// Initializes the simulation system
        /// </summary>
        /// <param name="world"></param>
        private void Init(SimulationWorld world)
        {
            this.World = world;
            this.Threads = new List<SimulationThread>();
        }

        /// <summary>
        /// Updates the simulation
        /// </summary>
        /// <param name="step"></param>
        public void Update(TimeSpan step)
        {
            // If there is still an update in progress ignore the call
            if (this.threadsToCompleteCount != this.completedThreadsCount)
                throw new Exception("Tried to call .Update() while another update is still running");

            SimulationContext context = this.GetContext();

            threadsToCompleteCount = 0;
            completedThreadsCount = 0;

            // Start threads
            foreach (var item in this.Threads)
            {
                threadsToCompleteCount++;
                item.ProcessEngines(context, step);
            }

            foreach (var item in this.Threads)
            {
                item.Thread.Join();
            }
        }

        /// <summary>
        /// Gets called when a simulation thread has finished
        /// </summary>
        protected void ThreadCompleted()
        {
            lock (objLock)
            {
                completedThreadsCount++;
            }
        }

        /// <summary>
        /// Gets the current simulation context
        /// </summary>
        /// <returns></returns>
        public virtual SimulationContext GetContext()
        {
            return new SimulationContext(this.World);
        }
    }
}
