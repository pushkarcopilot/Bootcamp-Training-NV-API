using Bootcamp.AutomatedBackupService.Interfaces;

namespace Bootcamp.AutomatedBackupService.Models
{
    public sealed class CustomPeriodicTimer : ICustomPeriodicTimer
    {
        private PeriodicTimer _actualTimer;

        public CustomPeriodicTimer(TimeSpan timeSpan)
            => _actualTimer = new PeriodicTimer(timeSpan);

        public async ValueTask<bool> WaitForNextTickAsync(CancellationToken cancellationToken = default)
            => await _actualTimer.WaitForNextTickAsync(cancellationToken);


        public void Dispose() => _actualTimer.Dispose();
    }
}