using System;

namespace SilowniaProjektWPF.DAL.Models
{
    public class Rezervation
    {
        public string PassNumber { get; }
        public Instructor Instructor { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public Rezervation(string PassNumber, Instructor Instructor, DateTime StartDate, DateTime EndDate)
        {
            this.PassNumber = PassNumber;
            this.Instructor = Instructor;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        public override bool Equals(object obj)
        {
            return obj is Rezervation rezervation &&
                PassNumber == rezervation.PassNumber &&
                Instructor == rezervation.Instructor &&
                StartDate == rezervation.StartDate &&
                EndDate == rezervation.EndDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PassNumber, Instructor, StartDate, EndDate);
        }
    }
}
