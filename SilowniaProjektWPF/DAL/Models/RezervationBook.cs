using SilowniaProjektWPF.Exceptions;
using SilowniaProjektWPF.Exceptions.ReservationExceptions;
using SilowniaProjektWPF.Services.ReservationConflictValidators;
using SilowniaProjektWPF.Services.ReservationCreators;
using SilowniaProjektWPF.Services.ReservationProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.DAL.Models
{
    /// <summary>
    /// Model for Reservations book
    /// </summary>
    public class ReservationBook
    {
        private readonly IReservationProvider _reservationProvider;
        private readonly IReservationCreator _reservationCreator;
        private readonly IReservationConflictValidator _reservationConflictValidator;

        /// <summary>
        /// Creates new Reservation book
        /// </summary>
        /// <param name="reservationProvider"> Implementation of reservation provider </param>
        /// <param name="reservationCreator"> Implementation of reservation creator </param>
        /// <param name="reservationConflictValidator"> Implementation of reservation conflict validator </param>
        public ReservationBook(IReservationProvider reservationProvider, IReservationCreator reservationCreator, IReservationConflictValidator reservationConflictValidator)
        {
            _reservationProvider = reservationProvider;
            _reservationCreator = reservationCreator;
            _reservationConflictValidator = reservationConflictValidator;
        }

        /// <summary>
        /// Get reservations
        /// </summary>
        /// <returns> IEnumerable<Reservation> from database </returns>
        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            return await _reservationProvider.GetAllReservations();
        }
        
        /// <summary>
        /// Add new reservation
        /// </summary>
        /// <param name="reservation"> Reservation to add </param>
        public async Task AddReservation(Reservation reservation)
        {
            if(await _reservationConflictValidator.IsConflictReservation(reservation))
            {
                throw new ReservationConflictException();
            }

            if (!await _reservationConflictValidator.IsWorkerExisting(reservation.InstructorIndex))
            {
                throw new ReservationWorkerNotExistingException();
            }

            if (!await _reservationConflictValidator.IsClientExisting(reservation.PassNumber))
            {
                throw new ReservationClientNotExistingException();
            }

            await _reservationCreator.CreateReservation(reservation);
        }
    }
}
