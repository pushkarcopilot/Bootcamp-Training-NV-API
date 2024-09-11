using System.ComponentModel.DataAnnotations;

namespace Bootcamp.Data.Models
{
    public class EngagementBackup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BackupId { get; set; }

        [Required]
        public int EngagementId { get; set; }

        [Required]
        public DateTime BackupTimestamp { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public int AuditTypeId { get; set; }

        [Required]
        public DateTimeOffset AuditStartDate { get; set; }

        [Required]
        public DateTimeOffset AuditEndDate { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public List<int> Auditors { get; set; }

        [Required]
        public int EngagementStatusId { get; set; }
    }
}
