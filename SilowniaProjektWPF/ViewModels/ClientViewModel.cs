using SilowniaProjektWPF.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.ViewModels
{
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
