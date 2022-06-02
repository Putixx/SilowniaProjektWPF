using SilowniaProjektWPF.Commands;
using SilowniaProjektWPF.Services;
using System.Windows.Input;

namespace SilowniaProjektWPF.ViewModels
{
    /// <summary>
    /// Starting application view model
    /// </summary>
    public class StartAppViewModel : ViewModelBase
    {
        public ICommand StartCommand { get; }
        public ICommand QuitCommand { get; }

        public StartAppViewModel(NavigationService<MainMenuViewModel> MainMenuNavigationService)
        {
            StartCommand = new NavigateCommand<MainMenuViewModel>(MainMenuNavigationService);
            QuitCommand = new QuitApplicationCommand();
        }
    }
}
