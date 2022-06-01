using SilowniaProjektWPF.DAL.Models;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.ReservationConflictValidators
{
    public interface IReservationConflictValidator
    {
        Task<Reservation> GetConflictReservation(Reservation reservation);
    }
}
