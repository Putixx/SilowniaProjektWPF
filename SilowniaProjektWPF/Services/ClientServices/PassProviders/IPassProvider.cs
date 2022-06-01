using SilowniaProjektWPF.DAL.Models;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.PassProviders
{
    public interface IPassProvider
    {
        Task CreatePass(Pass pass);
    }
}
