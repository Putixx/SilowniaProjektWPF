
using System;

namespace SilowniaProjektWPF.DAL.Models
{
    public class Worker
    {
        public string InstructorIndex { get; }
        public string Name { get; }
        public string Surname { get; }
        public string PhoneNumber { get; }
        public string Specialization { get; }
        public decimal HourlyCost { get; }

        public Worker(string InstructorIndex, string Name, string Surname, string PhoneNumber, string Specialization, string HourlyCost)
        {
            this.InstructorIndex = InstructorIndex;
            this.Name = Name;
            this.Surname = Surname;
            this.PhoneNumber = PhoneNumber;
            this.Specialization = Specialization;
            this.HourlyCost = decimal.TryParse(HourlyCost, out decimal result) ? result : 0;
        }

        public override bool Equals(object obj)
        {
            return obj is Worker instructor &&
                InstructorIndex == instructor.InstructorIndex &&
                Name == instructor.Name &&
                Surname == instructor.Surname &&
                PhoneNumber == instructor.PhoneNumber &&
                Specialization == instructor.Specialization;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(InstructorIndex, Name, Surname, PhoneNumber, Specialization);
        }

        public static bool operator ==(Worker i1, Worker i2)
        {
            if (i1 is null && i2 is null) return true;

            return !(i1 is null) && i1.Equals(i2);
        }
        public static bool operator !=(Worker i1, Worker i2) => !(i1 == i2);
    }
}
