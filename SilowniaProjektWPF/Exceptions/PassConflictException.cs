﻿using SilowniaProjektWPF.DAL.Models;
using System;

namespace SilowniaProjektWPF.Exceptions
{
    public class PassConflictException : Exception
    {
        public Pass ExistingPass { get; }
        public Pass IncomingPass { get; }

        public PassConflictException(Pass existingPass, Pass incomingPass)
        {
            ExistingPass = existingPass;
            IncomingPass = incomingPass;
        }

        public PassConflictException(string message, Pass existingPass, Pass incomingPass) : base(message)
        {
            ExistingPass = existingPass;
            IncomingPass = incomingPass;
        }

        public PassConflictException(string message, Exception innerException, Pass existingPass, Pass incomingPass) : base(message, innerException)
        {
            ExistingPass = existingPass;
            IncomingPass = incomingPass;
        }
    }
}
