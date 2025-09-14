using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class JourneyExtensions
    {
        public static IQueryable<Journey> IncludeJourneyWithOrderedStops(this IQueryable<Journey> query)
        {
            return query
                .Include(j => j.JourneyStops)
                    .ThenInclude(js => js.Stop)
                .Include(j => j.JourneyStops.OrderBy(js => js.Order));
        }
    }}
