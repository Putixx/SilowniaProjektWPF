﻿using SilowniaProjektWPF.DAL.Models;
using System;

namespace SilowniaProjektWPF.Exceptions
{
    public class ClientConflictException : Exception
    {
        public Client ExistingClient { get; }
        public Client IncomingClient { get; }

        public ClientConflictException(Client existingClient, Client incomingClient)
        {
            ExistingClient = existingClient;
            IncomingClient = incomingClient;
        }

        public ClientConflictException(string message, Client existingClient, Client incomingClient) : base(message)
        {
            ExistingClient = existingClient;
            IncomingClient = incomingClient;
        }

        public ClientConflictException(string message, Exception innerException, Client existingClient, Client incomingClient) : base(message, innerException)
        {
            ExistingClient = existingClient;
            IncomingClient = incomingClient;
        }
    }
}
