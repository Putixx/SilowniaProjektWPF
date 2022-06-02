using System;

namespace SilowniaProjektWPF.DAL.Models
{
    /// <summary>
    /// Model for equipment
    /// </summary>
    public class Equipment
    {
        public string Name { get; }
        public int Quantity { get; }
        public DateTime PurchaseDate { get; }
        public DateTime WarrantyExpireDate { get; }

        public Equipment(string Name, string Quantity, DateTime PurchaseDate, DateTime WarrantyExpireDate)
        {
            this.Name = Name;
            this.Quantity = int.TryParse(Quantity, out int result) ? result : 0;
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

        public static bool operator ==(Equipment e1, Equipment e2)
        {
            if (e1 is null && e2 is null) return true;

            return !(e1 is null) && e1.Equals(e2);
        }
        public static bool operator !=(Equipment e1, Equipment e2) => !(e1 == e2);
    }
}
