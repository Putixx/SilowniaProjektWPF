using SilowniaProjektWPF.DAL.Models;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.PassProviders
{
    /// <summary>
    /// Interface for pass provider
    /// </summary>
    public interface IPassProvider
    {
        /// <summary>
        /// Create new pass
        /// </summary>
        /// <param name="pass"> pass to create </param>
        Task CreatePass(Pass pass);
    }
}
