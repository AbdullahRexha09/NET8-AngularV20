using API.DTOs;
using API.Entities;
using API.Models;

namespace API.Extensions
{
    public static class MapperExtension
    {
        #region Journey
        public static Journey ToEntity(this JourneyRequestDto request)
        {
            return new Journey
            {
                Title = request.Title,
                Code = request.Code,
                Description = request.Description
            };
        }

        public static JourneyResponseDto ToDto(this Journey request)
        {
            return new JourneyResponseDto
            {
                Id = request.Id,
                Title = request.Title,
                Code = request.Code,
                Description = request.Description,
                CreatedAt = request.CreatedAt,
                Stops = request.JourneyStops.Select(js => js.Stop.ToDto())

            };
        }

        #endregion;

        #region Stop
        public static Stop ToEntity(this StopRequestDto request)
        {
            return new Stop
            {
                Name = request.Name,
                Code = request.Code,
                Description = request.Description
            };
        }

        public static StopResponseDto ToDto(this Stop request)
        {
            return new StopResponseDto
            {
                Id = request.Id,
                Name = request.Name,
                Code = request.Code,
                Description = request.Description,
                X = request.X,
                Y = request.Y,
                CreatedAt = request.CreatedAt
            };
        }
        #endregion;

    }
}
