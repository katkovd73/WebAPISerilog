using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace WebAPISerilog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // reading from appsettings.json file
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

                // using settings inside the appsettings.json
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();

                //Log.Logger = new LoggerConfiguration()
                //    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
                //    .CreateLogger();

                //Log.Logger = new LoggerConfiguration()
                //   .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
                //   .CreateLogger();

                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
