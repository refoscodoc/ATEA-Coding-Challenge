using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence.DataAccessLayer;
using Persistence.Repositories;
using Persistence.Repositories.Interfaces;

namespace ATEA_coding_challenge.Builder;

public static class BuilderCreator
{
     public static IHostBuilder CreateDefaultBuilder(string[] args)
     {
         return Host.CreateDefaultBuilder()
             .ConfigureAppConfiguration(app =>
             {
                 app.AddJsonFile("ATEA-coding-challenge/appsettings.json");
                 // app.AddJsonFile("appsettings.json");
                 // the line of code above is used in order to avoid an error during the DB migrations
             })
             .ConfigureServices((context, services) =>
             {
                 var configuration = context.Configuration;
                 var connectionString = configuration["DbConnectionString"];
                 var serverVersion = new MariaDbServerVersion(new Version(10, 10, 2));
                 services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
                 services.AddScoped<IAteaChallengeRepository, AteaChallengeRepository>();
                 services.AddDbContext<AteaChallengeDbContext>(
                     dbContextOptions => dbContextOptions
                         .UseMySql(connectionString, serverVersion)
                         .LogTo(Console.WriteLine, LogLevel.Information)
                         .EnableSensitiveDataLogging()
                         .EnableDetailedErrors()
                 );
             });
     }
}