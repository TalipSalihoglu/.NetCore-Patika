using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Webapi.Entities{
    public class MovieActor{
        public int MovieId { get; set; }
        public int ActorId{ get; set; }

        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
    public class MovieActorEntityConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(sc => new { sc.ActorId, sc.MovieId });
            builder.HasOne<Actor>(sc => sc.Actor)
                .WithMany(s => s.MovieActors)
                .HasForeignKey(sc => sc.ActorId);

            builder.HasOne<Movie>(sc => sc.Movie)
                .WithMany(s => s.MovieActors)
                .HasForeignKey(sc => sc.MovieId);
        }
    }
}