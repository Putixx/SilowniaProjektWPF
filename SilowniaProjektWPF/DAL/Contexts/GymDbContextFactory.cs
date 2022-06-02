using Microsoft.EntityFrameworkCore;

namespace SilowniaProjektWPF.DAL.Contexts
{
    /// <summary>
    /// Database context factory
    /// </summary>
    public class GymDbContextFactory
    {
        private readonly string _connectionString;

        /// <summary>
        /// Create new database context factory
        /// </summary>
        /// <param name="connectionString"> Connection string example : "Data Source=database.db" </param>
        public GymDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Create new database context
        /// </summary>
        /// <returns> New database context </returns>
        public GymDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new GymDbContext(options);
        }
    }
}
