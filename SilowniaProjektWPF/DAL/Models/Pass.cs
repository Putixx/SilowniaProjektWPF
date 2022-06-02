using System;

namespace SilowniaProjektWPF.DAL.Models
{
    /// <summary>
    /// Model for pass
    /// </summary>
    public class Pass
    {
        public string PassNumber { get; }
        public string PassType { get; }
        public DateTime PurchaseDate { get; }
        public DateTime ExpireDate { get; }

        public Pass(string PassNumber, string PassType, DateTime PurchaseDate, DateTime ExpireDate)
        {
            this.PassNumber = PassNumber;
            this.PassType = PassType;
            this.PurchaseDate = PurchaseDate;
            this.ExpireDate = ExpireDate;
        }

        public override bool Equals(object obj)
        {
            return obj is Pass pass &&
                PassNumber == pass.PassNumber &&
                PassType == pass.PassType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PassNumber, PassType);
        }

        public static bool operator ==(Pass p1, Pass p2)
        {
            if (p1 is null && p2 is null) return true;

            return !(p1 is null) && p1.Equals(p2);
        }
        public static bool operator !=(Pass p1, Pass p2) => !(p1 == p2);
    }
}
