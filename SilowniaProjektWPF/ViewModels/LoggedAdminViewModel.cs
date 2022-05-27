using SilowniaProjektWPF.Commands;
using SilowniaProjektWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SilowniaProjektWPF.ViewModels
{
    public class LoggedAdminViewModel : ViewModelBase
    {
        public ICommand ManageWorkersCommand { get; }
        public ICommand ManageClientsCommand { get; }
        public ICommand ManageEquipCommand { get; }
        public ICommand ManageReservationsCommand { get; }

        public LoggedAdminViewModel(NavigationService<WorkerListingViewModel> ManageWorkersNavigationService, NavigationService<ClientListingViewModel> ManageClientsNavigationService, NavigationService<EquipListingViewModel> ManageEquipNavigationService, NavigationService<ReservationListingViewModel> ManageReservationsNavigationService)
        {
            ManageWorkersCommand = new NavigateCommand<WorkerListingViewModel>(ManageWorkersNavigationService);
            ManageClientsCommand = new NavigateCommand<ClientListingViewModel>(ManageClientsNavigationService);
            ManageEquipCommand = new NavigateCommand<EquipListingViewModel>(ManageEquipNavigationService);
            ManageReservationsCommand = new NavigateCommand<ReservationListingViewModel>(ManageReservationsNavigationService);
        }
    }
}
