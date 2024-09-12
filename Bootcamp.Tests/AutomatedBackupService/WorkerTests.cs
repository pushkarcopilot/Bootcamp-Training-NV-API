using Bootcamp.AutomatedBackupService;
using Bootcamp.AutomatedBackupService.Interfaces;
using Bootcamp.Data.Interfaces;
using Bootcamp.Data.Models;
using Moq;
using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Tests.AutomatedBackupService
{
    public class WorkerTests
    {
        private readonly Mock<IEngagementRepository> _mockEngagementRepository;
        private readonly Mock<ICustomPeriodicTimer> _mockTimer;
        private readonly Worker _worker;
        private readonly Engagement[] MockEngagementList = [
                new Engagement { EngagementId = 1, Auditors = [1, 2], AuditTypeId = AuditTypeValue.InternalAudit , ClientName = "Client1", CountryId = 1, AuditEndDate = DateTime.Now, AuditStartDate = DateTime.Now }
        ];
        private readonly CancellationToken CToken = new();

        public WorkerTests()
        {
            _mockEngagementRepository = new Mock<IEngagementRepository>();
            _mockTimer = new Mock<ICustomPeriodicTimer>();
            _worker = new Worker(_mockEngagementRepository.Object, _mockTimer.Object);
        }

        [Fact]
        public void Worker_Constructor_ShouldInitializeCorrectly()
        {
            Assert.NotNull(_worker);
        }

        [Fact]
        public async Task BackupEngagements_ShouldUpdateExistingBackup_ForExistingEntity()
        {
            var engagementId = 1;

            var existingBackup = new EngagementBackup { EngagementId = engagementId };

            _mockEngagementRepository.Setup(repo => repo.GetAllEngagements()).ReturnsAsync(MockEngagementList);
            _mockEngagementRepository.Setup(repo => repo.GetEngagementBackupById(engagementId)).Returns(existingBackup);
            _mockEngagementRepository.Setup(repo => repo.PerformEngagementBackup(It.IsAny<EngagementBackup>(), true)).Verifiable();

            _mockTimer.SetupSequence(timer => timer.WaitForNextTickAsync(CToken)).ReturnsAsync(true).ReturnsAsync(false);

            await _worker.BackupEngagements();

            _mockEngagementRepository.Verify(repo => repo.PerformEngagementBackup(It.IsAny<EngagementBackup>(), true), Times.Once);
        }

        [Fact]
        public async Task BackupEngagements_ShouldPerformEngagementBackup_ForNewEntity()
        {
            _mockEngagementRepository.Setup(repo => repo.GetAllEngagements()).ReturnsAsync(MockEngagementList);
            _mockEngagementRepository.Setup(repo => repo.GetEngagementBackupById(It.IsAny<int>())).Returns((EngagementBackup)null);
            _mockEngagementRepository.Setup(repo => repo.PerformEngagementBackup(It.IsAny<EngagementBackup>(), false)).Verifiable();

            _mockTimer.SetupSequence(timer => timer.WaitForNextTickAsync(CToken))
                .ReturnsAsync(true)
                .ReturnsAsync(false);

            await _worker.BackupEngagements();

            _mockEngagementRepository.Verify(repo => repo.PerformEngagementBackup(It.IsAny<EngagementBackup>(), false), Times.Once);
        }

        [Fact]
        public async Task BackupEngagements_ShouldLogError_WhenExceptionOccurs()
        {
            _mockEngagementRepository.Setup(repo => repo.GetAllEngagements()).Throws(new Exception("Test exception"));
            _mockTimer.SetupSequence(timer => timer.WaitForNextTickAsync(CToken))
                .ReturnsAsync(true)
                .ReturnsAsync(false);

            var logFilePath = "log.txt";
            if (File.Exists(logFilePath))
            {
                File.Delete(logFilePath);
            }

            await _worker.BackupEngagements();

            var logContent = File.ReadAllText(logFilePath);
            Assert.Contains("Backup created failed at", logContent);
            Assert.Contains("Test exception", logContent);
        }
    }
}