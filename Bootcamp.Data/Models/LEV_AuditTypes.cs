using System.ComponentModel.DataAnnotations;

namespace Bootcamp.Data.Models
{
    public class LEV_AuditTypes
    {
        [Key]
        public int AuditTypeId { get; set; }
        public string AuditType { get; set; } = string.Empty;
        public int IsActive { get; set; }
    }
}
