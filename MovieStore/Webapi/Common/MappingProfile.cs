using AutoMapper;
using Webapi.Entities;
using WebApi.Common;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using Webapi.Application.DirectorOperations.Commands.CreateDirector;
using Webapi.Application.DirectorOperations.Queries;
using Webapi.Application.DirectorOperations.Queries.GetDirectorDetail;

namespace WebApi.Common{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Movie Operations
            CreateMap<Movie,MoviesViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => (src.Director.Name+" "+src.Director.LastName) ));
            
            CreateMap<Movie,MovieDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => (src.Director.Name+" "+src.Director.LastName) ))
                .ForMember(dest=>dest.Actors,opt=>opt.MapFrom(src=>src.MovieActors));

            CreateMap<CreateMovieModel,Movie>();
            
            // Director Operations
            CreateMap<CreateDirectorModel,Director>();
            CreateMap<Director,DirectorsViewModel>();
            CreateMap<Director,DirectorDetailModel>();
        }
    }
}