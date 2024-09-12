using Bootcamp.Data.Enums;
using Bootcamp.Data.Interfaces;

namespace Bootcamp.AutomatedBackupService.Utilities
{
    public static class Common
    {
        public static int? GetBackupFrequency(IEngagementRepository engagementRepository)
        {
            var backupFrequency = engagementRepository.GetEngagementBackupFrequency();

            if (backupFrequency == null) return null;

            int backupFreqHours = (int)(BackupFrequency)Enum.Parse(typeof(BackupFrequency), backupFrequency);

            return backupFreqHours;
        }
    }
}
