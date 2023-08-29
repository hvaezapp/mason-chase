using FluentValidation;
using FluentValidation.AspNetCore;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Handlers.Commands.Customer;
using Mc2.CrudTest.Core.Handlers.Queries.Customer;
using Mc2.CrudTest.Core.Interfaces.Repository;
using Mc2.CrudTest.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddScoped<ICustomerRepository, CustomerRepository>();


            // Fluent Validation Config
            #region
            //services.AddScoped<IValidator<AddCustomerCommand>, AddCustomerCommandValidator>();
            //services.AddScoped<IValidator<DeleteCustomerCommand>, DeleteCustomerCommandValidator>();
            //services.AddScoped<IValidator<EditCustomerCommand>, EditCustomerCommandValidator>();

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddCustomerCommandValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EditCustomerCommandValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<DeleteCustomerCommandValidator>());
            #endregion


            // MediatR Config
            #region
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IRequestHandler<AddCustomerCommand, RequestResponse>, AddCustomerCommandHandler>();
            services.AddScoped<IRequestHandler<EditCustomerCommand, RequestResponse>, EditCustomerCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCustomerCommand, RequestResponse>, DeleteCustomerCommandHandler>();
            services.AddScoped<IRequestHandler<GetCustomersQuery, RequestResponse>, GetCustomersQueryHandler>();
            #endregion
        }
    }
}
