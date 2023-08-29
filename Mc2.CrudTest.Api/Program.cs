using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.Dtos;
using Mc2.CrudTest.Core.Handlers.Commands.Customer;
using Mc2.CrudTest.Core.Handlers.Queries.Customer;
using Mc2.CrudTest.Core.Interfaces.Repository;
using Mc2.CrudTest.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddDbContext<CrudDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CrudDatabase")));


builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

//MediatR config

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<IRequestHandler<AddCustomerCommand, RequestResponse>, AddCustomerCommandHandler>();
builder.Services.AddScoped<IRequestHandler<EditCustomerCommand, RequestResponse>, EditCustomerCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteCustomerCommand, RequestResponse>, DeleteCustomerCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetCustomersQuery, RequestResponse>, GetCustomersQueryHandler>();





builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthorization();


app.MapControllers();

app.Run();
