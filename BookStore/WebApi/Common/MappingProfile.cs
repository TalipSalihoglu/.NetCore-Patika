using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.Application.BookOperations.GetBookDetail;
using WebApi.Application.BookOperations.GetBooks;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Entities;

namespace WebApi.Common{
    public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<CreateBookModel, Book>();
                CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
                CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));

                CreateMap<Genre,GenresViewModel>();
                CreateMap<Genre,GenreDetailViewModel>();

                CreateMap<CreateAuthorModel,Author>();

                CreateMap<Author,AuthorsViewModel>();
                CreateMap<Author,AuthorDetailViewModel>();
            }
        }
}