using SilowniaProjektWPF.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.ClientProviders
{
    /// <summary>
    /// Interface for client provider
    /// </summary>
    public interface IClientProvider
    {
        /// <summary>
        /// Get all clients from database
        /// </summary>
        /// <returns> IEnumerable<Client> from database </returns>
        Task<IEnumerable<Client>> GetClients();

        /// <summary>
        /// Create new client
        /// </summary>
        /// <param name="client"> client to create </param>
        Task CreateClient(Client client);
    }
}
