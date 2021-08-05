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
                        new Actor(){ Name="Keanu",LastName="Reeves"},
                        new Actor(){ Name="Laurence", LastName="Fishburne"},
                        new Actor(){ Name="Anne", LastName="Hathaway"},
                        new Actor(){ Name="Matthew", LastName="McConaughey"}
                    );
                    
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
                            DirectorId=1,
                            PublishDate=new DateTime(1997,05,12)                
                        },
                        new Movie(){
                            Name="Interstellar",
                            GenreId=1,
                            Price=15.6m,
                            DirectorId=2,
                            PublishDate=new DateTime(1995,11,19) 
                        }
                    );
                    context.MovieActors.AddRange(
                        new MovieActor(){ActorId=1,MovieId=1},
                        new MovieActor(){ActorId=2,MovieId=1},
                        new MovieActor(){ActorId=2,MovieId=2},
                        new MovieActor(){ActorId=3,MovieId=2},
                        new MovieActor(){ActorId=4,MovieId=2}
                    );
                    context.Customers.AddRange(
                        new Customer(){Name="Talip",LastName="Salih"},
                        new Customer(){Name="Derya",LastName="Dede",}
                    );
                    context.SaveChanges();
                }
        }
    }
}