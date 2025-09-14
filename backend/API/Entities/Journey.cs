
using API.Entities;

namespace API.Models
{
    public class Journey : BaseEntity
    {
        public required string Title { get; set; }
        public required string Code { get; set; }
        public required string Description { get; set; }
        public ICollection<JourneyStop> JourneyStops { get; set; } = new List<JourneyStop>();
    }
}
