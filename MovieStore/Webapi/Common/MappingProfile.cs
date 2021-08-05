using AutoMapper;
using Webapi.Entities;
using WebApi.Common;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using Webapi.Application.DirectorOperations.Commands.CreateDirector;
using Webapi.Application.DirectorOperations.Queries;
using Webapi.Application.DirectorOperations.Queries.GetDirectorDetail;
using Webapi.Application.ActorOperations.Commands.Queries.GetActors;
using Webapi.Application.ActorOperations.Commands.Queries.GetActorDetail;
using Webapi.Application.ActorOperations.Commands.CreateActor;
using Webapi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.Application.CustomerOperations.Queries.GetCustomerDetail;
using Webapi.Application.OrderOpearations.Commands.CreateOrder;
using Webapi.Application.OrderOpearations.Queries.GetOrder;
using Webapi.Application.OrderOpearations.Queries.GetOrderDetail;

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

            // Actor Operations
            CreateMap<Actor,GetActorsQueryModel>();
            CreateMap<Actor,ActorDetailModel>().ForMember(dest=>dest.Movies,opt=>opt.MapFrom(src=>src.MovieActors));
            CreateMap<CreateActorModel ,Actor>();

            // Customer Operations
            CreateMap<CreateCustomerModel,Customer>();
            CreateMap<Customer,CustomerDetailViewModel>();

            //Order Operations
            CreateMap<CreateOrderModel,Order>();
            
            CreateMap<Order,OrderViewModel>().ForMember(dest=>dest.MovieName,opt=>opt.MapFrom(src=>src.Movie.Name))
            .ForMember(dest=>dest.CustomerName,opt=>opt.MapFrom(src=>src.Customer.Name));

             CreateMap<Order,OrderDetailViewModel>().ForMember(dest=>dest.MovieName,opt=>opt.MapFrom(src=>src.Movie.Name))
            .ForMember(dest=>dest.CustomerName,opt=>opt.MapFrom(src=>src.Customer.Name));

        }
    }
}