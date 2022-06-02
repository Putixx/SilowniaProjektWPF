using SilowniaProjektWPF.DAL.Models;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.ReservationConflictValidators
{
    public interface IReservationConflictValidator
    {
        Task<bool> IsConflictReservation(Reservation reservation);
        Task<bool> IsWorkerExisting(string InstructorIndex);
        Task<bool> IsClientExisting(string PassNumber);
    }
}
