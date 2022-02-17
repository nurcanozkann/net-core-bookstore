using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                    return;

                context.Books.AddRange(
                     new Book()
                     {
                         Title = "Lean Startup",
                         GenreId = 1, //PersonelGrowth
                         PageCount = 200,
                         PublishDate = new DateTime(2001, 6, 12)
                     },
                     new Book()
                     {
                         Title = "Herland",
                         GenreId = 2, //scienceFiction
                         PageCount = 250,
                         PublishDate = new DateTime(2010, 5, 23)
                     },
                     new Book()
                      {
                          Title = "Duen",
                          GenreId = 2, //PersonelGrowth
                          PageCount = 540,
                          PublishDate = new DateTime(2002, 12, 21)
                      }
                );

                context.SaveChanges();
            }
        }
    }
}
