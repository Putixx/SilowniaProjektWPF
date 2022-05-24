using System;

namespace SilowniaProjektWPF.DAL.Models
{
    public class Instructor
    {
        public string Name { get; }
        public string Surname { get; }
        public string PhoneNumber { get; }
        public string Specialization { get; }
        public decimal HourlyCost { get; }

        public Instructor(string Name, string Surname, string PhoneNumber, string Specialization, decimal HourlyCost)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.PhoneNumber = PhoneNumber;
            this.Specialization = Specialization;
            this.HourlyCost = HourlyCost;
        }

        public override bool Equals(object obj)
        {
            return obj is Instructor instructor &&
                Name == instructor.Name &&
                Surname == instructor.Surname &&
                PhoneNumber == instructor.PhoneNumber &&
                Specialization == instructor.Specialization;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, PhoneNumber, Specialization);
        }

        public static bool operator ==(Instructor i1, Instructor i2)
        {
            if (i1 is null && i2 is null) return true;

            return !(i1 is null) && i1.Equals(i2);
        }
        public static bool operator !=(Instructor i1, Instructor i2) => !(i1 == i2);
    }
}
