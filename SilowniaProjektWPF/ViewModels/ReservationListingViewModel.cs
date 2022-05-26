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
        private readonly GymStore _gymStore;
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;

        public ICommand NewReservationCommand { get; }
        public ICommand LoadReservationCommand { get; }

        public ReservationListingViewModel(GymStore gymStore, NavigationService ReservationNavigationService)
        {
            _gymStore = gymStore;
            _reservations = new ObservableCollection<ReservationViewModel>();

            NewReservationCommand = new NavigateCommand(ReservationNavigationService);
            LoadReservationCommand = new LoadReservationsCommand(gymStore, this);
        }

        public static ReservationListingViewModel LoadViewModel(GymStore gymStore, NavigationService makeReservationNavigationService)
        {
            ReservationListingViewModel viewModel = new ReservationListingViewModel(gymStore, makeReservationNavigationService);

            viewModel.LoadReservationCommand.Execute(null);

            return viewModel;
        }

        public void UpdateReservations(IEnumerable<Reservation> reservations)
        {
            _reservations.Clear();

            foreach(Reservation reservation in reservations)
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);

                _reservations.Add(reservationViewModel);
            }
        }
    }
}
