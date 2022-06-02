using SilowniaProjektWPF.DAL.Models;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.ReservationCreators
{
    /// <summary>
    /// Interface for reservation creator
    /// </summary>
    public interface IReservationCreator
    {
        /// <summary>
        /// Create new reservation
        /// </summary>
        /// <param name="reservation"> New reservation to create </param>
        Task CreateReservation(Reservation reservation);
    }
}
