using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SilowniaProjektWPF.Commands
{
    public class LoadReservationsCommand : AsyncCommandBase
    {
        private readonly Gym _gym;
        private readonly ReservationListingViewModel _viewModel;

        public LoadReservationsCommand(Gym gym, ReservationListingViewModel viewModel)
        {
            _gym = gym;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Reservation> reservations = await _gym.GetAllReservations();

                _viewModel.UpdateReservations(reservations);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load reservations.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
