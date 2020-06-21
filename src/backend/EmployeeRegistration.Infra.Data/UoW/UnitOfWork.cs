using EmployeeRegistration.Domain.Interfaces;
using EmployeeRegistration.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRegistration.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        protected EmployeeRegistrationContext _context;

        public UnitOfWork(EmployeeRegistrationContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
