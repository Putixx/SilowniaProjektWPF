using Microsoft.EntityFrameworkCore;

namespace SilowniaProjektWPF.DAL.Contexts
{
    public class GymDbContextFactory
    {
        private readonly string _connectionString;

        public GymDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public GymDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new GymDbContext(options);
        }
    }
}
