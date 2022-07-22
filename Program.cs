// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DotnetConsoleAddMongo.Model;
using Microsoft.Extensions.Configuration;
using DotnetConsoleAddMongo.Service.Interface;
using DotnetConsoleAddMongo.Service.Concrete;

Console.WriteLine("Hello, World!");

var builder = Host.CreateDefaultBuilder()

    .ConfigureAppConfiguration((hostContext, config) =>
    {
    }).ConfigureServices((hostContext, services) =>
    {
        IConfiguration Configuration = new ConfigurationBuilder()
             .SetBasePath(hostContext.HostingEnvironment.ContentRootPath)
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddEnvironmentVariables()
             .AddCommandLine(args)
             .Build();

        Connection connection = new();
        Configuration.Bind("MongoDb", connection);

        services.AddSingleton<IConnection>(x => connection);
        services.AddTransient<ICountryService, CountryService>();
    })
    .UseConsoleLifetime();


var host = builder.Build();

using var serviceScope = host.Services.CreateScope();
var serviceProvider = serviceScope.ServiceProvider;

Factory factory = new(serviceProvider);
// var result = factory.RemoveAllCountry();
var result = factory.CreateCountry();
Console.WriteLine(result);