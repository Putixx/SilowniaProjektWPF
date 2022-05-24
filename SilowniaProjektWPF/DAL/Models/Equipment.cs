using System;

namespace SilowniaProjektWPF.DAL.Models
{
    public class Equipment
    {
        public string Name { get; }
        public int Quantity { get; }
        public DateTime PurchaseDate { get; }
        public DateTime WarrantyExpireDate { get; }

        public Equipment(string Name, int Quantity, DateTime PurchaseDate, DateTime WarrantyExpireDate)
        {
            this.Name = Name;
            this.Quantity = Quantity;
            this.PurchaseDate = PurchaseDate;
            this.WarrantyExpireDate = WarrantyExpireDate;
        }

        public override bool Equals(object obj)
        {
            return obj is Equipment equip &&
                Name == equip.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
