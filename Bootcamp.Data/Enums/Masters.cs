namespace Bootcamp.Data.Enums
{
    public class Masters
    {
        public enum AuditTypeId
        {
            InternalAudit,
            ExternalAudit,
            IRSTaxAudit,
            FinancialAudit
        }

        public enum EngagementStatusId
        {
            NotStarted,
            Assigned,
            InProgress,
            Completed
        }
    }
}
