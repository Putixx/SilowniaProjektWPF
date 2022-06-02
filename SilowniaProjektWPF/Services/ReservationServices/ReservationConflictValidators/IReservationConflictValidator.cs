using SilowniaProjektWPF.DAL.Models;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.ReservationConflictValidators
{
    /// <summary>
    /// Interface for conflict validator
    /// </summary>
    public interface IReservationConflictValidator
    {
        /// <summary>
        /// Checks if there is conflicting reservation
        /// </summary>
        /// <param name="reservation"> Reservation to check </param>
        /// <returns> true if there is conflicting reservation and false when there is not any conflicting reservation </returns>
        Task<bool> IsConflictReservation(Reservation reservation);

        /// <summary>
        /// Checks if worker is existing
        /// </summary>
        /// <param name="InstructorIndex"> Instructor index for worker reservation </param>
        /// <returns> true if worker exist and false if not </returns>
        Task<bool> IsWorkerExisting(string InstructorIndex);

        /// <summary>
        /// Checks if client is existing
        /// </summary>
        /// <param name="PassNumber"> Pass number for client reservation </param>
        /// <returns> true if client exist and false if not </returns>
        Task<bool> IsClientExisting(string PassNumber);
    }
}
