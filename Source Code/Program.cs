﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Topshelf;
using Windows_Service;


IConfiguration configFile = new ConfigurationBuilder().AddJsonFile("appsettings.json", false , true).Build();

var services = new ServiceCollection();

services
    .AddLogging(log => { log.ClearProviders(); log.AddNLog(); })
    .AddSingleton(configFile);

using (var serviceProvider = services.BuildServiceProvider())
{
    HostFactory.Run(ser =>
    {
        ser.SetServiceName("Windows-Service");
        ser.SetDisplayName("Windows-Service");
        ser.SetDescription("Windows-Service...");

        ser.Service<Service>(s =>
        {
            s.ConstructUsing(_ => new Service(serviceProvider));
            s.WhenStarted(async ss => await ss.Start());
            s.WhenStopped(ss => ss.Stop());
        });
    });
}

