using System;

namespace SilowniaProjektWPF.DAL.Models
{
    /// <summary>
    /// Model for client
    /// </summary>
    public class Client
    {
        public string Name { get; }
        public string Surname { get; }
        public string PhoneNumber { get; }
        public string PassNumber { get; }

        public Client(string Name, string Surname, string PhoneNumber, string PassNumber)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.PhoneNumber = PhoneNumber;
            this.PassNumber = PassNumber;
        }

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                Name == client.Name &&
                Surname == client.Surname &&
                PhoneNumber == client.PhoneNumber &&
                PassNumber == client.PassNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, PhoneNumber, PassNumber);
        }

        public static bool operator ==(Client c1, Client c2)
        {
            if (c1 is null && c2 is null) return true;

            return !(c1 is null) && c1.Equals(c2);
        }
        public static bool operator !=(Client c1, Client c2) => !(c1 == c2);
    }
}
