using Bootcamp.Data;
using Bootcamp.Data.Context;
using Bootcamp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bootcamp.AutomatedBackupService
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<EngagementDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                );

            serviceCollection.AddScoped<IEngagementRepository, EngagementRepository>()
                .BuildServiceProvider();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var engagementRepository = serviceProvider.GetRequiredService<IEngagementRepository>();

            var worker = new Worker(engagementRepository);

            await worker.StartProcess();
        }
    }
}
