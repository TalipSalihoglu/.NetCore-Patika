using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Webapi.DbOperations;
using System;
using Webapi.Entities;

namespace WebApi.Application.MovieOperations.Commands.CreateMovie{
    public class CreateMovieCommand{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateMovieModel Model{get;set;}
        public CreateMovieCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle(){
            var movie=_context.Movies.SingleOrDefault(x=>x.Name==Model.Name);
            if(movie!=null)
                throw new InvalidOperationException("Bu isimde film zaten kayıtlı.");
            
            movie=_mapper.Map<Movie>(Model);
 
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movie=_context.Movies.SingleOrDefault(x=>x.Name==Model.Name);
            foreach(var i in Model.Actors)
            {
                _context.MovieActors.Add(new MovieActor(){MovieId=movie.Id,ActorId=i});
            }
            _context.SaveChanges();
        }
    }
    public class CreateMovieModel{
        public string Name{get;set;}
        public int GenreId{get;set;}
        public int DirectorId{get;set;}
        public List<int> Actors{get;set;}
        public DateTime PublishDate { get; set; }
        public decimal Price{get;set;}
    }
}