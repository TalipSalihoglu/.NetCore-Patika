using System.Collections.Generic;

namespace Webapi.Entities{
    public class Director{
        
        public int Id{get;set;}
        public string Name{get;set;}
        public string LastName{get;set;}
        public List<Movie> Movies{get;set;}
    }
}