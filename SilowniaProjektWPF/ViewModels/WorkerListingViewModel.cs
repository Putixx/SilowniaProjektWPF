using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.Services;
using SilowniaProjektWPF.Stores;
using SilowniaProjektWPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SilowniaProjektWPF.ViewModels
{
    public class WorkerListingViewModel : ViewModelBase
    {
        private readonly GymStore _gymStore;
        private readonly ObservableCollection<WorkerViewModel> _workers;

        public IEnumerable<WorkerViewModel> Workers => _workers;

        public ICommand NewWorkerCommand { get; }
        public ICommand LoadWorkerCommand { get; }

        public WorkerListingViewModel(GymStore gymStore, NavigationService<MakeWorkerViewModel> WorkerNavigationService)
        {
            _gymStore = gymStore;
            _workers = new ObservableCollection<WorkerViewModel>();

            NewWorkerCommand = new NavigateCommand<MakeWorkerViewModel>(WorkerNavigationService);
            LoadWorkerCommand = new LoadWorkersCommand(gymStore, this);
        }

        public static WorkerListingViewModel LoadViewModel(GymStore gymStore, NavigationService<MakeWorkerViewModel> makeWorkerNavigationService)
        {
            WorkerListingViewModel viewModel = new WorkerListingViewModel(gymStore, makeWorkerNavigationService);

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
