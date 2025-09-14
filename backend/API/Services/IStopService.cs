using API.DTOs;

namespace API.Services
{
    public interface IStopService
    {
        Task<IEnumerable<StopResponseDto>> GetAllAsync();
        Task<StopResponseDto> GetByIdAsync(int id);
        Task<StopResponseDto> CreateAsync(StopRequestDto dto);
        Task<bool> UpdateAsync(int id, StopRequestDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
