﻿using SilowniaProjektWPF.Services;
using SilowniaProjektWPF.ViewModels;

namespace SilowniaProjektWPF.Commands
{
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
