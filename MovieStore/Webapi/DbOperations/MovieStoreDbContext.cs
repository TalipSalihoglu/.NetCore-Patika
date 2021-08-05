using Microsoft.EntityFrameworkCore;
using Webapi.Entities;

namespace Webapi.DbOperations
{
    public class MovieStoreDbContext : DbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FavoriteGenre> FavoriteGenres { get; set; }
        public DbSet<Order> Orders { get; set; }        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieActorEntityConfiguration());
        }
    }
}