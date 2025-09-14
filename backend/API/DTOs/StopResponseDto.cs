namespace API.DTOs
{
    public record class StopResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
