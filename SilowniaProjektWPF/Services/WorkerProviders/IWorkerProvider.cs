using SilowniaProjektWPF.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.WorkerProviders
{
    public interface IWorkerProvider
    {
        Task<IEnumerable<Worker>> GetWorkers();
        Task CreateWorker(Worker worker);
    }
}
