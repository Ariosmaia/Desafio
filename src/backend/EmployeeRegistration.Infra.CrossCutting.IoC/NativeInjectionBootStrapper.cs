using EmployeeRegistration.Application.Interfaces;
using EmployeeRegistration.Application.Services;
using EmployeeRegistration.Domain.Core.Notifications;
using EmployeeRegistration.Domain.Employees.Commands;
using EmployeeRegistration.Domain.Employees.Repository;
using EmployeeRegistration.Domain.Handlers;
using EmployeeRegistration.Domain.Interfaces;
using EmployeeRegistration.Infra.Data.Repository;
using EmployeeRegistration.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeRegistration.CrossCutting.Infra.IoC
{
    public class NativeInjectionBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Application
            services.AddScoped<IEmployeeAppService, EmployeeAppService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterEmployeeCommand, bool>, EmployeeCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateEmployeeCommand, bool>, EmployeeCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteEmployeeCommand, bool>, EmployeeCommandHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Infra - Data
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
