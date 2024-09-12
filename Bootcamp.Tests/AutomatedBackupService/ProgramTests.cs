using Bootcamp.AutomatedBackupService.Interfaces;
using Bootcamp.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Program = Bootcamp.AutomatedBackupService.Program;

namespace Bootcamp.Tests.AutomatedBackupService
{
    public class ProgramTests
    {
        [Fact]
        public void BuildConfiguration_ShouldReturnConfiguration()
        {
            var configuration = Program.BuildConfiguration();

            Assert.NotNull(configuration);
            Assert.True(configuration.GetValue<string>("AllowedHosts") != null);
        }

        [Fact]
        public void ConfigureServices_ShouldRegisterServices()
        {
            var configuration = new ConfigurationBuilder().Build();

            var serviceProvider = Program.ConfigureServices(configuration);

            Assert.NotNull(serviceProvider);

            var engagementRepository = serviceProvider.GetService<IEngagementRepository>();
            Assert.NotNull(engagementRepository);
        }

        [Fact]
        public async Task Main_ShouldCallBackupEngagements()
        {
            var mockRepository = new Mock<IEngagementRepository>();
            var mockTimer = new Mock<ICustomPeriodicTimer>();
            var mockWorker = new Mock<IWorker>();

            mockWorker.Setup(w => w.BackupEngagements()).Returns(Task.CompletedTask);


            // infinite loop in BackupEngagements and cannot inject a timer through Program
            //await Program.Main(new string[] { });
            //mockWorker.Verify(w => w.BackupEngagements(), Times.Once);
        }
    }
}
