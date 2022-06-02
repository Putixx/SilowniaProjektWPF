using Microsoft.EntityFrameworkCore;
using SilowniaProjektWPF.DAL.Contexts;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.DAL.ModelsDTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.ReservationProviders
{
    /// <summary>
    /// Implementation of reservation provider
    /// </summary>
    public class ReservationProvider : IReservationProvider
    {
        private readonly GymDbContextFactory _dbContextFactory;

        public ReservationProvider(GymDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Get all reservations
        /// </summary>
        /// <returns> IEnumerable<Reservation> from database </returns>
        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<ReservationDTO> reservationDTOs = await context.Reservations.ToListAsync();

                return reservationDTOs.Select(r => ToReservation(r));
            }
        }

        /// <summary>
        /// Converts reservation database transfer object to reservation model
        /// </summary>
        /// <param name="r"> reservation to convert </param>
        /// <returns> Reservation model </returns>
        private static Reservation ToReservation(ReservationDTO r)
        {
            return new Reservation(r.PassNumber, r.InstructorIndex, r.StartDate, r.EndDate);
        }
    }
}
