using SilowniaProjektWPF.DAL.Models;
using System;

namespace SilowniaProjektWPF.Exceptions
{
    /// <summary>
    /// Exception when trying to add equipment that is already in database
    /// </summary>
    public class EquipmentConflictException : Exception
    {
        public Equipment ExistingEquipment { get; }
        public Equipment IncomingEquipment { get; }

        public EquipmentConflictException(Equipment existingEquipment, Equipment incomingEquipment)
        {
            ExistingEquipment = existingEquipment;
            IncomingEquipment = incomingEquipment;
        }

        public EquipmentConflictException(string message, Equipment existingEquipment, Equipment incomingEquipment) : base(message)
        {
            ExistingEquipment = existingEquipment;
            IncomingEquipment = incomingEquipment;
        }

        public EquipmentConflictException(string message, Exception innerException, Equipment existingEquipment, Equipment incomingEquipment) : base(message, innerException)
        {
            ExistingEquipment = existingEquipment;
            IncomingEquipment = incomingEquipment;
        }
    }
}
