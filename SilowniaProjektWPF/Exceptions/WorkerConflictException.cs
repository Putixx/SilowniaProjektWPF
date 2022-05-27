using SilowniaProjektWPF.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilowniaProjektWPF.Exceptions
{
    public class WorkerConflictException : Exception
    {
        public Worker ExistingWorker { get; }
        public Worker IncomingWorker { get; }

        public WorkerConflictException(Worker existingWorker, Worker incomingWorker)
        {
            ExistingWorker = existingWorker;
            IncomingWorker = incomingWorker;
        }

        public WorkerConflictException(string message, Worker existingWorker, Worker incomingWorker) : base(message)
        {
            ExistingWorker = existingWorker;
            IncomingWorker = incomingWorker;
        }

        public WorkerConflictException(string message, Exception innerException, Worker existingWorker, Worker incomingWorker) : base(message, innerException)
        {
            ExistingWorker = existingWorker;
            IncomingWorker = incomingWorker;
        }
    }
}
