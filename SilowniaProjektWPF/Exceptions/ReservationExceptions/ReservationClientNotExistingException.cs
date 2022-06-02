using SilowniaProjektWPF.DAL.Models;
using System;

namespace SilowniaProjektWPF.Exceptions.ReservationExceptions
{
    /// <summary>
    /// Exception when trying to add new reservation for client that is not in database
    /// </summary>
    public class ReservationClientNotExistingException : Exception
    {
        public Reservation ExistingReservation { get; }
        public Reservation IncomingReservation { get; }

        public ReservationClientNotExistingException() { }

        public ReservationClientNotExistingException(Reservation existingReservation, Reservation incomingReservation)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

        public ReservationClientNotExistingException(string message, Reservation existingReservation, Reservation incomingReservation) : base(message)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

        public ReservationClientNotExistingException(string message, Exception innerException, Reservation existingReservation, Reservation incomingReservation) : base(message, innerException)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }
    }
}
