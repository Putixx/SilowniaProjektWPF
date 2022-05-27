using SilowniaProjektWPF.Stores;
using SilowniaProjektWPF.ViewModels;
using System;

namespace SilowniaProjektWPF.Services
{
    public class NavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(NavigationStore NavigationStore, Func<TViewModel> CreateViewModel)
        {
            _navigationStore = NavigationStore;
            _createViewModel = CreateViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
