using SilowniaProjektWPF.Stores;
using SilowniaProjektWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SilowniaProjektWPF.Commands
{
    public class LoadWorkersCommand : AsyncCommandBase
    {
        private readonly GymStore _gymStore;
        private readonly WorkerListingViewModel _viewModel;

        public LoadWorkersCommand(GymStore gymStore, WorkerListingViewModel viewModel)
        {
            _gymStore = gymStore;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _gymStore.Load();

                _viewModel.UpdateWorkers(_gymStore.Workers);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load workers.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
