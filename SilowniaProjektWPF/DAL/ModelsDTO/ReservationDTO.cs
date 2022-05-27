using System;
using System.ComponentModel.DataAnnotations;

namespace SilowniaProjektWPF.DAL.ModelsDTO
{
    public class ReservationDTO
    {
        [Key]
        public Guid ReservationID { get; set; }
        public string PassNumber { get; set; }
        public string InstructorIndex { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
