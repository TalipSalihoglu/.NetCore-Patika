using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Webapi.DbOperations;
using Webapi.Entities;

namespace WebApi.Application.MovieOperations.Queries.GetMovieDetail{
    public class GetMovieDetailQuery{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int MovieId;
        public GetMovieDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public MovieDetailViewModel Handle(){
            var movie=_context.Movies.Include(x=>x.Director).Where(x=>x.Id==MovieId).SingleOrDefault();
            if(movie is null)
                throw new InvalidOperationException("Film bulunamadı.");

            var result = _mapper.Map<MovieDetailViewModel>(movie);

            var list=_context.MovieActors.Include(x=>x.Actor).Where(x=>x.MovieId==MovieId).ToList();
            foreach(var i in list)
                result.Actors.Add(FullName(i.Actor));
                
            return result;
        }
        private string FullName(Actor actor){
            return actor.Name+" "+actor.LastName;
        }
    }
    public class MovieDetailViewModel{
        public string Name{get;set;}
        public string Genre{get;set;}
        public string Director{get;set;}
        public decimal Price{get;set;}
        public List<String> Actors{get;set;}
         public bool isActive{get;set;}
    }
}