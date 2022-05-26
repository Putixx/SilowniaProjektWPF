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
        private readonly Gym _gym;
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;

        public ICommand NewReservationCommand { get; }
        public ICommand LoadReservationCommand { get; }

        public ReservationListingViewModel(Gym gym, NavigationService ReservationNavigationService)
        {
            _gym = gym;
            _reservations = new ObservableCollection<ReservationViewModel>();

            NewReservationCommand = new NavigateCommand(ReservationNavigationService);
            LoadReservationCommand = new LoadReservationsCommand(gym, this);
        }

        public static ReservationListingViewModel LoadViewModel(Gym gym, NavigationService makeReservationNavigationService)
        {
            ReservationListingViewModel viewModel = new ReservationListingViewModel(gym, makeReservationNavigationService);

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
