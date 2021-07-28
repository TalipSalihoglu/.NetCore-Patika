using System;
using System.Collections.Generic;

namespace Webapi.Entities{
    public class Movie{
        public int Id{get;set;}
        public string Name{get;set;}
        public int GenreId{get;set;}
        public int DirectorId{get;set;}
        public Director Director{get;set;}
        public DateTime PublishDate { get; set; }
        public bool isActive{get;set;}=true;

       public virtual ICollection<MovieActor> MovieActors{get;set;}

        public decimal Price{get;set;}
    }
}