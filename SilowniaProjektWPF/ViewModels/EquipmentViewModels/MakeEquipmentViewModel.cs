using SilowniaProjektWPF.Commands;
using SilowniaProjektWPF.Services;
using SilowniaProjektWPF.Stores;
using System;
using System.Windows.Input;

namespace SilowniaProjektWPF.ViewModels
{
    /// <summary>
    /// Create equipment view model
    /// </summary>
    public class MakeEquipmentViewModel : ViewModelBase
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

        private string _quantity;
        public string Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
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

        private DateTime _warrantyExpireDate = new DateTime(2022, 1, 1);
        public DateTime WarrantyExpireDate
        {
            get => _warrantyExpireDate;
            set
            {
                _warrantyExpireDate = value;
                OnPropertyChanged(nameof(WarrantyExpireDate));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public MakeEquipmentViewModel(GymStore GymStore, NavigationService<EquipListingViewModel> EquipNavigationService)
        {
            SubmitCommand = new MakeEquipCommand(this, GymStore);
            CancelCommand = new NavigateCommand<EquipListingViewModel>(EquipNavigationService);
        }
    }
}
