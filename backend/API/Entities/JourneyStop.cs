using API.Models;

namespace API.Entities
{
    public class JourneyStop
    {
        public int JourneyId { get; set; }
        public Journey Journey { get; set; }

        public int StopId { get; set; }
        public Stop Stop { get; set; }
        public int Order { get; set; }

    }
}
