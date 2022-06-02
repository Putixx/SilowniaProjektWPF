using SilowniaProjektWPF.DAL.Models;

namespace SilowniaProjektWPF.ViewModels
{
    /// <summary>
    /// Client view model
    /// </summary>
    public class ClientViewModel : ViewModelBase
    {
        private readonly Client _client;

        public string Name => _client.Name;
        public string Surname => _client.Surname;
        public string PhoneNumber => _client.PhoneNumber;
        public string PassNumber => _client.PassNumber;

        public ClientViewModel(Client client)
        {
            _client = client;
        }
    }
}
