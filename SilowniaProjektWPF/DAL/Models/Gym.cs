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

        public Gym(string Name, ReservationBook reservationBook)
        {
            this.Name = Name;
            _reservationBook = reservationBook;
        }

        public void GetReservationsForInstructor(string InstructorIndex)
        {
            _reservationBook.GetReservationsForInstructorIndex(InstructorIndex);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _reservationBook.GetReservations();
        }

        public async Task MakeReservation(Reservation reservation)
        {
            await _reservationBook.AddReservation(reservation);
        }
    }
}
