using Microsoft.EntityFrameworkCore;
using SilowniaProjektWPF.DAL.Contexts;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.DAL.ModelsDTO;
using SilowniaProjektWPF.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.EquipmentProviders
{
    /// <summary>
    /// Implementation of equipment provider
    /// </summary>
    public class EquipmentProvider : IEquipmentProvider
    {
        private readonly GymDbContextFactory _dbContextFactory;

        public EquipmentProvider(GymDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Get equipment from database
        /// </summary>
        /// <returns> IEnumerable<Equipment> from database </returns>
        public async Task<IEnumerable<Equipment>> GetEquipment()
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<EquipmentDTO> EquipmentsDTOs = await context.Equipment.ToListAsync();

                return EquipmentsDTOs.Select(e => ToEquipment(e));
            }
        }

        /// <summary>
        /// Create new equipment in database
        /// </summary>
        /// <param name="Equipment"> Equipment to create </param>
        public async Task CreateEquipment(Equipment Equipment)
        {
            Equipment conflictingEquipment = await CheckIfExists(Equipment);

            if (conflictingEquipment != null)
            {
                throw new EquipmentConflictException(conflictingEquipment, Equipment);
            }

            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                EquipmentDTO EquipmentDTO = ToEquipmentDTO(Equipment);

                context.Equipment.Add(EquipmentDTO);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Check if this equipment is already in database
        /// </summary>
        /// <param name="Equipment"> Equipment to check </param>
        /// <returns> Equipment if exists, otherwise null</returns>
        private async Task<Equipment> CheckIfExists(Equipment Equipment)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                EquipmentDTO EquipmentDTO = await context.Equipment.Where(e => e.Name == Equipment.Name).FirstOrDefaultAsync();

                if (EquipmentDTO == null) return null;

                return ToEquipment(EquipmentDTO);
            }
        }

        /// <summary>
        /// Converts equipment model to equipment database transfer object
        /// </summary>
        /// <param name="Equipment"> equipment to convert </param>
        /// <returns> EquipmentDTO </returns>
        private EquipmentDTO ToEquipmentDTO(Equipment Equipment)
        {
            return new EquipmentDTO()
            {
                Name = Equipment.Name,
                Quantity = Equipment.Quantity,
                PurchaseDate = Equipment.PurchaseDate,
                WarrantyExpireDate = Equipment.WarrantyExpireDate
            };
        }

        /// <summary>
        /// Converts equipment database transfer object to equipment model
        /// </summary>
        /// <param name="e"> equipmentDTO to convert </param>
        /// <returns> Equipment </returns>
        private static Equipment ToEquipment(EquipmentDTO e)
        {
            return new Equipment(e.Name, e.Quantity.ToString(), e.PurchaseDate, e.WarrantyExpireDate);
        }
    }
}
