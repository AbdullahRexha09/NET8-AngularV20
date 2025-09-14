using API.Database;
using API.Entities;
using API.Models;

namespace API.Extensions
{
    public static class DbContextExtensions
    {
        public static Task Seed(this AppDbContext context)
        {
            if (context.Stop.Any())
                return Task.CompletedTask;

            context.Stop.AddRange(
                new Stop { Id = 1, Code = "S001", Name = "StopOne", Description = "Central Station", X = 40.7128M, Y = -74.0060M },
                new Stop { Id = 2, Code = "S002", Name = "StopTwo", Description = "City Park", X = 40.7130M, Y = -74.0000M },
                new Stop { Id = 3, Code = "S003", Name = "StopThree", Description = "University", X = 40.7140M, Y = -74.0020M },
                new Stop { Id = 4, Code = "S004", Name = "StopFour", Description = "Mall", X = 40.7150M, Y = -74.0050M },
                new Stop { Id = 5, Code = "S005", Name = "StopFive", Description = "Airport", X = 40.7160M, Y = -74.0080M });


            context.Journey.AddRange(
                new Journey{Id = 1, Code = "RNG001", Title = "RangOne", Description = "Estadio Deluxe",JourneyStops = new List<JourneyStop> {
                new JourneyStop
                {
                    JourneyId = 1,
                    StopId = 1
                },
                new JourneyStop
                {
                    JourneyId = 1,
                    StopId = 2
                },

           }
       }
   );

            context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
