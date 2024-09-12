namespace Bootcamp.AutomatedBackupService.Interfaces
{
    public interface ICustomPeriodicTimer : IDisposable
    {
        ValueTask<bool> WaitForNextTickAsync(CancellationToken cancellationToken = default);
    }
}
