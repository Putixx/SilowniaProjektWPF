using SilowniaProjektWPF.Commands;
using SilowniaProjektWPF.DAL.Models;
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
    public class MakeReservationViewModel : ViewModelBase
    {
        private string _passNumber;
        public string PassNumber
        {
            get => _passNumber;
            set
            {
                _passNumber = value;
                OnPropertyChanged(nameof(PassNumber));
            }
        }

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

        private DateTime _startDate = new DateTime(2022, 1, 1);
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime _endDate = new DateTime(2022, 1, 1);
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public MakeReservationViewModel(GymStore GymStore, NavigationService ReservationNavigationService) 
        {
            SubmitCommand = new MakeReservationCommand(this, GymStore, ReservationNavigationService);
            CancelCommand = new NavigateCommand(ReservationNavigationService);
        }
    }
}
