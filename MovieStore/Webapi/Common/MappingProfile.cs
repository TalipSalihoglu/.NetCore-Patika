using AutoMapper;
using Webapi.Entities;
using WebApi.Common;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;

namespace WebApi.Common{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie,MoviesViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => (src.Director.Name+" "+src.Director.LastName) ));
            
            CreateMap<Movie,MovieDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => (src.Director.Name+" "+src.Director.LastName) ));
        }
    }
}