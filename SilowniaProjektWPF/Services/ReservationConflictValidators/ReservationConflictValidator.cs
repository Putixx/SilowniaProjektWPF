using Microsoft.EntityFrameworkCore;
using SilowniaProjektWPF.DAL.Contexts;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.DAL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.ReservationConflictValidators
{
    public class ReservationConflictValidator : IReservationConflictValidator
    {
        private readonly GymDbContextFactory _dbContextFactory;

        public ReservationConflictValidator(GymDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Reservation> GetConflictReservation(Reservation reservation)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO = await context.Reservations.Where(r => r.PassNumber == reservation.PassNumber)
                    .Where(r => r.InstructorIndex == reservation.InstructorIndex)
                    .Where(r => r.StartDate <= reservation.EndDate)
                    .Where(r => r.EndDate >= reservation.StartDate)
                    .FirstOrDefaultAsync();

                if (reservationDTO == null) return null;

                return ToReservation(reservationDTO);
            }
        }

        private static Reservation ToReservation(ReservationDTO r)
        {
            return new Reservation(r.PassNumber, r.InstructorIndex, r.StartDate, r.EndDate);
        }
    }
}
