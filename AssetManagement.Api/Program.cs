using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Autofac.Extensions.DependencyInjection;
using NLog.Web;
using System;
using System.IO;
using AssetManagement.Api.Utility;

namespace AssetManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AutoMapperConfig.Initialize();

            NLogBuilder.ConfigureNLog("Configuration/nlog.config").GetCurrentClassLogger();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .ConfigureKestrel((context, options) =>
             {
                 options.Limits.MaxConcurrentConnections = 100;
                 options.Limits.MaxConcurrentUpgradedConnections = 100;
                 options.Limits.MaxRequestBodySize = 10 * 1024;               
             })
              .UseContentRoot(Directory.GetCurrentDirectory())
              .ConfigureServices(services => services.AddAutofac())
              .ConfigureAppConfiguration((hostContext, config) =>
              {
                  var env = hostContext.HostingEnvironment;
                  Console.WriteLine("Env:" + env.EnvironmentName);
                  config.SetBasePath(Path.Combine(env.ContentRootPath, "Configuration"))
                        .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile(path: $"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();
              })
              .UseStartup<Startup>()
              .UseNLog()
              .Build();
    }
}
