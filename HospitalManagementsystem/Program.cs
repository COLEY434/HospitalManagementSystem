using HospitalManagementsystem.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementsystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
             .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
             .Enrich.FromLogContext()
             .WriteTo.Console()
             .CreateBootstrapLogger();

            Log.Information("Hello, world from serilog!");

            var host = CreateHostBuilder(args).Build();//.Run();

            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
               // var logger = services.GetRequiredService<ILogger<Program>>();
               
                try
                {
                    var dbContext = services.GetRequiredService<ApplicationDbContext>();
                    Log.Information("Migrating database");
                    await dbContext.Database.MigrateAsync();
                    Log.Information("Done Migrating database");
                }
                catch (Exception ex)
                {
                    Log.Error(ex, ex.Message);
                }
            }

            Log.Information("Starting web host");
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, services, configuration) => configuration
                    .ReadFrom.Configuration(context.Configuration)
                    .ReadFrom.Services(services)
                    .Enrich.FromLogContext()
                    .WriteTo.Console())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
