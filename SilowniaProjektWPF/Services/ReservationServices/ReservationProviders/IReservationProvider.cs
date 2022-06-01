using SilowniaProjektWPF.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.ReservationProviders
{
    public interface IReservationProvider
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
    }
}
