using SilowniaProjektWPF.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SilowniaProjektWPF.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;

        public ICommand BackCommand { get; }

        public ReservationListingViewModel()
        {
            _reservations = new ObservableCollection<ReservationViewModel>();

            _reservations.Add(new ReservationViewModel(new Reservation("123", "D25", DateTime.Now, DateTime.Now)));
            _reservations.Add(new ReservationViewModel(new Reservation("12", "D253", DateTime.Now, DateTime.Now)));
            _reservations.Add(new ReservationViewModel(new Reservation("32", "D225", DateTime.Now, DateTime.Now)));
        }
    }
}
