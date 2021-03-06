using SilowniaProjektWPF.Stores;

namespace SilowniaProjektWPF.ViewModels
{
    /// <summary>
    /// Main view model
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore NavigationStore)
        {
            _navigationStore = NavigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
