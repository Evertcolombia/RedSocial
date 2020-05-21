using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API
{
    // Contructor of our program (init)    
    public class Program
    {
        public static void Main(string[] args)
        {   
            // CreateHostBuilder() creates an instance of Ihostboulder interface  and start up
            // the API of our application with a well set arguments
            // see down in the method
            // Build() inizialites the host
            var host = CreateHostBuilder(args).Build();

            // This function will apllies any pending migrationg to db
            using(var scope = host.Services.CreateScope())
            {
                // reolve depen dencies from the scope as sercives
                var services = scope.ServiceProvider;
                try
                {
                    // Calls the dataContext service from Persitance lawyer
                    var context = services.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred during migration");
                }
                // run app and block the calling thread
                // untill host shutdown
                host.Run();

            }

        }

        // IHostBuilder  interface work with the server
        // and set up our progrma
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => //initializes a newe instance
                {
                    // so this line use the statup app from API after
                    // get a hostbuilder
                    webBuilder.UseStartup<Startup>();
                });
    }
}
