using System.Collections.Generic;

namespace Webapi.Entities{
    public class Movie{
        public int Id{get;set;}
        public string Name{get;set;}
        public int GenreId{get;set;}
        public int DirectorId{get;set;}
        public Director Director{get;set;}

        // public int ActorId{get;set;}
        // public Actor Actor{get;set;}

        // public ICollection<MovieActor> MovieActors{get;set;}

        public decimal Price{get;set;}
    }
}