using Microsoft.EntityFrameworkCore;
using SilowniaProjektWPF.DAL.Contexts;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.DAL.ModelsDTO;
using SilowniaProjektWPF.Exceptions;
using System.Linq;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.PassProviders
{
    /// <summary>
    /// Implementation of pass provider
    /// </summary>
    public class PassProvider : IPassProvider
    {
        private readonly GymDbContextFactory _dbContextFactory;

        public PassProvider(GymDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Create new pass
        /// </summary>
        /// <param name="Pass"> pass to create </param>
        public async Task CreatePass(Pass Pass)
        {
            Pass conflictingPass = await CheckIfExists(Pass);

            if (conflictingPass != null)
            {
                throw new PassConflictException(conflictingPass, Pass);
            }

            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                PassDTO PassDTO = ToPassDTO(Pass);

                context.Passes.Add(PassDTO);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Checks if pass already exists
        /// </summary>
        /// <param name="Pass"> pass to check </param>
        /// <returns> pass if exists, otherwise null </returns>
        private async Task<Pass> CheckIfExists(Pass Pass)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                PassDTO PassDTO = await context.Passes.Where(p => p.PassNumber == Pass.PassNumber).FirstOrDefaultAsync();

                if (PassDTO == null) return null;

                return ToPass(PassDTO);
            }
        }

        /// <summary>
        /// Converts pass database transfer object to pass model
        /// </summary>
        /// <param name="p"> passDTO to transfer </param>
        /// <returns> Pass </returns>
        private static Pass ToPass(PassDTO p)
        {
            return new Pass(p.PassNumber, p.PassType, p.PurchaseDate, p.ExpireDate);
        }

        /// <summary>
        /// Converts pass model to pass database transfer object
        /// </summary>
        /// <param name="Pass"> pass to transfer </param>
        /// <returns> PassDTO </returns>
        private PassDTO ToPassDTO(Pass Pass)
        {
            return new PassDTO()
            {
                PassNumber = Pass.PassNumber,
                PassType = Pass.PassType,
                PurchaseDate = Pass.PurchaseDate,
                ExpireDate = Pass.ExpireDate
            };
        }
    }
}
