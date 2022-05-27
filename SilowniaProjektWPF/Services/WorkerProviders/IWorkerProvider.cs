using SilowniaProjektWPF.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.WorkerProviders
{
    public interface IWorkerProvider
    {
        Task<IEnumerable<Worker>> GetWorkers();
        Task CreateWorker(Worker worker);
    }
}
