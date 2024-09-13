
using Bootcamp.Data.Models;
using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Data.Interfaces
{
    public interface IEngagementRepository
    {
        Task<IEnumerable<Engagement>> GetAllEngagements();
        Task<IEnumerable<Country>> GetCountries();
        Task<IEnumerable<Auditor>> GetAuditors();
        Task<IEnumerable<AuditType>> GetAuditTypes();
        Task<IEnumerable<EngagementStatus>> GetEngagementStatus();
        Task<IEnumerable<Engagement>> GetEngagementById(int engagementId);
        void AddEngagement(Engagement engagement);

        void AddBackupSettings(string backupFrequency);

        string? GetEngagementBackupFrequency();

        EngagementBackup? GetEngagementBackupById(int id);

        void PerformEngagementBackup(EngagementBackup? backup, bool shouldUpdate);
    }
}
