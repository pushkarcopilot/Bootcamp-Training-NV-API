using static Bootcamp.Data.Enums.Masters;

namespace Bootcamp.Data.Models
{
    public class EngagementStatus
    {
        public EngagementStatusId EngagementStatusId { get; set; }

        public string Name { get; set; }

        public List<Engagement> Engagements { get; set; }
    }
}
