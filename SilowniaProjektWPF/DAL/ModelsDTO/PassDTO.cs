using System;
using System.ComponentModel.DataAnnotations;

namespace SilowniaProjektWPF.DAL.ModelsDTO
{
    /// <summary>
    /// Database transfer model for pass
    /// </summary>
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
