using EmployeeRegistration.CrossCutting.Infra.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EmployeeRegistration.Api.Configuration
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectionBootStrapper.RegisterServices(services);
        }
    }
}
