using System.ComponentModel.DataAnnotations;
using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Data.Models
{
    public class Engagement
    {
        [Key]
        public int EngagementId { get; set; }

        [Required]
        [MaxLength(255)]
        public string ClientName { get; set; }

        [Required]
        public AuditTypeId AuditTypeId { get; set; }

        [Required]
        public AuditType AuditType { get; set; }

        [Required]
        public DateTimeOffset AuditStartDate { get; set; }

        [Required]
        public DateTimeOffset AuditEndDate { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public List<int> Auditors { get; set; }

        [Required]
        public EngagementStatusId EngagementStatusId { get; set; }

        [Required]
        public EngagementStatus EngagementStatus { get; set; }
    }
}
