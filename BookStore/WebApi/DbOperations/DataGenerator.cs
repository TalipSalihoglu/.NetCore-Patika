using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;


namespace WebApi.DbOperations{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                // Look for any book.
                if (context.Books.Any() && context.Genres.Any() && context.Authors.Any())
                {
                    return;   // Data was already seeded
                }

                context.Authors.AddRange(
                    new Author{ Name="Joanne Kathleen",LastName="Rowling",BirthDate=new DateTime(1965,07,31)},
                    new Author{ Name="John Stuart",LastName="Mill",BirthDate=new DateTime(1873,07,05)},
                    new Author{ Name="John Ronald Reuel",LastName="Tolkien",BirthDate=new DateTime(1892,03,01)}
                );

                context.Genres.AddRange(
                    new Genre{ Name= "Personal Growth" },
                    new Genre{ Name= "Science Fiction" },
                    new Genre{ Name= "Romance"}
                );

                context.Books.AddRange(
                    new Book{Title="Lean Startup",GenreId=1,PageCount=200,AuthorId=1,PublishDate=new DateTime(2001,06,12)},
                    new Book{Title="Herland",GenreId=2,PageCount=250,AuthorId=2,PublishDate=new DateTime(2010,05,23)},
                    new Book{Title="Dune",GenreId=2,PageCount=540,AuthorId=3,PublishDate=new DateTime(2001,12,21)}
                );

                context.SaveChanges();
            }
        }
    }
}