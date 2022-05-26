using SilowniaProjektWPF.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Stores
{
    public class GymStore
    {
        private readonly List<Reservation> _reservations;
        private readonly Gym _gym;
        private readonly Lazy<Task> _initializeLazy;

        public IEnumerable<Reservation> Reservations => _reservations;


        public GymStore(Gym gym)
        {
            _reservations = new List<Reservation>();
            _initializeLazy = new Lazy<Task>(Initialize);
            _gym = gym;
        }

        public async Task Load()
        {
            await _initializeLazy.Value;
        }

        public async Task MakeReservation(Reservation reservation)
        {
            await _gym.MakeReservation(reservation);

            _reservations.Add(reservation);
        }

        private async Task Initialize()
        {
            IEnumerable<Reservation> reservations = await _gym.GetAllReservations();

            _reservations.Clear();
            _reservations.AddRange(reservations);
        }
    }
}
