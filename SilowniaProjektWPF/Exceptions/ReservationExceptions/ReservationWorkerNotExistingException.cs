using SilowniaProjektWPF.DAL.Models;
using System;

namespace SilowniaProjektWPF.Exceptions.ReservationExceptions
{
    /// <summary>
    /// Exception when trying to add new reservation for worker that is not in database
    /// </summary>
    public class ReservationWorkerNotExistingException : Exception
    {
        public Reservation ExistingReservation { get; }
        public Reservation IncomingReservation { get; }

        public ReservationWorkerNotExistingException() { }

        public ReservationWorkerNotExistingException(Reservation existingReservation, Reservation incomingReservation)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

        public ReservationWorkerNotExistingException(string message, Reservation existingReservation, Reservation incomingReservation) : base(message)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

        public ReservationWorkerNotExistingException(string message, Exception innerException, Reservation existingReservation, Reservation incomingReservation) : base(message, innerException)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }
    }
}
