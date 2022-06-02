using SilowniaProjektWPF.Stores;
using SilowniaProjektWPF.ViewModels;
using System;

namespace SilowniaProjektWPF.Services
{
    /// <summary>
    /// Logic for navigation in application 
    /// </summary>
    /// <typeparam name="TViewModel"> Generic param for navigation to make it simpler and in one place </typeparam>
    public class NavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(NavigationStore NavigationStore, Func<TViewModel> CreateViewModel)
        {
            _navigationStore = NavigationStore;
            _createViewModel = CreateViewModel;
        }

        /// <summary>
        /// Navigate to specific View
        /// </summary>
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
