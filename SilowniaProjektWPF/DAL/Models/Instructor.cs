
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
    }
}
