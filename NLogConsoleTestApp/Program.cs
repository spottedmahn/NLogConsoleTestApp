using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;

namespace NLogConsoleTestApp
{
    class Program
    {
        static ILogger<Program> logger;

        static void Main(string[] args)
        {
            //https://andrewlock.net/using-dependency-injection-in-a-net-core-console-application/
            //setup DI
            var services = new ServiceCollection();

            //add logging
            services.AddLogging();

            //build the provider;
            var serviceProvider = services.BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Trace, true);

            //configure nlog
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            loggerFactory.AddNLog();
            loggerFactory.ConfigureNLog("nlog.config");

            //create a logger
            logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogInformation("Hello World!");
        }
    }
}