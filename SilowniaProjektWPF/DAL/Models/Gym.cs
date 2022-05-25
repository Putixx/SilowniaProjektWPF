using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.DAL.Models
{
    public class Gym
    {
        private readonly ReservationBook _reservationBook;
        public string Name { get; }

        public Gym(string Name)
        {
            this.Name = Name;
            _reservationBook = new ReservationBook();
        }

        public IEnumerable<Reservation> GetReservationsForInstructor(string InstructorIndex)
        {
            return _reservationBook.GetReservationsForInstructorIndex(InstructorIndex);
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationBook.GetReservations();
        }

        public void MakeReservation(Reservation reservation)
        {
            _reservationBook.AddReservation(reservation);
        }
    }
}
