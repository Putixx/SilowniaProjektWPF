using SilowniaProjektWPF.Commands;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.Services;
using SilowniaProjektWPF.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SilowniaProjektWPF.ViewModels
{
    public class ClientListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ClientViewModel> _clients;

        public IEnumerable<ClientViewModel> Clients => _clients;

        public ICommand NewClientCommand { get; }
        public ICommand LoadClientCommand { get; }
        public ICommand MenuCommand { get; }

        public ClientListingViewModel(GymStore gymStore, NavigationService<MakeClientViewModel> ClientNavigationService, NavigationService<LoggedAdminViewModel> MenuNavigationService)
        {
            _clients = new ObservableCollection<ClientViewModel>();

            NewClientCommand = new NavigateCommand<MakeClientViewModel>(ClientNavigationService);
            LoadClientCommand = new LoadClientCommand(gymStore, this);
            MenuCommand = new NavigateCommand<LoggedAdminViewModel>(MenuNavigationService);
        }

        public static ClientListingViewModel LoadViewModel(GymStore gymStore, NavigationService<MakeClientViewModel> makeClientNavigationService, NavigationService<LoggedAdminViewModel> MenuNavigationService)
        {
            ClientListingViewModel viewModel = new ClientListingViewModel(gymStore, makeClientNavigationService, MenuNavigationService);

            viewModel.LoadClientCommand.Execute(null);

            return viewModel;
        }

        public void UpdateClients(IEnumerable<Client> clients)
        {
            _clients.Clear();

            foreach (Client client in clients)
            {
                ClientViewModel clientViewModel = new ClientViewModel(client);

                _clients.Add(clientViewModel);
            }
        }
    }
}
