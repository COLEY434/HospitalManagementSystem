using HospitalManagementsystem.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementsystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();//.Run();

            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();

                try
                {
                    var dbContext = services.GetRequiredService<ApplicationDbContext>();
                    logger.LogInformation("Migrating database");
                    await dbContext.Database.MigrateAsync();
                    logger.LogInformation("Done Migrating database");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, ex.Message);
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureLogging(logging =>
                 {
                     logging.ClearProviders();
                     logging.AddConsole();
                 })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
