using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
