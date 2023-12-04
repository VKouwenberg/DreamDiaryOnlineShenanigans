using Microsoft.EntityFrameworkCore;
using RazorPagesDreams.Data;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesDreamsContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesDreamsContext>>()))
        {
            if (context == null || context.Dream == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Dream.Any())
            {
                return;   // DB has been seeded
            }

            context.Dream.AddRange(
                new Dream
                {
                    Title = "Isolation monster baby balloon death scarousal",
                    DateAdded = DateTime.Parse("2022-2-12"),
                    SleepQuality = "Restless",
                    Visibility = "Everyone"
                },

                new Dream
                {
                    Title = "PTSD war is loud, burnt flesh doesn't smell as bad as you'd think, unfortunately",
                    DateAdded = DateTime.Parse("2022-3-13"),
                    SleepQuality = "Lovely",
                    Visibility = "Friends"
                },

                new Dream
                {
                    Title = "Beware of the responsibility of life. Bees. Beehive entrepeneur and father",
                    DateAdded = DateTime.Parse("2022-2-23"),
                    SleepQuality = "Good",
                    Visibility = "Friends"
                },

                new Dream
                {
                    Title = "CARLOS",
                    DateAdded = DateTime.Parse("2022-4-15"),
                    SleepQuality = "Ethereal",
                    Visibility = "Private"
                }
            );
            context.SaveChanges();
        }
    }
}