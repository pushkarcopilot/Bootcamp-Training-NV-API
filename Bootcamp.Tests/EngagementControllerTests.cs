using Bootcamp.Data.Interfaces;
using Bootcamp.Data.Models;
using Bootcamp.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using FluentValidation;
using FluentValidation.Results;

namespace Bootcamp.Tests
{
    public class EngagementControllerTests
    {
        private readonly Mock<IEngagementRepository> _mockEngRepo;
        private readonly EngagementController _controller;
        private readonly Mock<IValidator<Engagement>> _mockValidator;

        public EngagementControllerTests()
        {
            _mockEngRepo = new Mock<IEngagementRepository>();
            _controller = new EngagementController(_mockEngRepo.Object);
            _mockValidator = new Mock<IValidator<Engagement>>();
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

        [Fact]
        public async Task GetAllEngagements_ReturnsOk_WhenEngagementsExist()
        {
            var engagements = new List<Engagement>
        {
            new Engagement { EngagementId = 1, ClientName = "Client A" },
            new Engagement { EngagementId = 2, ClientName = "Client B" }
        };

            _mockEngRepo.Setup(repo => repo.GetAllEngagements())
                .ReturnsAsync(engagements);

            var result = await _controller.GetEngagements();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedEngagements = Assert.IsType<List<Engagement>>(okResult.Value);
            Assert.Equal(2, returnedEngagements.Count);
        }

        [Fact]
        public async Task GetAllEngagements_ReturnsNotFound_WhenEngagementsListIsEmpty()
        {
            _mockEngRepo.Setup(repo => repo.GetAllEngagements())
                .ReturnsAsync(new List<Engagement>());

            var result = await _controller.GetEngagements();

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateEngagement_ReturnsOk_WhenEngagementIsValid()
        {
            var engagement = new Engagement { EngagementId = 1, ClientName = "Client A" };
            var validationResult = new ValidationResult();
            _mockValidator.Setup(v => v.Validate(engagement)).Returns(validationResult);

            var result = _controller.CreateEngagement(engagement, _mockValidator.Object);

            var okResult = Assert.IsType<OkResult>(result);
            _mockEngRepo.Verify(repo => repo.AddEngagement(It.IsAny<Engagement>()), Times.Once);
        }

        [Fact]
        public void CreateEngagement_ReturnsBadRequest_WhenEngagementIsInvalid()
        {
            var engagement = new Engagement { EngagementId = 0, ClientName = " " };
            var validationResult = new ValidationResult(new[]
            {
            new ValidationFailure("ClientName", "Client name is required")
            });
            _mockValidator.Setup(v => v.Validate(engagement)).Returns(validationResult);

            var result = _controller.CreateEngagement(engagement, _mockValidator.Object);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);

            var errorMessages = badRequestResult.Value as IEnumerable<ValidationFailure>;
            Assert.NotNull(errorMessages);

            Assert.Equal("Client name is required", errorMessages.First().ErrorMessage);
            _mockEngRepo.Verify(repo => repo.AddEngagement(It.IsAny<Engagement>()), Times.Never);
        }

        [Fact]
        public void CreateEngagement_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            var engagement = new Engagement { EngagementId = 1, ClientName = "Client A" };
            var validationResult = new ValidationResult();
            _mockValidator.Setup(v => v.Validate(engagement)).Returns(validationResult);

            _mockEngRepo.Setup(repo => repo.AddEngagement(It.IsAny<Engagement>()))
                .Throws(new Exception("Database error"));

            var result = _controller.CreateEngagement(engagement, _mockValidator.Object);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Database error", badRequestResult.Value);
            _mockEngRepo.Verify(repo => repo.AddEngagement(It.IsAny<Engagement>()), Times.Once);
        }
    }
}
