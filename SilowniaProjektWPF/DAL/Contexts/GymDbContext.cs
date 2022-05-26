using Microsoft.EntityFrameworkCore;
using SilowniaProjektWPF.DAL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.DAL.Contexts
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ReservationDTO> Reservations { get; set; }
    }
}
