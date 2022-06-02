using SilowniaProjektWPF.Exceptions;
using SilowniaProjektWPF.Exceptions.ReservationExceptions;
using SilowniaProjektWPF.Services.ReservationConflictValidators;
using SilowniaProjektWPF.Services.ReservationCreators;
using SilowniaProjektWPF.Services.ReservationProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.DAL.Models
{
    public class ReservationBook
    {
        private readonly IReservationProvider _reservationProvider;
        private readonly IReservationCreator _reservationCreator;
        private readonly IReservationConflictValidator _reservationConflictValidator;

        public ReservationBook(IReservationProvider reservationProvider, IReservationCreator reservationCreator, IReservationConflictValidator reservationConflictValidator)
        {
            _reservationProvider = reservationProvider;
            _reservationCreator = reservationCreator;
            _reservationConflictValidator = reservationConflictValidator;
        }

        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            return await _reservationProvider.GetAllReservations();
        }

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
