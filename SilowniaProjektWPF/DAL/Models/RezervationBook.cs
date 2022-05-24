using SilowniaProjektWPF.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SilowniaProjektWPF.DAL.Models
{
    public class ReservationBook
    {
        private readonly List<Reservation> _reservations;

        public ReservationBook()
        {
            _reservations = new List<Reservation>();
        }

        public IEnumerable<Reservation> GetReservationsForInstructs(Instructor Instructor)
        {
            return _reservations.Where(r => r.Instructor == Instructor);
        }

        public void AddReservation(Reservation reservation)
        {
            foreach(Reservation existingReservation in _reservations)
            {
                if (existingReservation.Conflicts(reservation)) throw new ReservationConflictException(existingReservation, reservation);
            }

            _reservations.Add(reservation);
        }
    }
}
