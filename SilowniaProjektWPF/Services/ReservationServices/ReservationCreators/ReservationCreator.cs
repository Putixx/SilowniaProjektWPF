using SilowniaProjektWPF.DAL.Contexts;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.DAL.ModelsDTO;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.ReservationCreators
{
    /// <summary>
    /// Implementation of reservation creator
    /// </summary>
    public class ReservationCreator : IReservationCreator
    {
        private readonly GymDbContextFactory _dbContextFactory;

        public ReservationCreator(GymDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Create reservation
        /// </summary>
        /// <param name="reservation"> Reservation to create</param>
        public async Task CreateReservation(Reservation reservation)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO = ToReservationDTO(reservation);

                context.Reservations.Add(reservationDTO);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Convert to reservation database transfer object from reservation model
        /// </summary>
        /// <param name="reservation"> Reservation to convert </param>
        /// <returns> ReservationDTO </returns>
        private ReservationDTO ToReservationDTO(Reservation reservation)
        {
            return new ReservationDTO()
            {
                PassNumber = reservation.PassNumber,
                InstructorIndex = reservation.InstructorIndex,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate
            };
        }
    }
}
