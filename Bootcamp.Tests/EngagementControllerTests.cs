using Bootcamp.Data.Interfaces;
using Bootcamp.Data.Models;
using Bootcamp.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Bootcamp.Tests
{
    public class EngagementControllerTests
    {
        private readonly Mock<IEngagementRepository> _mockEngRepo;
        private readonly EngagementController _controller;

        public EngagementControllerTests()
        {
            _mockEngRepo = new Mock<IEngagementRepository>();
            _controller = new EngagementController(_mockEngRepo.Object);
        }

        [Fact]
        public void AddBackupSetting_ReturnsOkResult_WhenPayloadIsValid()
        {
            AddBackupSettingPayload
                payload = new()
                {
                    BackupFrequency = "Daily"
                };

            var result = _controller.AddBackupSetting(payload);

            Assert.Equal("ok", result);
        }

        [Fact]
        public void AddBackupSetting_ReturnsErrorMessage_WhenPayloadIsInvalid()
        {
            AddBackupSettingPayload
                payload = new()
                {
                    BackupFrequency = "Some invalid value"
                };

            var result = _controller.AddBackupSetting(payload);

            Assert.Equal("not okay", result);
        }

        [Fact]
        public async void GetEngagementByEngagementId_ReturnsOkResult_WithEmptyEngagementList()
        {
            int engagementId = 1;
            var expectedEngagements = Array.Empty<Engagement>();

            OkObjectResult ObObjectResult = new(expectedEngagements);

            var result = await _controller.GetEngagementByEngagementId(engagementId) as OkObjectResult;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, result.StatusCode);

            var actualEngagements = Assert.IsType<Engagement[]>(result.Value);
            Assert.Equal(expectedEngagements.Length, actualEngagements.Length);
        }

        [Fact]
        public async Task GetEngagementByEngagementId_ReturnsNotFoundResult_WhenEngagementNotFound()
        {
            var engagementId = 1;

            var asd = _mockEngRepo.Setup(repo => repo.GetEngagementById(engagementId))
                .ReturnsAsync((Engagement[])null);

            var result = await _controller.GetEngagementByEngagementId(engagementId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetEngagementByEngagementId_ThrowsException_WhenRepositoryThrowsException()
        {
            var engagementId = 1;

            _mockEngRepo.Setup(repo => repo.GetEngagementById(engagementId))
                        .ThrowsAsync(new Exception("Test exception"));

            await Assert.ThrowsAsync<Exception>(() => _controller.GetEngagementByEngagementId(engagementId));
        }
    }
}
