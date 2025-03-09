using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Windows_Service;


IConfiguration configFile = new ConfigurationBuilder().AddJsonFile("appsettings.json", false , true).Build();

var services = new ServiceCollection();

services
    .AddLogging(log => { log.ClearProviders(); log.AddNLog(); })
    .AddSingleton(configFile)
    .AddScoped<TestLogin>();

using (var serviceProvider = services.BuildServiceProvider())
{
    var objekti = serviceProvider.GetRequiredService<TestLogin>();
    objekti.Shenim();
}

