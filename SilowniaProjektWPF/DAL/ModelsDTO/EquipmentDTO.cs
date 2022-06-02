using System;
using System.ComponentModel.DataAnnotations;

namespace SilowniaProjektWPF.DAL.ModelsDTO
{
    /// <summary>
    /// Database transfer model for equipment
    /// </summary>
    public class EquipmentDTO
    {
        [Key]
        public Guid EquipmentID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyExpireDate { get; set; }
    }
}
