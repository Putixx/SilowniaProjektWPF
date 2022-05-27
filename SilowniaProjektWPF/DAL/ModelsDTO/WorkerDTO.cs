using System;
using System.ComponentModel.DataAnnotations;

namespace SilowniaProjektWPF.DAL.ModelsDTO
{
    public class WorkerDTO
    {
        [Key]
        public Guid WorkerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }
}
