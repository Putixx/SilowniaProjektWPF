using SilowniaProjektWPF.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.EquipmentProviders
{
    public interface IEquipmentProvider
    {
        Task<IEnumerable<Equipment>> GetEquipment();
        Task CreateEquipment(Equipment equipment);
    }
}
