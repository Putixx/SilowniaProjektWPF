using SilowniaProjektWPF.Commands;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.Services;
using SilowniaProjektWPF.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SilowniaProjektWPF.ViewModels
{
    /// <summary>
    /// Equipment listing view model
    /// </summary>
    public class EquipListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<EquipmentViewModel> _equipment;

        public IEnumerable<EquipmentViewModel> Equipment => _equipment;

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

        public ICommand NewEquipmentCommand { get; }
        public ICommand LoadEquipmentCommand { get; }
        public ICommand MenuCommand { get; }

        public EquipListingViewModel(GymStore gymStore, NavigationService<MakeEquipmentViewModel> EquipmentNavigationService, NavigationService<MainMenuViewModel> MenuNavigationService)
        {
            _equipment = new ObservableCollection<EquipmentViewModel>();

            NewEquipmentCommand = new NavigateCommand<MakeEquipmentViewModel>(EquipmentNavigationService);
            LoadEquipmentCommand = new LoadEquipmentCommand(gymStore, this);
            MenuCommand = new NavigateCommand<MainMenuViewModel>(MenuNavigationService);
        }

        public static EquipListingViewModel LoadViewModel(GymStore gymStore, NavigationService<MakeEquipmentViewModel> makeEquipmentNavigationService, NavigationService<MainMenuViewModel> MenuNavigationService)
        {
            EquipListingViewModel viewModel = new EquipListingViewModel(gymStore, makeEquipmentNavigationService, MenuNavigationService);

            viewModel.LoadEquipmentCommand.Execute(null);

            return viewModel;
        }

        public void UpdateEquipment(IEnumerable<Equipment> equipment)
        {
            _equipment.Clear();

            foreach (Equipment equip in equipment)
            {
                EquipmentViewModel equipViewModel = new EquipmentViewModel(equip);

                _equipment.Add(equipViewModel);
            }
        }
    }
}
