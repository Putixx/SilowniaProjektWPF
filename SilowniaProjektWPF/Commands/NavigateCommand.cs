using SilowniaProjektWPF.Services;
using SilowniaProjektWPF.ViewModels;

namespace SilowniaProjektWPF.Commands
{
    /// <summary>
    /// Logic for Navigation buttons
    /// </summary>
    /// <typeparam name="TViewModel"> Generic param for navigation to make it simpler and in one place </typeparam>
    public class NavigateCommand<TViewModel>: CommandBase where TViewModel : ViewModelBase
    {
        private readonly NavigationService<TViewModel> _navigationService;

        public NavigateCommand(NavigationService<TViewModel> NavigationService)
        {
            _navigationService = NavigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
