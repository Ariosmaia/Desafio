using EmployeeRegistration.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EmployeeRegistration.Api.Configuration
{
    public static class DatabseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<EmployeeRegistrationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        }

    }
}
