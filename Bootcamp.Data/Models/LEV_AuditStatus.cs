using System.ComponentModel.DataAnnotations;

namespace Bootcamp.Data.Models
{   
    public class LEV_AuditStatus
    {
        [Key]
        public int AuditStatusId { get; set; }
        public string AuditStatus { get; set; } = string.Empty;
        public int IsActive { get; set; }
    }
}
