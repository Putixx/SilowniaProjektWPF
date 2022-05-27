﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SilowniaProjektWPF.DAL.ModelsDTO
{
    public class PassDTO
    {
        [Key]
        public Guid PassID { get; set; }
        public string PassNumber { get; set; }
        public string PassType { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
