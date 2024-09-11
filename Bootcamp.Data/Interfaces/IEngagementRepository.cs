
using Bootcamp.Data.Models;
using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Data.Interfaces
{
    public interface IEngagementRepository
    {
        Task<IEnumerable<Engagement>> GetAllEngagements();

        void AddEngagement(Engagement engagement);

        void AddBackupSettings(string backupFrequency);

        string? GetEngagementBackupFrequency();

        EngagementBackup? GetEngagementBackupById(int id);

        void PerformEngagementBackup(EngagementBackup? backup, bool shouldUpdate);
    }
}
