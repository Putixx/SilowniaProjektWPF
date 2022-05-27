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
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginAdminCommand { get; }
        public ICommand LoginWorkerCommand { get; }

        public LoginViewModel(NavigationService<LoggedWorkerViewModel> LoggedWorkerNavigationService, NavigationService<LoggedAdminViewModel> LoggedAdminNavigationService)
        {
            LoginAdminCommand = new NavigateCommand<LoggedAdminViewModel>(LoggedAdminNavigationService);
            LoginWorkerCommand = new NavigateCommand<LoggedWorkerViewModel>(LoggedWorkerNavigationService);
        }
    }
}
