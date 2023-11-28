using Mc2.CrudTest.Api.Middlewares;
using Mc2.CrudTest.Core;
using Mc2.CrudTest.Infrastructure;
using Microsoft.OpenApi.Models;
using Serilog;


var builder = WebApplication.CreateBuilder(args);


//var connectionString = builder.Configuration.GetConnectionString("SqlServer");

//builder.Host.UseSerilog((hostBuilderContext, logConfig) =>
//{

//    logConfig.WriteTo.MSSqlServer(connectionString, "Logs", autoCreateSqlTable: true).MinimumLevel.Error();

//    /* if (hostBuilderContext.HostingEnvironment.IsDevelopment())
//     {
//         logConfig.WriteTo.Console().MinimumLevel.Debug();

//     }
//     else
//     {

//     }*/
//});


builder.Services.AddControllers();


builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

AddSwagger(builder.Services);


var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();

app.UseAuthorization();

app.UseCustomExceptionHandler();


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action=Index}/{id?}");

//app.MapFallbackToFile("index.html");


app.Run();

void AddSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(o =>
    {
        o.SwaggerDoc("v1", new OpenApiInfo()
        {
            Version = "v1",
            Title = "CrudTest Api"
        });

    });
}

