using SilowniaProjektWPF.Services.ClientProviders;
using SilowniaProjektWPF.Services.EquipmentProviders;
using SilowniaProjektWPF.Services.PassProviders;
using SilowniaProjektWPF.Services.WorkerProviders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.DAL.Models
{
    public class Gym
    {
        private readonly ReservationBook _reservationBook;
        private readonly IWorkerProvider _workersProvider;
        private readonly IEquipmentProvider _equipmentProvider;
        private readonly IClientProvider _clientProvider;
        private readonly IPassProvider _passProvider;
        public string Name { get; }

        public Gym(string Name, ReservationBook reservationBook, IWorkerProvider workersProvider, IEquipmentProvider equipmentProvider, IClientProvider clientProvider, IPassProvider passProvider)
        {
            this.Name = Name;
            _reservationBook = reservationBook;
            _workersProvider = workersProvider;
            _equipmentProvider = equipmentProvider;
            _clientProvider = clientProvider;
            _passProvider = passProvider;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _reservationBook.GetReservations();
        }

        public async Task<IEnumerable<Worker>> GetAllWorkers()
        {
            return await _workersProvider.GetWorkers();
        }

        public async Task<IEnumerable<Equipment>> GetAllEquipment()
        {
            return await _equipmentProvider.GetEquipment();
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _clientProvider.GetClients();
        }

        public async Task MakeReservation(Reservation reservation)
        {
            await _reservationBook.AddReservation(reservation);
        }

        public async Task MakeWorker(Worker worker)
        {
            await _workersProvider.CreateWorker(worker);
        }

        public async Task MakeEquipment(Equipment equipment)
        {
            await _equipmentProvider.CreateEquipment(equipment);
        }

        public async Task MakeClient(Client client)
        {
            await _clientProvider.CreateClient(client);
        }

        public async Task MakePass(Pass pass)
        {
            await _passProvider.CreatePass(pass);
        }
    }
}
