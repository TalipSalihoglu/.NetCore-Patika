using System.Collections.Generic;

namespace Webapi.Entities
{
    public class Customer{
        public int Id { get; set; }
        public string Name{get;set;}
        public string LastName { get; set; }
        public bool isActive{get;set;}=true;
        public virtual List<Movie> Orders { get; set; }
        public virtual ICollection<FavoriteGenre> FavoriteGenres{get;set;}
    }
}