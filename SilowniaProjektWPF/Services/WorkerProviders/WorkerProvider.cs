using Microsoft.EntityFrameworkCore;
using SilowniaProjektWPF.DAL.Contexts;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.DAL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.WorkerProviders
{
    public class WorkerProvider : IWorkerProvider
    {
        private readonly GymDbContextFactory _dbContextFactory;

        public WorkerProvider(GymDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Worker>> GetWorkers()
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<WorkerDTO> workersDTOs = await context.Workers.ToListAsync();

                return workersDTOs.Select(w => ToWorker(w));
            }
        }

        private static Worker ToWorker(WorkerDTO w)
        {
            return new Worker(w.Name, w.Surname, w.PhoneNumber);
        }

        public async Task CreateWorker(Worker worker)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                WorkerDTO workerDTO = ToWorkerDTO(worker);

                context.Workers.Add(workerDTO);
                await context.SaveChangesAsync();
            }
        }

        private WorkerDTO ToWorkerDTO(Worker worker)
        {
            return new WorkerDTO()
            {
                Name = worker.Name,
                Surname = worker.Surname,
                PhoneNumber = worker.PhoneNumber
            };
        }
    }
}
