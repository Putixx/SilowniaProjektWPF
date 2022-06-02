using SilowniaProjektWPF.DAL.Models;
using System;

namespace SilowniaProjektWPF.Exceptions
{
    /// <summary>
    /// Exception when trying to add new client with same number as existing one
    /// </summary>
    public class ClientExistingNumberException : Exception
    {
        public Client ExistingClient { get; }
        public Client IncomingClient { get; }

        public ClientExistingNumberException(Client existingClient, Client incomingClient)
        {
            ExistingClient = existingClient;
            IncomingClient = incomingClient;
        }

        public ClientExistingNumberException(string message, Client existingClient, Client incomingClient) : base(message)
        {
            ExistingClient = existingClient;
            IncomingClient = incomingClient;
        }

        public ClientExistingNumberException(string message, Exception innerException, Client existingClient, Client incomingClient) : base(message, innerException)
        {
            ExistingClient = existingClient;
            IncomingClient = incomingClient;
        }
    }
}
