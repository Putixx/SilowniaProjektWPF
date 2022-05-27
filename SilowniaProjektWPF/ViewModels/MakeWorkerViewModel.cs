using SilowniaProjektWPF.Commands;
using SilowniaProjektWPF.Services;
using SilowniaProjektWPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SilowniaProjektWPF.ViewModels
{
    public class MakeWorkerViewModel : ViewModelBase
    {
        private string _instructorIndex;
        public string InstructorIndex
        {
            get => _instructorIndex;
            set
            {
                _instructorIndex = value;
                OnPropertyChanged(nameof(InstructorIndex));
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        private string _specialization;
        public string Specialization
        {
            get => _specialization;
            set
            {
                _specialization = value;
                OnPropertyChanged(nameof(Specialization));
            }
        }

        private string _hourlyCost;
        public string HourlyCost
        {
            get => _hourlyCost;
            set
            {
                _hourlyCost = value;
                OnPropertyChanged(nameof(HourlyCost));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public MakeWorkerViewModel(GymStore GymStore, NavigationService<WorkerListingViewModel> WorkerNavigationService)
        {
            SubmitCommand = new MakeWorkerCommand(this, GymStore, WorkerNavigationService);
            CancelCommand = new NavigateCommand<WorkerListingViewModel>(WorkerNavigationService);
        }
    }
}
