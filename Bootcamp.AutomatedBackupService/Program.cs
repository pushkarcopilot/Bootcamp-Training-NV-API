using Bootcamp.Data;
using Bootcamp.Data.Context;
using Bootcamp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bootcamp.AutomatedBackupService
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<EngagementDbContext>(options =>
                    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Bootcamp2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;MultipleActiveResultSets=true;")
                    .LogTo(Console.WriteLine, LogLevel.Information));

            serviceCollection.AddScoped<IEngagementRepository, EngagementRepository>()
                .BuildServiceProvider();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var engagementRepository = serviceProvider.GetRequiredService<IEngagementRepository>();

            var worker = new Worker(engagementRepository);

            await worker.StartProcess();
        }
    }
}
