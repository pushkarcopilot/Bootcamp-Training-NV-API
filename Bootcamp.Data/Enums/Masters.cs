namespace Bootcamp.Data.Enums
{
    public class Masters
    {
      
        // Enum for Audit Type
        public enum AuditTypeValue
        {
            InternalAudit,
            ExternalAudit,
            ComplianceAudit,
            FinancialAudit
        }

        // Enum for Engagement Status
        public enum EngagementStatusValue
        {
            NotStarted,
            InProgress,
            Completed,
            OnHold,
            Cancelled
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
