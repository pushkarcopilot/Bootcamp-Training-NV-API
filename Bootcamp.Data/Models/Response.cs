namespace Bootcamp.Data.Models
{
    public class AllEngagementsResponse
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string AuditType { get; set; }
        public string EngagementStatus { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int CountryId { get; set; }
    }
}
