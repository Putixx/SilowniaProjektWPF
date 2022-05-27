﻿using SilowniaProjektWPF.Commands;
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
        public ICommand LoadReservationCommand { get; }
        public ICommand MenuCommand { get; }

        public ReservationListingViewModel(GymStore gymStore, NavigationService<MakeReservationViewModel> ReservationNavigationService, NavigationService<LoggedAdminViewModel> MenuNavigationService)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();

            NewReservationCommand = new NavigateCommand<MakeReservationViewModel>(ReservationNavigationService);
            LoadReservationCommand = new LoadReservationsCommand(gymStore, this);
            MenuCommand = new NavigateCommand<LoggedAdminViewModel>(MenuNavigationService);
        }

        public static ReservationListingViewModel LoadViewModel(GymStore gymStore, NavigationService<MakeReservationViewModel> makeReservationNavigationService, NavigationService<LoggedAdminViewModel> MenuNavigationService)
        {
            ReservationListingViewModel viewModel = new ReservationListingViewModel(gymStore, makeReservationNavigationService, MenuNavigationService);

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
