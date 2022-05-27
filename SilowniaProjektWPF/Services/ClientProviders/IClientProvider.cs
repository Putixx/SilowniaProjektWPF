using SilowniaProjektWPF.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.ClientProviders
{
    public interface IClientProvider
    {
        Task<IEnumerable<Client>> GetClients();
        Task CreateClient(Client client);
    }
}
