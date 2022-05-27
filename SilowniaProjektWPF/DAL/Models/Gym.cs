﻿using SilowniaProjektWPF.Exceptions;
using SilowniaProjektWPF.Services.EquipmentProviders;
using SilowniaProjektWPF.Services.WorkerProviders;
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
        private readonly IWorkerProvider _workersProvider;
        private readonly IEquipmentProvider _equipmentProvider;
        public string Name { get; }

        public Gym(string Name, ReservationBook reservationBook, IWorkerProvider workersProvider, IEquipmentProvider equipmentProvider)
        {
            this.Name = Name;
            _reservationBook = reservationBook;
            _workersProvider = workersProvider;
            _equipmentProvider = equipmentProvider;
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
    }
}
