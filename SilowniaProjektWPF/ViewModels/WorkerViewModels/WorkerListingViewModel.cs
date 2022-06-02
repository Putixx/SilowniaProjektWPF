using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.Services;
using SilowniaProjektWPF.Stores;
using SilowniaProjektWPF.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SilowniaProjektWPF.ViewModels
{
    /// <summary>
    /// Worker listing view model
    /// </summary>
    public class WorkerListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<WorkerViewModel> _workers;

        public IEnumerable<WorkerViewModel> Workers => _workers;

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ICommand NewWorkerCommand { get; }
        public ICommand LoadWorkerCommand { get; }
        public ICommand MenuCommand { get; }

        public WorkerListingViewModel(GymStore gymStore, NavigationService<MakeWorkerViewModel> WorkerNavigationService, NavigationService<MainMenuViewModel> MenuNavigationService)
        {
            _workers = new ObservableCollection<WorkerViewModel>();

            NewWorkerCommand = new NavigateCommand<MakeWorkerViewModel>(WorkerNavigationService);
            LoadWorkerCommand = new LoadWorkersCommand(gymStore, this);
            MenuCommand = new NavigateCommand<MainMenuViewModel>(MenuNavigationService);
        }

        public static WorkerListingViewModel LoadViewModel(GymStore gymStore, NavigationService<MakeWorkerViewModel> makeWorkerNavigationService, NavigationService<MainMenuViewModel> MenuNavigationService)
        {
            WorkerListingViewModel viewModel = new WorkerListingViewModel(gymStore, makeWorkerNavigationService, MenuNavigationService);

            viewModel.LoadWorkerCommand.Execute(null);

            return viewModel;
        }

        public void UpdateWorkers(IEnumerable<Worker> workers)
        {
            _workers.Clear();

            foreach (Worker worker in workers)
            {
                WorkerViewModel reservationViewModel = new WorkerViewModel(worker);

                _workers.Add(reservationViewModel);
            }
        }
    }
}
