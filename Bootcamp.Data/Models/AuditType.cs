using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Data.Models
{
    public class AuditType
    {
        public AuditTypeValue AuditTypeId { get; set; }

        public string? Name { get; set; }

        public List<Engagement>? Engagements { get; set; }
    }
}
