using API.Models;
using System.Text.Json.Serialization;

namespace API.DTOs
{
    public record class JourneyRequestDto
    {
        public required string Title { get; set; }
        public required string Code { get; set; }
        public required string Description { get; set; }
        public ICollection<string> StopCodesInOrder { get; set; } = new List<string>();

    }
}
