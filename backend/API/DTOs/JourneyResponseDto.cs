namespace API.DTOs
{
    public record class JourneyResponseDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<StopResponseDto>? Stops { get; set; }
    }
}
