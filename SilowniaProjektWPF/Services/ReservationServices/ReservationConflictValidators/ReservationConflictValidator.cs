using Microsoft.EntityFrameworkCore;
using SilowniaProjektWPF.DAL.Contexts;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.DAL.ModelsDTO;
using System.Linq;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.ReservationConflictValidators
{
    public class ReservationConflictValidator : IReservationConflictValidator
    {
        private readonly GymDbContextFactory _dbContextFactory;

        public ReservationConflictValidator(GymDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

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

        public async Task<bool> IsWorkerExisting(string InstructorIndex)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                WorkerDTO workerDTO = await context.Workers.Where(w => w.InstructorIndex == InstructorIndex).FirstOrDefaultAsync();

                if (workerDTO == null) return false;

                return true;
            }
        }

        public async Task<bool> IsClientExisting(string PassNumber)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                ClientDTO clientDTO = await context.Clients.Where(c => c.PassNumber == PassNumber).FirstOrDefaultAsync();

                if (clientDTO == null) return false;

                return true;
            }
        }

        private static Reservation ToReservation(ReservationDTO r)
        {
            return new Reservation(r.PassNumber, r.InstructorIndex, r.StartDate, r.EndDate);
        }
    }
}
