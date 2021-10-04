using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;
using System.IO;

namespace HTTP2Relay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var configuration= new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
            //.AddEnvironmentVariables()
            //.Build();
    //        var configuration = new ConfigurationBuilder()
    //.AddJsonFile("appsettings.json")
    //.Build();
    //        Log.Logger = new LoggerConfiguration()
    //            .ReadFrom.Configuration(configuration.GetSection("Serilog"))
    //            .CreateLogger();

            Log.Logger = new
                   LoggerConfiguration().MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext().WriteTo.File("C:\\Logs2\\Demo.txt",
                   rollingInterval: RollingInterval.Hour, fileSizeLimitBytes: 100000).CreateLogger();

            CreateHostBuilder(args).Build().Run();
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
