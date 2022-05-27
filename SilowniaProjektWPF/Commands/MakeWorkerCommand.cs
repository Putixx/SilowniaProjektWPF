using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.Exceptions;
using SilowniaProjektWPF.Services;
using SilowniaProjektWPF.Stores;
using SilowniaProjektWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SilowniaProjektWPF.Commands
{
    public class MakeWorkerCommand : AsyncCommandBase
    {
        private readonly MakeWorkerViewModel _makeWorkerViewModel;
        private readonly GymStore _gymStore;
        private readonly NavigationService<WorkerListingViewModel> _workerNavigationService;

        public MakeWorkerCommand(MakeWorkerViewModel MakeWorkerViewModel, GymStore GymStore, NavigationService<WorkerListingViewModel> WorkerNavigationService)
        {
            _makeWorkerViewModel = MakeWorkerViewModel;
            _gymStore = GymStore;
            _workerNavigationService = WorkerNavigationService;

            _makeWorkerViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makeWorkerViewModel.Name) && !string.IsNullOrEmpty(_makeWorkerViewModel.Surname) && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Worker worker = new Worker(
                _makeWorkerViewModel.InstructorIndex,
                _makeWorkerViewModel.Name,
                _makeWorkerViewModel.Surname,
                _makeWorkerViewModel.PhoneNumber,
                _makeWorkerViewModel.Specialization,
                _makeWorkerViewModel.HourlyCost
                );

            try
            {
                await _gymStore.MakeWorker(worker);
                MessageBox.Show("Successfuly added new worker.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (WorkerConflictException)
            {
                MessageBox.Show("This worker already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (WorkerExistingNumberException)
            {
                MessageBox.Show("Number already registered for existing worker.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to add new worker.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeWorkerViewModel.Name) ||
                e.PropertyName == nameof(MakeWorkerViewModel.Surname))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
