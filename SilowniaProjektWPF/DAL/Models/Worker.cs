
namespace SilowniaProjektWPF.DAL.Models
{
    public class Worker
    {
        public string Name { get; }
        public string Surname { get; }
        public string PhoneNumber { get; }

        public Worker(string Name, string Surname, string PhoneNumber)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.PhoneNumber = PhoneNumber;
        }
    }
}
