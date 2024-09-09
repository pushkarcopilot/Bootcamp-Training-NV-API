using System.ComponentModel.DataAnnotations;

namespace Bootcamp.Data.Models
{
    public class LEV_Auditors
    {
        [Key]
        public int AuditorsId { get; set; }
        public string AuditorsName { get; set; }=string.Empty;
        public int IsActive { get; set; }
    }
}
