using Microsoft.EntityFrameworkCore;
using SilowniaProjektWPF.DAL.ModelsDTO;

namespace SilowniaProjektWPF.DAL.Contexts
{
    /// <summary>
    /// Database context
    /// </summary>
    public class GymDbContext : DbContext
    {
        /// <summary>
        /// Init Gym database context
        /// </summary>
        /// <param name="options"> Pass your database context options </param>
        public GymDbContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// Database Set for reservations
        /// </summary>
        public DbSet<ReservationDTO> Reservations { get; set; }

        /// <summary>
        /// Database Set for workers
        /// </summary>
        public DbSet<WorkerDTO> Workers { get; set; }

        /// <summary>
        /// Database Set for equipment
        /// </summary>
        public DbSet<EquipmentDTO> Equipment { get; set; }

        /// <summary>
        /// Database Set for clients
        /// </summary>
        public DbSet<ClientDTO> Clients { get; set; }

        /// <summary>
        /// Database Set for passes
        /// </summary>
        public DbSet<PassDTO> Passes { get; set; }
    }
}
