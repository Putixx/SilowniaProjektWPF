using SilowniaProjektWPF.DAL.Models;
using System;

namespace SilowniaProjektWPF.ViewModels
{
    /// <summary>
    /// Equipment view model
    /// </summary>
    public class EquipmentViewModel : ViewModelBase
    {
        private readonly Equipment _equipment;

        public string Name => _equipment.Name;
        public string Quantity => _equipment.Quantity.ToString();
        public DateTime PurchaseDate => _equipment.PurchaseDate;
        public DateTime WarrantyExpireDate => _equipment.WarrantyExpireDate;

        public EquipmentViewModel(Equipment equipment)
        {
            _equipment = equipment;
        }
    }
}
