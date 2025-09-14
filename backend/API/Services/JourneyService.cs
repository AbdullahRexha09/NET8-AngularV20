using API.Database;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class JourneyService : IJourneyService
    {
        private readonly AppDbContext _context;

        public JourneyService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<JourneyResponseDto> CreateAsync(JourneyRequestDto dto)
        {
            var journey = dto.ToEntity();
            var stops = await _context.Stop
                        .Where(s => dto.StopCodesInOrder.Contains(s.Code))
                        .ToDictionaryAsync(s => s.Code);

            journey.JourneyStops = dto.StopCodesInOrder
            .Select((code, index) => new JourneyStop
            {
                StopId = stops[code].Id,
                Order = index
            }).ToList();
            _context.Journey.Add(journey);
            await _context.SaveChangesAsync();
            return journey.ToDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var journey = await _context.Journey
                               .IncludeJourneyWithOrderedStops()
                               .FirstOrDefaultAsync(j => j.Id == id);

            journey.IsDel = true;
            _context.Journey.Update(journey);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<JourneyResponseDto>> GetAllAsync()
        {
            var journeys = await _context.Journey
                                         .IncludeJourneyWithOrderedStops()
                                         .AsNoTracking()
                                         .ToListAsync();

            return journeys.Select(j => j.ToDto());
        }

        public async Task<JourneyResponseDto> GetByIdAsync(int id)
        {
            var journey = await _context.Journey
                                .IncludeJourneyWithOrderedStops()
                                .AsNoTracking()
                                .FirstOrDefaultAsync(j => j.Id == id);

            return journey?.ToDto();
        }

        public async Task<bool> UpdateAsync(int id, JourneyRequestDto dto)
        {
            var existingJourney = await _context.Journey
                                                .Include(j => j.JourneyStops)
                                                .FirstOrDefaultAsync(j => j.Id == id);

            var stops = await _context.Stop
                        .Where(s => dto.StopCodesInOrder.Contains(s.Code))
                        .ToDictionaryAsync(s => s.Code);


            if (existingJourney == null)
            {
                return false;
            }
            existingJourney.Title = dto.Title;
            existingJourney.Code = dto.Code;
            existingJourney.Description = dto.Description;
            existingJourney.JourneyStops = dto.StopCodesInOrder
            .Select((code, index) => new JourneyStop
            {
                StopId = stops[code].Id,
                Order = index
            }).ToList();

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
