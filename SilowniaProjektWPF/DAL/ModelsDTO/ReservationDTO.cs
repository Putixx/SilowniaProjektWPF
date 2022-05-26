using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
