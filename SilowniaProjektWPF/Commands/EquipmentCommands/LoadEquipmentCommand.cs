using SilowniaProjektWPF.Stores;
using SilowniaProjektWPF.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace SilowniaProjektWPF.Commands
{
    public class LoadEquipmentCommand : AsyncCommandBase
    {
        private readonly GymStore _gymStore;
        private readonly EquipListingViewModel _viewModel;

        public LoadEquipmentCommand(GymStore gymStore, EquipListingViewModel viewModel)
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

                _viewModel.UpdateEquipment(_gymStore.Equipment);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load reservations.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            _viewModel.IsLoading = false;
        }
    }
}
