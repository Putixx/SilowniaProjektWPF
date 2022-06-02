using Microsoft.EntityFrameworkCore;
using SilowniaProjektWPF.DAL.Contexts;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.DAL.ModelsDTO;
using SilowniaProjektWPF.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.WorkerProviders
{
    /// <summary>
    /// Implementation of worker provider
    /// </summary>
    public class WorkerProvider : IWorkerProvider
    {
        private readonly GymDbContextFactory _dbContextFactory;

        public WorkerProvider(GymDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Get all workers from database
        /// </summary>
        /// <returns> IEnumerable<Worker> from database </returns>
        public async Task<IEnumerable<Worker>> GetWorkers()
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<WorkerDTO> workersDTOs = await context.Workers.ToListAsync();

                return workersDTOs.Select(w => ToWorker(w));
            }
        }

        /// <summary>
        /// Create new worker
        /// </summary>
        public async Task CreateWorker(Worker worker)
        {
            Worker conflictingWorker = await CheckIfExists(worker);
            Worker conflictingNumber = await CheckIfSameNumber(worker);

            if (conflictingWorker != null)
            {
                throw new WorkerConflictException(conflictingWorker, worker);
            }

            if (conflictingNumber != null)
            {
                throw new WorkerExistingNumberException(conflictingNumber, worker);
            }

            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                WorkerDTO workerDTO = ToWorkerDTO(worker);

                context.Workers.Add(workerDTO);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Check if given worker is already in database
        /// </summary>
        /// <returns> Worker model </returns>
        private async Task<Worker> CheckIfExists(Worker worker)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                WorkerDTO workerDTO = await context.Workers.Where(w => w.InstructorIndex == worker.InstructorIndex)
                    .Where(w => w.Name == worker.Name)
                    .Where(w => w.Surname == worker.Surname)
                    .Where(w => w.PhoneNumber == worker.PhoneNumber)
                    .Where(w => w.Specialization == worker.Specialization)
                    .Where(w => w.HourlyCost == worker.HourlyCost.ToString())
                    .FirstOrDefaultAsync();

                if (workerDTO == null) return null;

                return ToWorker(workerDTO);
            }
        }

        /// <summary>
        /// Checks if there is already worker with given phone number
        /// </summary>
        /// <returns> Worker model </returns>
        private async Task<Worker> CheckIfSameNumber(Worker worker)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                WorkerDTO workerDTO = await context.Workers.Where(w => w.PhoneNumber == worker.PhoneNumber).FirstOrDefaultAsync();

                if (workerDTO == null) return null;

                return ToWorker(workerDTO);
            }
        }

        /// <summary>
        /// Converts to worker from worker database transfer object
        /// </summary>
        /// <returns> Worker model </returns>
        private static Worker ToWorker(WorkerDTO w)
        {
            return new Worker(w.InstructorIndex, w.Name, w.Surname, w.PhoneNumber, w.Specialization, w.HourlyCost);
        }

        /// <summary>
        /// Converts from worker database transfer object to worker
        /// </summary>
        /// <returns> WorkerDTO model </returns>
        private WorkerDTO ToWorkerDTO(Worker worker)
        {
            return new WorkerDTO()
            {
                InstructorIndex = worker.InstructorIndex,
                Name = worker.Name,
                Surname = worker.Surname,
                PhoneNumber = worker.PhoneNumber,
                Specialization = worker.Specialization,
                HourlyCost = worker.HourlyCost.ToString()
            };
        }
    }
}
