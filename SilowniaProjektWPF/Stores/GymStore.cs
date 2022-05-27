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
        private readonly List<Worker> _workers;
        private readonly Gym _gym;
        private readonly Lazy<Task> _initializeLazy;

        public IEnumerable<Reservation> Reservations => _reservations;
        public IEnumerable<Worker> Workers => _workers;


        public GymStore(Gym gym)
        {
            _reservations = new List<Reservation>();
            _workers = new List<Worker>();
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

        public async Task MakeWorker(Worker worker)
        {
            await _gym.MakeWorker(worker);

            _workers.Add(worker);
        }

        private async Task Initialize()
        {
            IEnumerable<Reservation> reservations = await _gym.GetAllReservations();
            IEnumerable<Worker> workers = await _gym.GetAllWorkers();

            _reservations.Clear();
            _reservations.AddRange(reservations);

            _workers.Clear();
            _workers.AddRange(workers);
        }
    }
}
