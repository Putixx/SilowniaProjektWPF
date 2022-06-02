using SilowniaProjektWPF.Services.ClientProviders;
using SilowniaProjektWPF.Services.EquipmentProviders;
using SilowniaProjektWPF.Services.PassProviders;
using SilowniaProjektWPF.Services.WorkerProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.DAL.Models
{
    /// <summary>
    /// Model for gym
    /// </summary>
    public class Gym
    {
        private readonly ReservationBook _reservationBook;
        private readonly IWorkerProvider _workersProvider;
        private readonly IEquipmentProvider _equipmentProvider;
        private readonly IClientProvider _clientProvider;
        private readonly IPassProvider _passProvider;
        public string Name { get; }

        /// <summary>
        /// Model for gym
        /// </summary>
        /// <param name="Name"> Name of gym </param>
        /// <param name="reservationBook"> Reservation book </param>
        /// <param name="workersProvider"> Implementation of work provider </param>
        /// <param name="equipmentProvider"> Implementation of equipment provider</param>
        /// <param name="clientProvider"> Implementation of client provider</param>
        /// <param name="passProvider"> Implementation of pass provider</param>
        public Gym(string Name, ReservationBook reservationBook, IWorkerProvider workersProvider, IEquipmentProvider equipmentProvider, IClientProvider clientProvider, IPassProvider passProvider)
        {
            this.Name = Name;
            _reservationBook = reservationBook;
            _workersProvider = workersProvider;
            _equipmentProvider = equipmentProvider;
            _clientProvider = clientProvider;
            _passProvider = passProvider;
        }

        /// <summary>
        /// Get all reservations from database
        /// </summary>
        /// <returns> IEnumerable<Reservation> from database </returns>
        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _reservationBook.GetReservations();
        }

        /// <summary>
        /// Get all workers from database
        /// </summary>
        /// <returns> IEnumerable<Worker> from database </returns>
        public async Task<IEnumerable<Worker>> GetAllWorkers()
        {
            return await _workersProvider.GetWorkers();
        }

        /// <summary>
        /// Get all equipment from database
        /// </summary>
        /// <returns> IEnumerable<Equipment> from database </returns>
        public async Task<IEnumerable<Equipment>> GetAllEquipment()
        {
            return await _equipmentProvider.GetEquipment();
        }

        /// <summary>
        /// Get all clients from database
        /// </summary>
        /// <returns> IEnumerable<Client> from database </returns>
        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _clientProvider.GetClients();
        }

        /// <summary>
        /// Make new reservation
        /// </summary>
        /// <param name="reservation"> Reservation to add </param>
        public async Task MakeReservation(Reservation reservation)
        {
            await _reservationBook.AddReservation(reservation);
        }

        /// <summary>
        /// Add new worker
        /// </summary>
        /// <param name="worker"> Worker to add </param>
        public async Task MakeWorker(Worker worker)
        {
            await _workersProvider.CreateWorker(worker);
        }

        /// <summary>
        /// Add new equipment
        /// </summary>
        /// <param name="equipment"> Equipment to add </param>
        public async Task MakeEquipment(Equipment equipment)
        {
            await _equipmentProvider.CreateEquipment(equipment);
        }

        /// <summary>
        /// Add new client
        /// </summary>
        /// <param name="client"> Client to add </param>
        public async Task MakeClient(Client client)
        {
            await _clientProvider.CreateClient(client);
        }

        /// <summary>
        /// Add new pass
        /// </summary>
        /// <param name="pass"> Pass to add </param>
        public async Task MakePass(Pass pass)
        {
            await _passProvider.CreatePass(pass);
        }
    }
}
