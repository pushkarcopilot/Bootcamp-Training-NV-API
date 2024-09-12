using Bootcamp.AutomatedBackupService;
using Bootcamp.AutomatedBackupService.Interfaces;
using Bootcamp.AutomatedBackupService.Utilities;
using Bootcamp.Data.Enums;
using Bootcamp.Data.Interfaces;
using Moq;

namespace Bootcamp.Tests.AutomatedBackupService
{
    public class CommonTests
    {
        private readonly Mock<IEngagementRepository> _mockEngagementRepository;
        private readonly Mock<ICustomPeriodicTimer> _mockTimer;
        private readonly Worker _worker;

        public CommonTests()
        {
            _mockEngagementRepository = new Mock<IEngagementRepository>();
            _mockTimer = new Mock<ICustomPeriodicTimer>();
            _worker = new Worker(_mockEngagementRepository.Object, _mockTimer.Object);
        }

        [Fact]
        public void GetBackupFrequency_ShouldReturnParsedFrequency()
        {
            _mockEngagementRepository.Setup(repo => repo.GetEngagementBackupFrequency()).Returns("Daily");

            var result = Common.GetBackupFrequency(_mockEngagementRepository.Object);

            Assert.NotNull(result);
            Assert.Equal((int)BackupFrequency.Daily, result);
        }

        [Fact]
        public void GetBackupFrequency_ShouldReturnNull_WhenFrequencyIsNull()
        {
            _mockEngagementRepository.Setup(repo => repo.GetEngagementBackupFrequency()).Returns((string)null);

            var result = Common.GetBackupFrequency(_mockEngagementRepository.Object);

            Assert.Null(result);
        }

        [Fact]
        public void GetBackupFrequency_ShouldThrowException_ForInvalidFrequency()
        {
            _mockEngagementRepository.Setup(repo => repo.GetEngagementBackupFrequency()).Returns("InvalidFrequency");

            Assert.Throws<ArgumentException>(() => Common.GetBackupFrequency(_mockEngagementRepository.Object));
        }
    }
}
