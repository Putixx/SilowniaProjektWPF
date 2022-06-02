using System;
using System.ComponentModel.DataAnnotations;

namespace SilowniaProjektWPF.DAL.ModelsDTO
{
    /// <summary>
    /// Database transfer model for worker
    /// </summary>
    public class WorkerDTO
    {
        [Key]
        public Guid WorkerID { get; set; }
        public string InstructorIndex { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialization { get; set; }
        public string HourlyCost { get; set; }
    }
}
