using Microsoft.EntityFrameworkCore;
using SilowniaProjektWPF.DAL.Contexts;
using SilowniaProjektWPF.DAL.Models;
using SilowniaProjektWPF.DAL.ModelsDTO;
using SilowniaProjektWPF.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Services.EquipmentProviders
{
    public class EquipmentProvider : IEquipmentProvider
    {
        private readonly GymDbContextFactory _dbContextFactory;

        public EquipmentProvider(GymDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Equipment>> GetEquipment()
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<EquipmentDTO> EquipmentsDTOs = await context.Equipment.ToListAsync();

                return EquipmentsDTOs.Select(e => ToEquipment(e));
            }
        }

        private static Equipment ToEquipment(EquipmentDTO e)
        {
            return new Equipment(e.Name, e.Quantity.ToString(), e.PurchaseDate, e.WarrantyExpireDate);
        }

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

        private async Task<Equipment> CheckIfExists(Equipment Equipment)
        {
            using (GymDbContext context = _dbContextFactory.CreateDbContext())
            {
                EquipmentDTO EquipmentDTO = await context.Equipment.Where(e => e.Name == Equipment.Name).FirstOrDefaultAsync();

                if (EquipmentDTO == null) return null;

                return ToEquipment(EquipmentDTO);
            }
        }
    }
}
