using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilowniaProjektWPF.DAL.ModelsDTO
{
    /// <summary>
    /// Database transfer model for client
    /// </summary>
    public class ClientDTO
    {
        [Key]
        public Guid ClientID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey("PassDTO")]
        public string PassNumber { get; set; }
    }
}
