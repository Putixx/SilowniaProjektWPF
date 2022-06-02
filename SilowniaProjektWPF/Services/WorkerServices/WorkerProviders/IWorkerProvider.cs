using SilowniaProjektWPF.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.WorkerProviders
{
    /// <summary>
    /// Interface for worker provider
    /// </summary>
    public interface IWorkerProvider
    {
        /// <summary>
        /// Get all wokers from database
        /// </summary>
        /// <returns> IEnumerable<Worker> from database </returns>
        Task<IEnumerable<Worker>> GetWorkers();

        /// <summary>
        /// Create new worker
        /// </summary>
        /// <param name="worker"> New worker to create </param>
        Task CreateWorker(Worker worker);
    }
}
