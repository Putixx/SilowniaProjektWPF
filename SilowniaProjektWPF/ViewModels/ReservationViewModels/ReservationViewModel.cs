using SilowniaProjektWPF.DAL.Models;
using System;

namespace SilowniaProjektWPF.ViewModels
{
    /// <summary>
    /// Reservation view model
    /// </summary>
    public class ReservationViewModel : ViewModelBase
    {
        private readonly Reservation _reservation;

        public string PassNumber => _reservation.PassNumber;
        public string InstructorIndex => _reservation.InstructorIndex;
        public DateTime StartDate => _reservation.StartDate;
        public DateTime EndDate => _reservation.EndDate;

        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }
    }
}
