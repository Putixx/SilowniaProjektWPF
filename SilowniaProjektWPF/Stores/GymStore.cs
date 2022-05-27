using SilowniaProjektWPF.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Stores
{
    public class GymStore
    {
        private readonly List<Reservation> _reservations;
        private readonly List<Worker> _workers;
        private readonly List<Equipment> _equipment;
        private readonly List<Client> _clients;
        private readonly Gym _gym;
        private readonly Lazy<Task> _initializeLazy;

        public IEnumerable<Reservation> Reservations => _reservations;
        public IEnumerable<Worker> Workers => _workers;
        public IEnumerable<Equipment> Equipment => _equipment;
        public IEnumerable<Client> Clients => _clients;


        public GymStore(Gym gym)
        {
            _reservations = new List<Reservation>();
            _workers = new List<Worker>();
            _equipment = new List<Equipment>();
            _clients = new List<Client>();
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

        public async Task MakeEquipment(Equipment equipment)
        {
            await _gym.MakeEquipment(equipment);

            _equipment.Add(equipment);
        }

        public async Task MakeClient(Client client)
        {
            await _gym.MakeClient(client);

            _clients.Add(client);
        }

        public async Task MakePass(Pass pass)
        {
            await _gym.MakePass(pass);
        }

        private async Task Initialize()
        {
            IEnumerable<Reservation> reservations = await _gym.GetAllReservations();
            IEnumerable<Worker> workers = await _gym.GetAllWorkers();
            IEnumerable<Equipment> equipment = await _gym.GetAllEquipment();
            IEnumerable<Client> client = await _gym.GetAllClients();

            _reservations.Clear();
            _reservations.AddRange(reservations);

            _workers.Clear();
            _workers.AddRange(workers);

            _equipment.Clear();
            _equipment.AddRange(equipment);

            _clients.Clear();
            _clients.AddRange(client);
        }
    }
}
