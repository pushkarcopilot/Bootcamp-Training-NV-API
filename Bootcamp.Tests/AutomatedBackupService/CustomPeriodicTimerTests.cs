using Bootcamp.AutomatedBackupService.Interfaces;
using Bootcamp.AutomatedBackupService.Models;
using Moq;

namespace Bootcamp.Tests.AutomatedBackupService
{
    public class CustomPeriodicTimerTests
    {
        private readonly Mock<ICustomPeriodicTimer> _mockTimer;

        public CustomPeriodicTimerTests()
        {
            _mockTimer = new Mock<ICustomPeriodicTimer>();

        }

        [Fact]
        public void Constructor_ShouldInitializeTimer()
        {
            var interval = TimeSpan.FromSeconds(10);

            using var timer = new CustomPeriodicTimer(interval);
        }

        [Fact]
        public async Task WaitForNextTickAsync_ShouldReturnTrue()
        {
            var interval = TimeSpan.FromMilliseconds(100); // Short interval for test
            using var timer = new CustomPeriodicTimer(interval);

            var result = await timer.WaitForNextTickAsync(CancellationToken.None);

            Assert.True(result);
        }

        [Fact]
        public async Task WaitForNextTickAsync_ShouldHandleCancellation()
        {
            var interval = TimeSpan.FromSeconds(1);
            using var timer = new CustomPeriodicTimer(interval);

            using var cts = new CancellationTokenSource();
            cts.CancelAfter(100); // Cancel after 100ms

            await Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await Task.FromResult(await timer.WaitForNextTickAsync(cts.Token));
            });
        }

        [Fact]
        public void Dispose_ShouldDisposeTimer()
        {
            var interval = TimeSpan.FromSeconds(10);
            var timer = new CustomPeriodicTimer(interval);

            timer.Dispose();

            // how to assert dispose?
        }
    }
}
