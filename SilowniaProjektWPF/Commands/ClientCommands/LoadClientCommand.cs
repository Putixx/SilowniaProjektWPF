using SilowniaProjektWPF.Stores;
using SilowniaProjektWPF.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace SilowniaProjektWPF.Commands
{
    /// <summary>
    /// Logic for button that load actual clients from database
    /// </summary>
    public class LoadClientCommand : AsyncCommandBase
    {
        private readonly GymStore _gymStore;
        private readonly ClientListingViewModel _viewModel;

        public LoadClientCommand(GymStore gymStore, ClientListingViewModel viewModel)
        {
            _gymStore = gymStore;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.IsLoading = true;

            try
            {
                await _gymStore.Load();

                _viewModel.UpdateClients(_gymStore.Clients);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load reservations.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            _viewModel.IsLoading = false;
        }
    }
}
