using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Data.Models
{
    public class Engagement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EngagementId { get; set; }

        [Required]
        [MaxLength(255)]
        public string ClientName { get; set; }

        [Required]
        public AuditTypeValue AuditTypeId { get; set; }

        [Required]
        public DateTimeOffset AuditStartDate { get; set; }
        public DateTimeOffset AuditEndDate { get; set; }
        public int CountryId { get; set; }

        [Required]
        public List<int> Auditors { get; set; }

        [Required]
        public EngagementStatusValue EngagementStatusId { get; set; }

    }
}
