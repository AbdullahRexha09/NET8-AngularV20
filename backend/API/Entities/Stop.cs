using API.Entities;

namespace API.Models
{
    public class Stop: BaseEntity
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required string Description { get; set; }
        public decimal X{ get; set; }
        public decimal Y{ get; set; }
        public ICollection<JourneyStop> JourneyStops { get; set; } = new List<JourneyStop>();


    }
}
