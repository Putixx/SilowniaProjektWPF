using Microsoft.EntityFrameworkCore;
using SilowniaProjektWPF.DAL.Contexts;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.DAL.ModelsDTO;
using System.Linq;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.ReservationConflictValidators
{
    /// <summary>
    /// Implementation of reservation conflict validator
    /// </summary>
    public class ReservationConflictValidator : IReservationConflictValidator
    {
        private readonly GymDbContextFactory _dbContextFactory;

        public ReservationConflictValidator(GymDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Checks if there is conflicting reservation
        /// </summary>
        /// <param name="reservation"> Reservation to check </param>
        /// <returns> true if there is conflicting reservation and false when there is not any conflicting reservation </returns>
        public async Task<bool> IsConflictReservation(Reservation reservation)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO = await context.Reservations.Where(r => r.InstructorIndex == reservation.InstructorIndex)
                    .Where(r => r.StartDate <= reservation.EndDate)
                    .Where(r => r.EndDate >= reservation.StartDate)
                    .FirstOrDefaultAsync();

                if (reservationDTO == null) return false;

                return true;
            }
        }

        /// <summary>
        /// Checks if worker is existing
        /// </summary>
        /// <param name="InstructorIndex"> Instructor index for worker reservation </param>
        /// <returns> true if worker exist and false if not </returns>
        public async Task<bool> IsWorkerExisting(string InstructorIndex)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                WorkerDTO workerDTO = await context.Workers.Where(w => w.InstructorIndex == InstructorIndex).FirstOrDefaultAsync();

                if (workerDTO == null) return false;

                return true;
            }
        }

        /// <summary>
        /// Checks if client is existing
        /// </summary>
        /// <param name="PassNumber"> Pass number for client reservation </param>
        /// <returns> true if client exist and false if not </returns>
        public async Task<bool> IsClientExisting(string PassNumber)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                ClientDTO clientDTO = await context.Clients.Where(c => c.PassNumber == PassNumber).FirstOrDefaultAsync();

                if (clientDTO == null) return false;

                return true;
            }
        }
    }
}
