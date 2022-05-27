using Microsoft.EntityFrameworkCore;
using SilowniaProjektWPF.DAL.ModelsDTO;

namespace SilowniaProjektWPF.DAL.Contexts
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ReservationDTO> Reservations { get; set; }
        public DbSet<WorkerDTO> Workers { get; set; }
        public DbSet<EquipmentDTO> Equipment { get; set; }
        public DbSet<ClientDTO> Clients { get; set; }
        public DbSet<PassDTO> Passes { get; set; }
    }
}
