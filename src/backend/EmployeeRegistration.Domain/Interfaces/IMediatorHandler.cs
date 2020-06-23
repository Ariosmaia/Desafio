using EmployeeRegistration.Domain.Core.Commands;
using EmployeeRegistration.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRegistration.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T evento) where T : Event;
        Task SendCommand<T>(T comando) where T : Command;
    }
}
