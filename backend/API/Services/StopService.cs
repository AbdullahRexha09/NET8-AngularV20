using API.Database;
using API.DTOs;
using API.Extensions;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class StopService : IStopService
    {
        private readonly AppDbContext _context;

        public StopService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<StopResponseDto> CreateAsync(StopRequestDto dto)
        {
            var stop = dto.ToEntity();
            _context.Stop.Add(stop);
            await _context.SaveChangesAsync();
            return stop.ToDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var stop = await _context.Stop.FindAsync(id);
            stop.IsDel = true;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<StopResponseDto>> GetAllAsync()
        {
            var stops = await _context.Stop.ToListAsync();
            return stops.Select(s => s.ToDto());
        }

        public async Task<StopResponseDto> GetByIdAsync(int id)
        {
            var stops = await _context.Stop.FindAsync(id);
            return stops?.ToDto();
        }

        public async Task<bool> UpdateAsync(int id, StopRequestDto dto)
        {
            var exsitingStop = await _context.Stop.FindAsync(id);
            if (exsitingStop == null)
            {
                return false;
            }

            exsitingStop.Name = dto.Name;
            exsitingStop.Code = dto.Code;
            exsitingStop.Description = dto.Description;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
