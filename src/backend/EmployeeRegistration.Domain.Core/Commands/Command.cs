using EmployeeRegistration.Domain.Core.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Core.Commands
{
    public class Command : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }

    }
}
