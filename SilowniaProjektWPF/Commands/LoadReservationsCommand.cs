using SilowniaProjektWPF.Stores;
using SilowniaProjektWPF.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace SilowniaProjektWPF.Commands
{
    public class LoadReservationsCommand : AsyncCommandBase
    {
        private readonly GymStore _gymStore;
        private readonly ReservationListingViewModel _viewModel;

        public LoadReservationsCommand(GymStore gymStore, ReservationListingViewModel viewModel)
        {
            _gymStore = gymStore;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _gymStore.Load();

                _viewModel.UpdateReservations(_gymStore.Reservations);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load reservations.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
