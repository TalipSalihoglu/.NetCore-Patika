using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Webapi.DbOperations;

namespace WebApi.Application.MovieOperations.Queries.GetMovies{
    public class GetMoviesQuery{
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetMoviesQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<MoviesViewModel> Handle(){
            var movieList=_context.Movies.Include(x=>x.Director).OrderBy(x=>x.Id).ToList();
            return _mapper.Map<List<MoviesViewModel>>(movieList);
        }
    }
    public class MoviesViewModel{
        public string Name{get;set;}
        public string Genre{get;set;}
        public string Director{get;set;}
        public decimal Price{get;set;}
    }
}