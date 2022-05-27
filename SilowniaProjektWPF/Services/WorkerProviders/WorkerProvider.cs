using Microsoft.EntityFrameworkCore;
using SilowniaProjektWPF.DAL.Contexts;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.DAL.ModelsDTO;
using SilowniaProjektWPF.Exceptions;
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
            return new Worker(w.InstructorIndex, w.Name, w.Surname, w.PhoneNumber, w.Specialization, w.HourlyCost);
        }

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

        private async Task<Worker> CheckIfSameNumber(Worker worker)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                WorkerDTO workerDTO = await context.Workers.Where(w => w.PhoneNumber == worker.PhoneNumber).FirstOrDefaultAsync();

                if (workerDTO == null) return null;

                return ToWorker(workerDTO);
            }
        }
    }
}
