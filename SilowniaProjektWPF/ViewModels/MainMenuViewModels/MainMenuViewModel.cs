using SilowniaProjektWPF.Commands;
using SilowniaProjektWPF.Services;
using System.Windows.Input;

namespace SilowniaProjektWPF.ViewModels
{
    /// <summary>
    /// Main menu view model
    /// </summary>
    public class MainMenuViewModel : ViewModelBase
    {
        public ICommand ManageWorkersCommand { get; }
        public ICommand ManageClientsCommand { get; }
        public ICommand ManageEquipCommand { get; }
        public ICommand ManageReservationsCommand { get; }
        public ICommand QuitCommand { get; }

        public MainMenuViewModel(NavigationService<WorkerListingViewModel> ManageWorkersNavigationService, NavigationService<ClientListingViewModel> ManageClientsNavigationService, NavigationService<EquipListingViewModel> ManageEquipNavigationService, NavigationService<ReservationListingViewModel> ManageReservationsNavigationService)
        {
            ManageWorkersCommand = new NavigateCommand<WorkerListingViewModel>(ManageWorkersNavigationService);
            ManageClientsCommand = new NavigateCommand<ClientListingViewModel>(ManageClientsNavigationService);
            ManageEquipCommand = new NavigateCommand<EquipListingViewModel>(ManageEquipNavigationService);
            ManageReservationsCommand = new NavigateCommand<ReservationListingViewModel>(ManageReservationsNavigationService);
            QuitCommand = new QuitApplicationCommand();
        }
    }
}
