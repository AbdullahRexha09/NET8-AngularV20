using API.DTOs;

namespace API.Services
{
    public interface IJourneyService
    {
        Task<IEnumerable<JourneyResponseDto>> GetAllAsync();
        Task<JourneyResponseDto> GetByIdAsync(int id);
        Task<JourneyResponseDto> CreateAsync(JourneyRequestDto dto);
        Task<bool> UpdateAsync(int id, JourneyRequestDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
