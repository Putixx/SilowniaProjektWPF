using SilowniaProjektWPF.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.ReservationProviders
{
    /// <summary>
    /// Interface for reservation provider
    /// </summary>
    public interface IReservationProvider
    {
        /// <summary>
        /// Get all reservations from database
        /// </summary>
        /// <returns> IEnumerable<Reservation> from database </returns>
        Task<IEnumerable<Reservation>> GetAllReservations();
    }
}
