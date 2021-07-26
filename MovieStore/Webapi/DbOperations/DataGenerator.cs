using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Webapi.Entities;

namespace Webapi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
                {
                    if (context.Movies.Any())
                    {
                        return;
                    }

                    context.Actors.AddRange(
                    new Actor()
                    {
                       Name="Keanu",
                       LastName="Reeves",
                    });
                    
                    context.Directors.AddRange(
                        new Director(){
                            Name="Lana",
                            LastName="Wachowski",                    
                        },
                        new Director(){
                            Name="Cristopher",
                            LastName="Nolan",                    
                        }
                    );

                    context.Movies.AddRange(
                        new Movie(){
                            Name="Matrix",
                            GenreId=1,
                            Price=12.4m,
                            DirectorId=1
                        },
                        new Movie(){
                            Name="Interstellar",
                            GenreId=1,
                            Price=15.6m,
                            DirectorId=2
                        }
                    );
                    context.SaveChanges();
                }
        }
    }
}