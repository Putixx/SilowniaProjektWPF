using SilowniaProjektWPF.DAL.Models;

namespace SilowniaProjektWPF.ViewModels
{
    public class WorkerViewModel : ViewModelBase
    {
        private readonly Worker _workers;

        public string InstructorIndex => _workers.InstructorIndex;
        public string Name => _workers.Name;
        public string Surname => _workers.Surname;
        public string PhoneNumber => _workers.PhoneNumber;
        public string Specialization => _workers.Specialization;
        public decimal HourlyCost => _workers.HourlyCost;

        public WorkerViewModel(Worker worker)
        {
            _workers = worker;
        }
    }
}
