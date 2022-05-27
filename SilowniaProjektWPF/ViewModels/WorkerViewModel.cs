using SilowniaProjektWPF.DAL.Models;

namespace SilowniaProjektWPF.ViewModels
{
    public class WorkerViewModel : ViewModelBase
    {
        private readonly Worker _workers;

        public string Name => _workers.Name;
        public string Surname => _workers.Surname;
        public string PhoneNumber => _workers.PhoneNumber;

        public WorkerViewModel(Worker worker)
        {
            _workers = worker;
        }
    }
}
