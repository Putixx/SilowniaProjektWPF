﻿using System;

namespace SilowniaProjektWPF.DAL.Models
{
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
    }
}
