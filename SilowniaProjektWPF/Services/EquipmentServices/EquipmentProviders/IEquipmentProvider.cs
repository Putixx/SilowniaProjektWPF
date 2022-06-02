using SilowniaProjektWPF.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.EquipmentProviders
{
    /// <summary>
    /// Interface for equipment provider
    /// </summary>
    public interface IEquipmentProvider
    {
        /// <summary>
        /// Get equipment from database
        /// </summary>
        /// <returns> IEnumerable<Equipment> from database </returns>
        Task<IEnumerable<Equipment>> GetEquipment();

        /// <summary>
        /// Create new equipment in database
        /// </summary>
        /// <param name="Equipment"> Equipment to create </param>
        Task CreateEquipment(Equipment Equipment);
    }
}
