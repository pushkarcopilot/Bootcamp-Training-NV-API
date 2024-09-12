using Bootcamp.AutomatedBackupService.Models;
using Bootcamp.AutomatedBackupService.Utilities;
using Bootcamp.Data;
using Bootcamp.Data.Context;
using Bootcamp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bootcamp.AutomatedBackupService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var configuration = BuildConfiguration();

            var serviceProvider = ConfigureServices(configuration);

            var engagementRepository = serviceProvider.GetRequiredService<IEngagementRepository>();

            var backupFrequency = Common.GetBackupFrequency(engagementRepository);

            Worker worker = new(engagementRepository, new CustomPeriodicTimer(TimeSpan.FromHours((double)backupFrequency)));
            //Worker worker = new(engagementRepository, new CustomPeriodicTimer(TimeSpan.FromSeconds(5)));

            await worker.BackupEngagements();
        }

        public static IConfiguration BuildConfiguration() => new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

        public static IServiceProvider ConfigureServices(IConfiguration configuration)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<EngagementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            serviceCollection.AddScoped<IEngagementRepository, EngagementRepository>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
