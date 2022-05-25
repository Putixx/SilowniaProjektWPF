using SilowniaProjektWPF.Commands;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.Services;
using SilowniaProjektWPF.Stores;
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

        public ICommand NewReservationCommand { get; }

        public ReservationListingViewModel(NavigationService ReservationNavigationService)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();

            NewReservationCommand = new NavigateCommand(ReservationNavigationService);


            _reservations.Add(new ReservationViewModel(new Reservation("123", "D25", DateTime.Now, DateTime.Now)));
            _reservations.Add(new ReservationViewModel(new Reservation("12", "D253", DateTime.Now, DateTime.Now)));
            _reservations.Add(new ReservationViewModel(new Reservation("32", "D225", DateTime.Now, DateTime.Now)));
        }
    }
}
