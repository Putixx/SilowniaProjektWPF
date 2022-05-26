using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
