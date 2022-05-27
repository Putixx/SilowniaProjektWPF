using SilowniaProjektWPF.Commands;
using SilowniaProjektWPF.Services;
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
