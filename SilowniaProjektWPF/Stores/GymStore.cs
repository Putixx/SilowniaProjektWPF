using SilowniaProjektWPF.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Stores
{
    /// <summary>
    /// Gym store 
    /// </summary>
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

        /// <summary>
        /// Load data from database
        /// </summary>
        public async Task Load()
        {
            await _initializeLazy.Value;
        }

        /// <summary>
        /// Make new reservation
        /// </summary>
        /// <param name="reservation"> reservation to make </param>
        public async Task MakeReservation(Reservation reservation)
        {
            await _gym.MakeReservation(reservation);

            _reservations.Add(reservation);
        }

        /// <summary>
        /// Add new worker
        /// </summary>
        /// <param name="worker"> worker to add </param>
        public async Task MakeWorker(Worker worker)
        {
            await _gym.MakeWorker(worker);

            _workers.Add(worker);
        }

        /// <summary>
        /// Add new equipment
        /// </summary>
        /// <param name="equipment"> equipment to add </param>
        public async Task MakeEquipment(Equipment equipment)
        {
            await _gym.MakeEquipment(equipment);

            _equipment.Add(equipment);
        }

        /// <summary>
        /// Add new client
        /// </summary>
        /// <param name="client"> client to add </param>
        public async Task MakeClient(Client client)
        {
            await _gym.MakeClient(client);

            _clients.Add(client);
        }

        /// <summary>
        /// Add new pass
        /// </summary>
        /// <param name="pass"> pass to add </param>
        public async Task MakePass(Pass pass)
        {
            await _gym.MakePass(pass);
        }

        /// <summary>
        /// Initalize data from database
        /// </summary>
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
