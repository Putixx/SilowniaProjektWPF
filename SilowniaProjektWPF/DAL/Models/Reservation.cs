using System;

namespace SilowniaProjektWPF.DAL.Models
{
    public class Reservation
    {
        public string PassNumber { get; }
        public string InstructorIndex { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public Reservation(string PassNumber, string InstructorIndex, DateTime StartDate, DateTime EndDate)
        {
            this.PassNumber = PassNumber;
            this.InstructorIndex = InstructorIndex;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        public override bool Equals(object obj)
        {
            return obj is Reservation reservation &&
                PassNumber == reservation.PassNumber &&
                InstructorIndex == reservation.InstructorIndex &&
                StartDate == reservation.StartDate &&
                EndDate == reservation.EndDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PassNumber, InstructorIndex, StartDate, EndDate);
        }

        public bool Conflicts(Reservation reservation)
        {
            if (reservation.InstructorIndex != InstructorIndex) return false;

            return reservation.StartDate <= EndDate && reservation.EndDate >= StartDate;
        }

        public static bool operator ==(Reservation r1, Reservation r2)
        {
            if (r1 is null && r2 is null) return true;

            return !(r1 is null) && r1.Equals(r2);
        }
        public static bool operator !=(Reservation r1, Reservation r2) => !(r1 == r2);
    }
}
