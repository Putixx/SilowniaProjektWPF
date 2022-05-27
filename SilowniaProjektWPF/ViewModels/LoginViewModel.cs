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
        public ICommand StartCommand { get; }

        public LoginViewModel(NavigationService<LoggedAdminViewModel> LoggedAdminNavigationService)
        {
            StartCommand = new NavigateCommand<LoggedAdminViewModel>(LoggedAdminNavigationService);
        }
    }
}
