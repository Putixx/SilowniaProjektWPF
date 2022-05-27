using SilowniaProjektWPF.Commands;
using SilowniaProjektWPF.Services;
using SilowniaProjektWPF.Stores;
using System;
using System.Windows.Input;

namespace SilowniaProjektWPF.ViewModels
{
    public class MakeClientViewModel : ViewModelBase
    {
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

        private string _passType;
        public string PassType
        {
            get => _passType;
            set
            {
                _passType = value;
                OnPropertyChanged(nameof(PassType));
            }
        }

        private DateTime _purchaseDate = new DateTime(2022, 1, 1);
        public DateTime PurchaseDate
        {
            get => _purchaseDate;
            set
            {
                _purchaseDate = value;
                OnPropertyChanged(nameof(PurchaseDate));
            }
        }

        private DateTime _ExpireDate = new DateTime(2022, 1, 1);
        public DateTime ExpireDate
        {
            get => _ExpireDate;
            set
            {
                _ExpireDate = value;
                OnPropertyChanged(nameof(ExpireDate));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public MakeClientViewModel(GymStore GymStore, NavigationService<ClientListingViewModel> ClientNavigationService)
        {
            SubmitCommand = new MakeClientCommand(this, GymStore, ClientNavigationService);
            CancelCommand = new NavigateCommand<ClientListingViewModel>(ClientNavigationService);
        }
    }
}
