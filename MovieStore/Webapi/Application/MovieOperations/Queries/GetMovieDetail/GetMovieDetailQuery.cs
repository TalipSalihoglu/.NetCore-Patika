using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Webapi.DbOperations;

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

            return _mapper.Map<MovieDetailViewModel>(movie);
        }
    }
    public class MovieDetailViewModel{
        public string Name{get;set;}
        public string Genre{get;set;}
        public string Director{get;set;}
        public decimal Price{get;set;}
    }
}