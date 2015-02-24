using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulation
{
    public class SimulationThread
    {
        /// <summary>
        /// The logical thread of the simulation thread
        /// </summary>
        internal Thread Thread { get; set; }

        /// <summary>
        /// Enumeration for the state of the simulation thread
        /// </summary>
        public enum SimulationThreadState
        {
            NOT_RUNNING,
            RUNNING
        }

        public List<SimulationEngine> Engines { get; set; }

        /// <summary>
        /// The execution state of the simulation thread
        /// </summary>
        public SimulationThreadState State { get; private set; }

        public delegate void ThreadCompletedDelegate();

        /// <summary>
        /// Event gets called when the thread has completed
        /// </summary>
        public event ThreadCompletedDelegate ThreadCompleted;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="engines">The list of the engines to update</param>
        public SimulationThread(List<SimulationEngine> engines)
        {
            this.State = SimulationThreadState.NOT_RUNNING;
            this.Engines = engines;
        }

        /// <summary>
        /// Executes the engines
        /// </summary>
        /// <param name="threadStartContext"></param>
        public void ProcessEngines(SimulationContext threadStartContext, TimeSpan step)
        {
            this.Thread = new Thread(new ParameterizedThreadStart(ThreadProcessEngines));
            this.Thread.Start(new SimulationEngineThreadStart() { Context = threadStartContext, Step = step });           
        }

        /// <summary>
        /// Start function for the thread
        /// </summary>
        /// <param name="threadStartContext"></param>
        protected void ThreadProcessEngines(object threadStartContext)
        {
            try
            {
                this.State = SimulationThreadState.RUNNING;
                var context = (SimulationEngineThreadStart)threadStartContext;

                foreach (var simEngine in this.Engines)
                {
                    simEngine.UpdateWorld(context.Context, context.Step);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in SimulationThread {0}: {1}", this.Thread.ManagedThreadId, ex.Message);
            }
            finally
            {
                this.State = SimulationThreadState.NOT_RUNNING;
                if (this.ThreadCompleted != null)
                    this.ThreadCompleted();
            }            
        }
    }
}
